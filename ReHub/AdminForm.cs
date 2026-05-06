using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReHub
{
    public partial class AdminForm : Form
    {
        private User currentUser;

        public AdminForm(User user)
        {
            InitializeComponent();
            // === ОБРАБОТЧИКИ НАВИГАЦИИ ===
            this.btnNavAnalytics.Click += (s, e) => ShowPanel("analytics");
            this.btnNavElectives.Click += (s, e) => ShowPanel("electives");
            this.btnNavTeachers.Click += (s, e) => ShowPanel("teachers");
            this.btnNavStudents.Click += (s, e) => ShowPanel("students");
            this.btnNavSettings.Click += (s, e) => ShowPanel("settings");

            // === ОБРАБОТЧИКИ ТАБОВ ===
            this.btnTabElectives.Click += (s, e) => ShowPanel("electives");
            this.btnTabTeachers.Click += (s, e) => ShowPanel("teachers");
            this.btnTabStudents.Click += (s, e) => ShowPanel("students");

            

            currentUser = user;
            this.Text = $"НОВА - Администратор: {user.FullName}";
            LoadAllData();
            this.dgvElectives.SelectionChanged += new EventHandler(this.dgvElectives_SelectionChanged);
            string greeting = GetTimeBasedGreeting();
            this.lblCurrentUser.Text = $"{greeting}, Администратор!";

        }
        

        private string GetTimeBasedGreeting()
        {
            int hour = DateTime.Now.Hour;
            if (hour >= 6 && hour < 12) return "Доброе утро";
            else if (hour >= 12 && hour < 18) return "Добрый день";
            else return "Добрый вечер";
        }

        // ==================== ЗАГРУЗКА ДАННЫХ ====================
        private void LoadAllData()
        {
            LoadElectives();
            LoadTeachers();
            LoadStudents();
            LoadTeachersComboBox();
        }

        private void LoadElectives()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT f.М_факультатива, f.Название, f.Описание, p.ФИО as Преподаватель, 
                           f.Макс_количество, f.Дата_занятия, f.Время_занятия
                           FROM Факультатив f 
                           LEFT JOIN Преподаватель p ON f.М_преподавателя = p.М_преподавателя";

                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvElectives.DataSource = dt;
                        if (dgvElectives.Columns.Contains("М_факультатива"))
                            dgvElectives.Columns["М_факультатива"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки факультативов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTeachers()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT М_преподавателя, ФИО, Кафедра, Email, Телефон, Логин, Пароль FROM Преподаватель";
                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvTeachers.DataSource = dt;
                        if (dgvTeachers.Columns.Contains("М_преподавателя"))
                            dgvTeachers.Columns["М_преподавателя"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки преподавателей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNavAnalytics_Click(object sender, EventArgs e)
        {
            ShowPanel("analytics");
        }
        private void LoadStudents()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT М_студента, ФИО, Группа, Email, Телефон, Логин, Пароль FROM Студент";
                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvStudents.DataSource = dt;
                        if (dgvStudents.Columns.Contains("М_студента"))
                            dgvStudents.Columns["М_студента"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки студентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTeachersComboBox()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT М_преподавателя, ФИО FROM Преподаватель";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            cmbTeachers.Items.Clear();
                            while (reader.Read())
                            {
                                cmbTeachers.Items.Add(new
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1)
                                });
                            }
                        }
                    }
                }
                cmbTeachers.DisplayMember = "Name";
                cmbTeachers.ValueMember = "Id";
                if (cmbTeachers.Items.Count > 0) cmbTeachers.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка преподавателей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== АНАЛИТИКА (РЕАЛЬНЫЕ ДАННЫЕ) ====================
        public void LoadAnalyticsData()
        {
            try
            {
                this.pnlAnalytics.Controls.Clear();

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // === КАРТОЧКИ СТАТИСТИКИ ===
                    int totalRequests = 0, activeElectives = 0, fullnessPercent = 0, pendingRequests = 0;

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Заявка", conn))
                        totalRequests = Convert.ToInt32(cmd.ExecuteScalar());

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Факультатив WHERE Статус = 'Активен' OR Статус IS NULL", conn))
                        activeElectives = Convert.ToInt32(cmd.ExecuteScalar());

                    string fillQuery = @"SELECT CASE WHEN SUM(f.Макс_количество) = 0 OR SUM(f.Макс_количество) IS NULL THEN 0 
                        ELSE ROUND(CAST(COUNT(z.М_заявки) AS FLOAT) / SUM(f.Макс_количество) * 100, 0) END
                        FROM Факультатив f LEFT JOIN Заявка z ON f.М_факультатива = z.М_факультатива
                        WHERE (z.Статус = 'Принято' OR z.Статус = 'Одобрена')";
                    using (SqlCommand cmd = new SqlCommand(fillQuery, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value) fullnessPercent = Convert.ToInt32(result);
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Заявка WHERE Статус = 'Ожидание' OR Статус = 'На рассмотрении'", conn))
                        pendingRequests = Convert.ToInt32(cmd.ExecuteScalar());

                    string[] titles = { "Всего заявок", "Активных факультативов", "Заполненность", "Ожидают одобрения" };
                    string[] values = { totalRequests.ToString(), activeElectives.ToString(), fullnessPercent + "%", pendingRequests.ToString() };

                    for (int i = 0; i < 4; i++)
                    {
                        Panel card = new Panel
                        {
                            Location = new Point(14 + i * 220, 14),
                            Size = new Size(205, 76),
                            BackColor = Color.White,
                            BorderStyle = BorderStyle.FixedSingle,
                            Padding = new Padding(12)
                        };
                        Label lbl = new Label
                        {
                            Text = titles[i],
                            Font = new Font("Segoe UI", 9F),
                            ForeColor = Color.FromArgb(100, 100, 100),
                            AutoSize = false,
                            Size = new Size(180, 20),
                            Location = new Point(12, 8)
                        };
                        Label val = new Label
                        {
                            Text = values[i],
                            Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                            ForeColor = Color.FromArgb(24, 95, 165),
                            AutoSize = true,
                            Location = new Point(12, 30)
                        };
                        card.Controls.Add(val);
                        card.Controls.Add(lbl);
                        this.pnlAnalytics.Controls.Add(card);
                    }

                    // === ГРАФИКИ ===
                    // Столбчатая диаграмма
                    Chart chartBar = new Chart
                    {
                        Location = new Point(14, 100),
                        Size = new Size(550, 260),
                        BackColor = Color.White
                    };
                    chartBar.Titles.Add("Заявки по месяцам");
                    chartBar.Titles[0].Font = new Font("Segoe UI", 10F, FontStyle.Bold);

                    Series sBar = new Series("Заявки")
                    {
                        ChartType = SeriesChartType.Column,
                        Color = Color.FromArgb(24, 95, 165)
                    };
                    chartBar.Series.Add(sBar);
                    chartBar.ChartAreas.Add(new ChartArea("AreaBar"));

                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT DATENAME(MONTH, Дата_подачи) as M, COUNT(*) as C 
                        FROM Заявка WHERE Дата_подачи IS NOT NULL 
                        GROUP BY DATENAME(MONTH, Дата_подачи), MONTH(Дата_подачи) 
                        ORDER BY MONTH(Дата_подачи)", conn))
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                            chartBar.Series["Заявки"].Points.AddXY(r["M"], r["C"]);
                    }
                    this.pnlAnalytics.Controls.Add(chartBar);

                    // Круговая диаграмма
                    Chart chartPie = new Chart
                    {
                        Location = new Point(574, 100),
                        Size = new Size(350, 260),
                        BackColor = Color.White
                    };
                    chartPie.Titles.Add("Статусы заявок");
                    chartPie.Titles[0].Font = new Font("Segoe UI", 10F, FontStyle.Bold);

                    Series sPie = new Series("Статусы") { ChartType = SeriesChartType.Doughnut };
                    sPie["PieLabelStyle"] = "Outside";
                    chartPie.Series.Add(sPie);
                    chartPie.ChartAreas.Add(new ChartArea("AreaPie"));

                    using (SqlCommand cmd = new SqlCommand("SELECT Статус, COUNT(*) as C FROM Заявка GROUP BY Статус", conn))
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            int idx = sPie.Points.AddXY(r["Статус"], r["C"]);
                            string st = r["Статус"].ToString();
                            if (st == "Принято" || st == "Одобрена") sPie.Points[idx].Color = Color.Green;
                            else if (st == "Ожидание") sPie.Points[idx].Color = Color.Orange;
                            else if (st == "Отклонено") sPie.Points[idx].Color = Color.Red;
                            else sPie.Points[idx].Color = Color.Gray;
                        }
                    }
                    this.pnlAnalytics.Controls.Add(chartPie);

                    // === ТАБЛИЦА "ТОП ФАКУЛЬТАТИВОВ" ===
                    Panel pnlT = new Panel
                    {
                        Location = new Point(14, 370),
                        Size = new Size(550, 200),
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    Label lblT = new Label
                    {
                        Text = "Топ факультативов",
                        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                        AutoSize = true,
                        Location = new Point(10, 10)
                    };

                    DataGridView dgv = new DataGridView
                    {
                        Location = new Point(10, 35),
                        Size = new Size(530, 155),
                        BorderStyle = BorderStyle.None,
                        BackgroundColor = Color.White,
                        RowHeadersVisible = false,
                        Font = new Font("Segoe UI", 9F),
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    };
                    dgv.Columns.Add("Name", "Название");
                    dgv.Columns.Add("Count", "Заявок");
                    dgv.Columns.Add("Percent", "%");

                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT TOP 5 f.Название, COUNT(z.М_заявки) as C, ISNULL(f.Макс_количество, 1) as Max 
                        FROM Факультатив f 
                        INNER JOIN Заявка z ON f.М_факультатива = z.М_факультатива 
                        WHERE (z.Статус = 'Принято' OR z.Статус = 'Одобрена') AND f.Название IS NOT NULL 
                        GROUP BY f.М_факультатива, f.Название, f.Макс_количество 
                        ORDER BY C DESC", conn))
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            string n = r["Название"].ToString();
                            int c = Convert.ToInt32(r["C"]), m = Convert.ToInt32(r["Max"]);
                            int p = (m > 0) ? (int)Math.Round((double)c / m * 100) : 0;
                            if (!string.IsNullOrEmpty(n))
                                dgv.Rows.Add(n, c, p + "%");
                        }
                    }
                    pnlT.Controls.Add(lblT);
                    pnlT.Controls.Add(dgv);
                    this.pnlAnalytics.Controls.Add(pnlT);

                    // === УВЕДОМЛЕНИЯ ===
                    Panel pnlN = new Panel
                    {
                        Location = new Point(574, 370),
                        Size = new Size(350, 200),
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        AutoScroll = true
                    };
                    Label lblN = new Label
                    {
                        Text = "Последние уведомления",
                        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                        AutoSize = true,
                        Location = new Point(10, 10)
                    };
                    pnlN.Controls.Add(lblN);

                    int y = 35;
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT TOP 5 s.ФИО, f.Название, z.Дата_подачи 
                        FROM Заявка z 
                        JOIN Студент s ON z.М_студента = s.М_студента 
                        JOIN Факультатив f ON z.М_факультатива = f.М_факультатива 
                        ORDER BY z.Дата_подачи DESC", conn))
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            Panel p = new Panel
                            {
                                Location = new Point(10, y),
                                Size = new Size(330, 50),
                                BackColor = Color.FromArgb(245, 244, 240)
                            };
                            Label t = new Label
                            {
                                Text = $"🔵 {r["ФИО"]} → «{r["Название"]}»\n   {Convert.ToDateTime(r["Дата_подачи"]):dd MMM HH:mm}",
                                Font = new Font("Segoe UI", 9F),
                                AutoSize = true,
                                Location = new Point(8, 8)
                            };
                            p.Controls.Add(t);
                            pnlN.Controls.Add(p);
                            y += 55;
                        }
                    }
                    this.pnlAnalytics.Controls.Add(pnlN);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки аналитики: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ====================
        private void ClearElectiveFields()
        {
            txtElectiveName.Clear();
            txtElectiveDescription.Clear();
            numMaxStudents.Value = 30;
        }

        private void dgvElectives_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvElectives.SelectedRows.Count > 0)
            {
                var row = dgvElectives.SelectedRows[0];
                txtElectiveName.Text = row.Cells["Название"].Value?.ToString() ?? "";
                txtElectiveDescription.Text = row.Cells["Описание"].Value?.ToString() ?? "";
                if (row.Cells["Макс_количество"].Value != null)
                    numMaxStudents.Value = Convert.ToInt32(row.Cells["Макс_количество"].Value);
            }
        }

        // ==================== ОБРАБОТЧИКИ КНОПОК (ФАКУЛЬТАТИВЫ) ====================
        private void btnCreateElective_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtElectiveName.Text) || cmbTeachers.SelectedItem == null)
            {
                MessageBox.Show("Заполните название факультатива и выберите преподавателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO Факультатив (Название, Описание, М_преподавателя, Макс_количество) 
                                   VALUES (@Name, @Description, @TeacherId, @MaxStudents)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        dynamic selectedTeacher = cmbTeachers.SelectedItem;
                        command.Parameters.AddWithValue("@Name", txtElectiveName.Text);
                        command.Parameters.AddWithValue("@Description",
                            string.IsNullOrEmpty(txtElectiveDescription.Text) ? DBNull.Value : (object)txtElectiveDescription.Text);
                        command.Parameters.AddWithValue("@TeacherId", selectedTeacher.Id);
                        command.Parameters.AddWithValue("@MaxStudents", numMaxStudents.Value);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show($"Факультатив '{txtElectiveName.Text}' создан успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearElectiveFields();
                    LoadElectives();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка создания факультатива: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditElective_Click_1(object sender, EventArgs e)
        {
            if (dgvElectives.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите факультатив для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedRow = dgvElectives.SelectedRows[0];
            int electiveId = Convert.ToInt32(selectedRow.Cells["М_факультатива"].Value);
            using (var editForm = new EditElectiveForm(electiveId, selectedRow))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadElectives();
                    MessageBox.Show("Факультатив обновлен успешно!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDeleteElective_Click_1(object sender, EventArgs e)
        {
            if (dgvElectives.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите факультатив для удаления", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int electiveId = Convert.ToInt32(dgvElectives.SelectedRows[0].Cells["М_факультатива"].Value);
            string electiveName = dgvElectives.SelectedRows[0].Cells["Название"].Value?.ToString() ?? "";
            if (MessageBox.Show($"Удалить факультатив '{electiveName}'?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();
                        string deleteApplicationsQuery = "DELETE FROM Заявка WHERE М_факультатива = @ElectiveId";
                        using (var command = new SqlCommand(deleteApplicationsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ElectiveId", electiveId);
                            command.ExecuteNonQuery();
                        }
                        string deleteElectiveQuery = "DELETE FROM Факультатив WHERE М_факультатива = @ElectiveId";
                        using (var command = new SqlCommand(deleteElectiveQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ElectiveId", electiveId);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show($"Факультатив '{electiveName}' удален успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadElectives();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления факультатива: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadAllData();
        }

        // ==================== ЭКСПОРТ В EXCEL (ФАКУЛЬТАТИВЫ) ====================
        private void btnGenerateElectivesReport_Click_1(object sender, EventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Отчёт по факультативам";
                worksheet.Cells.Font.Name = "Times New Roman";
                worksheet.Cells.Font.Size = 11;
                int currentRow = 1;

                worksheet.Cells[currentRow, 1] = "МКОУ \"Волчихинская СШ№2\"";
                Excel.Range orgRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 7]];
                orgRange.Merge(); orgRange.Font.Bold = true; orgRange.Font.Size = 14;
                orgRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; currentRow += 2;

                worksheet.Cells[currentRow, 1] = "ОТЧЕТ ПО ФАКУЛЬТАТИВАМ";
                Excel.Range titleRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 7]];
                titleRange.Merge(); titleRange.Font.Bold = true; titleRange.Font.Size = 12;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; currentRow += 2;

                worksheet.Cells[5, 1] = $"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}";
                worksheet.Cells[4, 1] = $"Создал: {currentUser?.FullName ?? "Администратор"}";
                currentRow += 2;

                string[] headers = { "Название факультатива", "Описание", "Преподаватель", "Макс. студентов", "Дата занятия", "Время занятия", "Кол-во студентов" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[currentRow, i + 1] = headers[i];
                    Excel.Range headerCell = worksheet.Cells[currentRow, i + 1];
                    headerCell.Font.Bold = true;
                    headerCell.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    worksheet.Columns[i + 1].ColumnWidth = (i == 0) ? 25 : (i == 1) ? 50 : (i == 2) ? 20 : 15;
                }
                currentRow++;

                string SqlText = @"SELECT 
                    f.Название as 'Название факультатива',
                    f.Описание as 'Описание',
                    p.ФИО as 'Преподаватель',
                    f.Макс_количество as 'Макс. студентов',
                    f.Дата_занятия as 'Дата занятия',
                    f.Время_занятия as 'Время занятия',
                    (SELECT COUNT(*) FROM Заявка z WHERE z.М_факультатива = f.М_факультатива AND z.Статус = 'Принято') as 'Кол-во студентов'
                FROM Факультатив f 
                LEFT JOIN Преподаватель p ON f.М_преподавателя = p.М_преподавателя
                ORDER BY f.Название";

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(SqlText, connection))
                    {
                        DataTable table = new DataTable(); adapter.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            for (int j = 0; j < headers.Length; j++)
                            {
                                worksheet.Cells[currentRow, j + 1] = row[j]?.ToString() ?? "";
                                Excel.Range dataCell = worksheet.Cells[currentRow, j + 1];
                                dataCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            }
                            currentRow++;
                        }
                    }
                }
                currentRow += 2;
                worksheet.Cells[currentRow, 1] = "Подпись: _________________________";
                worksheet.Cells[currentRow, 1].Font.Bold = true;

                excelApp.Visible = true; excelApp.UserControl = true;
                MessageBox.Show("Отчет по факультативам успешно создан!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);
            }
        }

        // ==================== ПРЕПОДАВАТЕЛИ ====================
        private void btnCreateTeacher_Click_1(object sender, EventArgs e)
        {
            using (var form = new TeacherRegistrationForm())
            {
                if (form.ShowDialog() == DialogResult.OK) { LoadTeachers(); LoadTeachersComboBox(); }
            }
        }

        private void btnDeleteTeacher_Click_1(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите преподавателя для удаления", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int teacherId = Convert.ToInt32(dgvTeachers.SelectedRows[0].Cells["М_преподавателя"].Value);
            string teacherName = dgvTeachers.SelectedRows[0].Cells["ФИО"].Value?.ToString() ?? "";
            if (MessageBox.Show($"Удалить преподавателя '{teacherName}'?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();
                        string updateElectivesQuery = "UPDATE Факультатив SET М_преподавателя = NULL WHERE М_преподавателя = @TeacherId";
                        using (var command = new SqlCommand(updateElectivesQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TeacherId", teacherId);
                            command.ExecuteNonQuery();
                        }
                        string deleteTeacherQuery = "DELETE FROM Преподаватель WHERE М_преподавателя = @TeacherId";
                        using (var command = new SqlCommand(deleteTeacherQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TeacherId", teacherId);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show($"Преподаватель '{teacherName}' удален успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTeachers(); LoadTeachersComboBox(); LoadElectives();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления преподавателя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGenerateTeachersReport_Click_1(object sender, EventArgs e)
        {
            Excel.Application excelApp = null; Excel.Workbook workbook = null; Excel.Worksheet worksheet = null;
            try
            {
                excelApp = new Excel.Application(); workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Sheets[1]; worksheet.Name = "Отчёт по преподавателям";
                worksheet.Cells.Font.Name = "Times New Roman"; worksheet.Cells.Font.Size = 11;
                int currentRow = 1;

                worksheet.Cells[currentRow, 1] = "МКОУ \"Волчихинская СШ№2\"";
                Excel.Range orgRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 7]];
                orgRange.Merge(); orgRange.Font.Bold = true; orgRange.Font.Size = 14;
                orgRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; currentRow += 2;

                worksheet.Cells[currentRow, 1] = "ОТЧЕТ ПО ПРЕПОДАВАТЕЛЯМ";
                Excel.Range titleRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 7]];
                titleRange.Merge(); titleRange.Font.Bold = true; titleRange.Font.Size = 12;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; currentRow += 2;

                worksheet.Cells[5, 1] = $"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}";
                worksheet.Cells[4, 1] = $"Создал: {currentUser?.FullName ?? "Администратор"}"; currentRow += 2;

                string[] headers = { "ФИО преподавателя", "Кафедра", "Email", "Телефон", "Логин", "Кол-во факультативов" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[currentRow, i + 1] = headers[i];
                    Excel.Range headerCell = worksheet.Cells[currentRow, i + 1];
                    headerCell.Font.Bold = true; headerCell.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    worksheet.Columns[i + 1].ColumnWidth = (i == 0) ? 25 : (i == 1) ? 20 : (i == 2) ? 25 : (i == 3) ? 15 : (i == 4) ? 15 : 25;
                }
                currentRow++;

                string SqlText = @"SELECT 
                        p.ФИО as 'ФИО преподавателя', p.Кафедра as 'Кафедра', p.Email as 'Email',
                        p.Телефон as 'Телефон', p.Логин as 'Логин',
                        (SELECT COUNT(*) FROM Факультатив f WHERE f.М_преподавателя = p.М_преподавателя) as 'Кол-во факультативов'
                    FROM Преподаватель p ORDER BY p.ФИО";

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(SqlText, connection))
                    {
                        DataTable table = new DataTable(); adapter.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            for (int j = 0; j < headers.Length; j++)
                            {
                                worksheet.Cells[currentRow, j + 1] = row[j]?.ToString() ?? "";
                                Excel.Range dataCell = worksheet.Cells[currentRow, j + 1];
                                dataCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            }
                            currentRow++;
                        }
                    }
                }
                currentRow += 2;
                worksheet.Cells[currentRow, 1] = "Подпись: _________________________";
                worksheet.Cells[currentRow, 1].Font.Bold = true;

                excelApp.Visible = true; excelApp.UserControl = true;
                MessageBox.Show("Отчет по преподавателям успешно создан!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);
            }
        }

        // ==================== СТУДЕНТЫ ====================
        private void btnCreateStudent_Click_1(object sender, EventArgs e)
        {
            using (var form = new StudentRegistrationForm())
            {
                if (form.ShowDialog() == DialogResult.OK) LoadStudents();
            }
        }

        private void btnDeleteStudent_Click_1(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите студента для удаления", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int studentId = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["М_студента"].Value);
            string studentName = dgvStudents.SelectedRows[0].Cells["ФИО"].Value?.ToString() ?? "";
            if (MessageBox.Show($"Удалить студента '{studentName}'?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();
                        string deleteApplicationsQuery = "DELETE FROM Заявка WHERE М_студента = @StudentId";
                        using (var command = new SqlCommand(deleteApplicationsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@StudentId", studentId);
                            command.ExecuteNonQuery();
                        }
                        string deleteStudentQuery = "DELETE FROM Студент WHERE М_студента = @StudentId";
                        using (var command = new SqlCommand(deleteStudentQuery, connection))
                        {
                            command.Parameters.AddWithValue("@StudentId", studentId);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show($"Студент '{studentName}' удален успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления студента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGenerateStudentsReport_Click_1(object sender, EventArgs e)
        {
            Excel.Application excelApp = null; Excel.Workbook workbook = null; Excel.Worksheet worksheet = null;
            try
            {
                excelApp = new Excel.Application(); workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Sheets[1]; worksheet.Name = "Отчёт по студентам";
                worksheet.Cells.Font.Name = "Times New Roman"; worksheet.Cells.Font.Size = 11;
                int currentRow = 1;

                worksheet.Cells[currentRow, 1] = "МКОУ \"Волчихинская СШ№2\"";
                Excel.Range orgRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 7]];
                orgRange.Merge(); orgRange.Font.Bold = true; orgRange.Font.Size = 14;
                orgRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; currentRow += 2;

                worksheet.Cells[currentRow, 1] = "ОТЧЕТ ПО СТУДЕНТАМ";
                Excel.Range titleRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 7]];
                titleRange.Merge(); titleRange.Font.Bold = true; titleRange.Font.Size = 12;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; currentRow += 2;

                worksheet.Cells[5, 1] = $"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}";
                worksheet.Cells[4, 1] = $"Создал: {currentUser?.FullName ?? "Администратор"}"; currentRow += 2;

                string[] headers = { "ФИО студента", "Группа", "Email", "Телефон", "Логин", "Кол-во факультативов" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[currentRow, i + 1] = headers[i];
                    Excel.Range headerCell = worksheet.Cells[currentRow, i + 1];
                    headerCell.Font.Bold = true; headerCell.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    worksheet.Columns[i + 1].ColumnWidth = (i == 0) ? 25 : (i == 1) ? 15 : (i == 2) ? 25 : (i == 3) ? 15 : (i == 4) ? 15 : 25;
                }
                currentRow++;

                string SqlText = @"SELECT 
                        s.ФИО as 'ФИО студента', s.Группа as 'Группа', s.Email as 'Email',
                        s.Телефон as 'Телефон', s.Логин as 'Логин',
                        (SELECT COUNT(*) FROM Заявка z WHERE z.М_студента = s.М_студента AND z.Статус = 'Принято') as 'Кол-во факультативов'
                    FROM Студент s ORDER BY s.Группа, s.ФИО";

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(SqlText, connection))
                    {
                        DataTable table = new DataTable(); adapter.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            for (int j = 0; j < headers.Length; j++)
                            {
                                worksheet.Cells[currentRow, j + 1] = row[j]?.ToString() ?? "";
                                Excel.Range dataCell = worksheet.Cells[currentRow, j + 1];
                                dataCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            }
                            currentRow++;
                        }
                    }
                }
                currentRow += 2;
                worksheet.Cells[currentRow, 1] = "Подпись: _________________________";
                worksheet.Cells[currentRow, 1].Font.Bold = true;

                excelApp.Visible = true; excelApp.UserControl = true;
                MessageBox.Show("Отчет по студентам успешно создан!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);
            }
        }

        // ==================== ПРОЧЕЕ ====================
        private void label5_Click(object sender, EventArgs e) { Application.Exit(); }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите преподавателя для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedRow = dgvTeachers.SelectedRows[0];
            int teacherId = Convert.ToInt32(selectedRow.Cells["М_преподавателя"].Value);
            using (var editForm = new EditTeacherForm(teacherId, selectedRow))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTeachers();
                    MessageBox.Show("Данные преподавателя обновлены успешно!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите студента для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedRow = dgvStudents.SelectedRows[0];
            int studentId = Convert.ToInt32(selectedRow.Cells["М_студента"].Value);
            using (var editForm = new EditStudentForm(studentId, selectedRow))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadStudents();
                    MessageBox.Show("Данные студента обновлены успешно!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // ==================== ПЕРЕКЛЮЧЕНИЕ ПАНЕЛЕЙ ====================
        private void ShowPanel(string name)
        {
            pnlElectives.Visible = false;
            pnlTeachers.Visible = false;
            pnlStudents.Visible = false;
            pnlAnalytics.Visible = false;

            btnTabElectives.ForeColor = Color.FromArgb(100, 100, 100);
            btnTabTeachers.ForeColor = Color.FromArgb(100, 100, 100);
            btnTabStudents.ForeColor = Color.FromArgb(100, 100, 100);

            btnNavElectives.BackColor = Color.White; btnNavElectives.ForeColor = Color.FromArgb(80, 80, 80);
            btnNavTeachers.BackColor = Color.White; btnNavTeachers.ForeColor = Color.FromArgb(80, 80, 80);
            btnNavStudents.BackColor = Color.White; btnNavStudents.ForeColor = Color.FromArgb(80, 80, 80);

            switch (name)
            {
                case "electives":
                    pnlElectives.Visible = true; pnlElectives.BringToFront();
                    btnTabElectives.ForeColor = Color.FromArgb(24, 95, 165);
                    btnNavElectives.BackColor = Color.FromArgb(230, 241, 251);
                    btnNavElectives.ForeColor = Color.FromArgb(24, 95, 165);
                    break;
                case "teachers":
                    pnlTeachers.Visible = true; pnlTeachers.BringToFront();
                    btnTabTeachers.ForeColor = Color.FromArgb(24, 95, 165);
                    btnNavTeachers.BackColor = Color.FromArgb(230, 241, 251);
                    btnNavTeachers.ForeColor = Color.FromArgb(24, 95, 165);
                    break;
                case "students":
                    pnlStudents.Visible = true; pnlStudents.BringToFront();
                    btnTabStudents.ForeColor = Color.FromArgb(24, 95, 165);
                    btnNavStudents.BackColor = Color.FromArgb(230, 241, 251);
                    btnNavStudents.ForeColor = Color.FromArgb(24, 95, 165);
                    break;
                case "analytics":
                    pnlAnalytics.Visible = true; pnlAnalytics.BringToFront();
                    btnNavAnalytics.BackColor = Color.FromArgb(230, 241, 251);
                    btnNavAnalytics.ForeColor = Color.FromArgb(24, 95, 165);
                    LoadAnalyticsData();
                    break;
                case "settings":
                    new SettingsForm(currentUser).ShowDialog();
                    break;
            }
        }

        // ==================== СТИЛИЗАЦИЯ ====================
        private enum BtnStyle { Primary, Default, Danger, Success }

        private void StyleBtn(Button btn, string text, BtnStyle style)
        {
            btn.Text = text;
            btn.Size = new Size(108, 36);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.Font = new Font("Segoe UI", 10F);
            btn.Cursor = Cursors.Hand;

            switch (style)
            {
                case BtnStyle.Primary:
                    btn.BackColor = Color.FromArgb(24, 95, 165);
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(24, 95, 165);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(12, 68, 124);
                    break;
                case BtnStyle.Danger:
                    btn.BackColor = Color.FromArgb(252, 235, 235);
                    btn.ForeColor = Color.FromArgb(163, 45, 45);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(247, 193, 193);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(247, 193, 193);
                    break;
                case BtnStyle.Success:
                    btn.BackColor = Color.FromArgb(234, 243, 222);
                    btn.ForeColor = Color.FromArgb(59, 109, 17);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(192, 221, 151);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 221, 151);
                    break;
                default:
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.FromArgb(50, 50, 50);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 244, 240);
                    break;
            }
        }

        private void StyleLabel(Label lbl)
        {
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 9F);
            lbl.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void StyleTextBox(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 10F);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(230, 230, 230);
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Font = new Font("Segoe UI", 10F);
            dgv.RowTemplate.Height = 34;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 244, 240);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 100, 100);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 244, 240);
            dgv.ColumnHeadersHeight = 34;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 241, 251);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(24, 95, 165);
            dgv.EnableHeadersVisualStyles = false;
        }
    }
}