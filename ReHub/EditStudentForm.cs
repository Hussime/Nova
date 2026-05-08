using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReHub
{
    public partial class EditStudentForm : Form
    {
        private int studentId;
        private DataGridViewRow selectedRow;

        public EditStudentForm(int studentId, DataGridViewRow row)
        {
            InitializeComponent();
            this.studentId = studentId;
            this.selectedRow = row;
            LoadFormData();
        }

        private void LoadFormData()
        {
            txtFullName.Text = selectedRow.Cells["ФИО"].Value?.ToString() ?? "";
            txtGroup.Text = selectedRow.Cells["Группа"].Value?.ToString() ?? "";
            txtEmail.Text = selectedRow.Cells["Email"].Value?.ToString() ?? "";

            // Загружаем телефон в MaskedTextBox
            string phone = selectedRow.Cells["Телефон"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(phone))
            {
                mtxtPhone.Text = phone;
            }

            txtLogin.Text = selectedRow.Cells["Логин"].Value?.ToString() ?? "";
            txtPassword.Text = selectedRow.Cells["Пароль"].Value?.ToString() ?? "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text) ||
                string.IsNullOrEmpty(txtGroup.Text) ||
                string.IsNullOrEmpty(txtLogin.Text) ||
                string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Заполните обязательные поля (ФИО, Группа, Логин, Пароль)", "Ошибка",
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
                        command.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        command.Parameters.AddWithValue("@Group", txtGroup.Text.Trim());
                        command.Parameters.AddWithValue("@Email",
                            string.IsNullOrEmpty(txtEmail.Text) ? DBNull.Value : (object)txtEmail.Text.Trim());
                        command.Parameters.AddWithValue("@Phone",
                            string.IsNullOrEmpty(mtxtPhone.Text) || mtxtPhone.Text.Contains('_') ? DBNull.Value : (object)mtxtPhone.Text.Trim());
                        command.Parameters.AddWithValue("@Login", txtLogin.Text.Trim());
                        command.Parameters.AddWithValue("@Password", txtPassword.Text);
                        command.Parameters.AddWithValue("@StudentId", studentId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные ученика обновлены успешно!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка редактирования ученика: {ex.Message}", "Ошибка",
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