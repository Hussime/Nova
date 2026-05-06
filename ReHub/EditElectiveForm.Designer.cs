namespace ReHub
{
    partial class EditElectiveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditElectiveForm));
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblElectiveName = new System.Windows.Forms.Label();
            this.txtElectiveName = new System.Windows.Forms.TextBox();
            this.lblElectiveDescription = new System.Windows.Forms.Label();
            this.txtElectiveDescription = new System.Windows.Forms.TextBox();
            this.lblMaxStudents = new System.Windows.Forms.Label();
            this.numMaxStudents = new System.Windows.Forms.NumericUpDown();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.cmbTeachers = new System.Windows.Forms.ComboBox();
            this.lblLessonDate = new System.Windows.Forms.Label();
            this.dtpLessonDate = new System.Windows.Forms.DateTimePicker();
            this.lblLessonTime = new System.Windows.Forms.Label();
            this.txtLessonTime = new System.Windows.Forms.TextBox();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlTitleBar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStudents)).BeginInit();
            this.pnlActions.SuspendLayout();
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
            this.pnlTitleBar.Size = new System.Drawing.Size(520, 48);
            this.pnlTitleBar.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.lblFormTitle.Location = new System.Drawing.Point(16, 12);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(281, 25);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Редактирование факультатива";
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
            this.btnClose.Location = new System.Drawing.Point(480, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Controls.Add(this.lblElectiveName);
            this.pnlContent.Controls.Add(this.txtElectiveName);
            this.pnlContent.Controls.Add(this.lblElectiveDescription);
            this.pnlContent.Controls.Add(this.txtElectiveDescription);
            this.pnlContent.Controls.Add(this.lblMaxStudents);
            this.pnlContent.Controls.Add(this.numMaxStudents);
            this.pnlContent.Controls.Add(this.lblTeacher);
            this.pnlContent.Controls.Add(this.cmbTeachers);
            this.pnlContent.Controls.Add(this.lblLessonDate);
            this.pnlContent.Controls.Add(this.dtpLessonDate);
            this.pnlContent.Controls.Add(this.lblLessonTime);
            this.pnlContent.Controls.Add(this.txtLessonTime);
            this.pnlContent.Controls.Add(this.pnlActions);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 48);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(24, 16, 24, 0);
            this.pnlContent.Size = new System.Drawing.Size(520, 432);
            this.pnlContent.TabIndex = 0;
            // 
            // lblElectiveName
            // 
            this.lblElectiveName.AutoSize = true;
            this.lblElectiveName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblElectiveName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblElectiveName.Location = new System.Drawing.Point(25, 8);
            this.lblElectiveName.Name = "lblElectiveName";
            this.lblElectiveName.Size = new System.Drawing.Size(64, 15);
            this.lblElectiveName.TabIndex = 0;
            this.lblElectiveName.Text = "Название*";
            // 
            // txtElectiveName
            // 
            this.txtElectiveName.BackColor = System.Drawing.Color.White;
            this.txtElectiveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtElectiveName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtElectiveName.Location = new System.Drawing.Point(25, 26);
            this.txtElectiveName.Name = "txtElectiveName";
            this.txtElectiveName.Size = new System.Drawing.Size(450, 25);
            this.txtElectiveName.TabIndex = 1;
            // 
            // lblElectiveDescription
            // 
            this.lblElectiveDescription.AutoSize = true;
            this.lblElectiveDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblElectiveDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblElectiveDescription.Location = new System.Drawing.Point(25, 64);
            this.lblElectiveDescription.Name = "lblElectiveDescription";
            this.lblElectiveDescription.Size = new System.Drawing.Size(62, 15);
            this.lblElectiveDescription.TabIndex = 2;
            this.lblElectiveDescription.Text = "Описание";
            // 
            // txtElectiveDescription
            // 
            this.txtElectiveDescription.BackColor = System.Drawing.Color.White;
            this.txtElectiveDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtElectiveDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtElectiveDescription.Location = new System.Drawing.Point(25, 82);
            this.txtElectiveDescription.Multiline = true;
            this.txtElectiveDescription.Name = "txtElectiveDescription";
            this.txtElectiveDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtElectiveDescription.Size = new System.Drawing.Size(450, 90);
            this.txtElectiveDescription.TabIndex = 3;
            // 
            // lblMaxStudents
            // 
            this.lblMaxStudents.AutoSize = true;
            this.lblMaxStudents.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaxStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblMaxStudents.Location = new System.Drawing.Point(25, 180);
            this.lblMaxStudents.Name = "lblMaxStudents";
            this.lblMaxStudents.Size = new System.Drawing.Size(99, 15);
            this.lblMaxStudents.TabIndex = 4;
            this.lblMaxStudents.Text = "Макс. учеников*";
            // 
            // numMaxStudents
            // 
            this.numMaxStudents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numMaxStudents.Location = new System.Drawing.Point(25, 198);
            this.numMaxStudents.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxStudents.Name = "numMaxStudents";
            this.numMaxStudents.Size = new System.Drawing.Size(120, 25);
            this.numMaxStudents.TabIndex = 5;
            this.numMaxStudents.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblTeacher
            // 
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTeacher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblTeacher.Location = new System.Drawing.Point(255, 180);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(96, 15);
            this.lblTeacher.TabIndex = 6;
            this.lblTeacher.Text = "Преподаватель*";
            // 
            // cmbTeachers
            // 
            this.cmbTeachers.BackColor = System.Drawing.Color.White;
            this.cmbTeachers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeachers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTeachers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTeachers.Location = new System.Drawing.Point(255, 198);
            this.cmbTeachers.Name = "cmbTeachers";
            this.cmbTeachers.Size = new System.Drawing.Size(220, 25);
            this.cmbTeachers.TabIndex = 7;
            // 
            // lblLessonDate
            // 
            this.lblLessonDate.AutoSize = true;
            this.lblLessonDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLessonDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblLessonDate.Location = new System.Drawing.Point(25, 236);
            this.lblLessonDate.Name = "lblLessonDate";
            this.lblLessonDate.Size = new System.Drawing.Size(77, 15);
            this.lblLessonDate.TabIndex = 8;
            this.lblLessonDate.Text = "Дата занятия";
            // 
            // dtpLessonDate
            // 
            this.dtpLessonDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtpLessonDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.dtpLessonDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpLessonDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLessonDate.Location = new System.Drawing.Point(25, 254);
            this.dtpLessonDate.Name = "dtpLessonDate";
            this.dtpLessonDate.Size = new System.Drawing.Size(180, 25);
            this.dtpLessonDate.TabIndex = 9;
            // 
            // lblLessonTime
            // 
            this.lblLessonTime.AutoSize = true;
            this.lblLessonTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLessonTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblLessonTime.Location = new System.Drawing.Point(255, 236);
            this.lblLessonTime.Name = "lblLessonTime";
            this.lblLessonTime.Size = new System.Drawing.Size(87, 15);
            this.lblLessonTime.TabIndex = 10;
            this.lblLessonTime.Text = "Время занятия";
            // 
            // txtLessonTime
            // 
            this.txtLessonTime.BackColor = System.Drawing.Color.White;
            this.txtLessonTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLessonTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLessonTime.Location = new System.Drawing.Point(255, 254);
            this.txtLessonTime.Name = "txtLessonTime";
            this.txtLessonTime.Size = new System.Drawing.Size(120, 25);
            this.txtLessonTime.TabIndex = 11;
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.Transparent;
            this.pnlActions.Controls.Add(this.btnSave);
            this.pnlActions.Controls.Add(this.btnCancel);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(24, 370);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlActions.Size = new System.Drawing.Size(470, 60);
            this.pnlActions.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(68)))), ((int)(((byte)(124)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(35, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(172, 57);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCancel.Location = new System.Drawing.Point(234, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(172, 57);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditElectiveForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(520, 480);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditElectiveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование факультатива";
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStudents)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // ==================== CONTROLS ====================
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblElectiveName;
        private System.Windows.Forms.TextBox txtElectiveName;
        private System.Windows.Forms.Label lblElectiveDescription;
        private System.Windows.Forms.TextBox txtElectiveDescription;
        private System.Windows.Forms.Label lblMaxStudents;
        private System.Windows.Forms.NumericUpDown numMaxStudents;
        private System.Windows.Forms.Label lblTeacher;
        private System.Windows.Forms.ComboBox cmbTeachers;
        private System.Windows.Forms.Label lblLessonDate;
        private System.Windows.Forms.DateTimePicker dtpLessonDate;
        private System.Windows.Forms.Label lblLessonTime;
        private System.Windows.Forms.TextBox txtLessonTime;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}