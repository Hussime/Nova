namespace ReHub
{
    partial class StudentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.я = new System.Windows.Forms.TabPage();
            this.txtCourseDescription = new System.Windows.Forms.TextBox();
            this.txtMaxStudents = new System.Windows.Forms.TextBox();
            this.txtCourseTeacher = new System.Windows.Forms.TextBox();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.dgvElectives = new System.Windows.Forms.DataGridView();
            this.tabApplications = new System.Windows.Forms.TabPage();
            this.dgvMyApplications = new System.Windows.Forms.DataGridView();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSelectedElective = new System.Windows.Forms.TextBox();
            this.txtSelectedTeacher = new System.Windows.Forms.TextBox();
            this.txtSelectedTime = new System.Windows.Forms.TextBox();
            this.dtpSelectedDate = new System.Windows.Forms.DateTimePicker();
            this.tabControl.SuspendLayout();
            this.я.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElectives)).BeginInit();
            this.tabApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyApplications)).BeginInit();
            this.tabSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.я);
            this.tabControl.Controls.Add(this.tabApplications);
            this.tabControl.Controls.Add(this.tabSchedule);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(12, 46);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 618);
            this.tabControl.TabIndex = 0;
            // 
            // я
            // 
            this.я.Controls.Add(this.txtCourseDescription);
            this.я.Controls.Add(this.txtMaxStudents);
            this.я.Controls.Add(this.txtCourseTeacher);
            this.я.Controls.Add(this.txtCourseName);
            this.я.Controls.Add(this.label6);
            this.я.Controls.Add(this.label5);
            this.я.Controls.Add(this.label4);
            this.я.Controls.Add(this.label3);
            this.я.Controls.Add(this.label2);
            this.я.Controls.Add(this.btnRefresh);
            this.я.Controls.Add(this.btnApply);
            this.я.Controls.Add(this.dgvElectives);
            this.я.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.я.Location = new System.Drawing.Point(4, 22);
            this.я.Name = "я";
            this.я.Padding = new System.Windows.Forms.Padding(3);
            this.я.Size = new System.Drawing.Size(768, 592);
            this.я.TabIndex = 0;
            this.я.Text = "Доступные факультативы";
            this.я.UseVisualStyleBackColor = true;
            // 
            // txtCourseDescription
            // 
            this.txtCourseDescription.Location = new System.Drawing.Point(87, 397);
            this.txtCourseDescription.Multiline = true;
            this.txtCourseDescription.Name = "txtCourseDescription";
            this.txtCourseDescription.ReadOnly = true;
            this.txtCourseDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCourseDescription.Size = new System.Drawing.Size(657, 125);
            this.txtCourseDescription.TabIndex = 17;
            // 
            // txtMaxStudents
            // 
            this.txtMaxStudents.Location = new System.Drawing.Point(133, 528);
            this.txtMaxStudents.Name = "txtMaxStudents";
            this.txtMaxStudents.ReadOnly = true;
            this.txtMaxStudents.Size = new System.Drawing.Size(163, 22);
            this.txtMaxStudents.TabIndex = 16;
            // 
            // txtCourseTeacher
            // 
            this.txtCourseTeacher.Location = new System.Drawing.Point(441, 362);
            this.txtCourseTeacher.Name = "txtCourseTeacher";
            this.txtCourseTeacher.ReadOnly = true;
            this.txtCourseTeacher.Size = new System.Drawing.Size(303, 22);
            this.txtCourseTeacher.TabIndex = 15;
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(87, 342);
            this.txtCourseName.Multiline = true;
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.ReadOnly = true;
            this.txtCourseName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCourseName.Size = new System.Drawing.Size(261, 49);
            this.txtCourseName.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(370, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Учитель:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 531);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Макс. студентов:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 397);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Описание:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Название:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Детали факультатива:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(131, 256);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(109, 42);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(12, 256);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(113, 42);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Подать заявку";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // dgvElectives
            // 
            this.dgvElectives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElectives.Location = new System.Drawing.Point(6, 6);
            this.dgvElectives.Name = "dgvElectives";
            this.dgvElectives.Size = new System.Drawing.Size(756, 244);
            this.dgvElectives.TabIndex = 0;
            // 
            // tabApplications
            // 
            this.tabApplications.Controls.Add(this.dgvMyApplications);
            this.tabApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabApplications.Location = new System.Drawing.Point(4, 22);
            this.tabApplications.Name = "tabApplications";
            this.tabApplications.Padding = new System.Windows.Forms.Padding(3);
            this.tabApplications.Size = new System.Drawing.Size(768, 592);
            this.tabApplications.TabIndex = 1;
            this.tabApplications.Text = "Мои заявки";
            this.tabApplications.UseVisualStyleBackColor = true;
            // 
            // dgvMyApplications
            // 
            this.dgvMyApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyApplications.Location = new System.Drawing.Point(6, 6);
            this.dgvMyApplications.Name = "dgvMyApplications";
            this.dgvMyApplications.Size = new System.Drawing.Size(756, 454);
            this.dgvMyApplications.TabIndex = 0;
            // 
            // tabSchedule
            // 
            this.tabSchedule.Controls.Add(this.dtpSelectedDate);
            this.tabSchedule.Controls.Add(this.txtSelectedTime);
            this.tabSchedule.Controls.Add(this.txtSelectedTeacher);
            this.tabSchedule.Controls.Add(this.txtSelectedElective);
            this.tabSchedule.Controls.Add(this.label17);
            this.tabSchedule.Controls.Add(this.label16);
            this.tabSchedule.Controls.Add(this.label15);
            this.tabSchedule.Controls.Add(this.label14);
            this.tabSchedule.Controls.Add(this.label13);
            this.tabSchedule.Controls.Add(this.dgvSchedule);
            this.tabSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabSchedule.Location = new System.Drawing.Point(4, 22);
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.Size = new System.Drawing.Size(768, 592);
            this.tabSchedule.TabIndex = 2;
            this.tabSchedule.Text = "Расписание моих факультативов";
            this.tabSchedule.UseVisualStyleBackColor = true;
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Location = new System.Drawing.Point(3, 3);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.Size = new System.Drawing.Size(762, 369);
            this.dgvSchedule.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.txtLogin);
            this.tabPage1.Controls.Add(this.txtPhone);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.txtGroup);
            this.tabPage1.Controls.Add(this.txtFullName);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(768, 592);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Мой профиль";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(34, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 44);
            this.button1.TabIndex = 45;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPassword.Location = new System.Drawing.Point(107, 155);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(169, 22);
            this.txtPassword.TabIndex = 44;
            // 
            // txtLogin
            // 
            this.txtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLogin.Location = new System.Drawing.Point(107, 129);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(169, 22);
            this.txtLogin.TabIndex = 43;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPhone.Location = new System.Drawing.Point(107, 105);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(169, 22);
            this.txtPhone.TabIndex = 42;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtEmail.Location = new System.Drawing.Point(107, 77);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(169, 22);
            this.txtEmail.TabIndex = 41;
            // 
            // txtGroup
            // 
            this.txtGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtGroup.Location = new System.Drawing.Point(107, 51);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(169, 22);
            this.txtGroup.TabIndex = 40;
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFullName.Location = new System.Drawing.Point(107, 25);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(169, 22);
            this.txtFullName.TabIndex = 39;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(34, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(242, 44);
            this.button2.TabIndex = 37;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(31, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "Пароль:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(31, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "Логин:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(31, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "Телефон:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(31, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 16);
            this.label10.TabIndex = 33;
            this.label10.Text = "Email:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(31, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 16);
            this.label11.TabIndex = 32;
            this.label11.Text = "Группа:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(31, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 16);
            this.label12.TabIndex = 31;
            this.label12.Text = "ФИО:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(762, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentUser.Location = new System.Drawing.Point(17, 9);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(70, 25);
            this.lblCurrentUser.TabIndex = 5;
            this.lblCurrentUser.Text = "label4";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(28, 392);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(153, 24);
            this.label13.TabIndex = 1;
            this.label13.Text = "Детали занятия";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 433);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 16);
            this.label14.TabIndex = 2;
            this.label14.Text = "Факультатив:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 465);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 16);
            this.label15.TabIndex = 3;
            this.label15.Text = "Преподаватель:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(29, 494);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 16);
            this.label16.TabIndex = 4;
            this.label16.Text = "Дата занятия:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(29, 520);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 16);
            this.label17.TabIndex = 5;
            this.label17.Text = "Время занятия:";
            // 
            // txtSelectedElective
            // 
            this.txtSelectedElective.Location = new System.Drawing.Point(160, 427);
            this.txtSelectedElective.Name = "txtSelectedElective";
            this.txtSelectedElective.ReadOnly = true;
            this.txtSelectedElective.Size = new System.Drawing.Size(480, 22);
            this.txtSelectedElective.TabIndex = 6;
            // 
            // txtSelectedTeacher
            // 
            this.txtSelectedTeacher.Location = new System.Drawing.Point(160, 459);
            this.txtSelectedTeacher.Name = "txtSelectedTeacher";
            this.txtSelectedTeacher.ReadOnly = true;
            this.txtSelectedTeacher.Size = new System.Drawing.Size(480, 22);
            this.txtSelectedTeacher.TabIndex = 7;
            // 
            // txtSelectedTime
            // 
            this.txtSelectedTime.Location = new System.Drawing.Point(160, 517);
            this.txtSelectedTime.Name = "txtSelectedTime";
            this.txtSelectedTime.ReadOnly = true;
            this.txtSelectedTime.Size = new System.Drawing.Size(294, 22);
            this.txtSelectedTime.TabIndex = 8;
            // 
            // dtpSelectedDate
            // 
            this.dtpSelectedDate.Enabled = false;
            this.dtpSelectedDate.Location = new System.Drawing.Point(160, 489);
            this.dtpSelectedDate.Name = "dtpSelectedDate";
            this.dtpSelectedDate.Size = new System.Drawing.Size(294, 22);
            this.dtpSelectedDate.TabIndex = 9;
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 676);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.я.ResumeLayout(false);
            this.я.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElectives)).EndInit();
            this.tabApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyApplications)).EndInit();
            this.tabSchedule.ResumeLayout(false);
            this.tabSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage я;
        private System.Windows.Forms.TabPage tabApplications;
        private System.Windows.Forms.DataGridView dgvElectives;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridView dgvMyApplications;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.TextBox txtCourseDescription;
        private System.Windows.Forms.TextBox txtMaxStudents;
        private System.Windows.Forms.TextBox txtCourseTeacher;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpSelectedDate;
        private System.Windows.Forms.TextBox txtSelectedTime;
        private System.Windows.Forms.TextBox txtSelectedTeacher;
        private System.Windows.Forms.TextBox txtSelectedElective;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}