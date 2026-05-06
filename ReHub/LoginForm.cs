using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReHub
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.txtPassword.KeyPress += new KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtLogin.KeyPress += new KeyPressEventHandler(this.txtLogin_KeyPress);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private User AuthenticateUserUniversal(string login, string password)
        {
            // Проверка на вход администратора
            User user = CheckUserInTable("Администратор", "М_администратора", "ФИО", login, password, "Администратор");
            if (user != null) return user;

            // Проверка на вход преподавателя
            user = CheckUserInTable("Преподаватель", "М_преподавателя", "ФИО", login, password, "Преподаватель");
            if (user != null) return user;

            // Проверка на вход ученика
            user = CheckUserInTable("Студент", "М_студента", "ФИО", login, password, "Студент");
            return user;
        }

        private User CheckUserInTable(string tableName, string idColumn, string nameColumn, string login, string password, string role)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = $"SELECT {idColumn}, {nameColumn}, Логин FROM {tableName} WHERE Логин = @Login AND Пароль = @Password";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(0),
                                FullName = reader.GetString(1),
                                Login = reader.GetString(2),
                                Role = role
                            };
                        }
                    }
                }
            }
            return null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                User user = AuthenticateUserUniversal(login, password);
                if (user != null)
                {
                    MessageBox.Show($"Добро пожаловать, {user.FullName}!",
                        "Успешный вход", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    switch (user.Role)
                    {
                        case "Преподаватель":
                            new TeacherForm(user).Show();
                            break;
                        case "Студент":
                            new StudentForm(user).Show();
                            break;
                        case "Администратор":
                            new AdminForm(user).Show();
                            break;
                        default:
                            MessageBox.Show("Неизвестная роль пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            // Переключаем видимость пароля
            if (txtPassword.PasswordChar == '•')
            {
                txtPassword.PasswordChar = '\0'; // Показываем пароль
                btnShowPassword.Text = "🔒"; // Меняем иконку
            }
            else
            {
                txtPassword.PasswordChar = '•'; // Скрываем пароль
                btnShowPassword.Text = "👁"; // Меняем иконку
            }
        }
    }
}