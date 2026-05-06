using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ReHub
{
    public partial class SettingsForm : Form
    {
        private User currentUser;

        public SettingsForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadAdminInfo();
            LoadLastBackupInfo();
            LoadInterfaceSettings();

            
        }


        // === ЗАГРУЗКА ДАННЫХ ===
        private void LoadAdminInfo()
        {
            lblCurrentAdmin.Text = $"Текущий администратор: {currentUser.FullName}";
        }

        
        private void LoadInterfaceSettings()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Тема, Язык FROM Настройки_Системы WHERE М_настройки = 1";
                    using (var cmd = new SqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string theme = reader["Тема"].ToString();
                            string language = reader["Язык"].ToString();

                            cmbTheme.SelectedIndex = (theme == "Тёмная") ? 1 : 0;
                            cmbLanguage.SelectedIndex = (language == "English") ? 1 : 0;
                        }
                    }
                }
            }
            catch { }
        }

        // === ПЕРЕКЛЮЧЕНИЕ ВКЛАДОК ===
        private void ShowPanel(string panelName)
        {
            pnlProfile.Visible = (panelName == "profile");
            pnlBackup.Visible = (panelName == "backup");
            pnlInterface.Visible = (panelName == "interface");

            btnProfile.BackColor = (panelName == "profile")
                ? Color.FromArgb(230, 241, 251) : Color.White;
            btnProfile.ForeColor = (panelName == "profile")
                ? Color.FromArgb(24, 95, 165) : Color.FromArgb(80, 80, 80);

            btnBackup.BackColor = (panelName == "backup")
                ? Color.FromArgb(230, 241, 251) : Color.White;
            btnBackup.ForeColor = (panelName == "backup")
                ? Color.FromArgb(24, 95, 165) : Color.FromArgb(80, 80, 80);

            btnInterface.BackColor = (panelName == "interface")
                ? Color.FromArgb(230, 241, 251) : Color.White;
            btnInterface.ForeColor = (panelName == "interface")
                ? Color.FromArgb(24, 95, 165) : Color.FromArgb(80, 80, 80);
        }

        private void btnProfile_Click(object sender, EventArgs e) => ShowPanel("profile");
        private void btnBackup_Click(object sender, EventArgs e) => ShowPanel("backup");
        private void btnInterface_Click(object sender, EventArgs e) => ShowPanel("interface");

        // === ПРОФИЛЬ: СМЕНА ПАРОЛЯ ===
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                lblPasswordResult.Text = "⚠️ Заполните оба поля";
                lblPasswordResult.ForeColor = Color.Orange;
                return;
            }

            if (newPassword.Length < 6)
            {
                lblPasswordResult.Text = "⚠️ Пароль должен содержать минимум 6 символов";
                lblPasswordResult.ForeColor = Color.Orange;
                return;
            }

            if (newPassword != confirmPassword)
            {
                lblPasswordResult.Text = "⚠️ Пароли не совпадают";
                lblPasswordResult.ForeColor = Color.Orange;
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Администратор SET Пароль = @Password WHERE М_администратора = @AdminId";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Password", newPassword); // В продакшене — хешировать!
                        cmd.Parameters.AddWithValue("@AdminId", currentUser.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                lblPasswordResult.Text = "✅ Пароль успешно изменён!";
                lblPasswordResult.ForeColor = Color.Green;
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
            catch (Exception ex)
            {
                lblPasswordResult.Text = $"❌ Ошибка: {ex.Message}";
                lblPasswordResult.ForeColor = Color.Red;
            }
        }

        // === РЕЗЕРВНОЕ КОПИРОВАНИЕ ===
        private void btnCreateBackup_Click(object sender, EventArgs e)
        {
            try
            {
                // Путь для сохранения - Документы пользователя
                string backupPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "ReHub_Backups"
                );

                // Создаем папку если нет
                if (!Directory.Exists(backupPath))
                {
                    Directory.CreateDirectory(backupPath);
                }

                string backupFile = Path.Combine(backupPath,
                    $"ReHub_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Создаем текстовый файл
                    using (var writer = new StreamWriter(backupFile, false, Encoding.UTF8))
                    {
                        writer.WriteLine("========================================");
                        writer.WriteLine("РЕЗЕРВНАЯ КОПИЯ БАЗЫ ДАННЫХ ReHub");
                        writer.WriteLine($"Дата создания: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                        writer.WriteLine("========================================\n");

                        // 1. Экспорт таблицы "Факультатив"
                        writer.WriteLine("----------------------------------------");
                        writer.WriteLine("ТАБЛИЦА: Факультатив");
                        writer.WriteLine("----------------------------------------");

                        string queryElectives = "SELECT * FROM Факультатив";
                        using (var cmd = new SqlCommand(queryElectives, conn))
                        using (var reader = cmd.ExecuteReader())
                        {
                            // Пишем заголовки столбцов
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                writer.Write(reader.GetName(i).PadRight(25));
                            }
                            writer.WriteLine();
                            writer.WriteLine(new string('-', 150));

                            // Пишем данные
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string value = reader.IsDBNull(i) ? "NULL" : reader[i].ToString();
                                    writer.Write(value.PadRight(25));
                                }
                                writer.WriteLine();
                            }
                        }
                        writer.WriteLine();

                        // 2. Экспорт таблицы "Студент"
                        writer.WriteLine("----------------------------------------");
                        writer.WriteLine("ТАБЛИЦА: Студент");
                        writer.WriteLine("----------------------------------------");

                        string queryStudents = "SELECT * FROM Студент";
                        using (var cmd = new SqlCommand(queryStudents, conn))
                        using (var reader = cmd.ExecuteReader())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                writer.Write(reader.GetName(i).PadRight(25));
                            }
                            writer.WriteLine();
                            writer.WriteLine(new string('-', 150));

                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string value = reader.IsDBNull(i) ? "NULL" : reader[i].ToString();
                                    writer.Write(value.PadRight(25));
                                }
                                writer.WriteLine();
                            }
                        }
                        writer.WriteLine();

                        // 3. Экспорт таблицы "Преподаватель"
                        writer.WriteLine("----------------------------------------");
                        writer.WriteLine("ТАБЛИЦА: Преподаватель");
                        writer.WriteLine("----------------------------------------");

                        string queryTeachers = "SELECT * FROM Преподаватель";
                        using (var cmd = new SqlCommand(queryTeachers, conn))
                        using (var reader = cmd.ExecuteReader())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                writer.Write(reader.GetName(i).PadRight(25));
                            }
                            writer.WriteLine();
                            writer.WriteLine(new string('-', 150));

                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string value = reader.IsDBNull(i) ? "NULL" : reader[i].ToString();
                                    writer.Write(value.PadRight(25));
                                }
                                writer.WriteLine();
                            }
                        }
                        writer.WriteLine();

                        // 4. Экспорт таблицы "Заявка"
                        writer.WriteLine("----------------------------------------");
                        writer.WriteLine("ТАБЛИЦА: Заявка");
                        writer.WriteLine("----------------------------------------");

                        string queryApplications = "SELECT * FROM Заявка";
                        using (var cmd = new SqlCommand(queryApplications, conn))
                        using (var reader = cmd.ExecuteReader())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                writer.Write(reader.GetName(i).PadRight(25));
                            }
                            writer.WriteLine();
                            writer.WriteLine(new string('-', 150));

                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string value = reader.IsDBNull(i) ? "NULL" : reader[i].ToString();
                                    writer.Write(value.PadRight(25));
                                }
                                writer.WriteLine();
                            }
                        }
                        writer.WriteLine();

                        // 5. Экспорт таблицы "Администратор"
                        writer.WriteLine("----------------------------------------");
                        writer.WriteLine("ТАБЛИЦА: Администратор");
                        writer.WriteLine("----------------------------------------");

                        string queryAdmins = "SELECT * FROM Администратор";
                        using (var cmd = new SqlCommand(queryAdmins, conn))
                        using (var reader = cmd.ExecuteReader())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                writer.Write(reader.GetName(i).PadRight(25));
                            }
                            writer.WriteLine();
                            writer.WriteLine(new string('-', 150));

                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string value = reader.IsDBNull(i) ? "NULL" : reader[i].ToString();
                                    writer.Write(value.PadRight(25));
                                }
                                writer.WriteLine();
                            }
                        }
                        writer.WriteLine();

                        writer.WriteLine("========================================");
                        writer.WriteLine("КОНЕЦ РЕЗЕРВНОЙ КОПИИ");
                        writer.WriteLine("========================================");
                    }
                }

                lblBackupResult.Text = "✅ Резервная копия успешно создана!";
                lblBackupResult.ForeColor = Color.Green;
                lblBackupResult.Text += $"\nПуть: {backupFile}";

                // Сохраняем информацию о бэкапе
                SaveBackupInfo();
            }
            catch (Exception ex)
            {
                lblBackupResult.Text = $"❌ Ошибка: {ex.Message}";
                lblBackupResult.ForeColor = Color.Red;
            }
        }

        private void SaveBackupInfo()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Проверяем существование таблицы и столбца
                    string checkTable = @"
                IF OBJECT_ID('Настройки_Системы', 'U') IS NOT NULL
                BEGIN
                    IF COL_LENGTH('Настройки_Системы', 'Дата_последнего_бэкапа') IS NOT NULL
                    BEGIN
                        UPDATE Настройки_Системы 
                        SET Дата_последнего_бэкапа = @Date,
                            Дата_обновления = GETDATE()
                        WHERE М_настройки = 1
                    END
                END";

                    using (var cmd = new SqlCommand(checkTable, conn))
                    {
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { /* Игнорируем ошибки */ }
        }

        private void btnOpenBackupFolder_Click(object sender, EventArgs e)
        {
            string backupPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ReHub_Backups"
            );

            if (Directory.Exists(backupPath))
                System.Diagnostics.Process.Start(backupPath);
            else
                MessageBox.Show("Папка с резервными копиями не найдена", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadLastBackupInfo()
        {
            try
            {
                string backupPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "ReHub_Backups"
                );

                if (Directory.Exists(backupPath))
                {
                    var backupFiles = Directory.GetFiles(backupPath, "ReHub_Backup_*.txt")
                        .OrderByDescending(f => File.GetCreationTime(f))
                        .FirstOrDefault();

                    if (backupFiles != null)
                    {
                        DateTime lastBackup = File.GetCreationTime(backupFiles);
                        lblLastBackup.Text = $"Последняя копия: {lastBackup:dd.MM.yyyy HH:mm}";
                        return;
                    }
                }

                lblLastBackup.Text = "Последняя копия: не создавалась";
            }
            catch
            {
                lblLastBackup.Text = "Последняя копия: не создавалась";
            }
        }

        // === НАСТРОЙКИ ИНТЕРФЕЙСА ===
        private void btnSaveInterface_Click(object sender, EventArgs e)
        {
            try
            {
                string theme = cmbTheme.SelectedIndex == 0 ? "Светлая" : "Тёмная";
                string language = cmbLanguage.SelectedIndex == 0 ? "Русский" : "English";

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE Настройки_Системы 
                        SET Тема = @Theme, Язык = @Language, Дата_обновления = @Date 
                        WHERE М_настройки = 1";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Theme", theme);
                        cmd.Parameters.AddWithValue("@Language", language);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }

                lblInterfaceResult.Text = "✅ Настройки применены!";
                lblInterfaceResult.ForeColor = Color.Green;
                lblPreview.Text = $"Предпросмотр: {theme} тема • {language}";

                // Применяем тему сразу (опционально)
                ApplyTheme(theme);
            }
            catch (Exception ex)
            {
                lblInterfaceResult.Text = $"❌ Ошибка: {ex.Message}";
                lblInterfaceResult.ForeColor = Color.Red;
            }
        }

        private void ApplyTheme(string theme)
        {
            if (theme == "Тёмная")
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                pnlSidebar.BackColor = Color.FromArgb(40, 40, 40);
                pnlTitleBar.BackColor = Color.FromArgb(50, 50, 50);
                lblFormTitle.ForeColor = Color.White;
                // ... применить ко всем контролам
            }
            else
            {
                this.BackColor = Color.FromArgb(245, 244, 240);
                pnlSidebar.BackColor = Color.White;
                pnlTitleBar.BackColor = Color.White;
                lblFormTitle.ForeColor = Color.FromArgb(24, 95, 165);
                // ... вернуть светлую тему
            }
        }


        // === ПРОЧЕЕ ===
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}