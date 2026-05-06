using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ReHub
{
    public partial class StudentForm : Form
    {
        private User currentUser;
        private string avatarPath = "";

        public StudentForm(User user)
        {
            InitializeComponent();
            currentUser = user;

            // Привязка событий навигации
            btnNavElectives.Click += (s, e) => ShowPanel("electives");
            btnNavApplications.Click += (s, e) => ShowPanel("applications");
            btnNavSchedule.Click += (s, e) => ShowPanel("schedule");
            btnNavNotifs.Click += (s, e) => ShowPanel("notifs");
            btnNavProfile.Click += (s, e) => ShowPanel("profile");

            // 🔔 ВАЖНО: Подписка на колокольчик
            btnNotifBell.Click += (s, e) => ShowPanel("notifs");

            // События аватарки
            pnlAvatarContainer.Click += (s, e) => ShowPanel("profile");
            picAvatar.Click += (s, e) => ShowPanel("profile");
            pnlAvatarProfile.Click += (s, e) => ChangeAvatar();
            picAvatarProfile.Click += (s, e) => ChangeAvatar();

            // События кнопок
            btnApply.Click += btnApply_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnMarkAll.Click += btnMarkAll_Click;
            btnSaveProfile.Click += btnSaveProfile_Click;
            btnCancelProfile.Click += btnCancelProfile_Click;
            btnCloseForm.Click += (s, e) => Application.Exit();

            // События таблиц
            dgvElectives.SelectionChanged += dgvElectives_SelectionChanged;
            dgvSchedule.SelectionChanged += dgvSchedule_SelectionChanged;

            // Загрузка данных
            this.Text = $"Нова - Ученик: {user.FullName}";
            LoadElectives();
            LoadMyApplications();
            LoadSchedule();
            LoadPersonalData();

            // 🔔 Создаём тестовые уведомления при первом входе
            CreateTestNotifications();
            LoadNotifications();

            LoadAvatar();

            string greeting = GetTimeBasedGreeting();
            lblCurrentUser.Text = $"{greeting}, {user.FullName}!";

            ShowPanel("electives");
        }

        // ==================== НАВИГАЦИЯ ====================
        private void ShowPanel(string name)
        {
            pnlElectives.Visible = false;
            pnlApplications.Visible = false;
            pnlSchedule.Visible = false;
            pnlNotifs.Visible = false;
            pnlProfile.Visible = false;

            SetActiveNav(null);

            switch (name)
            {
                case "electives":
                    pnlElectives.Visible = true;
                    SetActiveNav(btnNavElectives);
                    break;
                case "applications":
                    pnlApplications.Visible = true;
                    SetActiveNav(btnNavApplications);
                    break;
                case "schedule":
                    pnlSchedule.Visible = true;
                    SetActiveNav(btnNavSchedule);
                    break;
                case "notifs":
                    pnlNotifs.Visible = true;
                    SetActiveNav(btnNavNotifs);
                    LoadNotifications();
                    break;
                case "profile":
                    pnlProfile.Visible = true;
                    SetActiveNav(btnNavProfile);
                    LoadPersonalData();
                    break;
            }
        }

        private void SetActiveNav(Button btn)
        {
            var buttons = new Button[] { btnNavElectives, btnNavApplications, btnNavSchedule, btnNavNotifs, btnNavProfile };
            foreach (var b in buttons)
            {
                if (b == btn)
                {
                    b.BackColor = Color.FromArgb(230, 241, 251);
                    b.ForeColor = Color.FromArgb(24, 95, 165);
                }
                else
                {
                    b.BackColor = Color.White;
                    b.ForeColor = Color.FromArgb(80, 80, 80);
                }
            }
        }

        // ==================== ЗАГРУЗКА ДАННЫХ ====================
        private void LoadElectives()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT f.М_факультатива, f.Название, f.Описание, p.ФИО as Преподаватель, f.Макс_количество 
                                   FROM Факультатив f INNER JOIN Преподаватель p ON f.М_преподавателя = p.М_преподавателя";
                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvElectives.DataSource = dt;

                        if (dgvElectives.Columns.Contains("М_факультатива")) dgvElectives.Columns["М_факультатива"].Visible = false;
                        if (dgvElectives.Columns.Contains("Название")) dgvElectives.Columns["Название"].HeaderText = "Название";
                        if (dgvElectives.Columns.Contains("Описание")) dgvElectives.Columns["Описание"].HeaderText = "Описание";
                        if (dgvElectives.Columns.Contains("Преподаватель")) dgvElectives.Columns["Преподаватель"].HeaderText = "Преподаватель";
                        if (dgvElectives.Columns.Contains("Макс_количество")) dgvElectives.Columns["Макс_количество"].Visible = false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки факультативов: {ex.Message}"); }
        }

        private void LoadMyApplications()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT z.М_заявки, f.Название as Факультатив, z.Дата_подачи, z.Статус 
                                   FROM Заявка z INNER JOIN Факультатив f ON z.М_факультатива = f.М_факультатива 
                                   WHERE z.М_студента = @StudentId";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentId", currentUser.Id);
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvMyApplications.DataSource = dt;
                            if (dgvMyApplications.Columns.Contains("М_заявки")) dgvMyApplications.Columns["М_заявки"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки заявок: {ex.Message}"); }
        }

        private void LoadSchedule()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT f.Название as Факультатив, p.ФИО as Преподаватель, f.Дата_занятия as Дата, f.Время_занятия as Время 
                                   FROM Факультатив f INNER JOIN Преподаватель p ON f.М_преподавателя = p.М_преподавателя 
                                   INNER JOIN Заявка z ON f.М_факультатива = z.М_факультатива 
                                   WHERE z.М_студента = @StudentId AND z.Статус = 'Принято' AND f.Дата_занятия IS NOT NULL";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentId", currentUser.Id);
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvSchedule.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки расписания: {ex.Message}"); }
        }

        private void LoadPersonalData()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT ФИО, Группа, Email, Телефон, Логин, Пароль FROM Студент WHERE М_студента = @StudentId", connection))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", currentUser.Id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFullName.Text = reader["ФИО"]?.ToString() ?? "";
                                txtGroup.Text = reader["Группа"]?.ToString() ?? "";
                                txtEmail.Text = reader["Email"]?.ToString() ?? "";
                                txtPhone.Text = reader["Телефон"]?.ToString() ?? "";
                                txtLogin.Text = reader["Логин"]?.ToString() ?? "";
                                txtPassword.Text = reader["Пароль"]?.ToString() ?? "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки профиля: {ex.Message}"); }
        }

        // ==================== ЛОГИКА ДЕЙСТВИЙ ====================
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (dgvElectives.SelectedRows.Count == 0) { MessageBox.Show("Выберите факультатив для подачи заявки"); return; }

            int electiveId = Convert.ToInt32(dgvElectives.SelectedRows[0].Cells["М_факультатива"].Value);
            string electiveName = dgvElectives.SelectedRows[0].Cells["Название"].Value.ToString();

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // 1. Проверка на дубликат заявки
                    using (var checkCmd = new SqlCommand("SELECT COUNT(*) FROM Заявка WHERE М_студента = @StudentId AND М_факультатива = @ElectiveId", connection))
                    {
                        checkCmd.Parameters.AddWithValue("@StudentId", currentUser.Id);
                        checkCmd.Parameters.AddWithValue("@ElectiveId", electiveId);
                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("Вы уже подавали заявку на этот факультатив");
                            return;
                        }
                    }

                    // 2. Получение ID преподавателя
                    int teacherId = 0;
                    using (var teacherCmd = new SqlCommand("SELECT М_преподавателя FROM Факультатив WHERE М_факультатива = @ElectiveId", connection))
                    {
                        teacherCmd.Parameters.AddWithValue("@ElectiveId", electiveId);
                        var result = teacherCmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            teacherId = Convert.ToInt32(result);
                        }
                    }

                    // 3. Добавление заявки
                    using (var cmd = new SqlCommand("INSERT INTO Заявка (М_студента, М_факультатива, Статус, Дата_подачи) VALUES (@StudentId, @ElectiveId, 'Ожидание', GETDATE())", connection))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", currentUser.Id);
                        cmd.Parameters.AddWithValue("@ElectiveId", electiveId);
                        cmd.ExecuteNonQuery();
                    }

                    // 4. Уведомление студенту
                    CreateNotification(currentUser.Id, $"Заявка на факультатив «{electiveName}» успешно подана и ожидает рассмотрения преподавателем.", "info");

                    // 5. 🔔 НОВОЕ: Уведомление преподавателю
                    if (teacherId > 0)
                    {
                        CreateTeacherNotification(teacherId, $"📩 Новая заявка на факультатив «{electiveName}» от ученика {currentUser.FullName}.", "warning");
                    }
                }

                MessageBox.Show("Заявка успешно подана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMyApplications();
                UpdateNotificationBadge();
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        private void CreateTeacherNotification(int teacherId, string text, string type = "info")
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Проверяем существование столбца М_преподавателя
                    var checkColumn = new SqlCommand(@"
                        IF NOT EXISTS (
                            SELECT * FROM sys.columns 
                            WHERE object_id = OBJECT_ID('Уведомление') 
                            AND name = 'М_преподавателя'
                        )
                        BEGIN
                            ALTER TABLE Уведомление ADD М_преподавателя INT NULL
                        END", conn);
                    checkColumn.ExecuteNonQuery();

                    using (var cmd = new SqlCommand(
                        "INSERT INTO Уведомление (М_преподавателя, Текст, Тип) VALUES (@TeacherId, @Text, @Type)", conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherId", teacherId);
                        cmd.Parameters.AddWithValue("@Text", text);
                        cmd.Parameters.AddWithValue("@Type", type);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }

        private void UpdateNotificationBadge()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Уведомление WHERE М_студента = @StudentId AND Прочитано = 0", conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", currentUser.Id);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        lblNotifBadge.Text = count.ToString();
                        lblNotifBadge.Visible = count > 0;

                        if (count > 0)
                            lblNotifSub.Text = $"{count} непрочитанных";
                    }
                }
            }
            catch { }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadElectives();
            LoadMyApplications();
            LoadSchedule();
        }

        private void dgvElectives_SelectionChanged(object sender, EventArgs e)
        {
            // Отображение деталей внизу при клике на строку
            if (dgvElectives.SelectedRows.Count > 0 && dgvElectives.CurrentRow != null)
            {
                var row = dgvElectives.CurrentRow;
                txtCourseName.Text = row.Cells["Название"]?.Value?.ToString() ?? "";
                txtCourseDescription.Text = row.Cells["Описание"]?.Value?.ToString() ?? "Описание отсутствует";
                txtCourseTeacher.Text = row.Cells["Преподаватель"]?.Value?.ToString() ?? "";
                txtMaxStudents.Text = row.Cells["Макс_количество"]?.Value?.ToString() ?? "";
            }
        }

        private void dgvSchedule_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count > 0 && dgvSchedule.CurrentRow != null)
            {
                var row = dgvSchedule.CurrentRow;
                txtSelectedElective.Text = row.Cells["Факультатив"]?.Value?.ToString() ?? "";
                txtSelectedTeacher.Text = row.Cells["Преподаватель"]?.Value?.ToString() ?? "";

                if (row.Cells["Дата"]?.Value != null && row.Cells["Дата"].Value != DBNull.Value)
                    dtpSelectedDate.Value = Convert.ToDateTime(row.Cells["Дата"].Value);

                txtSelectedTime.Text = row.Cells["Время"]?.Value?.ToString() ?? "";
            }
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtGroup.Text) || string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Заполните обязательные поля (ФИО, Группа, Логин, Пароль)");
                return;
            }

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(@"UPDATE Студент SET ФИО = @FullName, Группа = @Group, Email = @Email, Телефон = @Phone, Логин = @Login, Пароль = @Password WHERE М_студента = @StudentId", connection))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@Group", txtGroup.Text);
                        cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(txtEmail.Text) ? DBNull.Value : (object)txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(txtPhone.Text) ? DBNull.Value : (object)txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Login", txtLogin.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@StudentId", currentUser.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Профиль обновлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentUser.FullName = txtFullName.Text;
                string greeting = GetTimeBasedGreeting();
                lblCurrentUser.Text = $"{greeting}, {txtFullName.Text}!";
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка сохранения: {ex.Message}"); }
        }

        private void btnCancelProfile_Click(object sender, EventArgs e)
        {
            LoadPersonalData();
        }

        // ==================== УВЕДОМЛЕНИЯ ====================
        private void CreateTestNotifications()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var checkCmd = new SqlCommand("SELECT COUNT(*) FROM Уведомление WHERE М_студента = @StudentId", conn);
                    checkCmd.Parameters.AddWithValue("@StudentId", currentUser.Id);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        CreateNotification(currentUser.Id, "Добро пожаловать в систему НОВА! 🎉", "success");
                        CreateNotification(currentUser.Id, "Не забудьте подать заявку на факультативы до конца недели", "warning");
                        CreateNotification(currentUser.Id, "Проверьте своё расписание занятий", "info");
                    }
                }
            }
            catch { }
        }

        private void LoadNotifications()
        {
            pnlNotifList.Controls.Clear();
            int unread = 0;

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    var createTable = new SqlCommand(@"
                IF OBJECT_ID('Уведомление', 'U') IS NULL
                BEGIN
                    CREATE TABLE Уведомление (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        М_студента INT NOT NULL,
                        Текст NVARCHAR(500) NOT NULL,
                        Тип NVARCHAR(20) DEFAULT 'info',
                        Дата_создания DATETIME DEFAULT GETDATE(),
                        Прочитано BIT DEFAULT 0
                    )
                END", connection);
                    createTable.ExecuteNonQuery();

                    using (var cmd = new SqlCommand(@"
                SELECT Id, Текст, Тип, Дата_создания, Прочитано 
                FROM Уведомление 
                WHERE М_студента = @StudentId 
                ORDER BY Дата_создания DESC", connection))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", currentUser.Id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            int y = 0;
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string text = reader.GetString(1);
                                string type = reader["Тип"]?.ToString() ?? "info";
                                DateTime date = reader.GetDateTime(3);
                                bool isRead = reader.GetBoolean(4);

                                if (!isRead) unread++;

                                var card = BuildNotifCard(id, text, type, date, isRead);
                                card.Location = new Point(14, y);
                                card.Width = pnlNotifList.ClientSize.Width - 28;
                                pnlNotifList.Controls.Add(card);
                                y += card.Height + 8;
                            }
                        }
                    }
                }

                UpdateNotifBadge(unread);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private Panel BuildNotifCard(int id, string text, string type, DateTime date, bool isRead)
        {
            Panel card = new Panel();
            card.Height = 70;
            card.BackColor = Color.White;
            card.Padding = new Padding(12);
            card.Cursor = Cursors.Hand;
            card.Tag = id;
            card.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            if (!isRead)
            {
                card.Paint += (s, e) =>
                {
                    e.Graphics.FillRectangle(
                        new SolidBrush(Color.FromArgb(24, 95, 165)),
                        0, 0, 4, card.Height);
                };
            }

            Label icon = new Label();
            icon.AutoSize = false;
            icon.Size = new Size(32, 32);
            icon.Location = new Point(16, 19);
            icon.Font = new Font("Segoe UI", 16F);

            switch (type.ToLower())
            {
                case "success": icon.Text = "✓"; icon.ForeColor = Color.FromArgb(59, 109, 17); break;
                case "warning": icon.Text = "⚠"; icon.ForeColor = Color.FromArgb(217, 119, 6); break;
                case "error": icon.Text = "✕"; icon.ForeColor = Color.FromArgb(163, 45, 45); break;
                default: icon.Text = "ℹ"; icon.ForeColor = Color.FromArgb(24, 95, 165); break;
            }

            Label lblText = new Label();
            lblText.Text = text;
            lblText.Font = new Font("Segoe UI", 10F);
            lblText.ForeColor = isRead ? Color.FromArgb(100, 100, 100) : Color.FromArgb(30, 30, 30);
            lblText.AutoSize = false;
            lblText.MaximumSize = new Size(850, 0);
            lblText.Size = new Size(850, 40);
            lblText.Location = new Point(60, 10);
            lblText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            Label lblDate = new Label();
            lblDate.Text = date.ToString("dd.MM HH:mm");
            lblDate.Font = new Font("Segoe UI", 8F);
            lblDate.ForeColor = Color.FromArgb(150, 150, 150);
            lblDate.AutoSize = true;
            lblDate.Location = new Point(60, 38);

            card.Controls.AddRange(new Control[] { icon, lblText, lblDate });

            int capturedId = id;
            card.Click += (s, e) => MarkAsRead(capturedId, card);
            icon.Click += (s, e) => MarkAsRead(capturedId, card);
            lblText.Click += (s, e) => MarkAsRead(capturedId, card);
            lblDate.Click += (s, e) => MarkAsRead(capturedId, card);

            return card;
        }

        private void MarkAsRead(int id, Panel card)
        {
            DialogResult result = MessageBox.Show(
                "Удалить это уведомление?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "DELETE FROM Уведомление WHERE Id = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadNotifications();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateNotifBadge(int count)
        {
            lblNotifBadge.Text = count.ToString();
            lblNotifBadge.Visible = count > 0;

            if (count > 0)
                lblNotifSub.Text = $"{count} непрочитанных";
            else
                lblNotifSub.Text = "Все уведомления прочитаны";
        }

        private void btnMarkAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Отметить все уведомления как прочитанные?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "UPDATE Уведомление SET Прочитано = 1 WHERE М_студента = @StudentId AND Прочитано = 0", conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", currentUser.Id);
                        int updated = cmd.ExecuteNonQuery();
                    }
                }
                LoadNotifications();
                MessageBox.Show("Все уведомления отмечены как прочитанные", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void CreateNotification(int studentId, string text, string type = "info")
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                        "INSERT INTO Уведомление (М_студента, Текст, Тип) VALUES (@StudentId, @Text, @Type)", conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", studentId);
                        cmd.Parameters.AddWithValue("@Text", text);
                        cmd.Parameters.AddWithValue("@Type", type);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }

        // ==================== ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ ====================
        private string GetTimeBasedGreeting()
        {
            int hour = DateTime.Now.Hour;
            if (hour >= 6 && hour < 12) return "Доброе утро";
            else if (hour >= 12 && hour < 18) return "Добрый день";
            else return "Добрый вечер";
        }

        private Image GetDefaultAvatar()
        {
            var bmp = new Bitmap(100, 100);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(230, 241, 251));
                using (var brush = new SolidBrush(Color.FromArgb(24, 95, 165)))
                {
                    g.FillEllipse(brush, 25, 45, 50, 50);
                    g.FillEllipse(brush, 35, 10, 30, 30);
                }
            }
            return bmp;
        }

        private void MakePictureBoxCircular(PictureBox pb, int size)
        {
            pb.Width = size;
            pb.Height = size;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.BackColor = Color.Transparent;

            var path = new GraphicsPath();
            path.AddEllipse(0, 0, size - 1, size - 1);
            pb.Region = new Region(path);
        }

        private void LoadAvatar()
        {
            string dir = Path.Combine(Application.StartupPath, "avatars");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            avatarPath = Path.Combine(dir, $"student_{currentUser.Id}.png");

            Image avatarImg;

            if (File.Exists(avatarPath))
            {
                avatarImg = Image.FromFile(avatarPath);
            }
            else
            {
                avatarImg = GetDefaultAvatar();
            }

            MakePictureBoxCircular(picAvatar, 36);
            MakePictureBoxCircular(picAvatarProfile, 80);

            picAvatar.Image = avatarImg;
            picAvatarProfile.Image = avatarImg;
        }

        private void ChangeAvatar()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Выберите аватарку";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var img = Image.FromFile(ofd.FileName))
                        {
                            string dir = Path.Combine(Application.StartupPath, "avatars");
                            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                            string path = Path.Combine(dir, $"student_{currentUser.Id}.png");
                            img.Save(path, ImageFormat.Png);
                            LoadAvatar();
                        }
                        MessageBox.Show("Аватарка успешно обновлена!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}