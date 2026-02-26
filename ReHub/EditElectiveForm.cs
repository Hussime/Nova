using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReHub
{
    public partial class EditElectiveForm : Form
    {
        private int electiveId;
        private DataGridViewRow selectedRow;

        public EditElectiveForm(int electiveId, DataGridViewRow row)
        {
            InitializeComponent();
            this.electiveId = electiveId;
            this.selectedRow = row;
            LoadFormData();
            LoadTeachersComboBox();
        }

        private void LoadFormData()
        {
            // Заполняем поля данными из выбранной строки
            txtElectiveName.Text = selectedRow.Cells["Название"].Value?.ToString() ?? "";
            txtElectiveDescription.Text = selectedRow.Cells["Описание"].Value?.ToString() ?? "";

            if (selectedRow.Cells["Макс_количество"].Value != null)
                numMaxStudents.Value = Convert.ToInt32(selectedRow.Cells["Макс_количество"].Value);

            // Дата и время занятия
            if (selectedRow.Cells["Дата_занятия"].Value != null && selectedRow.Cells["Дата_занятия"].Value != DBNull.Value)
                dtpLessonDate.Value = Convert.ToDateTime(selectedRow.Cells["Дата_занятия"].Value);

            txtLessonTime.Text = selectedRow.Cells["Время_занятия"].Value?.ToString() ?? "";
        }

        private void LoadTeachersComboBox()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT М_преподавателя, ФИО FROM Преподаватель";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            cmbTeachers.Items.Clear();
                            while (reader.Read())
                            {
                                cmbTeachers.Items.Add(new
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1)
                                });
                            }
                        }
                    }
                }
                cmbTeachers.DisplayMember = "Name";
                cmbTeachers.ValueMember = "Id";

                // Устанавливаем текущего преподавателя
                string currentTeacher = selectedRow.Cells["Преподаватель"].Value?.ToString() ?? "";
                foreach (var item in cmbTeachers.Items)
                {
                    dynamic teacher = item;
                    if (teacher.Name == currentTeacher)
                    {
                        cmbTeachers.SelectedItem = item;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка преподавателей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtElectiveName.Text) || cmbTeachers.SelectedItem == null)
            {
                MessageBox.Show("Заполните название факультатива и выберите преподавателя", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE Факультатив 
                                   SET Название = @Name, 
                                       Описание = @Description, 
                                       М_преподавателя = @TeacherId, 
                                       Макс_количество = @MaxStudents,
                                       Дата_занятия = @LessonDate,
                                       Время_занятия = @LessonTime
                                   WHERE М_факультатива = @ElectiveId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        dynamic selectedTeacher = cmbTeachers.SelectedItem;
                        command.Parameters.AddWithValue("@Name", txtElectiveName.Text);
                        command.Parameters.AddWithValue("@Description",
                            string.IsNullOrEmpty(txtElectiveDescription.Text) ? DBNull.Value : (object)txtElectiveDescription.Text);
                        command.Parameters.AddWithValue("@TeacherId", selectedTeacher.Id);
                        command.Parameters.AddWithValue("@MaxStudents", numMaxStudents.Value);
                        command.Parameters.AddWithValue("@LessonDate",
                            dtpLessonDate.Value == dtpLessonDate.MinDate ? DBNull.Value : (object)dtpLessonDate.Value);
                        command.Parameters.AddWithValue("@LessonTime",
                            string.IsNullOrEmpty(txtLessonTime.Text) ? DBNull.Value : (object)txtLessonTime.Text);
                        command.Parameters.AddWithValue("@ElectiveId", electiveId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Факультатив обновлен успешно!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка редактирования факультатива: {ex.Message}", "Ошибка",
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