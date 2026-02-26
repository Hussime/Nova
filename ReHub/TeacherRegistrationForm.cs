using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReHub
{
    public partial class TeacherRegistrationForm : Form
    {
        public TeacherRegistrationForm()
        {
            InitializeComponent();
        }



        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text) ||
                            string.IsNullOrEmpty(txtLogin.Text) ||
                            string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Заполните обязательные поля: ФИО, Логин, Пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Преподаватель WHERE Логин = @Login";
                    using (var checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Login", txtLogin.Text);
                        int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (existingCount > 0)
                        {
                            MessageBox.Show("Преподаватель с таким логином уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string insertQuery = @"INSERT INTO Преподаватель (ФИО, Кафедра, Email, Телефон, Логин, Пароль) 
                                         VALUES (@FullName, @Department, @Email, @Phone, @Login, @Password)";
                    using (var command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        command.Parameters.AddWithValue("@Department", string.IsNullOrEmpty(txtDepartment.Text) ? DBNull.Value : (object)txtDepartment.Text);
                        command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(txtEmail.Text) ? DBNull.Value : (object)txtEmail.Text);
                        command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(txtPhone.Text) ? DBNull.Value : (object)txtPhone.Text);
                        command.Parameters.AddWithValue("@Login", txtLogin.Text);
                        command.Parameters.AddWithValue("@Password", txtPassword.Text);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Преподаватель {txtFullName.Text} успешно зарегистрирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации преподавателя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}