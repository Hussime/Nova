namespace ReHub
{
    partial class AdminForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblNavMain = new System.Windows.Forms.Label();
            this.btnNavAnalytics = new System.Windows.Forms.Button();
            this.btnNavElectives = new System.Windows.Forms.Button();
            this.btnNavTeachers = new System.Windows.Forms.Button();
            this.btnNavStudents = new System.Windows.Forms.Button();
            this.lblNavSystem = new System.Windows.Forms.Label();
            this.btnNavSettings = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlElectives = new System.Windows.Forms.Panel();
            this.dgvElectives = new System.Windows.Forms.DataGridView();
            this.pnlElectiveForm = new System.Windows.Forms.Panel();
            this.lblElectiveName = new System.Windows.Forms.Label();
            this.txtElectiveName = new System.Windows.Forms.TextBox();
            this.lblElectiveTeacher = new System.Windows.Forms.Label();
            this.cmbTeachers = new System.Windows.Forms.ComboBox();
            this.lblElectiveMax = new System.Windows.Forms.Label();
            this.numMaxStudents = new System.Windows.Forms.NumericUpDown();
            this.lblElectiveDesc = new System.Windows.Forms.Label();
            this.txtElectiveDescription = new System.Windows.Forms.TextBox();
            this.pnlElectiveActions = new System.Windows.Forms.Panel();
            this.btnCreateElective = new System.Windows.Forms.Button();
            this.btnEditElective = new System.Windows.Forms.Button();
            this.btnDeleteElective = new System.Windows.Forms.Button();
            this.btnGenerateElectivesReport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlTeachers = new System.Windows.Forms.Panel();
            this.dgvTeachers = new System.Windows.Forms.DataGridView();
            this.pnlTeacherActions = new System.Windows.Forms.Panel();
            this.btnCreateTeacher = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDeleteTeacher = new System.Windows.Forms.Button();
            this.btnGenerateTeachersReport = new System.Windows.Forms.Button();
            this.pnlStudents = new System.Windows.Forms.Panel();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.pnlStudentActions = new System.Windows.Forms.Panel();
            this.btnCreateStudent = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.btnGenerateStudentsReport = new System.Windows.Forms.Button();
            this.pnlAnalytics = new System.Windows.Forms.Panel();
            this.pnlTabBar = new System.Windows.Forms.Panel();
            this.btnTabElectives = new System.Windows.Forms.Button();
            this.btnTabTeachers = new System.Windows.Forms.Button();
            this.btnTabStudents = new System.Windows.Forms.Button();
            this.chartBarRequests = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPieStatuses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvTopElectives = new System.Windows.Forms.DataGridView();
            this.pnlNotifications = new System.Windows.Forms.Panel();
            this.pnlTitleBar.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlElectives.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElectives)).BeginInit();
            this.pnlElectiveForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStudents)).BeginInit();
            this.pnlElectiveActions.SuspendLayout();
            this.pnlTeachers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).BeginInit();
            this.pnlTeacherActions.SuspendLayout();
            this.pnlStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.pnlStudentActions.SuspendLayout();
            this.pnlTabBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPieStatuses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopElectives)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.White;
            this.pnlTitleBar.Controls.Add(this.lblAppName);
            this.pnlTitleBar.Controls.Add(this.lblCurrentUser);
            this.pnlTitleBar.Controls.Add(this.btnClose);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlTitleBar.Size = new System.Drawing.Size(1500, 48);
            this.pnlTitleBar.TabIndex = 2;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.lblAppName.Location = new System.Drawing.Point(16, 12);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(65, 25);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "НОВА";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCurrentUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblCurrentUser.Location = new System.Drawing.Point(90, 14);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(206, 19);
            this.lblCurrentUser.TabIndex = 1;
            this.lblCurrentUser.Text = "Добрый день, Администратор!";
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
            this.btnClose.Location = new System.Drawing.Point(1460, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.label5_Click);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.lblNavMain);
            this.pnlSidebar.Controls.Add(this.btnNavAnalytics);
            this.pnlSidebar.Controls.Add(this.btnNavElectives);
            this.pnlSidebar.Controls.Add(this.btnNavTeachers);
            this.pnlSidebar.Controls.Add(this.btnNavStudents);
            this.pnlSidebar.Controls.Add(this.lblNavSystem);
            this.pnlSidebar.Controls.Add(this.btnNavSettings);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 48);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlSidebar.Size = new System.Drawing.Size(190, 672);
            this.pnlSidebar.TabIndex = 1;
            // 
            // lblNavMain
            // 
            this.lblNavMain.AutoSize = true;
            this.lblNavMain.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNavMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblNavMain.Location = new System.Drawing.Point(14, 10);
            this.lblNavMain.Name = "lblNavMain";
            this.lblNavMain.Size = new System.Drawing.Size(56, 13);
            this.lblNavMain.TabIndex = 0;
            this.lblNavMain.Text = "ГЛАВНОЕ";
            // 
            // btnNavAnalytics
            // 
            this.btnNavAnalytics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.btnNavAnalytics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavAnalytics.FlatAppearance.BorderSize = 0;
            this.btnNavAnalytics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAnalytics.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavAnalytics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnNavAnalytics.Location = new System.Drawing.Point(0, 28);
            this.btnNavAnalytics.Name = "btnNavAnalytics";
            this.btnNavAnalytics.Size = new System.Drawing.Size(190, 36);
            this.btnNavAnalytics.TabIndex = 1;
            this.btnNavAnalytics.Text = "  Аналитика";
            this.btnNavAnalytics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavAnalytics.UseVisualStyleBackColor = false;
            // 
            // btnNavElectives
            // 
            this.btnNavElectives.BackColor = System.Drawing.Color.White;
            this.btnNavElectives.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavElectives.FlatAppearance.BorderSize = 0;
            this.btnNavElectives.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnNavElectives.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavElectives.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavElectives.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnNavElectives.Location = new System.Drawing.Point(0, 64);
            this.btnNavElectives.Name = "btnNavElectives";
            this.btnNavElectives.Size = new System.Drawing.Size(190, 36);
            this.btnNavElectives.TabIndex = 2;
            this.btnNavElectives.Text = "  Факультативы";
            this.btnNavElectives.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavElectives.UseVisualStyleBackColor = false;
            // 
            // btnNavTeachers
            // 
            this.btnNavTeachers.BackColor = System.Drawing.Color.White;
            this.btnNavTeachers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavTeachers.FlatAppearance.BorderSize = 0;
            this.btnNavTeachers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnNavTeachers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavTeachers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavTeachers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnNavTeachers.Location = new System.Drawing.Point(0, 100);
            this.btnNavTeachers.Name = "btnNavTeachers";
            this.btnNavTeachers.Size = new System.Drawing.Size(190, 36);
            this.btnNavTeachers.TabIndex = 3;
            this.btnNavTeachers.Text = "  Преподаватели";
            this.btnNavTeachers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavTeachers.UseVisualStyleBackColor = false;
            // 
            // btnNavStudents
            // 
            this.btnNavStudents.BackColor = System.Drawing.Color.White;
            this.btnNavStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavStudents.FlatAppearance.BorderSize = 0;
            this.btnNavStudents.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnNavStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavStudents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnNavStudents.Location = new System.Drawing.Point(0, 136);
            this.btnNavStudents.Name = "btnNavStudents";
            this.btnNavStudents.Size = new System.Drawing.Size(190, 36);
            this.btnNavStudents.TabIndex = 4;
            this.btnNavStudents.Text = "  Ученики";
            this.btnNavStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavStudents.UseVisualStyleBackColor = false;
            // 
            // lblNavSystem
            // 
            this.lblNavSystem.AutoSize = true;
            this.lblNavSystem.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNavSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblNavSystem.Location = new System.Drawing.Point(14, 182);
            this.lblNavSystem.Name = "lblNavSystem";
            this.lblNavSystem.Size = new System.Drawing.Size(57, 13);
            this.lblNavSystem.TabIndex = 5;
            this.lblNavSystem.Text = "СИСТЕМА";
            // 
            // btnNavSettings
            // 
            this.btnNavSettings.BackColor = System.Drawing.Color.White;
            this.btnNavSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavSettings.FlatAppearance.BorderSize = 0;
            this.btnNavSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnNavSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSettings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnNavSettings.Location = new System.Drawing.Point(0, 198);
            this.btnNavSettings.Name = "btnNavSettings";
            this.btnNavSettings.Size = new System.Drawing.Size(190, 36);
            this.btnNavSettings.TabIndex = 6;
            this.btnNavSettings.Text = "  Настройки";
            this.btnNavSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSettings.UseVisualStyleBackColor = false;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.pnlContent.Controls.Add(this.pnlElectives);
            this.pnlContent.Controls.Add(this.pnlTeachers);
            this.pnlContent.Controls.Add(this.pnlStudents);
            this.pnlContent.Controls.Add(this.pnlAnalytics);
            this.pnlContent.Controls.Add(this.pnlTabBar);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(190, 48);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1310, 672);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlElectives
            // 
            this.pnlElectives.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.pnlElectives.Controls.Add(this.dgvElectives);
            this.pnlElectives.Controls.Add(this.pnlElectiveForm);
            this.pnlElectives.Controls.Add(this.pnlElectiveActions);
            this.pnlElectives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlElectives.Location = new System.Drawing.Point(0, 40);
            this.pnlElectives.Name = "pnlElectives";
            this.pnlElectives.Padding = new System.Windows.Forms.Padding(14);
            this.pnlElectives.Size = new System.Drawing.Size(1310, 632);
            this.pnlElectives.TabIndex = 0;
            // 
            // dgvElectives
            // 
            this.dgvElectives.AllowUserToAddRows = false;
            this.dgvElectives.AllowUserToDeleteRows = false;
            this.dgvElectives.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvElectives.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvElectives.BackgroundColor = System.Drawing.Color.White;
            this.dgvElectives.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvElectives.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvElectives.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvElectives.ColumnHeadersHeight = 34;
            this.dgvElectives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvElectives.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvElectives.EnableHeadersVisualStyles = false;
            this.dgvElectives.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvElectives.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvElectives.Location = new System.Drawing.Point(14, 14);
            this.dgvElectives.MultiSelect = false;
            this.dgvElectives.Name = "dgvElectives";
            this.dgvElectives.ReadOnly = true;
            this.dgvElectives.RowHeadersVisible = false;
            this.dgvElectives.RowTemplate.Height = 34;
            this.dgvElectives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvElectives.Size = new System.Drawing.Size(1410, 290);
            this.dgvElectives.TabIndex = 1;
            // 
            // pnlElectiveForm
            // 
            this.pnlElectiveForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlElectiveForm.BackColor = System.Drawing.Color.Transparent;
            this.pnlElectiveForm.Controls.Add(this.lblElectiveName);
            this.pnlElectiveForm.Controls.Add(this.txtElectiveName);
            this.pnlElectiveForm.Controls.Add(this.lblElectiveTeacher);
            this.pnlElectiveForm.Controls.Add(this.cmbTeachers);
            this.pnlElectiveForm.Controls.Add(this.lblElectiveMax);
            this.pnlElectiveForm.Controls.Add(this.numMaxStudents);
            this.pnlElectiveForm.Controls.Add(this.lblElectiveDesc);
            this.pnlElectiveForm.Controls.Add(this.txtElectiveDescription);
            this.pnlElectiveForm.Location = new System.Drawing.Point(14, 312);
            this.pnlElectiveForm.Name = "pnlElectiveForm";
            this.pnlElectiveForm.Size = new System.Drawing.Size(1890, 110);
            this.pnlElectiveForm.TabIndex = 2;
            // 
            // lblElectiveName
            // 
            this.lblElectiveName.AutoSize = true;
            this.lblElectiveName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblElectiveName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblElectiveName.Location = new System.Drawing.Point(0, 0);
            this.lblElectiveName.Name = "lblElectiveName";
            this.lblElectiveName.Size = new System.Drawing.Size(59, 15);
            this.lblElectiveName.TabIndex = 0;
            this.lblElectiveName.Text = "Название";
            // 
            // txtElectiveName
            // 
            this.txtElectiveName.BackColor = System.Drawing.Color.White;
            this.txtElectiveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtElectiveName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtElectiveName.Location = new System.Drawing.Point(0, 18);
            this.txtElectiveName.Name = "txtElectiveName";
            this.txtElectiveName.Size = new System.Drawing.Size(280, 25);
            this.txtElectiveName.TabIndex = 1;
            // 
            // lblElectiveTeacher
            // 
            this.lblElectiveTeacher.AutoSize = true;
            this.lblElectiveTeacher.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblElectiveTeacher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblElectiveTeacher.Location = new System.Drawing.Point(294, 0);
            this.lblElectiveTeacher.Name = "lblElectiveTeacher";
            this.lblElectiveTeacher.Size = new System.Drawing.Size(91, 15);
            this.lblElectiveTeacher.TabIndex = 2;
            this.lblElectiveTeacher.Text = "Преподаватель";
            // 
            // cmbTeachers
            // 
            this.cmbTeachers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTeachers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTeachers.Location = new System.Drawing.Point(294, 18);
            this.cmbTeachers.Name = "cmbTeachers";
            this.cmbTeachers.Size = new System.Drawing.Size(220, 25);
            this.cmbTeachers.TabIndex = 3;
            // 
            // lblElectiveMax
            // 
            this.lblElectiveMax.AutoSize = true;
            this.lblElectiveMax.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblElectiveMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblElectiveMax.Location = new System.Drawing.Point(528, 0);
            this.lblElectiveMax.Name = "lblElectiveMax";
            this.lblElectiveMax.Size = new System.Drawing.Size(94, 15);
            this.lblElectiveMax.TabIndex = 4;
            this.lblElectiveMax.Text = "Макс. учеников";
            // 
            // numMaxStudents
            // 
            this.numMaxStudents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numMaxStudents.Location = new System.Drawing.Point(528, 18);
            this.numMaxStudents.Name = "numMaxStudents";
            this.numMaxStudents.Size = new System.Drawing.Size(100, 25);
            this.numMaxStudents.TabIndex = 5;
            this.numMaxStudents.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblElectiveDesc
            // 
            this.lblElectiveDesc.AutoSize = true;
            this.lblElectiveDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblElectiveDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblElectiveDesc.Location = new System.Drawing.Point(0, 56);
            this.lblElectiveDesc.Name = "lblElectiveDesc";
            this.lblElectiveDesc.Size = new System.Drawing.Size(62, 15);
            this.lblElectiveDesc.TabIndex = 6;
            this.lblElectiveDesc.Text = "Описание";
            // 
            // txtElectiveDescription
            // 
            this.txtElectiveDescription.BackColor = System.Drawing.Color.White;
            this.txtElectiveDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtElectiveDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtElectiveDescription.Location = new System.Drawing.Point(0, 74);
            this.txtElectiveDescription.Name = "txtElectiveDescription";
            this.txtElectiveDescription.Size = new System.Drawing.Size(628, 25);
            this.txtElectiveDescription.TabIndex = 7;
            // 
            // pnlElectiveActions
            // 
            this.pnlElectiveActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlElectiveActions.BackColor = System.Drawing.Color.Transparent;
            this.pnlElectiveActions.Controls.Add(this.btnCreateElective);
            this.pnlElectiveActions.Controls.Add(this.btnEditElective);
            this.pnlElectiveActions.Controls.Add(this.btnDeleteElective);
            this.pnlElectiveActions.Controls.Add(this.btnGenerateElectivesReport);
            this.pnlElectiveActions.Controls.Add(this.btnRefresh);
            this.pnlElectiveActions.Location = new System.Drawing.Point(14, 426);
            this.pnlElectiveActions.Name = "pnlElectiveActions";
            this.pnlElectiveActions.Size = new System.Drawing.Size(1890, 44);
            this.pnlElectiveActions.TabIndex = 3;
            // 
            // btnCreateElective
            // 
            this.btnCreateElective.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnCreateElective.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateElective.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnCreateElective.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(68)))), ((int)(((byte)(124)))));
            this.btnCreateElective.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateElective.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCreateElective.ForeColor = System.Drawing.Color.White;
            this.btnCreateElective.Location = new System.Drawing.Point(0, 0);
            this.btnCreateElective.Name = "btnCreateElective";
            this.btnCreateElective.Size = new System.Drawing.Size(108, 36);
            this.btnCreateElective.TabIndex = 0;
            this.btnCreateElective.Text = "Создать";
            this.btnCreateElective.UseVisualStyleBackColor = false;
            this.btnCreateElective.Click += new System.EventHandler(this.btnCreateElective_Click_1);
            // 
            // btnEditElective
            // 
            this.btnEditElective.BackColor = System.Drawing.Color.White;
            this.btnEditElective.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditElective.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnEditElective.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnEditElective.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditElective.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEditElective.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnEditElective.Location = new System.Drawing.Point(114, 0);
            this.btnEditElective.Name = "btnEditElective";
            this.btnEditElective.Size = new System.Drawing.Size(108, 36);
            this.btnEditElective.TabIndex = 1;
            this.btnEditElective.Text = "Изменить";
            this.btnEditElective.UseVisualStyleBackColor = false;
            this.btnEditElective.Click += new System.EventHandler(this.btnEditElective_Click_1);
            // 
            // btnDeleteElective
            // 
            this.btnDeleteElective.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnDeleteElective.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteElective.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnDeleteElective.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnDeleteElective.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteElective.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDeleteElective.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnDeleteElective.Location = new System.Drawing.Point(228, 0);
            this.btnDeleteElective.Name = "btnDeleteElective";
            this.btnDeleteElective.Size = new System.Drawing.Size(108, 36);
            this.btnDeleteElective.TabIndex = 2;
            this.btnDeleteElective.Text = "Удалить";
            this.btnDeleteElective.UseVisualStyleBackColor = false;
            this.btnDeleteElective.Click += new System.EventHandler(this.btnDeleteElective_Click_1);
            // 
            // btnGenerateElectivesReport
            // 
            this.btnGenerateElectivesReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(243)))), ((int)(((byte)(222)))));
            this.btnGenerateElectivesReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateElectivesReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(221)))), ((int)(((byte)(151)))));
            this.btnGenerateElectivesReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(221)))), ((int)(((byte)(151)))));
            this.btnGenerateElectivesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateElectivesReport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGenerateElectivesReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(109)))), ((int)(((byte)(17)))));
            this.btnGenerateElectivesReport.Location = new System.Drawing.Point(342, 0);
            this.btnGenerateElectivesReport.Name = "btnGenerateElectivesReport";
            this.btnGenerateElectivesReport.Size = new System.Drawing.Size(108, 36);
            this.btnGenerateElectivesReport.TabIndex = 3;
            this.btnGenerateElectivesReport.Text = "Отчёт в Excel";
            this.btnGenerateElectivesReport.UseVisualStyleBackColor = false;
            this.btnGenerateElectivesReport.Click += new System.EventHandler(this.btnGenerateElectivesReport_Click_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnRefresh.Location = new System.Drawing.Point(480, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(108, 36);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // pnlTeachers
            // 
            this.pnlTeachers.AutoScroll = true;
            this.pnlTeachers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.pnlTeachers.Controls.Add(this.dgvTeachers);
            this.pnlTeachers.Controls.Add(this.pnlTeacherActions);
            this.pnlTeachers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeachers.Location = new System.Drawing.Point(0, 40);
            this.pnlTeachers.Name = "pnlTeachers";
            this.pnlTeachers.Padding = new System.Windows.Forms.Padding(14);
            this.pnlTeachers.Size = new System.Drawing.Size(1310, 632);
            this.pnlTeachers.TabIndex = 1;
            this.pnlTeachers.Visible = false;
            // 
            // dgvTeachers
            // 
            this.dgvTeachers.AllowUserToAddRows = false;
            this.dgvTeachers.AllowUserToDeleteRows = false;
            this.dgvTeachers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTeachers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeachers.BackgroundColor = System.Drawing.Color.White;
            this.dgvTeachers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTeachers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeachers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTeachers.ColumnHeadersHeight = 34;
            this.dgvTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTeachers.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTeachers.EnableHeadersVisualStyles = false;
            this.dgvTeachers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvTeachers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvTeachers.Location = new System.Drawing.Point(14, 14);
            this.dgvTeachers.MultiSelect = false;
            this.dgvTeachers.Name = "dgvTeachers";
            this.dgvTeachers.ReadOnly = true;
            this.dgvTeachers.RowHeadersVisible = false;
            this.dgvTeachers.RowTemplate.Height = 34;
            this.dgvTeachers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeachers.Size = new System.Drawing.Size(1410, 320);
            this.dgvTeachers.TabIndex = 0;
            // 
            // pnlTeacherActions
            // 
            this.pnlTeacherActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTeacherActions.BackColor = System.Drawing.Color.Transparent;
            this.pnlTeacherActions.Controls.Add(this.btnCreateTeacher);
            this.pnlTeacherActions.Controls.Add(this.button1);
            this.pnlTeacherActions.Controls.Add(this.btnDeleteTeacher);
            this.pnlTeacherActions.Controls.Add(this.btnGenerateTeachersReport);
            this.pnlTeacherActions.Location = new System.Drawing.Point(14, 342);
            this.pnlTeacherActions.Name = "pnlTeacherActions";
            this.pnlTeacherActions.Size = new System.Drawing.Size(1890, 44);
            this.pnlTeacherActions.TabIndex = 1;
            // 
            // btnCreateTeacher
            // 
            this.btnCreateTeacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnCreateTeacher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateTeacher.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnCreateTeacher.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(68)))), ((int)(((byte)(124)))));
            this.btnCreateTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTeacher.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCreateTeacher.ForeColor = System.Drawing.Color.White;
            this.btnCreateTeacher.Location = new System.Drawing.Point(0, 0);
            this.btnCreateTeacher.Name = "btnCreateTeacher";
            this.btnCreateTeacher.Size = new System.Drawing.Size(108, 36);
            this.btnCreateTeacher.TabIndex = 0;
            this.btnCreateTeacher.Text = "Создать";
            this.btnCreateTeacher.UseVisualStyleBackColor = false;
            this.btnCreateTeacher.Click += new System.EventHandler(this.btnCreateTeacher_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button1.Location = new System.Drawing.Point(114, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Изменить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDeleteTeacher
            // 
            this.btnDeleteTeacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnDeleteTeacher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteTeacher.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnDeleteTeacher.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnDeleteTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTeacher.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDeleteTeacher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnDeleteTeacher.Location = new System.Drawing.Point(228, 0);
            this.btnDeleteTeacher.Name = "btnDeleteTeacher";
            this.btnDeleteTeacher.Size = new System.Drawing.Size(108, 36);
            this.btnDeleteTeacher.TabIndex = 2;
            this.btnDeleteTeacher.Text = "Удалить";
            this.btnDeleteTeacher.UseVisualStyleBackColor = false;
            this.btnDeleteTeacher.Click += new System.EventHandler(this.btnDeleteTeacher_Click_1);
            // 
            // btnGenerateTeachersReport
            // 
            this.btnGenerateTeachersReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(243)))), ((int)(((byte)(222)))));
            this.btnGenerateTeachersReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateTeachersReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(221)))), ((int)(((byte)(151)))));
            this.btnGenerateTeachersReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(221)))), ((int)(((byte)(151)))));
            this.btnGenerateTeachersReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateTeachersReport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGenerateTeachersReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(109)))), ((int)(((byte)(17)))));
            this.btnGenerateTeachersReport.Location = new System.Drawing.Point(342, 0);
            this.btnGenerateTeachersReport.Name = "btnGenerateTeachersReport";
            this.btnGenerateTeachersReport.Size = new System.Drawing.Size(108, 36);
            this.btnGenerateTeachersReport.TabIndex = 3;
            this.btnGenerateTeachersReport.Text = "Отчёт в Excel";
            this.btnGenerateTeachersReport.UseVisualStyleBackColor = false;
            this.btnGenerateTeachersReport.Click += new System.EventHandler(this.btnGenerateTeachersReport_Click_1);
            // 
            // pnlStudents
            // 
            this.pnlStudents.AutoScroll = true;
            this.pnlStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.pnlStudents.Controls.Add(this.dgvStudents);
            this.pnlStudents.Controls.Add(this.pnlStudentActions);
            this.pnlStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStudents.Location = new System.Drawing.Point(0, 40);
            this.pnlStudents.Name = "pnlStudents";
            this.pnlStudents.Padding = new System.Windows.Forms.Padding(14);
            this.pnlStudents.Size = new System.Drawing.Size(1310, 632);
            this.pnlStudents.TabIndex = 2;
            this.pnlStudents.Visible = false;
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStudents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStudents.ColumnHeadersHeight = 34;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStudents.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvStudents.EnableHeadersVisualStyles = false;
            this.dgvStudents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvStudents.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvStudents.Location = new System.Drawing.Point(14, 14);
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.RowTemplate.Height = 34;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(1410, 320);
            this.dgvStudents.TabIndex = 0;
            // 
            // pnlStudentActions
            // 
            this.pnlStudentActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStudentActions.BackColor = System.Drawing.Color.Transparent;
            this.pnlStudentActions.Controls.Add(this.btnCreateStudent);
            this.pnlStudentActions.Controls.Add(this.button2);
            this.pnlStudentActions.Controls.Add(this.btnDeleteStudent);
            this.pnlStudentActions.Controls.Add(this.btnGenerateStudentsReport);
            this.pnlStudentActions.Location = new System.Drawing.Point(14, 342);
            this.pnlStudentActions.Name = "pnlStudentActions";
            this.pnlStudentActions.Size = new System.Drawing.Size(1890, 44);
            this.pnlStudentActions.TabIndex = 1;
            // 
            // btnCreateStudent
            // 
            this.btnCreateStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnCreateStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateStudent.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnCreateStudent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(68)))), ((int)(((byte)(124)))));
            this.btnCreateStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateStudent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCreateStudent.ForeColor = System.Drawing.Color.White;
            this.btnCreateStudent.Location = new System.Drawing.Point(0, 0);
            this.btnCreateStudent.Name = "btnCreateStudent";
            this.btnCreateStudent.Size = new System.Drawing.Size(108, 36);
            this.btnCreateStudent.TabIndex = 0;
            this.btnCreateStudent.Text = "Создать";
            this.btnCreateStudent.UseVisualStyleBackColor = false;
            this.btnCreateStudent.Click += new System.EventHandler(this.btnCreateStudent_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button2.Location = new System.Drawing.Point(114, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "Изменить";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnDeleteStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteStudent.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnDeleteStudent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnDeleteStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteStudent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDeleteStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnDeleteStudent.Location = new System.Drawing.Point(228, 0);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(108, 36);
            this.btnDeleteStudent.TabIndex = 2;
            this.btnDeleteStudent.Text = "Удалить";
            this.btnDeleteStudent.UseVisualStyleBackColor = false;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click_1);
            // 
            // btnGenerateStudentsReport
            // 
            this.btnGenerateStudentsReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(243)))), ((int)(((byte)(222)))));
            this.btnGenerateStudentsReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateStudentsReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(221)))), ((int)(((byte)(151)))));
            this.btnGenerateStudentsReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(221)))), ((int)(((byte)(151)))));
            this.btnGenerateStudentsReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateStudentsReport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGenerateStudentsReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(109)))), ((int)(((byte)(17)))));
            this.btnGenerateStudentsReport.Location = new System.Drawing.Point(342, 0);
            this.btnGenerateStudentsReport.Name = "btnGenerateStudentsReport";
            this.btnGenerateStudentsReport.Size = new System.Drawing.Size(108, 36);
            this.btnGenerateStudentsReport.TabIndex = 3;
            this.btnGenerateStudentsReport.Text = "Отчёт в Excel";
            this.btnGenerateStudentsReport.UseVisualStyleBackColor = false;
            this.btnGenerateStudentsReport.Click += new System.EventHandler(this.btnGenerateStudentsReport_Click_1);
            // 
            // pnlAnalytics
            // 
            this.pnlAnalytics.AutoScroll = true;
            this.pnlAnalytics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.pnlAnalytics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAnalytics.Location = new System.Drawing.Point(0, 40);
            this.pnlAnalytics.Name = "pnlAnalytics";
            this.pnlAnalytics.Size = new System.Drawing.Size(1310, 632);
            this.pnlAnalytics.TabIndex = 3;
            this.pnlAnalytics.Visible = false;
            // 
            // pnlTabBar
            // 
            this.pnlTabBar.BackColor = System.Drawing.Color.White;
            this.pnlTabBar.Controls.Add(this.btnTabElectives);
            this.pnlTabBar.Controls.Add(this.btnTabTeachers);
            this.pnlTabBar.Controls.Add(this.btnTabStudents);
            this.pnlTabBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTabBar.Name = "pnlTabBar";
            this.pnlTabBar.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.pnlTabBar.Size = new System.Drawing.Size(1310, 40);
            this.pnlTabBar.TabIndex = 4;
            // 
            // btnTabElectives
            // 
            this.btnTabElectives.BackColor = System.Drawing.Color.White;
            this.btnTabElectives.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabElectives.FlatAppearance.BorderSize = 0;
            this.btnTabElectives.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabElectives.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTabElectives.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnTabElectives.Location = new System.Drawing.Point(12, 0);
            this.btnTabElectives.Name = "btnTabElectives";
            this.btnTabElectives.Size = new System.Drawing.Size(140, 40);
            this.btnTabElectives.TabIndex = 0;
            this.btnTabElectives.Text = "Факультативы";
            this.btnTabElectives.UseVisualStyleBackColor = false;
            // 
            // btnTabTeachers
            // 
            this.btnTabTeachers.BackColor = System.Drawing.Color.White;
            this.btnTabTeachers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabTeachers.FlatAppearance.BorderSize = 0;
            this.btnTabTeachers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabTeachers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTabTeachers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnTabTeachers.Location = new System.Drawing.Point(154, 0);
            this.btnTabTeachers.Name = "btnTabTeachers";
            this.btnTabTeachers.Size = new System.Drawing.Size(140, 40);
            this.btnTabTeachers.TabIndex = 1;
            this.btnTabTeachers.Text = "Преподаватели";
            this.btnTabTeachers.UseVisualStyleBackColor = false;
            // 
            // btnTabStudents
            // 
            this.btnTabStudents.BackColor = System.Drawing.Color.White;
            this.btnTabStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabStudents.FlatAppearance.BorderSize = 0;
            this.btnTabStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabStudents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTabStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnTabStudents.Location = new System.Drawing.Point(296, 0);
            this.btnTabStudents.Name = "btnTabStudents";
            this.btnTabStudents.Size = new System.Drawing.Size(140, 40);
            this.btnTabStudents.TabIndex = 2;
            this.btnTabStudents.Text = "Ученики";
            this.btnTabStudents.UseVisualStyleBackColor = false;
            // 
            // chartBarRequests
            // 
            this.chartBarRequests.Location = new System.Drawing.Point(0, 0);
            this.chartBarRequests.Name = "chartBarRequests";
            this.chartBarRequests.Size = new System.Drawing.Size(300, 300);
            this.chartBarRequests.TabIndex = 0;
            // 
            // chartPieStatuses
            // 
            this.chartPieStatuses.Location = new System.Drawing.Point(0, 0);
            this.chartPieStatuses.Name = "chartPieStatuses";
            this.chartPieStatuses.Size = new System.Drawing.Size(300, 300);
            this.chartPieStatuses.TabIndex = 0;
            // 
            // dgvTopElectives
            // 
            this.dgvTopElectives.Location = new System.Drawing.Point(0, 0);
            this.dgvTopElectives.Name = "dgvTopElectives";
            this.dgvTopElectives.Size = new System.Drawing.Size(240, 150);
            this.dgvTopElectives.TabIndex = 0;
            // 
            // pnlNotifications
            // 
            this.pnlNotifications.Location = new System.Drawing.Point(0, 0);
            this.pnlNotifications.Name = "pnlNotifications";
            this.pnlNotifications.Size = new System.Drawing.Size(200, 100);
            this.pnlNotifications.TabIndex = 0;
            // 
            // AdminForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1500, 720);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlElectives.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvElectives)).EndInit();
            this.pnlElectiveForm.ResumeLayout(false);
            this.pnlElectiveForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStudents)).EndInit();
            this.pnlElectiveActions.ResumeLayout(false);
            this.pnlTeachers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).EndInit();
            this.pnlTeacherActions.ResumeLayout(false);
            this.pnlStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.pnlStudentActions.ResumeLayout(false);
            this.pnlTabBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBarRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPieStatuses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopElectives)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // ==================== CONTROLS ====================
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnNavAnalytics;
        private System.Windows.Forms.Button btnNavElectives;
        private System.Windows.Forms.Button btnNavTeachers;
        private System.Windows.Forms.Button btnNavStudents;
        private System.Windows.Forms.Button btnNavSettings;
        private System.Windows.Forms.Label lblNavMain;
        private System.Windows.Forms.Label lblNavSystem;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlTabBar;
        private System.Windows.Forms.Button btnTabElectives;
        private System.Windows.Forms.Button btnTabTeachers;
        private System.Windows.Forms.Button btnTabStudents;
        private System.Windows.Forms.Panel pnlElectives;
        private System.Windows.Forms.DataGridView dgvElectives;
        private System.Windows.Forms.Panel pnlElectiveForm;
        private System.Windows.Forms.Label lblElectiveName;
        private System.Windows.Forms.TextBox txtElectiveName;
        private System.Windows.Forms.Label lblElectiveTeacher;
        private System.Windows.Forms.ComboBox cmbTeachers;
        private System.Windows.Forms.Label lblElectiveMax;
        private System.Windows.Forms.NumericUpDown numMaxStudents;
        private System.Windows.Forms.Label lblElectiveDesc;
        private System.Windows.Forms.TextBox txtElectiveDescription;
        private System.Windows.Forms.Panel pnlElectiveActions;
        private System.Windows.Forms.Button btnCreateElective;
        private System.Windows.Forms.Button btnEditElective;
        private System.Windows.Forms.Button btnDeleteElective;
        private System.Windows.Forms.Button btnGenerateElectivesReport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlTeachers;
        private System.Windows.Forms.DataGridView dgvTeachers;
        private System.Windows.Forms.Panel pnlTeacherActions;
        private System.Windows.Forms.Button btnCreateTeacher;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDeleteTeacher;
        private System.Windows.Forms.Button btnGenerateTeachersReport;
        private System.Windows.Forms.Panel pnlStudents;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Panel pnlStudentActions;
        private System.Windows.Forms.Button btnCreateStudent;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.Button btnGenerateStudentsReport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlAnalytics;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBarRequests;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPieStatuses;
        private System.Windows.Forms.DataGridView dgvTopElectives;
        private System.Windows.Forms.Panel pnlNotifications;
    }
}