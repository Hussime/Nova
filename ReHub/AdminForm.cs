using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReHub
{
    public partial class AdminForm : Form
    {
        private User currentUser;

        public AdminForm(User user)
        {
            currentUser = user;
            InitializeComponent();
            this.Text = $"ReHub - Администратор: {user.FullName}";
            LoadAllData();
            this.dgvElectives.SelectionChanged += new EventHandler(this.dgvElectives_SelectionChanged);
            string greeting = GetTimeBasedGreeting();
            this.lblCurrentUser.Text = $"{greeting}, Администратор!";
        }
        private string GetTimeBasedGreeting()
        {
            int hour = DateTime.Now.Hour;

            if (hour >= 6 && hour < 12)
            {
                return "Доброе утро";
            }
            else if (hour >= 12 && hour < 18)
            {
                return "Добрый день";
            }
            else
            {
                return "Добрый вечер";
            }
        }
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

                        // Скрываем колонку с ID для пользователя
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
                    // Добавляем М_преподавателя в запрос
                    string query = "SELECT М_преподавателя, ФИО, Кафедра, Email, Телефон, Логин, Пароль FROM Преподаватель";

                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvTeachers.DataSource = dt;

                        // Скрываем колонку с ID для пользователя
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

        private void LoadStudents()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    // Добавляем М_студента в запрос
                    string query = "SELECT М_студента, ФИО, Группа, Email, Телефон, Логин, Пароль FROM Студент";

                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvStudents.DataSource = dt;

                        // Скрываем колонку с ID для пользователя
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
                if (cmbTeachers.Items.Count > 0)
                    cmbTeachers.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка преподавателей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



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
                txtElectiveName.Text = row.Cells["Название"].Value.ToString();
                txtElectiveDescription.Text = row.Cells["Описание"].Value?.ToString() ?? "";
                numMaxStudents.Value = Convert.ToInt32(row.Cells["Макс_количество"].Value);
            }
        }



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

            // Открываем форму редактирования
            using (var editForm = new EditElectiveForm(electiveId, selectedRow))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновляем данные после успешного редактирования
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
            string electiveName = dgvElectives.SelectedRows[0].Cells["Название"].Value.ToString();

            if (MessageBox.Show($"Удалить факультатив '{electiveName}'?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();

                        // Сначала удаляем связанные заявки
                        string deleteApplicationsQuery = "DELETE FROM Заявка WHERE М_факультатива = @ElectiveId";
                        using (var command = new SqlCommand(deleteApplicationsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ElectiveId", electiveId);
                            command.ExecuteNonQuery();
                        }

                        // Затем удаляем факультатив
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

                // Устанавливаем шрифт для всего листа
                worksheet.Cells.Font.Name = "Times New Roman";
                worksheet.Cells.Font.Size = 11;

                int currentRow = 1;

                // ШАПКА ОРГАНИЗАЦИИ
                worksheet.Cells[currentRow, 1] = "МКОУ \"Волчихинская СШ№2\"";
                Excel.Range orgRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 7]];
                orgRange.Merge();
                orgRange.Font.Bold = true;
                orgRange.Font.Size = 14;
                orgRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // ЗАГОЛОВОК ОТЧЕТА
                worksheet.Cells[currentRow, 1] = "ОТЧЕТ ПО ФАКУЛЬТАТИВАМ";
                Excel.Range titleRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 7]];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 12;
                titleRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // ИНФОРМАЦИЯ О СОЗДАНИИ
                worksheet.Cells[5, 1] = $"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}";
                worksheet.Cells[4, 1] = $"Создал: Моисеенко М.А.";
                currentRow += 2;

                // ЗАГОЛОВКИ ТАБЛИЦЫ
                string[] headers = {
                    "Название факультатива",
                    "Описание",
                    "Преподаватель",
                    "Макс. студентов",
                    "Дата занятия",
                    "Время занятия",
                    "Кол-во студентов"
                };

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[currentRow, i + 1] = headers[i];
                    Excel.Range headerCell = worksheet.Cells[currentRow, i + 1];
                    headerCell.Font.Bold = true;
                    headerCell.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    headerCell.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                    // Настраиваем ширину столбцов
                    if (i == 0) worksheet.Columns[i + 1].ColumnWidth = 25; // Название
                    else if (i == 1) worksheet.Columns[i + 1].ColumnWidth = 50; // Описание
                    else if (i == 2) worksheet.Columns[i + 1].ColumnWidth = 20; // Преподаватель
                    else worksheet.Columns[i + 1].ColumnWidth = 15; // Остальные столбцы
                }
                currentRow++;

                // ДАННЫЕ ИЗ БАЗЫ ДАННЫХ
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

                // ИСПРАВЛЕННАЯ СТРОКА: используем DatabaseHelper.GetConnection() вместо Class.DataBase.connStr
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(SqlText, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        foreach (DataRow row in table.Rows)
                        {
                            for (int j = 0; j < headers.Length; j++)
                            {
                                worksheet.Cells[currentRow, j + 1] = row[j]?.ToString() ?? "";
                                Excel.Range dataCell = worksheet.Cells[currentRow, j + 1];
                                dataCell.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            }
                            currentRow++;
                        }
                    }
                }

                // ПОДПИСИ
                currentRow += 2;
                worksheet.Cells[currentRow, 1] = "Подпись: _________________________";
                worksheet.Cells[currentRow, 1].Font.Bold = true;
                currentRow++;



                excelApp.Visible = true;
                excelApp.UserControl = true;

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
                // Освобождаем ресурсы
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);
            }
        }

        

       
        private void btnCreateTeacher_Click_1(object sender, EventArgs e)
        {
            using (var form = new TeacherRegistrationForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTeachers();
                    LoadTeachersComboBox();
                }
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
            string teacherName = dgvTeachers.SelectedRows[0].Cells["ФИО"].Value.ToString();

            if (MessageBox.Show($"Удалить преподавателя '{teacherName}'?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();

                        // Обновляем факультативы, чтобы убрать ссылку на преподавателя
                        string updateElectivesQuery = "UPDATE Факультатив SET М_преподавателя = NULL WHERE М_преподавателя = @TeacherId";
                        using (var command = new SqlCommand(updateElectivesQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TeacherId", teacherId);
                            command.ExecuteNonQuery();
                        }

                        // Удаляем преподавателя
                        string deleteTeacherQuery = "DELETE FROM Преподаватель WHERE М_преподавателя = @TeacherId";
                        using (var command = new SqlCommand(deleteTeacherQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TeacherId", teacherId);
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Преподаватель '{teacherName}' удален успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadTeachers();
                    LoadTeachersComboBox();
                    LoadElectives();
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления преподавателя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGenerateTeachersReport_Click_1(object sender, EventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Отчёт по преподавателям";

                // Устанавливаем шрифт для всего листа
                worksheet.Cells.Font.Name = "Times New Roman";
                worksheet.Cells.Font.Size = 11;

                int currentRow = 1;

                // ШАПКА ОРГАНИЗАЦИИ
                worksheet.Cells[currentRow, 1] = "МКОУ \"Волчихинская СШ№2\"";
                Excel.Range orgRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 7]];
                orgRange.Merge();
                orgRange.Font.Bold = true;
                orgRange.Font.Size = 14;
                orgRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // ЗАГОЛОВОК ОТЧЕТА
                worksheet.Cells[currentRow, 1] = "ОТЧЕТ ПО ПРЕПОДАВАТЕЛЯМ";
                Excel.Range titleRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 7]];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 12;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // ИНФОРМАЦИЯ О СОЗДАНИИ
                worksheet.Cells[5, 1] = $"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}";
                worksheet.Cells[4, 1] = $"Создал: Моисеенко М.А.";
                currentRow += 2;

                // ЗАГОЛОВКИ ТАБЛИЦЫ
                string[] headers = {
            "ФИО преподавателя",
            "Кафедра",
            "Email",
            "Телефон",
            "Логин",
            "Кол-во факультативов"
        };

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[currentRow, i + 1] = headers[i];
                    Excel.Range headerCell = worksheet.Cells[currentRow, i + 1];
                    headerCell.Font.Bold = true;
                    headerCell.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                    // Настраиваем ширину столбцов
                    if (i == 0) worksheet.Columns[i + 1].ColumnWidth = 25; // ФИО
                    else if (i == 1) worksheet.Columns[i + 1].ColumnWidth = 20; // Кафедра
                    else if (i == 2) worksheet.Columns[i + 1].ColumnWidth = 25; // Email
                    else if (i == 3) worksheet.Columns[i + 1].ColumnWidth = 15; // Телефон
                    else if (i == 4) worksheet.Columns[i + 1].ColumnWidth = 15; // Логин
                    else worksheet.Columns[i + 1].ColumnWidth = 25; // Кол-во факультативов
                }
                currentRow++;

                // ДАННЫЕ ИЗ БАЗЫ ДАННЫХ
                string SqlText = @"SELECT 
                        p.ФИО as 'ФИО преподавателя',
                        p.Кафедра as 'Кафедра',
                        p.Email as 'Email',
                        p.Телефон as 'Телефон',
                        p.Логин as 'Логин',
                        (SELECT COUNT(*) FROM Факультатив f WHERE f.М_преподавателя = p.М_преподавателя) as 'Кол-во факультативов'
                    FROM Преподаватель p
                    ORDER BY p.ФИО";

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(SqlText, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

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

                // ПОДПИСИ
                currentRow += 2;
                worksheet.Cells[currentRow, 1] = "Подпись: _________________________";
                worksheet.Cells[currentRow, 1].Font.Bold = true;
                currentRow++;

                excelApp.Visible = true;
                excelApp.UserControl = true;

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
                // Освобождаем ресурсы
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);
            }
        }

        private void btnCreateStudent_Click_1(object sender, EventArgs e)
        {
            using (var form = new StudentRegistrationForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadStudents();
                }
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
            string studentName = dgvStudents.SelectedRows[0].Cells["ФИО"].Value.ToString();

            if (MessageBox.Show($"Удалить студента '{studentName}'?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();

                        // Удаляем заявки студента
                        string deleteApplicationsQuery = "DELETE FROM Заявка WHERE М_студента = @StudentId";
                        using (var command = new SqlCommand(deleteApplicationsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@StudentId", studentId);
                            command.ExecuteNonQuery();
                        }

                        // Удаляем студента
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
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Отчёт по студентам";

                // Устанавливаем шрифт для всего листа
                worksheet.Cells.Font.Name = "Times New Roman";
                worksheet.Cells.Font.Size = 11;

                int currentRow = 1;

                // ШАПКА ОРГАНИЗАЦИИ
                worksheet.Cells[currentRow, 1] = "МКОУ \"Волчихинская СШ№2\"";
                Excel.Range orgRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 7]];
                orgRange.Merge();
                orgRange.Font.Bold = true;
                orgRange.Font.Size = 14;
                orgRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // ЗАГОЛОВОК ОТЧЕТА
                worksheet.Cells[currentRow, 1] = "ОТЧЕТ ПО СТУДЕНТАМ";
                Excel.Range titleRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 7]];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 12;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // ИНФОРМАЦИЯ О СОЗДАНИИ
                worksheet.Cells[5, 1] = $"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}";
                worksheet.Cells[4, 1] = $"Создал: Моисеенко М.А.";
                currentRow += 2;

                // ЗАГОЛОВКИ ТАБЛИЦЫ
                string[] headers = {
            "ФИО студента",
            "Группа",
            "Email",
            "Телефон",
            "Логин",
            "Кол-во факультативов"
        };

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[currentRow, i + 1] = headers[i];
                    Excel.Range headerCell = worksheet.Cells[currentRow, i + 1];
                    headerCell.Font.Bold = true;
                    headerCell.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                    // Настраиваем ширину столбцов
                    if (i == 0) worksheet.Columns[i + 1].ColumnWidth = 25; // ФИО студента
                    else if (i == 1) worksheet.Columns[i + 1].ColumnWidth = 15; // Группа
                    else if (i == 2) worksheet.Columns[i + 1].ColumnWidth = 25; // Email
                    else if (i == 3) worksheet.Columns[i + 1].ColumnWidth = 15; // Телефон
                    else if (i == 4) worksheet.Columns[i + 1].ColumnWidth = 15; // Логин
                    else worksheet.Columns[i + 1].ColumnWidth = 25;
                    // Кол-во факультативов
                }
                currentRow++;

                // ДАННЫЕ ИЗ БАЗЫ ДАННЫХ
                string SqlText = @"SELECT 
                        s.ФИО as 'ФИО студента',
                        s.Группа as 'Группа',
                        s.Email as 'Email',
                        s.Телефон as 'Телефон',
                        s.Логин as 'Логин',
                        (SELECT COUNT(*) FROM Заявка z WHERE z.М_студента = s.М_студента AND z.Статус = 'Принято') as 'Кол-во факультативов'
                    FROM Студент s
                    ORDER BY s.Группа, s.ФИО";

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(SqlText, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

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

                // ПОДПИСИ
                currentRow += 2;
                worksheet.Cells[currentRow, 1] = "Подпись: _________________________";
                worksheet.Cells[currentRow, 1].Font.Bold = true;
                currentRow++;

                excelApp.Visible = true;
                excelApp.UserControl = true;

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
                // Освобождаем ресурсы
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
    }
}