using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReHub
{
    public partial class StudentRegistrationForm : Form
    {
        public StudentRegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text) ||
                string.IsNullOrEmpty(txtGroup.Text) ||
                string.IsNullOrEmpty(txtLogin.Text) ||
                string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Заполните обязательные поля: ФИО, Группа, Логин, Пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка Email
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                string email = txtEmail.Text.Trim();
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Введите корректный Email адрес", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Проверка телефона
            if (!string.IsNullOrEmpty(mtxtPhone.Text))
            {
                string phone = mtxtPhone.Text.Trim();
                if (phone.Contains('_') || phone.Length < 18)
                {
                    MessageBox.Show("Введите корректный номер телефона в формате +7 (999) 000-00-00", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Студент WHERE Логин = @Login";
                    using (var checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Login", txtLogin.Text);
                        int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (existingCount > 0)
                        {
                            MessageBox.Show("Студент с таким логином уже существует", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string insertQuery = @"INSERT INTO Студент (ФИО, Группа, Email, Телефон, Логин, Пароль) 
                                         VALUES (@FullName, @Group, @Email, @Phone, @Login, @Password)";
                    using (var command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        command.Parameters.AddWithValue("@Group", txtGroup.Text.Trim());
                        command.Parameters.AddWithValue("@Email",
                            string.IsNullOrEmpty(txtEmail.Text) ? DBNull.Value : (object)txtEmail.Text.Trim());
                        command.Parameters.AddWithValue("@Phone",
                            string.IsNullOrEmpty(mtxtPhone.Text) || mtxtPhone.Text.Contains('_') ? DBNull.Value : (object)mtxtPhone.Text.Trim());
                        command.Parameters.AddWithValue("@Login", txtLogin.Text.Trim());
                        command.Parameters.AddWithValue("@Password", txtPassword.Text);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Студент {txtFullName.Text} успешно зарегистрирован!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации студента: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                return Regex.IsMatch(email.Trim(),
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}