using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReHub
{
    public partial class TeacherForm : Form
    {
        private User currentUser;
        private DataTable electivesData;
        private string avatarPath = "";

        public TeacherForm(User user)
        {
            InitializeComponent();
            currentUser = user;

            btnNavApps.Click += (s, e) => ShowPanel("apps");
            btnNavStudents.Click += (s, e) => ShowPanel("students");
            btnNavElectives.Click += (s, e) => ShowPanel("electives");
            btnNavSchedule.Click += (s, e) => ShowPanel("schedule");
            btnNavNotifs.Click += (s, e) => ShowPanel("notifs");
            btnNavProfile.Click += (s, e) => ShowPanel("teacher_profile");
            btnNotifBell.Click += (s, e) => ShowPanel("notifs");
            btnCloseForm.Click += (s, e) => Application.Exit();
            dgvMyElectives.SelectionChanged += dgvMyElectives_SelectionChanged;

            btnApprove.Click += btnApprove_Click_1;
            btnReject.Click += btnReject_Click_1;
            btnSetSchedule.Click += btnSetSchedule_Click_1;
            btnExpelStudent.Click += button1_Click;
            button2.Click += button2_Click;
            btnMarkAll.Click += btnMarkAllTeacher_Click;
            comboBoxElectives.SelectedIndexChanged += comboBoxElectives_SelectedIndexChanged_1;

            pnlTeacherAvatarContainer.Click += (s, e) => ChangeTeacherAvatar();
            picTeacherAvatarProfile.Click += (s, e) => ChangeTeacherAvatar();
            picAvatar.Click += (s, e) => ShowPanel("teacher_profile");

            btnSaveTeacherProfile.Click += btnSaveTeacherProfile_Click;
            btnCancelTeacherProfile.Click += (s, e) => LoadTeacherProfile();

            this.Text = $"НОВА - Преподаватель: {user.FullName}";

            LoadApplications();
            LoadApprovedStudents();
            LoadMyElectives();
            LoadCourseStudents();
            LoadElectivesToComboBox();
            LoadScheduleElectives();
            LoadNotificationsTeacher();
            LoadTeacherAvatar();
            LoadTeacherProfile();

            string greeting = GetTimeBasedGreeting();
            lblCurrentUser.Text = $"{greeting}, {currentUser.FullName}!";

            ShowPanel("apps");
        }

        private void ShowPanel(string name)
        {
            pnlApps.Visible = false;
            pnlStudents.Visible = false;
            pnlMyElectives.Visible = false;
            pnlSchedule.Visible = false;
            pnlNotifs.Visible = false;
            pnlTeacherProfile.Visible = false;

            var buttons = new[] { btnNavApps, btnNavStudents, btnNavElectives, btnNavSchedule, btnNavNotifs, btnNavProfile };
            foreach (var b in buttons)
            {
                b.BackColor = Color.White;
                b.ForeColor = Color.FromArgb(80, 80, 80);
            }

            switch (name)
            {
                case "apps":
                    pnlApps.Visible = true;
                    btnNavApps.BackColor = Color.FromArgb(230, 241, 251);
                    btnNavApps.ForeColor = Color.FromArgb(24, 95, 165);
                    break;
                case "students":
                    pnlStudents.Visible = true;
                    btnNavStudents.BackColor = Color.FromArgb(230, 241, 251);
                    btnNavStudents.ForeColor = Color.FromArgb(24, 95, 165);
                    break;
                case "electives":
                    pnlMyElectives.Visible = true;
                    btnNavElectives.BackColor = Color.FromArgb(230, 241, 251);
                    btnNavElectives.ForeColor = Color.FromArgb(24, 95, 165);
                    break;
                case "schedule":
                    pnlSchedule.Visible = true;
                    btnNavSchedule.BackColor = Color.FromArgb(230, 241, 251);
                    btnNavSchedule.ForeColor = Color.FromArgb(24, 95, 165);
                    break;
                case "notifs":
                    pnlNotifs.Visible = true;
                    btnNavNotifs.BackColor = Color.FromArgb(230, 241, 251);
                    btnNavNotifs.ForeColor = Color.FromArgb(24, 95, 165);
                    LoadNotificationsTeacher();
                    break;
                case "teacher_profile":
                    pnlTeacherProfile.Visible = true;
                    btnNavProfile.BackColor = Color.FromArgb(230, 241, 251);
                    btnNavProfile.ForeColor = Color.FromArgb(24, 95, 165);
                    LoadTeacherProfile();
                    break;
            }
        }

        private string GetTimeBasedGreeting()
        {
            int hour = DateTime.Now.Hour;
            if (hour >= 6 && hour < 12) return "Доброе утро";
            else if (hour >= 12 && hour < 18) return "Добрый день";
            else return "Добрый вечер";
        }

        private void LoadApplications()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT z.М_заявки, s.М_студента, s.ФИО as Студент, f.Название as Факультатив, 
                           z.Дата_подачи, z.Статус
                           FROM Заявка z 
                           INNER JOIN Студент s ON z.М_студента = s.М_студента
                           INNER JOIN Факультатив f ON z.М_факультатива = f.М_факультатива
                           WHERE f.М_преподавателя = @TeacherId AND z.Статус = 'Ожидание'";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvApplications.DataSource = dt;

                            if (dgvApplications.Columns.Contains("М_заявки")) dgvApplications.Columns["М_заявки"].Visible = false;
                            if (dgvApplications.Columns.Contains("М_студента")) dgvApplications.Columns["М_студента"].Visible = false;

                            if (dgvApplications.Columns.Contains("Студент"))
                                dgvApplications.Columns["Студент"].HeaderText = "Ученик";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заявок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadApprovedStudents(int electiveId = 0)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT s.ФИО, s.Группа, f.Название as Факультатив,
                            z.Статус as Статус_заявки, z.Дата_подачи
                        FROM Заявка z 
                        INNER JOIN Студент s ON z.М_студента = s.М_студента
                        INNER JOIN Факультатив f ON z.М_факультатива = f.М_факультатива
                        WHERE f.М_преподавателя = @TeacherId AND z.Статус = 'Принято'";

                    if (electiveId > 0) query += " AND f.М_факультатива = @ElectiveId";
                    query += " ORDER BY s.ФИО, f.Название";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        if (electiveId > 0) command.Parameters.AddWithValue("@ElectiveId", electiveId);

                        using (var adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvStudents.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки студентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMyElectives()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT М_факультатива, Название, Описание, Дата_занятия, Время_занятия
                                   FROM Факультатив 
                                   WHERE М_преподавателя = @TeacherId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvMyElectives.DataSource = dt;

                            if (dgvMyElectives.Columns.Contains("М_факультатива")) dgvMyElectives.Columns["М_факультатива"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки факультативов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCourseStudents()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT DISTINCT s.ФИО, s.Группа, s.Email, s.Телефон, s.Логин, s.Пароль
                        FROM Заявка z 
                        INNER JOIN Студент s ON z.М_студента = s.М_студента
                        INNER JOIN Факультатив f ON z.М_факультатива = f.М_факультатива
                        WHERE f.М_преподавателя = @TeacherId AND z.Статус = 'Принято'
                        ORDER BY s.ФИО";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvCourseStudents.DataSource = dt;
                            if (dgvCourseStudents.Columns.Contains("ФИО")) dgvCourseStudents.Columns["ФИО"].HeaderText = "ФИО ученика";
                            if (dgvCourseStudents.Columns.Contains("Группа")) dgvCourseStudents.Columns["Группа"].HeaderText = "Класс";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки студентов на курсах: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadElectivesToComboBox()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT М_факультатива, Название 
                           FROM Факультатив 
                           WHERE М_преподавателя = @TeacherId
                           ORDER BY Название";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            electivesData = new DataTable();
                            adapter.Fill(electivesData);

                            DataRow allRow = electivesData.NewRow();
                            allRow["М_факультатива"] = 0;
                            allRow["Название"] = "Все факультативы";
                            electivesData.Rows.InsertAt(allRow, 0);

                            comboBoxElectives.DataSource = electivesData;
                            comboBoxElectives.DisplayMember = "Название";
                            comboBoxElectives.ValueMember = "М_факультатива";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки факультативов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadScheduleElectives()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT М_факультатива, Название 
                           FROM Факультатив 
                           WHERE М_преподавателя = @TeacherId
                           ORDER BY Название";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            comboBoxScheduleElectives.DataSource = dt;
                            comboBoxScheduleElectives.DisplayMember = "Название";
                            comboBoxScheduleElectives.ValueMember = "М_факультатива";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки факультативов: {ex.Message}");
            }
        }

        private void btnApprove_Click_1(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для подтверждения", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int applicationId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["М_заявки"].Value);
            int studentId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["М_студента"].Value);
            string studentName = dgvApplications.SelectedRows[0].Cells["Студент"].Value.ToString();
            string electiveName = dgvApplications.SelectedRows[0].Cells["Факультатив"].Value.ToString();

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("UPDATE Заявка SET Статус = 'Принято', Проверяет = @TeacherId WHERE М_заявки = @ApplicationId", connection))
                    {
                        cmd.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        cmd.Parameters.AddWithValue("@ApplicationId", applicationId);
                        cmd.ExecuteNonQuery();
                    }
                    CreateStudentNotification(studentId, $"Ваша заявка на факультатив «{electiveName}» принята преподавателем!", "success");
                }

                MessageBox.Show($"Заявка студента {studentName} принята!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadApplications();
                LoadApprovedStudents();
                RefreshCourseStudentsWithFilter();
                UpdateTeacherBadge(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подтверждения заявки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReject_Click_1(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для отклонения", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int applicationId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["М_заявки"].Value);
            int studentId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["М_студента"].Value);
            string studentName = dgvApplications.SelectedRows[0].Cells["Студент"].Value.ToString();
            string electiveName = dgvApplications.SelectedRows[0].Cells["Факультатив"].Value.ToString();

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("UPDATE Заявка SET Статус = 'Отклонено', Проверяет = @TeacherId WHERE М_заявки = @ApplicationId", connection))
                    {
                        cmd.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        cmd.Parameters.AddWithValue("@ApplicationId", applicationId);
                        cmd.ExecuteNonQuery();
                    }
                    CreateStudentNotification(studentId, $"Ваша заявка на факультатив «{electiveName}» отклонена преподавателем.", "warning");
                }

                MessageBox.Show($"Заявка студента {studentName} отклонена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadApplications();
                RefreshCourseStudentsWithFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отклонения заявки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetSchedule_Click_1(object sender, EventArgs e)
        {
            if (comboBoxScheduleElectives.SelectedItem == null)
            {
                MessageBox.Show("Выберите факультатив из списка", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtLessonTime.Text))
            {
                MessageBox.Show("Введите время занятия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int electiveId = Convert.ToInt32(comboBoxScheduleElectives.SelectedValue);
            string electiveName = comboBoxScheduleElectives.Text;

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE Факультатив SET Дата_занятия = @LessonDate, Время_занятия = @LessonTime 
                                   WHERE М_факультатива = @ElectiveId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LessonDate", dtpLessonDate.Value);
                        command.Parameters.AddWithValue("@LessonTime", txtLessonTime.Text);
                        command.Parameters.AddWithValue("@ElectiveId", electiveId);
                        command.ExecuteNonQuery();
                    }
                    CreateTeacherNotification(currentUser.Id, $"Расписание для факультатива «{electiveName}» обновлено.", "success");
                }

                MessageBox.Show($"Расписание для факультатива '{electiveName}' установлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMyElectives();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка установки расписания: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите студента для отчисления из таблицы", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string studentName = dgvStudents.SelectedRows[0].Cells["ФИО"].Value?.ToString() ?? "неизвестный студент";
            string electiveName = dgvStudents.SelectedRows[0].Cells["Факультатив"].Value?.ToString();

            if (string.IsNullOrEmpty(electiveName))
            {
                MessageBox.Show("Не удалось определить факультатив студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Вы уверены, что хотите отчислить студента {studentName} с факультатива '{electiveName}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ExpelStudent(studentName, electiveName);
            }
        }

        private void ExpelStudent(string studentName, string electiveName)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE Заявка 
                   SET Статус = 'Отчислен', Проверяет = @TeacherId 
                   WHERE М_заявки IN (
                       SELECT z.М_заявки 
                       FROM Заявка z 
                       INNER JOIN Студент s ON z.М_студента = s.М_студента
                       INNER JOIN Факультатив f ON z.М_факультатива = f.М_факультатива
                       WHERE s.ФИО = @StudentName 
                       AND f.Название = @ElectiveName
                       AND f.М_преподавателя = @TeacherId 
                       AND z.Статус = 'Принято'
                   )";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        command.Parameters.AddWithValue("@StudentName", studentName);
                        command.Parameters.AddWithValue("@ElectiveName", electiveName);
                        int affectedRows = command.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show($"Студент {studentName} успешно отчислен с факультатива '{electiveName}'!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadApprovedStudents();
                            RefreshCourseStudentsWithFilter();
                        }
                        else
                        {
                            MessageBox.Show($"Не удалось найти студента {studentName} на факультативе '{electiveName}'", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отчисления студента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvMyElectives_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMyElectives.SelectedRows.Count > 0 && dgvMyElectives.CurrentRow != null)
            {
                try
                {
                    var row = dgvMyElectives.CurrentRow;

                    // Получаем ID факультатива (из скрытой колонки или из текста)
                    int electiveId = -1;
                    string electiveName = row.Cells["Название"].Value?.ToString();

                    // Ищем соответствие в comboBoxScheduleElectives
                    foreach (DataRowView item in comboBoxScheduleElectives.Items)
                    {
                        if (item["Название"].ToString() == electiveName)
                        {
                            comboBoxScheduleElectives.SelectedItem = item;
                            electiveId = Convert.ToInt32(item["М_факультатива"]);
                            break;
                        }
                    }

                    // Подставляем дату если есть
                    if (row.Cells["Дата_занятия"].Value != null && row.Cells["Дата_занятия"].Value != DBNull.Value)
                    {
                        dtpLessonDate.Value = Convert.ToDateTime(row.Cells["Дата_занятия"].Value);
                    }

                    // Подставляем время если есть
                    if (row.Cells["Время_занятия"].Value != null)
                    {
                        txtLessonTime.Text = row.Cells["Время_занятия"].Value.ToString();
                    }
                }
                catch { }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                DataTable students = GetAllEnrolledStudents();

                if (students.Rows.Count == 0)
                {
                    MessageBox.Show("Нет зачисленных учеников", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Данные учеников";
                worksheet.Cells.Font.Name = "Times New Roman";
                worksheet.Cells.Font.Size = 11;

                int currentRow = 1;

                // ШАПКА ОРГАНИЗАЦИИ
                worksheet.Cells[currentRow, 1] = "МКОУ \"Волчихинская СШ№2\"";
                Excel.Range orgRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 6]];
                orgRange.Merge();
                orgRange.Font.Bold = true;
                orgRange.Font.Size = 14;
                orgRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // ЗАГОЛОВОК
                worksheet.Cells[currentRow, 1] = "ДАННЫЕ ДЛЯ ДОСТУПА УЧЕНИКОВ";
                Excel.Range titleRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 6]];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 12;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // ИНФОРМАЦИЯ (ИСПРАВЛЕНИЕ 5 И 6 СТРОК)
                worksheet.Cells[currentRow, 1] = "Преподаватель:";
                worksheet.Cells[currentRow, 1].Font.Bold = true;
                worksheet.Cells[currentRow, 2] = currentUser.FullName;
                currentRow++;

                worksheet.Cells[currentRow, 1] = "Дата формирования:";
                worksheet.Cells[currentRow, 1].Font.Bold = true;
                worksheet.Cells[currentRow, 2] = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                currentRow += 2;

                // ЗАГОЛОВОК ТАБЛИЦЫ (СЕРЫЙ ФОН ПО ВСЕЙ ШИРИНЕ)
                worksheet.Cells[currentRow, 1] = "СПИСОК УЧЕНИКОВ";
                Excel.Range studentsTitleRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 6]];
                studentsTitleRange.Merge();
                studentsTitleRange.Font.Bold = true;
                studentsTitleRange.Font.Size = 11;
                studentsTitleRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                studentsTitleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                currentRow++;

                // ЗАГОЛОВКИ СТОЛБЦОВ
                string[] headers = { "№", "ФИО ученика", "Email", "Телефон", "Логин", "Пароль" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[currentRow, i + 1] = headers[i];
                    Excel.Range headerCell = worksheet.Cells[currentRow, i + 1];
                    headerCell.Font.Bold = true;
                    headerCell.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                    // Ширина столбцов
                    if (i == 0) worksheet.Columns[i + 1].ColumnWidth = 5;
                    else if (i == 1) worksheet.Columns[i + 1].ColumnWidth = 30;
                    else if (i == 2) worksheet.Columns[i + 1].ColumnWidth = 25;
                    else if (i == 3) worksheet.Columns[i + 1].ColumnWidth = 18;
                    else if (i == 4) worksheet.Columns[i + 1].ColumnWidth = 15;
                    else worksheet.Columns[i + 1].ColumnWidth = 15;
                }
                currentRow++;

                // ДАННЫЕ УЧЕНИКОВ
                for (int i = 0; i < students.Rows.Count; i++)
                {
                    worksheet.Cells[currentRow, 1] = i + 1;
                    worksheet.Cells[currentRow, 2] = SafeString(students.Rows[i]["ФИО"]);
                    worksheet.Cells[currentRow, 3] = SafeString(students.Rows[i]["Email"]);
                    worksheet.Cells[currentRow, 4] = SafeString(students.Rows[i]["Телефон"]);
                    worksheet.Cells[currentRow, 5] = SafeString(students.Rows[i]["Логин"]);
                    worksheet.Cells[currentRow, 6] = SafeString(students.Rows[i]["Пароль"]);

                    // Границы
                    for (int j = 1; j <= headers.Length; j++)
                    {
                        Excel.Range dataCell = worksheet.Cells[currentRow, j];
                        dataCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                    currentRow++;
                }

                // ИТОГОВАЯ СТРОКА (СЕРЫЙ ФОН ПО ВСЕЙ ШИРИНЕ)
                worksheet.Cells[currentRow, 1] = $"Всего учеников: {students.Rows.Count}";
                Excel.Range totalRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 6]];
                totalRange.Merge();
                totalRange.Font.Bold = true;
                totalRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                currentRow += 2;

                worksheet.Cells[currentRow, 1] = "Подпись: _________________________";
                worksheet.Cells[currentRow, 1].Font.Bold = true;

                // Автоподбор ширины
                worksheet.Columns.AutoFit();

                worksheet.Activate();
                excelApp.Visible = true;
                excelApp.UserControl = true;
                MessageBox.Show($"Отчёт успешно создан!\nВсего учеников: {students.Rows.Count}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчета: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);
            }
        }

        private DataTable GetAllEnrolledStudents()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT DISTINCT s.ФИО, s.Email, s.Телефон, s.Логин, s.Пароль
                        FROM Заявка z 
                        INNER JOIN Студент s ON z.М_студента = s.М_студента
                        INNER JOIN Факультатив f ON z.М_факультатива = f.М_факультатива
                        WHERE f.М_преподавателя = @TeacherId AND z.Статус = 'Принято'
                        ORDER BY s.ФИО";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки студентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        private void comboBoxElectives_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxElectives.SelectedItem != null)
                {
                    DataRowView selectedRow = comboBoxElectives.SelectedItem as DataRowView;
                    if (selectedRow != null)
                    {
                        int selectedElectiveId = Convert.ToInt32(selectedRow["М_факультатива"]);
                        if (selectedElectiveId == 0) LoadApprovedStudents();
                        else LoadApprovedStudents(selectedElectiveId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при фильтрации студентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCourseStudentsWithFilter()
        {
            try
            {
                if (comboBoxElectives.SelectedItem != null)
                {
                    DataRowView selectedRow = comboBoxElectives.SelectedItem as DataRowView;
                    if (selectedRow != null)
                    {
                        int selectedElectiveId = Convert.ToInt32(selectedRow["М_факультатива"]);
                        if (selectedElectiveId == 0) LoadApprovedStudents();
                        else LoadApprovedStudents(selectedElectiveId);
                    }
                }
                else LoadApprovedStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении списка студентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadApprovedStudents();
            }
        }

        private void LoadNotificationsTeacher()
        {
            pnlNotifList.Controls.Clear();
            int unread = 0;
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    var checkTable = new SqlCommand(@"IF OBJECT_ID('Уведомление', 'U') IS NULL BEGIN CREATE TABLE Уведомление (Id INT PRIMARY KEY IDENTITY(1,1), М_студента INT NULL, М_преподавателя INT NULL, Текст NVARCHAR(500) NOT NULL, Тип NVARCHAR(20) DEFAULT 'info', Дата_создания DATETIME DEFAULT GETDATE(), Прочитано BIT DEFAULT 0) END ELSE BEGIN IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Уведомление') AND name = 'М_преподавателя') BEGIN ALTER TABLE Уведомление ADD М_преподавателя INT NULL END END", connection);
                    checkTable.ExecuteNonQuery();

                    using (var cmd = new SqlCommand("SELECT Id, Текст, Тип, Дата_создания, Прочитано FROM Уведомление WHERE М_преподавателя = @TeacherId ORDER BY Дата_создания DESC", connection))
                    {
                        cmd.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            int y = 0;
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string text = reader.GetString(1);
                                string type = reader["Тип"]?.ToString() ?? "info";
                                DateTime date = reader.GetDateTime(3);
                                bool isRead = reader.GetBoolean(4);
                                if (!isRead) unread++;

                                var card = BuildTeacherNotifCard(id, text, type, date, isRead);
                                card.Location = new Point(14, y);
                                card.Width = pnlNotifList.ClientSize.Width - 28;
                                pnlNotifList.Controls.Add(card);
                                y += card.Height + 8;
                            }
                        }
                    }
                }
                UpdateTeacherBadge(unread);
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки уведомлений: {ex.Message}"); }
        }

        private Panel BuildTeacherNotifCard(int id, string text, string type, DateTime date, bool isRead)
        {
            Panel card = new Panel();
            card.Height = 70;
            card.BackColor = Color.White;
            card.Padding = new Padding(12);
            card.Cursor = Cursors.Hand;
            card.Tag = id;
            if (!isRead) card.Paint += (s, e) => e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(24, 95, 165)), 0, 0, 4, card.Height);

            Label icon = new Label(); icon.AutoSize = false; icon.Size = new Size(32, 32); icon.Location = new Point(16, 19); icon.Font = new Font("Segoe UI", 16F);
            switch (type.ToLower()) { case "success": icon.Text = "✓"; icon.ForeColor = Color.FromArgb(59, 109, 17); break; case "warning": icon.Text = "⚠"; icon.ForeColor = Color.FromArgb(217, 119, 6); break; case "error": icon.Text = "✕"; icon.ForeColor = Color.FromArgb(163, 45, 45); break; default: icon.Text = "ℹ"; icon.ForeColor = Color.FromArgb(24, 95, 165); break; }

            Label lblText = new Label(); lblText.Text = text; lblText.Font = new Font("Segoe UI", 10F); lblText.ForeColor = isRead ? Color.FromArgb(100, 100, 100) : Color.FromArgb(30, 30, 30); lblText.AutoSize = false; lblText.Size = new Size(card.Width - 80, 20); lblText.Location = new Point(60, 15);
            Label lblDate = new Label(); lblDate.Text = date.ToString("dd.MM HH:mm"); lblDate.Font = new Font("Segoe UI", 8F); lblDate.ForeColor = Color.FromArgb(150, 150, 150); lblDate.AutoSize = true; lblDate.Location = new Point(60, 38);

            card.Controls.AddRange(new Control[] { icon, lblText, lblDate });
            int capturedId = id;
            card.Click += (s, e) => MarkTeacherNotifRead(capturedId, card);
            icon.Click += (s, e) => MarkTeacherNotifRead(capturedId, card);
            lblText.Click += (s, e) => MarkTeacherNotifRead(capturedId, card);
            lblDate.Click += (s, e) => MarkTeacherNotifRead(capturedId, card);
            return card;
        }

        private void MarkTeacherNotifRead(int id, Panel card)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection()) { connection.Open(); using (var cmd = new SqlCommand("UPDATE Уведомление SET Прочитано = 1 WHERE Id = @Id", connection)) { cmd.Parameters.AddWithValue("@Id", id); cmd.ExecuteNonQuery(); } }
                card.Invalidate();
                LoadNotificationsTeacher();
            }
            catch { }
        }

        private void btnMarkAllTeacher_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Отметить все уведомления как прочитанные?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                using (var connection = DatabaseHelper.GetConnection()) { connection.Open(); using (var cmd = new SqlCommand("UPDATE Уведомление SET Прочитано = 1 WHERE М_преподавателя = @TeacherId AND Прочитано = 0", connection)) { cmd.Parameters.AddWithValue("@TeacherId", currentUser.Id); cmd.ExecuteNonQuery(); } }
                LoadNotificationsTeacher();
                MessageBox.Show("Все уведомления отмечены как прочитанные", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        private void UpdateTeacherBadge(int count)
        {
            lblNotifBadge.Text = count.ToString();
            lblNotifBadge.Visible = count > 0;
            if (count > 0) lblNotifSub.Text = $"{count} непрочитанных";
            else lblNotifSub.Text = "Все уведомления прочитаны";
        }

        private void CreateTeacherNotification(int teacherId, string text, string type = "info")
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    var checkColumn = new SqlCommand("IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Уведомление') AND name = 'М_преподавателя') BEGIN ALTER TABLE Уведомление ADD М_преподавателя INT NULL END", connection);
                    checkColumn.ExecuteNonQuery();
                    using (var cmd = new SqlCommand("INSERT INTO Уведомление (М_преподавателя, Текст, Тип) VALUES (@TeacherId, @Text, @Type)", connection))
                    {
                        cmd.Parameters.AddWithValue("@TeacherId", teacherId); cmd.Parameters.AddWithValue("@Text", text); cmd.Parameters.AddWithValue("@Type", type); cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }

        private void CreateStudentNotification(int studentId, string text, string type = "info")
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    var checkTable = new SqlCommand("IF OBJECT_ID('Уведомление', 'U') IS NULL BEGIN CREATE TABLE Уведомление (Id INT PRIMARY KEY IDENTITY(1,1), М_студента INT NOT NULL, Текст NVARCHAR(500) NOT NULL, Тип NVARCHAR(20) DEFAULT 'info', Дата_создания DATETIME DEFAULT GETDATE(), Прочитано BIT DEFAULT 0) END", connection);
                    checkTable.ExecuteNonQuery();
                    using (var cmd = new SqlCommand("INSERT INTO Уведомление (М_студента, Текст, Тип) VALUES (@StudentId, @Text, @Type)", connection))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", studentId); cmd.Parameters.AddWithValue("@Text", text); cmd.Parameters.AddWithValue("@Type", type); cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }

        private string SafeString(object value)
        {
            if (value == null || value == DBNull.Value) return "";
            return value.ToString().Replace("\0", "").Replace("\u0001", "").Trim();
        }

        private Image GetDefaultTeacherAvatar()
        {
            var bmp = new Bitmap(100, 100);
            using (var g = Graphics.FromImage(bmp)) { g.Clear(Color.FromArgb(230, 241, 251)); using (var brush = new SolidBrush(Color.FromArgb(24, 95, 165))) { g.FillEllipse(brush, 25, 45, 50, 50); g.FillEllipse(brush, 35, 10, 30, 30); } }
            return bmp;
        }

        private string GetTeacherAvatarPath()
        {
            string dir = Path.Combine(Application.StartupPath, "avatars");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            return Path.Combine(dir, $"teacher_{currentUser.Id}.png");
        }

        private void LoadTeacherAvatar()
        {
            avatarPath = GetTeacherAvatarPath();
            Image avatarImg = File.Exists(avatarPath) ? Image.FromFile(avatarPath) : GetDefaultTeacherAvatar();
            MakePictureBoxCircular(picAvatar, 36);
            MakePictureBoxCircular(picTeacherAvatarProfile, 80);
            picAvatar.Image = avatarImg;
            picTeacherAvatarProfile.Image = avatarImg;
        }

        private void MakePictureBoxCircular(PictureBox pb, int size)
        {
            pb.Width = size; pb.Height = size; pb.SizeMode = PictureBoxSizeMode.StretchImage; pb.BackColor = Color.Transparent;
            var path = new GraphicsPath(); path.AddEllipse(0, 0, size - 1, size - 1); pb.Region = new Region(path);
        }

        private void ChangeTeacherAvatar()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp"; ofd.Title = "Выберите аватарку";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var img = Image.FromFile(ofd.FileName))
                        {
                            string dir = Path.Combine(Application.StartupPath, "avatars");
                            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                            string path = GetTeacherAvatarPath(); img.Save(path, ImageFormat.Png); LoadTeacherAvatar();
                        }
                        MessageBox.Show("Аватарка успешно обновлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void LoadTeacherProfile()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT ФИО, Кафедра, Email, Телефон, Логин, Пароль FROM Преподаватель WHERE М_преподавателя = @TeacherId", connection))
                    {
                        cmd.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTeacherFullName.Text = reader["ФИО"]?.ToString() ?? "";
                                txtTeacherGroup.Text = reader["Кафедра"]?.ToString() ?? "";
                                txtTeacherEmail.Text = reader["Email"]?.ToString() ?? "";
                                txtTeacherPhone.Text = reader["Телефон"]?.ToString() ?? "";
                                txtTeacherLogin.Text = reader["Логин"]?.ToString() ?? "";
                                txtTeacherPassword.Text = reader["Пароль"]?.ToString() ?? "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки профиля: {ex.Message}"); }
        }

        private void btnSaveTeacherProfile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTeacherFullName.Text) || string.IsNullOrEmpty(txtTeacherLogin.Text) || string.IsNullOrEmpty(txtTeacherPassword.Text))
            { MessageBox.Show("Заполните обязательные поля (ФИО, Логин, Пароль)"); return; }

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(@"UPDATE Преподаватель SET ФИО = @FullName, Кафедра = @Department, Email = @Email, Телефон = @Phone, Логин = @Login, Пароль = @Password WHERE М_преподавателя = @TeacherId", connection))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtTeacherFullName.Text);
                        cmd.Parameters.AddWithValue("@Department", txtTeacherGroup.Text);
                        cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(txtTeacherEmail.Text) ? DBNull.Value : (object)txtTeacherEmail.Text);
                        cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(txtTeacherPhone.Text) ? DBNull.Value : (object)txtTeacherPhone.Text);
                        cmd.Parameters.AddWithValue("@Login", txtTeacherLogin.Text);
                        cmd.Parameters.AddWithValue("@Password", txtTeacherPassword.Text);
                        cmd.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Профиль обновлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentUser.FullName = txtTeacherFullName.Text;
                string greeting = GetTimeBasedGreeting();
                lblCurrentUser.Text = $"{greeting}, {txtTeacherFullName.Text}!";
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка сохранения: {ex.Message}"); }
        }
    }
}