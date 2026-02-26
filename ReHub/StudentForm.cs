using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReHub
{
    public partial class StudentForm : Form
    {
        private User currentUser;

        public StudentForm(User user)
        {
            currentUser = user;
            InitializeComponent();
            this.Text = $"ReHub - Студент: {user.FullName}";
            LoadElectives();
            LoadMyApplications();
            LoadSchedule();
            this.dgvElectives.SelectionChanged += new EventHandler(this.dgvElectives_SelectionChanged);
            this.dgvElectives.SelectionChanged += new EventHandler(this.dgvSchedule_SelectionChanged);
            LoadPersonalData();


            string greeting = GetTimeBasedGreeting();
            this.lblCurrentUser.Text = $"{greeting}, {currentUser.FullName}!";
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
        private void LoadElectives()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT f.М_факультатива, f.Название, f.Описание, p.ФИО as Преподаватель, 
                                   f.Макс_количество
                                   FROM Факультатив f 
                                   INNER JOIN Преподаватель p ON f.М_преподавателя = p.М_преподавателя";

                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvElectives.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки факультативов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMyApplications()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT z.М_заявки, f.Название as Факультатив, z.Дата_подачи, z.Статус
                                   FROM Заявка z 
                                   INNER JOIN Факультатив f ON z.М_факультатива = f.М_факультатива
                                   WHERE z.М_студента = @StudentId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentId", currentUser.Id);
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvMyApplications.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заявок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSchedule()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT f.Название as Факультатив, p.ФИО as Преподаватель, 
                           f.Дата_занятия as Дата, f.Время_занятия as Время
                           FROM Факультатив f 
                           INNER JOIN Преподаватель p ON f.М_преподавателя = p.М_преподавателя
                           INNER JOIN Заявка z ON f.М_факультатива = z.М_факультатива
                           WHERE z.М_студента = @StudentId AND z.Статус = 'Принято'
                           AND f.Дата_занятия IS NOT NULL";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentId", currentUser.Id);
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvSchedule.DataSource = dt;

                            // Добавляем обработчик события выбора строки
                            dgvSchedule.SelectionChanged += new EventHandler(dgvSchedule_SelectionChanged);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки расписания: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSchedule_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count > 0)
            {
                var row = dgvSchedule.SelectedRows[0];

                // Заполняем поля данными из выбранной строки
                txtSelectedElective.Text = row.Cells["Факультатив"].Value?.ToString() ?? "";
                txtSelectedTeacher.Text = row.Cells["Преподаватель"].Value?.ToString() ?? "";

                // Обрабатываем дату
                if (row.Cells["Дата"].Value != null && row.Cells["Дата"].Value != DBNull.Value)
                {
                    dtpSelectedDate.Value = Convert.ToDateTime(row.Cells["Дата"].Value);
                }

                txtSelectedTime.Text = row.Cells["Время"].Value?.ToString() ?? "";


            }

        }


        private void btnApply_Click(object sender, EventArgs e)
        {
            if (dgvElectives.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите факультатив для подачи заявки", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int electiveId = Convert.ToInt32(dgvElectives.SelectedRows[0].Cells["М_факультатива"].Value);
            string electiveName = dgvElectives.SelectedRows[0].Cells["Название"].Value.ToString();

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Заявка WHERE М_студента = @StudentId AND М_факультатива = @ElectiveId";
                    using (var checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@StudentId", currentUser.Id);
                        checkCommand.Parameters.AddWithValue("@ElectiveId", electiveId);
                        int existingApplications = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (existingApplications > 0)
                        {
                            MessageBox.Show("Вы уже подавали заявку на этот факультатив", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    string insertQuery = @"INSERT INTO Заявка (М_студента, М_факультатива, Статус) 
                                         VALUES (@StudentId, @ElectiveId, 'Ожидание')";
                    using (var command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@StudentId", currentUser.Id);
                        command.Parameters.AddWithValue("@ElectiveId", electiveId);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Заявка на факультатив '{electiveName}' подана успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMyApplications();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подачи заявки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadElectives();
            LoadMyApplications();
            LoadSchedule();
        }

        private void dgvElectives_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvElectives.SelectedRows.Count > 0)
            {
                var row = dgvElectives.SelectedRows[0];

                txtCourseName.Text = row.Cells["Название"].Value.ToString();
                txtCourseDescription.Text = row.Cells["Описание"].Value?.ToString() ?? "Описание отсутствует";
                txtCourseTeacher.Text = row.Cells["Преподаватель"].Value.ToString();
                txtMaxStudents.Text = row.Cells["Макс_количество"].Value.ToString();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtGroup.Text) ||
        string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Заполните обязательные поля (ФИО, Группа, Логин, Пароль)", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE Студент 
                           SET ФИО = @FullName, 
                               Группа = @Group, 
                               Email = @Email,
                               Телефон = @Phone,
                               Логин = @Login,
                               Пароль = @Password
                           WHERE М_студента = @StudentId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        command.Parameters.AddWithValue("@Group", txtGroup.Text);
                        command.Parameters.AddWithValue("@Email",
                            string.IsNullOrEmpty(txtEmail.Text) ? DBNull.Value : (object)txtEmail.Text);
                        command.Parameters.AddWithValue("@Phone",
                            string.IsNullOrEmpty(txtPhone.Text) ? DBNull.Value : (object)txtPhone.Text);
                        command.Parameters.AddWithValue("@Login", txtLogin.Text);
                        command.Parameters.AddWithValue("@Password", txtPassword.Text);
                        command.Parameters.AddWithValue("@StudentId", currentUser.Id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Персональные данные обновлены успешно!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Обновляем заголовок формы и приветствие
                            this.Text = $"ReHub - Студент: {txtFullName.Text}";
                            this.lblCurrentUser.Text = $"{GetTimeBasedGreeting()}, {txtFullName.Text}!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPersonalData()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT ФИО, Группа, Email, Телефон, Логин, Пароль 
                           FROM Студент 
                           WHERE М_студента = @StudentId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentId", currentUser.Id);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Автозаполнение полей при входе
                                txtFullName.Text = reader["ФИО"]?.ToString() ?? "";
                                txtGroup.Text = reader["Группа"]?.ToString() ?? "";
                                txtEmail.Text = reader["Email"]?.ToString() ?? "";
                                txtPhone.Text = reader["Телефон"]?.ToString() ?? "";
                                txtLogin.Text = reader["Логин"]?.ToString() ?? "";
                                txtPassword.Text = reader["Пароль"]?.ToString() ?? "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки персональных данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadPersonalData();
        }
    }
}