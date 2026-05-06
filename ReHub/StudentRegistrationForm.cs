using System;
using System.Data.SqlClient;
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

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // Проверка уникальности логина
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

                    // Регистрация студента
                    string insertQuery = @"INSERT INTO Студент (ФИО, Группа, Email, Телефон, Логин, Пароль) 
                                         VALUES (@FullName, @Group, @Email, @Phone, @Login, @Password)";
                    using (var command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        command.Parameters.AddWithValue("@Group", txtGroup.Text);
                        command.Parameters.AddWithValue("@Email",
                            string.IsNullOrEmpty(txtEmail.Text) ? DBNull.Value : (object)txtEmail.Text);
                        command.Parameters.AddWithValue("@Phone",
                            string.IsNullOrEmpty(txtPhone.Text) ? DBNull.Value : (object)txtPhone.Text);
                        command.Parameters.AddWithValue("@Login", txtLogin.Text);
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