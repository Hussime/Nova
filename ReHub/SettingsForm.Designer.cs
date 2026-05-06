namespace ReHub
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnInterface = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlProfile = new System.Windows.Forms.Panel();
            this.lblCurrentAdmin = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.lblPasswordResult = new System.Windows.Forms.Label();
            this.pnlBackup = new System.Windows.Forms.Panel();
            this.lblBackupInfo = new System.Windows.Forms.Label();
            this.lblLastBackup = new System.Windows.Forms.Label();
            this.btnCreateBackup = new System.Windows.Forms.Button();
            this.lblBackupResult = new System.Windows.Forms.Label();
            this.btnOpenBackupFolder = new System.Windows.Forms.Button();
            this.pnlInterface = new System.Windows.Forms.Panel();
            this.lblTheme = new System.Windows.Forms.Label();
            this.cmbTheme = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblPreview = new System.Windows.Forms.Label();
            this.btnSaveInterface = new System.Windows.Forms.Button();
            this.lblInterfaceResult = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTitleBar.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            this.pnlBackup.SuspendLayout();
            this.pnlInterface.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.White;
            this.pnlTitleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitleBar.Controls.Add(this.lblFormTitle);
            this.pnlTitleBar.Controls.Add(this.btnClose);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlTitleBar.Size = new System.Drawing.Size(900, 48);
            this.pnlTitleBar.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.lblFormTitle.Location = new System.Drawing.Point(16, 12);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(188, 25);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Настройки системы";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnClose.Location = new System.Drawing.Point(860, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSidebar.Controls.Add(this.btnProfile);
            this.pnlSidebar.Controls.Add(this.btnBackup);
            this.pnlSidebar.Controls.Add(this.btnInterface);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 48);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.pnlSidebar.Size = new System.Drawing.Size(200, 502);
            this.pnlSidebar.TabIndex = 1;
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnProfile.Location = new System.Drawing.Point(0, 20);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(200, 44);
            this.btnProfile.TabIndex = 0;
            this.btnProfile.Text = "👤 Профиль";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.White;
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnBackup.Location = new System.Drawing.Point(0, 64);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(200, 44);
            this.btnBackup.TabIndex = 1;
            this.btnBackup.Text = "💾 Резервная копия";
            this.btnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnInterface
            // 
            this.btnInterface.BackColor = System.Drawing.Color.White;
            this.btnInterface.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInterface.FlatAppearance.BorderSize = 0;
            this.btnInterface.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInterface.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnInterface.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnInterface.Location = new System.Drawing.Point(0, 108);
            this.btnInterface.Name = "btnInterface";
            this.btnInterface.Size = new System.Drawing.Size(200, 44);
            this.btnInterface.TabIndex = 2;
            this.btnInterface.Text = "🎨 Интерфейс";
            this.btnInterface.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInterface.UseVisualStyleBackColor = false;
            this.btnInterface.Click += new System.EventHandler(this.btnInterface_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Controls.Add(this.pnlProfile);
            this.pnlContent.Controls.Add(this.pnlBackup);
            this.pnlContent.Controls.Add(this.pnlInterface);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 48);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(24, 16, 24, 0);
            this.pnlContent.Size = new System.Drawing.Size(700, 502);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlProfile
            // 
            this.pnlProfile.BackColor = System.Drawing.Color.Transparent;
            this.pnlProfile.Controls.Add(this.lblCurrentAdmin);
            this.pnlProfile.Controls.Add(this.lblNewPassword);
            this.pnlProfile.Controls.Add(this.txtNewPassword);
            this.pnlProfile.Controls.Add(this.lblConfirmPassword);
            this.pnlProfile.Controls.Add(this.txtConfirmPassword);
            this.pnlProfile.Controls.Add(this.btnChangePassword);
            this.pnlProfile.Controls.Add(this.lblPasswordResult);
            this.pnlProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProfile.Location = new System.Drawing.Point(24, 16);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Padding = new System.Windows.Forms.Padding(24);
            this.pnlProfile.Size = new System.Drawing.Size(650, 484);
            this.pnlProfile.TabIndex = 0;
            // 
            // lblCurrentAdmin
            // 
            this.lblCurrentAdmin.AutoSize = true;
            this.lblCurrentAdmin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.lblCurrentAdmin.Location = new System.Drawing.Point(0, 0);
            this.lblCurrentAdmin.Name = "lblCurrentAdmin";
            this.lblCurrentAdmin.Size = new System.Drawing.Size(242, 20);
            this.lblCurrentAdmin.TabIndex = 0;
            this.lblCurrentAdmin.Text = "Текущий администратор: [Имя]";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblNewPassword.Location = new System.Drawing.Point(0, 40);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(88, 15);
            this.lblNewPassword.TabIndex = 1;
            this.lblNewPassword.Text = "Новый пароль";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.White;
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNewPassword.Location = new System.Drawing.Point(0, 58);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '•';
            this.txtNewPassword.Size = new System.Drawing.Size(300, 25);
            this.txtNewPassword.TabIndex = 2;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblConfirmPassword.Location = new System.Drawing.Point(0, 96);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(120, 15);
            this.lblConfirmPassword.TabIndex = 3;
            this.lblConfirmPassword.Text = "Подтвердите пароль";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.White;
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(0, 114);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '•';
            this.txtConfirmPassword.Size = new System.Drawing.Size(300, 25);
            this.txtConfirmPassword.TabIndex = 4;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnChangePassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(68)))), ((int)(((byte)(124)))));
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(0, 160);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(140, 36);
            this.btnChangePassword.TabIndex = 5;
            this.btnChangePassword.Text = "Сменить пароль";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // lblPasswordResult
            // 
            this.lblPasswordResult.AutoSize = true;
            this.lblPasswordResult.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPasswordResult.Location = new System.Drawing.Point(0, 200);
            this.lblPasswordResult.Name = "lblPasswordResult";
            this.lblPasswordResult.Size = new System.Drawing.Size(0, 15);
            this.lblPasswordResult.TabIndex = 6;
            // 
            // pnlBackup
            // 
            this.pnlBackup.BackColor = System.Drawing.Color.Transparent;
            this.pnlBackup.Controls.Add(this.lblBackupInfo);
            this.pnlBackup.Controls.Add(this.lblLastBackup);
            this.pnlBackup.Controls.Add(this.btnCreateBackup);
            this.pnlBackup.Controls.Add(this.lblBackupResult);
            this.pnlBackup.Controls.Add(this.btnOpenBackupFolder);
            this.pnlBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackup.Location = new System.Drawing.Point(24, 16);
            this.pnlBackup.Name = "pnlBackup";
            this.pnlBackup.Padding = new System.Windows.Forms.Padding(24);
            this.pnlBackup.Size = new System.Drawing.Size(650, 484);
            this.pnlBackup.TabIndex = 1;
            this.pnlBackup.Visible = false;
            // 
            // lblBackupInfo
            // 
            this.lblBackupInfo.AutoSize = true;
            this.lblBackupInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBackupInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblBackupInfo.Location = new System.Drawing.Point(0, 0);
            this.lblBackupInfo.Name = "lblBackupInfo";
            this.lblBackupInfo.Size = new System.Drawing.Size(473, 19);
            this.lblBackupInfo.TabIndex = 0;
            this.lblBackupInfo.Text = "Создайте резервную копию базы данных для защиты от потери данных.";
            // 
            // lblLastBackup
            // 
            this.lblLastBackup.AutoSize = true;
            this.lblLastBackup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLastBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblLastBackup.Location = new System.Drawing.Point(0, 40);
            this.lblLastBackup.Name = "lblLastBackup";
            this.lblLastBackup.Size = new System.Drawing.Size(192, 15);
            this.lblLastBackup.TabIndex = 1;
            this.lblLastBackup.Text = "Последняя копия: не создавалась";
            // 
            // btnCreateBackup
            // 
            this.btnCreateBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(243)))), ((int)(((byte)(222)))));
            this.btnCreateBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateBackup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(221)))), ((int)(((byte)(151)))));
            this.btnCreateBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(221)))), ((int)(((byte)(151)))));
            this.btnCreateBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateBackup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCreateBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(109)))), ((int)(((byte)(17)))));
            this.btnCreateBackup.Location = new System.Drawing.Point(0, 70);
            this.btnCreateBackup.Name = "btnCreateBackup";
            this.btnCreateBackup.Size = new System.Drawing.Size(200, 42);
            this.btnCreateBackup.TabIndex = 2;
            this.btnCreateBackup.Text = "Создать резервную копию";
            this.btnCreateBackup.UseVisualStyleBackColor = false;
            this.btnCreateBackup.Click += new System.EventHandler(this.btnCreateBackup_Click);
            // 
            // lblBackupResult
            // 
            this.lblBackupResult.AutoSize = true;
            this.lblBackupResult.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBackupResult.Location = new System.Drawing.Point(0, 120);
            this.lblBackupResult.Name = "lblBackupResult";
            this.lblBackupResult.Size = new System.Drawing.Size(0, 15);
            this.lblBackupResult.TabIndex = 3;
            // 
            // btnOpenBackupFolder
            // 
            this.btnOpenBackupFolder.BackColor = System.Drawing.Color.White;
            this.btnOpenBackupFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenBackupFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnOpenBackupFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnOpenBackupFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenBackupFolder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnOpenBackupFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnOpenBackupFolder.Location = new System.Drawing.Point(0, 150);
            this.btnOpenBackupFolder.Name = "btnOpenBackupFolder";
            this.btnOpenBackupFolder.Size = new System.Drawing.Size(180, 36);
            this.btnOpenBackupFolder.TabIndex = 4;
            this.btnOpenBackupFolder.Text = "Открыть папку";
            this.btnOpenBackupFolder.UseVisualStyleBackColor = false;
            this.btnOpenBackupFolder.Click += new System.EventHandler(this.btnOpenBackupFolder_Click);
            // 
            // pnlInterface
            // 
            this.pnlInterface.BackColor = System.Drawing.Color.Transparent;
            this.pnlInterface.Controls.Add(this.lblTheme);
            this.pnlInterface.Controls.Add(this.cmbTheme);
            this.pnlInterface.Controls.Add(this.lblLanguage);
            this.pnlInterface.Controls.Add(this.cmbLanguage);
            this.pnlInterface.Controls.Add(this.lblPreview);
            this.pnlInterface.Controls.Add(this.btnSaveInterface);
            this.pnlInterface.Controls.Add(this.lblInterfaceResult);
            this.pnlInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInterface.Location = new System.Drawing.Point(24, 16);
            this.pnlInterface.Name = "pnlInterface";
            this.pnlInterface.Padding = new System.Windows.Forms.Padding(24);
            this.pnlInterface.Size = new System.Drawing.Size(650, 484);
            this.pnlInterface.TabIndex = 2;
            this.pnlInterface.Visible = false;
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblTheme.Location = new System.Drawing.Point(0, 0);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(110, 15);
            this.lblTheme.TabIndex = 0;
            this.lblTheme.Text = "Тема оформления";
            // 
            // cmbTheme
            // 
            this.cmbTheme.BackColor = System.Drawing.Color.White;
            this.cmbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTheme.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTheme.Items.AddRange(new object[] {
            "Светлая",
            "Тёмная"});
            this.cmbTheme.Location = new System.Drawing.Point(0, 18);
            this.cmbTheme.Name = "cmbTheme";
            this.cmbTheme.Size = new System.Drawing.Size(200, 25);
            this.cmbTheme.TabIndex = 1;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblLanguage.Location = new System.Drawing.Point(0, 64);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(103, 15);
            this.lblLanguage.TabIndex = 2;
            this.lblLanguage.Text = "Язык интерфейса";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.BackColor = System.Drawing.Color.White;
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLanguage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbLanguage.Items.AddRange(new object[] {
            "Русский",
            "English"});
            this.cmbLanguage.Location = new System.Drawing.Point(0, 82);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(200, 25);
            this.cmbLanguage.TabIndex = 3;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblPreview.Location = new System.Drawing.Point(0, 128);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(225, 15);
            this.lblPreview.TabIndex = 4;
            this.lblPreview.Text = "Предпросмотр: Светлая тема • Русский";
            // 
            // btnSaveInterface
            // 
            this.btnSaveInterface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnSaveInterface.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveInterface.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnSaveInterface.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(68)))), ((int)(((byte)(124)))));
            this.btnSaveInterface.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveInterface.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSaveInterface.ForeColor = System.Drawing.Color.White;
            this.btnSaveInterface.Location = new System.Drawing.Point(0, 160);
            this.btnSaveInterface.Name = "btnSaveInterface";
            this.btnSaveInterface.Size = new System.Drawing.Size(120, 36);
            this.btnSaveInterface.TabIndex = 5;
            this.btnSaveInterface.Text = "Применить";
            this.btnSaveInterface.UseVisualStyleBackColor = false;
            this.btnSaveInterface.Click += new System.EventHandler(this.btnSaveInterface_Click);
            // 
            // lblInterfaceResult
            // 
            this.lblInterfaceResult.AutoSize = true;
            this.lblInterfaceResult.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInterfaceResult.Location = new System.Drawing.Point(0, 200);
            this.lblInterfaceResult.Name = "lblInterfaceResult";
            this.lblInterfaceResult.Size = new System.Drawing.Size(0, 15);
            this.lblInterfaceResult.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlProfile.ResumeLayout(false);
            this.pnlProfile.PerformLayout();
            this.pnlBackup.ResumeLayout(false);
            this.pnlBackup.PerformLayout();
            this.pnlInterface.ResumeLayout(false);
            this.pnlInterface.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // ==================== CONTROLS ====================
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnInterface;
        private System.Windows.Forms.Panel pnlContent;

        // Профиль
        private System.Windows.Forms.Panel pnlProfile;
        private System.Windows.Forms.Label lblCurrentAdmin;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label lblPasswordResult;

        // Резервное копирование
        private System.Windows.Forms.Panel pnlBackup;
        private System.Windows.Forms.Label lblBackupInfo;
        private System.Windows.Forms.Label lblLastBackup;
        private System.Windows.Forms.Button btnCreateBackup;
        private System.Windows.Forms.Label lblBackupResult;
        private System.Windows.Forms.Button btnOpenBackupFolder;

        // Интерфейс
        private System.Windows.Forms.Panel pnlInterface;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.ComboBox cmbTheme;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Button btnSaveInterface;
        private System.Windows.Forms.Label lblInterfaceResult;

        private System.Windows.Forms.Button btnSave;
    }
}