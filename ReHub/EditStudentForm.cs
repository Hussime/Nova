using System;
using System.Data.SqlClient;
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
            txtPhone.Text = selectedRow.Cells["Телефон"].Value?.ToString() ?? "";
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
                        command.Parameters.AddWithValue("@StudentId", studentId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные студента обновлены успешно!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка редактирования студента: {ex.Message}", "Ошибка",
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