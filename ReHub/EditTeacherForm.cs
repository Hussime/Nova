using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReHub
{
    public partial class EditTeacherForm : Form
    {
        private int teacherId;
        private DataGridViewRow selectedRow;

        public EditTeacherForm(int teacherId, DataGridViewRow row)
        {
            InitializeComponent();
            this.teacherId = teacherId;
            this.selectedRow = row;
            LoadFormData();
        }

        private void LoadFormData()
        {
            txtFullName.Text = selectedRow.Cells["ФИО"].Value?.ToString() ?? "";
            txtDepartment.Text = selectedRow.Cells["Кафедра"].Value?.ToString() ?? "";
            txtEmail.Text = selectedRow.Cells["Email"].Value?.ToString() ?? "";
            txtPhone.Text = selectedRow.Cells["Телефон"].Value?.ToString() ?? "";
            txtLogin.Text = selectedRow.Cells["Логин"].Value?.ToString() ?? "";
            txtPassword.Text = selectedRow.Cells["Пароль"].Value?.ToString() ?? "";
        }



        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Заполните обязательные поля (ФИО, Логин, Пароль)", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE Преподаватель 
                                   SET ФИО = @FullName, 
                                       Кафедра = @Department, 
                                       Email = @Email,
                                       Телефон = @Phone,
                                       Логин = @Login,
                                       Пароль = @Password
                                   WHERE М_преподавателя = @TeacherId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        command.Parameters.AddWithValue("@Department",
                            string.IsNullOrEmpty(txtDepartment.Text) ? DBNull.Value : (object)txtDepartment.Text);
                        command.Parameters.AddWithValue("@Email",
                            string.IsNullOrEmpty(txtEmail.Text) ? DBNull.Value : (object)txtEmail.Text);
                        command.Parameters.AddWithValue("@Phone",
                            string.IsNullOrEmpty(txtPhone.Text) ? DBNull.Value : (object)txtPhone.Text);
                        command.Parameters.AddWithValue("@Login", txtLogin.Text);
                        command.Parameters.AddWithValue("@Password", txtPassword.Text);
                        command.Parameters.AddWithValue("@TeacherId", teacherId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные преподавателя обновлены успешно!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка редактирования преподавателя: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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