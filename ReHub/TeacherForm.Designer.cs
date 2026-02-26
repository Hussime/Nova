namespace ReHub
{
    partial class TeacherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabApplications = new System.Windows.Forms.TabPage();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            this.tabStudents = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.btnExpelStudent = new System.Windows.Forms.Button();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.btnSetSchedule = new System.Windows.Forms.Button();
            this.dtpLessonDate = new System.Windows.Forms.DateTimePicker();
            this.txtLessonTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMyElectives = new System.Windows.Forms.DataGridView();
            this.tabCourseStudents = new System.Windows.Forms.TabPage();
            this.dgvCourseStudents = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.comboBoxElectives = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.tabStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.tabSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyElectives)).BeginInit();
            this.tabCourseStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabApplications);
            this.tabControl1.Controls.Add(this.tabStudents);
            this.tabControl1.Controls.Add(this.tabSchedule);
            this.tabControl1.Controls.Add(this.tabCourseStudents);
            this.tabControl1.Location = new System.Drawing.Point(12, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabApplications
            // 
            this.tabApplications.Controls.Add(this.btnReject);
            this.tabApplications.Controls.Add(this.btnApprove);
            this.tabApplications.Controls.Add(this.dgvApplications);
            this.tabApplications.Location = new System.Drawing.Point(4, 22);
            this.tabApplications.Name = "tabApplications";
            this.tabApplications.Padding = new System.Windows.Forms.Padding(3);
            this.tabApplications.Size = new System.Drawing.Size(768, 400);
            this.tabApplications.TabIndex = 0;
            this.tabApplications.Text = "Заявки учеников";
            this.tabApplications.UseVisualStyleBackColor = true;
            // 
            // btnReject
            // 
            this.btnReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReject.Location = new System.Drawing.Point(381, 319);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(159, 75);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Отклонить";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click_1);
            // 
            // btnApprove
            // 
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnApprove.Location = new System.Drawing.Point(216, 319);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(159, 75);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Принять";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click_1);
            // 
            // dgvApplications
            // 
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.Location = new System.Drawing.Point(6, 6);
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.Size = new System.Drawing.Size(756, 307);
            this.dgvApplications.TabIndex = 0;
            // 
            // tabStudents
            // 
            this.tabStudents.Controls.Add(this.comboBoxElectives);
            this.tabStudents.Controls.Add(this.button2);
            this.tabStudents.Controls.Add(this.btnExpelStudent);
            this.tabStudents.Controls.Add(this.dgvStudents);
            this.tabStudents.Location = new System.Drawing.Point(4, 22);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tabStudents.Size = new System.Drawing.Size(768, 400);
            this.tabStudents.TabIndex = 1;
            this.tabStudents.Text = "Зачисленые на курс";
            this.tabStudents.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(508, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 45);
            this.button2.TabIndex = 3;
            this.button2.Text = "Отчет";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExpelStudent
            // 
            this.btnExpelStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExpelStudent.Location = new System.Drawing.Point(88, 349);
            this.btnExpelStudent.Name = "btnExpelStudent";
            this.btnExpelStudent.Size = new System.Drawing.Size(159, 45);
            this.btnExpelStudent.TabIndex = 2;
            this.btnExpelStudent.Text = "Отчислить";
            this.btnExpelStudent.UseVisualStyleBackColor = true;
            this.btnExpelStudent.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvStudents
            // 
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(6, 35);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.Size = new System.Drawing.Size(756, 308);
            this.dgvStudents.TabIndex = 0;
            // 
            // tabSchedule
            // 
            this.tabSchedule.Controls.Add(this.btnSetSchedule);
            this.tabSchedule.Controls.Add(this.dtpLessonDate);
            this.tabSchedule.Controls.Add(this.txtLessonTime);
            this.tabSchedule.Controls.Add(this.label2);
            this.tabSchedule.Controls.Add(this.label1);
            this.tabSchedule.Controls.Add(this.dgvMyElectives);
            this.tabSchedule.Location = new System.Drawing.Point(4, 22);
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.Size = new System.Drawing.Size(768, 400);
            this.tabSchedule.TabIndex = 2;
            this.tabSchedule.Text = "Расписание факультета";
            this.tabSchedule.UseVisualStyleBackColor = true;
            // 
            // btnSetSchedule
            // 
            this.btnSetSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetSchedule.Location = new System.Drawing.Point(373, 328);
            this.btnSetSchedule.Name = "btnSetSchedule";
            this.btnSetSchedule.Size = new System.Drawing.Size(215, 47);
            this.btnSetSchedule.TabIndex = 5;
            this.btnSetSchedule.Text = "Установить или обновить расписание";
            this.btnSetSchedule.UseVisualStyleBackColor = true;
            this.btnSetSchedule.Click += new System.EventHandler(this.btnSetSchedule_Click_1);
            // 
            // dtpLessonDate
            // 
            this.dtpLessonDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpLessonDate.Location = new System.Drawing.Point(121, 327);
            this.dtpLessonDate.Name = "dtpLessonDate";
            this.dtpLessonDate.Size = new System.Drawing.Size(200, 22);
            this.dtpLessonDate.TabIndex = 4;
            // 
            // txtLessonTime
            // 
            this.txtLessonTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLessonTime.Location = new System.Drawing.Point(121, 355);
            this.txtLessonTime.Name = "txtLessonTime";
            this.txtLessonTime.Size = new System.Drawing.Size(100, 22);
            this.txtLessonTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(17, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Время:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Дата занятия:";
            // 
            // dgvMyElectives
            // 
            this.dgvMyElectives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyElectives.Location = new System.Drawing.Point(-4, 3);
            this.dgvMyElectives.Name = "dgvMyElectives";
            this.dgvMyElectives.Size = new System.Drawing.Size(762, 317);
            this.dgvMyElectives.TabIndex = 0;
            // 
            // tabCourseStudents
            // 
            this.tabCourseStudents.Controls.Add(this.dgvCourseStudents);
            this.tabCourseStudents.Controls.Add(this.btnRefresh);
            this.tabCourseStudents.Location = new System.Drawing.Point(4, 22);
            this.tabCourseStudents.Name = "tabCourseStudents";
            this.tabCourseStudents.Size = new System.Drawing.Size(768, 400);
            this.tabCourseStudents.TabIndex = 3;
            this.tabCourseStudents.Text = "Данные моих студентов";
            this.tabCourseStudents.UseVisualStyleBackColor = true;
            // 
            // dgvCourseStudents
            // 
            this.dgvCourseStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourseStudents.Location = new System.Drawing.Point(3, 3);
            this.dgvCourseStudents.Name = "dgvCourseStudents";
            this.dgvCourseStudents.Size = new System.Drawing.Size(762, 331);
            this.dgvCourseStudents.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRefresh.Location = new System.Drawing.Point(3, 340);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(762, 54);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(755, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentUser.Location = new System.Drawing.Point(16, 13);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(70, 25);
            this.lblCurrentUser.TabIndex = 4;
            this.lblCurrentUser.Text = "label4";
            // 
            // comboBoxElectives
            // 
            this.comboBoxElectives.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxElectives.FormattingEnabled = true;
            this.comboBoxElectives.Location = new System.Drawing.Point(511, 6);
            this.comboBoxElectives.Name = "comboBoxElectives";
            this.comboBoxElectives.Size = new System.Drawing.Size(254, 24);
            this.comboBoxElectives.TabIndex = 4;
            this.comboBoxElectives.SelectedIndexChanged += new System.EventHandler(this.comboBoxElectives_SelectedIndexChanged_1);
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TeacherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.tabStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.tabSchedule.ResumeLayout(false);
            this.tabSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyElectives)).EndInit();
            this.tabCourseStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabApplications;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.TabPage tabCourseStudents;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button btnSetSchedule;
        private System.Windows.Forms.DateTimePicker dtpLessonDate;
        private System.Windows.Forms.TextBox txtLessonTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMyElectives;
        private System.Windows.Forms.DataGridView dgvCourseStudents;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnExpelStudent;
        private System.Windows.Forms.ComboBox comboBoxElectives;
    }
}