using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReHub
{
    public partial class TeacherRegistrationForm : Form
    {
        public TeacherRegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text) ||
                string.IsNullOrEmpty(txtLogin.Text) ||
                string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Заполните обязательные поля: ФИО, Логин, Пароль", "Ошибка",
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

                    // Проверка уникальности логина
                    string checkQuery = "SELECT COUNT(*) FROM Преподаватель WHERE Логин = @Login";
                    using (var checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Login", txtLogin.Text);
                        int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (existingCount > 0)
                        {
                            MessageBox.Show("Преподаватель с таким логином уже существует", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Регистрация преподавателя
                    string insertQuery = @"INSERT INTO Преподаватель (ФИО, Кафедра, Email, Телефон, Логин, Пароль) 
                                         VALUES (@FullName, @Department, @Email, @Phone, @Login, @Password)";
                    using (var command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        command.Parameters.AddWithValue("@Department",
                            string.IsNullOrEmpty(txtDepartment.Text) ? DBNull.Value : (object)txtDepartment.Text.Trim());
                        command.Parameters.AddWithValue("@Email",
                            string.IsNullOrEmpty(txtEmail.Text) ? DBNull.Value : (object)txtEmail.Text.Trim());
                        command.Parameters.AddWithValue("@Phone",
                            string.IsNullOrEmpty(mtxtPhone.Text) || mtxtPhone.Text.Contains('_') ? DBNull.Value : (object)mtxtPhone.Text.Trim());
                        command.Parameters.AddWithValue("@Login", txtLogin.Text.Trim());
                        command.Parameters.AddWithValue("@Password", txtPassword.Text);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Преподаватель {txtFullName.Text} успешно зарегистрирован!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации преподавателя: {ex.Message}", "Ошибка",
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