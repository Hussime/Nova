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
    public partial class TeacherForm : Form
    {
        private User currentUser;

        public TeacherForm(User user)
        {
            currentUser = user;
            InitializeComponent();
            this.Text = $"ReHub - Преподаватель: {user.FullName}";
            LoadApplications();
            LoadApprovedStudents();
            LoadMyElectives();
            LoadCourseStudents();
            LoadElectivesToComboBox();
            string greeting = GetTimeBasedGreeting();
            this.lblCurrentUser.Text = $"{greeting}, {currentUser.FullName}!";
        }
        private DataTable electivesData;
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
        private void LoadApplications()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT z.М_заявки, s.ФИО as Студент, f.Название as Факультатив, 
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
                    string query = @"SELECT 
                            s.ФИО, 
                            s.Группа, 
                            f.Название as Факультатив,
                            z.Статус as Статус_заявки,
                            z.Дата_подачи
                        FROM Заявка z 
                        INNER JOIN Студент s ON z.М_студента = s.М_студента
                        INNER JOIN Факультатив f ON z.М_факультатива = f.М_факультатива
                        WHERE f.М_преподавателя = @TeacherId AND z.Статус = 'Принято'";

                    // Добавляем фильтр по факультативу если выбран конкретный
                    if (electiveId > 0)
                    {
                        query += " AND f.М_факультатива = @ElectiveId";
                    }

                    query += " ORDER BY s.ФИО, f.Название";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TeacherId", currentUser.Id);

                        if (electiveId > 0)
                        {
                            command.Parameters.AddWithValue("@ElectiveId", electiveId);
                        }

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
                    string query = @"SELECT DISTINCT
                            s.ФИО, 
                            s.Группа, 
                            s.Email, 
                            s.Телефон,
                            s.Логин,
                            s.Пароль
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
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки студентов на курсах: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApprove_Click_1(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для подтверждения", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int applicationId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["М_заявки"].Value);
            string studentName = dgvApplications.SelectedRows[0].Cells["Студент"].Value.ToString();

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE Заявка SET Статус = 'Принято', Проверяет = @TeacherId 
                           WHERE М_заявки = @ApplicationId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        command.Parameters.AddWithValue("@ApplicationId", applicationId);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Заявка студента {studentName} принята!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadApplications();
                    LoadApprovedStudents();

                    // Обновляем список студентов с учетом текущего фильтра
                    RefreshCourseStudentsWithFilter();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подтверждения заявки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReject_Click_1(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для отклонения", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int applicationId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["М_заявки"].Value);
            string studentName = dgvApplications.SelectedRows[0].Cells["Студент"].Value.ToString();

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE Заявка SET Статус = 'Отклонено', Проверяет = @TeacherId 
                           WHERE М_заявки = @ApplicationId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TeacherId", currentUser.Id);
                        command.Parameters.AddWithValue("@ApplicationId", applicationId);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Заявка студента {studentName} отклонена!", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadApplications();

                    // Обновляем список студентов с учетом текущего фильтра
                    RefreshCourseStudentsWithFilter();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отклонения заявки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetSchedule_Click_1(object sender, EventArgs e)
        {
            if (dgvMyElectives.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите факультатив", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtLessonTime.Text))
            {
                MessageBox.Show("Введите время занятия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int electiveId = Convert.ToInt32(dgvMyElectives.SelectedRows[0].Cells["М_факультатива"].Value);
            string electiveName = dgvMyElectives.SelectedRows[0].Cells["Название"].Value.ToString();

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

                    MessageBox.Show($"Расписание для факультатива '{electiveName}' установлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMyElectives();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка установки расписания: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadApplications();
            LoadApprovedStudents();
            LoadMyElectives();
            LoadCourseStudents();
            LoadElectivesToComboBox();
            RefreshCourseStudentsWithFilter();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите студента для отчисления из таблицы", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string studentName = "";
            string electiveName = "";

            try
            {
                // Получаем данные выбранного студента
                var row = dgvStudents.SelectedRows[0];
                studentName = row.Cells["ФИО"].Value?.ToString() ?? "неизвестный студент";

                // Получаем название факультатива из выбранной строки
                if (row.Cells["Факультатив"] != null && row.Cells["Факультатив"].Value != null)
                {
                    electiveName = row.Cells["Факультатив"].Value.ToString();
                }

                if (string.IsNullOrEmpty(electiveName))
                {
                    MessageBox.Show("Не удалось определить факультатив студента", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Подтверждение отчисления
                string message = $"Вы уверены, что хотите отчислить студента {studentName} с факультатива '{electiveName}'?";

                if (MessageBox.Show(message, "Подтверждение отчисления",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExpelStudent(studentName, electiveName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении данных студента: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show($"Студент {studentName} успешно отчислен с факультатива '{electiveName}'!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Обновляем данные с учетом фильтра
                            LoadApprovedStudents();
                            RefreshCourseStudentsWithFilter();
                        }
                        else
                        {
                            MessageBox.Show($"Не удалось найти студента {studentName} на факультативе '{electiveName}'",
                                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отчисления студента: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                // Получаем список факультативов преподавателя
                DataTable electives = GetTeacherElectives();

                if (electives.Rows.Count == 0)
                {
                    MessageBox.Show("У вас нет активных факультативов", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Создаем приложение Excel
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Сводный отчет";

                // Устанавливаем шрифт для всего листа
                worksheet.Cells.Font.Name = "Times New Roman";
                worksheet.Cells.Font.Size = 11;

                int currentRow = 1;

                // ШАПКА ОРГАНИЗАЦИИ
                worksheet.Cells[currentRow, 1] = "МКОУ \"Волчихинская СШ№2\"";
                Excel.Range orgRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 5]];
                orgRange.Merge();
                orgRange.Font.Bold = true;
                orgRange.Font.Size = 14;
                orgRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // ЗАГОЛОВОК ОТЧЕТА
                worksheet.Cells[currentRow, 1] = "СВОДНЫЙ ОТЧЕТ ПО ФАКУЛЬТАТИВАМ";
                Excel.Range titleRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 5]];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 12;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // ИНФОРМАЦИЯ О ПРЕПОДАВАТЕЛЕ
                worksheet.Cells[currentRow, 1] = "Преподаватель:";
                worksheet.Cells[currentRow, 2] = currentUser.FullName;
                currentRow++;

                worksheet.Cells[currentRow, 1] = "Дата формирования:";
                worksheet.Cells[currentRow, 2] = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                currentRow += 2;

                // СВОДНАЯ ТАБЛИЦА ПО ФАКУЛЬТАТИВАМ
                worksheet.Cells[currentRow, 1] = "СТАТИСТИКА ПО ФАКУЛЬТАТИВАМ";
                Excel.Range statsTitleRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 5]];
                statsTitleRange.Merge();
                statsTitleRange.Font.Bold = true;
                statsTitleRange.Font.Size = 11;
                statsTitleRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                statsTitleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                currentRow++;

                // Заголовки таблицы
                string[] headers = { "Факультатив", "Количество студентов", "Дата формирования", "Статус", "Преподаватель" };

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[currentRow, i + 1] = headers[i];
                    Excel.Range headerCell = worksheet.Cells[currentRow, i + 1];
                    headerCell.Font.Bold = true;
                    headerCell.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                    // Настраиваем ширину столбцов
                    if (i == 0) worksheet.Columns[i + 1].ColumnWidth = 30; // Факультатив
                    else if (i == 1) worksheet.Columns[i + 1].ColumnWidth = 20; // Количество студентов
                    else if (i == 2) worksheet.Columns[i + 1].ColumnWidth = 18; // Дата формирования
                    else if (i == 3) worksheet.Columns[i + 1].ColumnWidth = 15; // Статус
                    else worksheet.Columns[i + 1].ColumnWidth = 25; // Преподаватель
                }
                currentRow++;

                // Данные по каждому факультативу
                int totalStudents = 0;
                int successfulReports = 0;

                foreach (DataRow electiveRow in electives.Rows)
                {
                    int electiveId = Convert.ToInt32(electiveRow["М_факультатива"]);
                    string electiveName = electiveRow["Название"].ToString();

                    // Получаем студентов для текущего факультатива
                    DataTable enrolledStudents = GetEnrolledStudentsByElective(electiveId);
                    int studentCount = enrolledStudents.Rows.Count;
                    totalStudents += studentCount;

                    // Заполняем данные в таблицу
                    worksheet.Cells[currentRow, 1] = electiveName;
                    worksheet.Cells[currentRow, 2] = studentCount;
                    worksheet.Cells[currentRow, 3] = DateTime.Now.ToString("dd.MM.yyyy");
                    worksheet.Cells[currentRow, 4] = studentCount > 0 ? "Активен" : "Нет студентов";
                    worksheet.Cells[currentRow, 5] = currentUser.FullName;

                    // Границы для строки
                    for (int j = 1; j <= headers.Length; j++)
                    {
                        Excel.Range cell = worksheet.Cells[currentRow, j];
                        cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }

                    // Создаем отдельный лист для факультатива со студентами
                    if (studentCount > 0 && CreateElectiveSheet(workbook, electiveId, electiveName))
                    {
                        successfulReports++;
                    }

                    currentRow++;
                }

                // ИТОГИ
                worksheet.Cells[currentRow, 1] = "ВСЕГО:";
                worksheet.Cells[currentRow, 2] = totalStudents;
                worksheet.Cells[currentRow, 3] = "-";
                worksheet.Cells[currentRow, 4] = "-";
                worksheet.Cells[currentRow, 5] = "-";

                // Выделение итоговой строки
                for (int j = 1; j <= headers.Length; j++)
                {
                    Excel.Range cell = worksheet.Cells[currentRow, j];
                    cell.Font.Bold = true;
                    cell.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }

                currentRow += 2;


                worksheet.Cells[currentRow, 1] = "Подпись: _________________________";
                worksheet.Cells[currentRow, 1].Font.Bold = true;
                currentRow++;

                // Активируем сводный лист
                worksheet.Activate();

                excelApp.Visible = true;
                excelApp.UserControl = true;

                MessageBox.Show($"Отчет успешно создан!\nФакультативов: {successfulReports}\nВсего студентов: {totalStudents}",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private bool CreateElectiveSheet(Microsoft.Office.Interop.Excel.Workbook workbook, int electiveId, string electiveName)
        {
            Excel.Worksheet worksheet = null;

            try
            {
                DataTable enrolledStudents = GetEnrolledStudentsByElective(electiveId);

                if (enrolledStudents.Rows.Count == 0)
                {
                    return false;
                }

                // Создаем новый лист
                worksheet = workbook.Worksheets.Add();
                worksheet.Name = CreateSafeSheetName(electiveName);

                // Устанавливаем шрифт для всего листа
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

                // ЗАГОЛОВОК ОТЧЕТА
                worksheet.Cells[currentRow, 1] = $"СПИСОК СТУДЕНТОВ ФАКУЛЬТАТИВА: {electiveName}";
                Excel.Range titleRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 6]];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 12;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // ИНФОРМАЦИЯ
                worksheet.Cells[currentRow, 1] = "Преподаватель:";
                worksheet.Cells[currentRow, 2] = currentUser.FullName;
                currentRow++;

                worksheet.Cells[currentRow, 1] = "Дата формирования:";
                worksheet.Cells[currentRow, 2] = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                currentRow++;

                worksheet.Cells[currentRow, 1] = "Количество студентов:";
                worksheet.Cells[currentRow, 2] = enrolledStudents.Rows.Count;
                currentRow += 2;

                // ТАБЛИЦА СТУДЕНТОВ
                worksheet.Cells[currentRow, 1] = "СПИСОК СТУДЕНТОВ";
                Excel.Range studentsTitleRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 6]];
                studentsTitleRange.Merge();
                studentsTitleRange.Font.Bold = true;
                studentsTitleRange.Font.Size = 11;
                studentsTitleRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                studentsTitleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                currentRow++;

                // Заголовки таблицы студентов
                string[] studentHeaders = { "№", "ФИО студента", "Группа", "Дата зачисления", "Email", "Телефон" };

                for (int i = 0; i < studentHeaders.Length; i++)
                {
                    worksheet.Cells[currentRow, i + 1] = studentHeaders[i];
                    Excel.Range headerCell = worksheet.Cells[currentRow, i + 1];
                    headerCell.Font.Bold = true;
                    headerCell.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                    // Настраиваем ширину столбцов
                    if (i == 0) worksheet.Columns[i + 1].ColumnWidth = 21;  // №
                    else if (i == 1) worksheet.Columns[i + 1].ColumnWidth = 25; // ФИО
                    else if (i == 2) worksheet.Columns[i + 1].ColumnWidth = 15; // Группа
                    else if (i == 3) worksheet.Columns[i + 1].ColumnWidth = 18; // Дата зачисления
                    else if (i == 4) worksheet.Columns[i + 1].ColumnWidth = 25; // Email
                    else worksheet.Columns[i + 1].ColumnWidth = 15; // Телефон
                }
                currentRow++;

                // Данные студентов
                for (int i = 0; i < enrolledStudents.Rows.Count; i++)
                {
                    worksheet.Cells[currentRow, 1] = i + 1;
                    worksheet.Cells[currentRow, 2] = SafeString(enrolledStudents.Rows[i]["ФИО"]);
                    worksheet.Cells[currentRow, 3] = SafeString(enrolledStudents.Rows[i]["Группа"]);
                    worksheet.Cells[currentRow, 4] = SafeString(enrolledStudents.Rows[i]["Дата_подачи"]);
                    worksheet.Cells[currentRow, 5] = SafeString(enrolledStudents.Rows[i]["Email"]);
                    worksheet.Cells[currentRow, 6] = SafeString(enrolledStudents.Rows[i]["Телефон"]);

                    // Границы для всех ячеек строки
                    for (int j = 1; j <= studentHeaders.Length; j++)
                    {
                        Excel.Range dataCell = worksheet.Cells[currentRow, j];
                        dataCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                    currentRow++;
                }

                // Итоговая строка
                worksheet.Cells[currentRow, 1] = $"Всего студентов: {enrolledStudents.Rows.Count}";
                Excel.Range totalRange = worksheet.Range[worksheet.Cells[currentRow, 1], worksheet.Cells[currentRow, 6]];
                totalRange.Merge();
                totalRange.Font.Bold = true;
                totalRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                currentRow += 2;

 

                worksheet.Cells[currentRow, 1] = "Подпись: _________________________";
                worksheet.Cells[currentRow, 1].Font.Bold = true;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
            }
        }

        // Вспомогательные методы остаются без изменений
        private string CreateSafeSheetName(string name)
        {
            if (string.IsNullOrEmpty(name)) return "Кружок";

            string safeName = name.Replace(":", "_").Replace("\\", "_").Replace("/", "_")
                                 .Replace("?", "_").Replace("*", "_").Replace("[", "_")
                                 .Replace("]", "_");

            if (safeName.Length > 31) return safeName.Substring(0, 28) + "...";
            return safeName;
        }

        private string SafeString(object value)
        {
            if (value == null || value == DBNull.Value) return "";
            return value.ToString().Replace("\0", "").Replace("\u0001", "").Trim();
        }

        // Методы для получения данных из БД остаются без изменений
        private DataTable GetTeacherElectives()
        {
            DataTable dt = new DataTable();

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
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки кружков: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        private DataTable GetEnrolledStudentsByElective(int electiveId)
        {
            DataTable dt = new DataTable();

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    string query = @"SELECT 
             s.ФИО, 
             s.Группа, 
             z.Дата_подачи,
             s.Email,
             s.Телефон
         FROM Заявка z 
         INNER JOIN Студент s ON z.М_студента = s.М_студента
         WHERE z.М_факультатива = @ElectiveId 
         AND z.Статус = 'Принято'
         ORDER BY s.ФИО";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ElectiveId", electiveId);
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки студентов: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
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

                            // Добавляем элемент "Все факультативы"
                            DataRow allRow = electivesData.NewRow();
                            allRow["М_факультатива"] = 0;
                            allRow["Название"] = "Все факультативы";
                            electivesData.Rows.InsertAt(allRow, 0);

                            // Настраиваем ComboBox
                            comboBoxElectives.DataSource = electivesData;
                            comboBoxElectives.DisplayMember = "Название";
                            comboBoxElectives.ValueMember = "М_факультатива";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки факультативов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        // Вспомогательный метод для обновления студентов с учетом текущего фильтра
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
                        LoadApprovedStudents(selectedElectiveId);
                    }
                }
                else
                {
                    LoadApprovedStudents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении списка студентов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadApprovedStudents(); // Загружаем всех студентов в случае ошибки
            }
        }

        private void comboBoxElectives_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxElectives.SelectedItem != null)
                {
                    // Получаем выбранную строку данных
                    DataRowView selectedRow = comboBoxElectives.SelectedItem as DataRowView;

                    if (selectedRow != null)
                    {
                        int selectedElectiveId = Convert.ToInt32(selectedRow["М_факультатива"]);

                        // Если выбран "Все факультативы" (ID = 0), загружаем всех студентов
                        if (selectedElectiveId == 0)
                        {
                            LoadApprovedStudents(); // Без фильтра
                        }
                        else
                        {
                            LoadApprovedStudents(selectedElectiveId); // С фильтром по факультативу
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при фильтрации студентов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}