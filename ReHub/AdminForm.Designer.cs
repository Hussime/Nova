namespace ReHub
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabElectives = new System.Windows.Forms.TabPage();
            this.txtElectiveDescription = new System.Windows.Forms.TextBox();
            this.btnGenerateElectivesReport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteElective = new System.Windows.Forms.Button();
            this.btnEditElective = new System.Windows.Forms.Button();
            this.btnCreateElective = new System.Windows.Forms.Button();
            this.numMaxStudents = new System.Windows.Forms.NumericUpDown();
            this.cmbTeachers = new System.Windows.Forms.ComboBox();
            this.txtElectiveName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvElectives = new System.Windows.Forms.DataGridView();
            this.tabTeachers = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGenerateTeachersReport = new System.Windows.Forms.Button();
            this.btnDeleteTeacher = new System.Windows.Forms.Button();
            this.btnCreateTeacher = new System.Windows.Forms.Button();
            this.dgvTeachers = new System.Windows.Forms.DataGridView();
            this.tabStudents = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.btnGenerateStudentsReport = new System.Windows.Forms.Button();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.btnCreateStudent = new System.Windows.Forms.Button();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabElectives.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElectives)).BeginInit();
            this.tabTeachers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).BeginInit();
            this.tabStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabElectives);
            this.tabControl1.Controls.Add(this.tabTeachers);
            this.tabControl1.Controls.Add(this.tabStudents);
            this.tabControl1.Location = new System.Drawing.Point(12, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabElectives
            // 
            this.tabElectives.Controls.Add(this.txtElectiveDescription);
            this.tabElectives.Controls.Add(this.btnGenerateElectivesReport);
            this.tabElectives.Controls.Add(this.btnRefresh);
            this.tabElectives.Controls.Add(this.btnDeleteElective);
            this.tabElectives.Controls.Add(this.btnEditElective);
            this.tabElectives.Controls.Add(this.btnCreateElective);
            this.tabElectives.Controls.Add(this.numMaxStudents);
            this.tabElectives.Controls.Add(this.cmbTeachers);
            this.tabElectives.Controls.Add(this.txtElectiveName);
            this.tabElectives.Controls.Add(this.label4);
            this.tabElectives.Controls.Add(this.label3);
            this.tabElectives.Controls.Add(this.label2);
            this.tabElectives.Controls.Add(this.label1);
            this.tabElectives.Controls.Add(this.dgvElectives);
            this.tabElectives.Location = new System.Drawing.Point(4, 22);
            this.tabElectives.Name = "tabElectives";
            this.tabElectives.Padding = new System.Windows.Forms.Padding(3);
            this.tabElectives.Size = new System.Drawing.Size(768, 400);
            this.tabElectives.TabIndex = 0;
            this.tabElectives.Text = "Управление факультативами";
            this.tabElectives.UseVisualStyleBackColor = true;
            // 
            // txtElectiveDescription
            // 
            this.txtElectiveDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtElectiveDescription.Location = new System.Drawing.Point(98, 220);
            this.txtElectiveDescription.Multiline = true;
            this.txtElectiveDescription.Name = "txtElectiveDescription";
            this.txtElectiveDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtElectiveDescription.Size = new System.Drawing.Size(519, 86);
            this.txtElectiveDescription.TabIndex = 14;
            // 
            // btnGenerateElectivesReport
            // 
            this.btnGenerateElectivesReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGenerateElectivesReport.Location = new System.Drawing.Point(651, 352);
            this.btnGenerateElectivesReport.Name = "btnGenerateElectivesReport";
            this.btnGenerateElectivesReport.Size = new System.Drawing.Size(111, 42);
            this.btnGenerateElectivesReport.TabIndex = 13;
            this.btnGenerateElectivesReport.Text = "Отчет";
            this.btnGenerateElectivesReport.UseVisualStyleBackColor = true;
            this.btnGenerateElectivesReport.Click += new System.EventHandler(this.btnGenerateElectivesReport_Click_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRefresh.Location = new System.Drawing.Point(651, 181);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(111, 42);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // btnDeleteElective
            // 
            this.btnDeleteElective.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteElective.Location = new System.Drawing.Point(252, 342);
            this.btnDeleteElective.Name = "btnDeleteElective";
            this.btnDeleteElective.Size = new System.Drawing.Size(111, 42);
            this.btnDeleteElective.TabIndex = 11;
            this.btnDeleteElective.Text = "Удалить";
            this.btnDeleteElective.UseVisualStyleBackColor = true;
            this.btnDeleteElective.Click += new System.EventHandler(this.btnDeleteElective_Click_1);
            // 
            // btnEditElective
            // 
            this.btnEditElective.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditElective.Location = new System.Drawing.Point(135, 342);
            this.btnEditElective.Name = "btnEditElective";
            this.btnEditElective.Size = new System.Drawing.Size(111, 42);
            this.btnEditElective.TabIndex = 10;
            this.btnEditElective.Text = "Изменить";
            this.btnEditElective.UseVisualStyleBackColor = true;
            this.btnEditElective.Click += new System.EventHandler(this.btnEditElective_Click_1);
            // 
            // btnCreateElective
            // 
            this.btnCreateElective.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreateElective.Location = new System.Drawing.Point(18, 342);
            this.btnCreateElective.Name = "btnCreateElective";
            this.btnCreateElective.Size = new System.Drawing.Size(111, 42);
            this.btnCreateElective.TabIndex = 9;
            this.btnCreateElective.Text = "Создать";
            this.btnCreateElective.UseVisualStyleBackColor = true;
            this.btnCreateElective.Click += new System.EventHandler(this.btnCreateElective_Click_1);
            // 
            // numMaxStudents
            // 
            this.numMaxStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numMaxStudents.Location = new System.Drawing.Point(542, 312);
            this.numMaxStudents.Name = "numMaxStudents";
            this.numMaxStudents.Size = new System.Drawing.Size(120, 22);
            this.numMaxStudents.TabIndex = 8;
            // 
            // cmbTeachers
            // 
            this.cmbTeachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbTeachers.FormattingEnabled = true;
            this.cmbTeachers.Location = new System.Drawing.Point(98, 312);
            this.cmbTeachers.Name = "cmbTeachers";
            this.cmbTeachers.Size = new System.Drawing.Size(290, 24);
            this.cmbTeachers.TabIndex = 7;
            // 
            // txtElectiveName
            // 
            this.txtElectiveName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtElectiveName.Location = new System.Drawing.Point(98, 194);
            this.txtElectiveName.Name = "txtElectiveName";
            this.txtElectiveName.Size = new System.Drawing.Size(519, 22);
            this.txtElectiveName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(424, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Макс. учеников:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(22, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Учитель:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(17, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Описание:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название:";
            // 
            // dgvElectives
            // 
            this.dgvElectives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElectives.Location = new System.Drawing.Point(6, 6);
            this.dgvElectives.Name = "dgvElectives";
            this.dgvElectives.Size = new System.Drawing.Size(756, 169);
            this.dgvElectives.TabIndex = 0;
            // 
            // tabTeachers
            // 
            this.tabTeachers.Controls.Add(this.button1);
            this.tabTeachers.Controls.Add(this.btnGenerateTeachersReport);
            this.tabTeachers.Controls.Add(this.btnDeleteTeacher);
            this.tabTeachers.Controls.Add(this.btnCreateTeacher);
            this.tabTeachers.Controls.Add(this.dgvTeachers);
            this.tabTeachers.Location = new System.Drawing.Point(4, 22);
            this.tabTeachers.Name = "tabTeachers";
            this.tabTeachers.Padding = new System.Windows.Forms.Padding(3);
            this.tabTeachers.Size = new System.Drawing.Size(768, 400);
            this.tabTeachers.TabIndex = 1;
            this.tabTeachers.Text = "Управление преподавателями";
            this.tabTeachers.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(173, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 54);
            this.button1.TabIndex = 13;
            this.button1.Text = "Изменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGenerateTeachersReport
            // 
            this.btnGenerateTeachersReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGenerateTeachersReport.Location = new System.Drawing.Point(598, 340);
            this.btnGenerateTeachersReport.Name = "btnGenerateTeachersReport";
            this.btnGenerateTeachersReport.Size = new System.Drawing.Size(161, 54);
            this.btnGenerateTeachersReport.TabIndex = 12;
            this.btnGenerateTeachersReport.Text = "Отчет";
            this.btnGenerateTeachersReport.UseVisualStyleBackColor = true;
            this.btnGenerateTeachersReport.Click += new System.EventHandler(this.btnGenerateTeachersReport_Click_1);
            // 
            // btnDeleteTeacher
            // 
            this.btnDeleteTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteTeacher.Location = new System.Drawing.Point(340, 340);
            this.btnDeleteTeacher.Name = "btnDeleteTeacher";
            this.btnDeleteTeacher.Size = new System.Drawing.Size(161, 54);
            this.btnDeleteTeacher.TabIndex = 11;
            this.btnDeleteTeacher.Text = "Удалить";
            this.btnDeleteTeacher.UseVisualStyleBackColor = true;
            this.btnDeleteTeacher.Click += new System.EventHandler(this.btnDeleteTeacher_Click_1);
            // 
            // btnCreateTeacher
            // 
            this.btnCreateTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreateTeacher.Location = new System.Drawing.Point(6, 340);
            this.btnCreateTeacher.Name = "btnCreateTeacher";
            this.btnCreateTeacher.Size = new System.Drawing.Size(161, 54);
            this.btnCreateTeacher.TabIndex = 10;
            this.btnCreateTeacher.Text = "Создать";
            this.btnCreateTeacher.UseVisualStyleBackColor = true;
            this.btnCreateTeacher.Click += new System.EventHandler(this.btnCreateTeacher_Click_1);
            // 
            // dgvTeachers
            // 
            this.dgvTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeachers.Location = new System.Drawing.Point(3, 6);
            this.dgvTeachers.Name = "dgvTeachers";
            this.dgvTeachers.Size = new System.Drawing.Size(756, 328);
            this.dgvTeachers.TabIndex = 1;
            // 
            // tabStudents
            // 
            this.tabStudents.Controls.Add(this.button2);
            this.tabStudents.Controls.Add(this.btnGenerateStudentsReport);
            this.tabStudents.Controls.Add(this.btnDeleteStudent);
            this.tabStudents.Controls.Add(this.btnCreateStudent);
            this.tabStudents.Controls.Add(this.dgvStudents);
            this.tabStudents.Location = new System.Drawing.Point(4, 22);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Size = new System.Drawing.Size(768, 400);
            this.tabStudents.TabIndex = 2;
            this.tabStudents.Text = "Управление студентами";
            this.tabStudents.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(176, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 54);
            this.button2.TabIndex = 17;
            this.button2.Text = "Изменить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnGenerateStudentsReport
            // 
            this.btnGenerateStudentsReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGenerateStudentsReport.Location = new System.Drawing.Point(601, 340);
            this.btnGenerateStudentsReport.Name = "btnGenerateStudentsReport";
            this.btnGenerateStudentsReport.Size = new System.Drawing.Size(161, 54);
            this.btnGenerateStudentsReport.TabIndex = 16;
            this.btnGenerateStudentsReport.Text = "Отчет";
            this.btnGenerateStudentsReport.UseVisualStyleBackColor = true;
            this.btnGenerateStudentsReport.Click += new System.EventHandler(this.btnGenerateStudentsReport_Click_1);
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteStudent.Location = new System.Drawing.Point(343, 340);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(161, 54);
            this.btnDeleteStudent.TabIndex = 15;
            this.btnDeleteStudent.Text = "Удалить";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click_1);
            // 
            // btnCreateStudent
            // 
            this.btnCreateStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreateStudent.Location = new System.Drawing.Point(9, 340);
            this.btnCreateStudent.Name = "btnCreateStudent";
            this.btnCreateStudent.Size = new System.Drawing.Size(161, 54);
            this.btnCreateStudent.TabIndex = 14;
            this.btnCreateStudent.Text = "Создать";
            this.btnCreateStudent.UseVisualStyleBackColor = true;
            this.btnCreateStudent.Click += new System.EventHandler(this.btnCreateStudent_Click_1);
            // 
            // dgvStudents
            // 
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(6, 6);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.Size = new System.Drawing.Size(756, 328);
            this.dgvStudents.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(762, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "X";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentUser.Location = new System.Drawing.Point(11, 9);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(70, 25);
            this.lblCurrentUser.TabIndex = 6;
            this.lblCurrentUser.Text = "label4";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabElectives.ResumeLayout(false);
            this.tabElectives.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElectives)).EndInit();
            this.tabTeachers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).EndInit();
            this.tabStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabElectives;
        private System.Windows.Forms.TabPage tabTeachers;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.DataGridView dgvElectives;
        private System.Windows.Forms.Button btnGenerateElectivesReport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeleteElective;
        private System.Windows.Forms.Button btnEditElective;
        private System.Windows.Forms.Button btnCreateElective;
        private System.Windows.Forms.NumericUpDown numMaxStudents;
        private System.Windows.Forms.ComboBox cmbTeachers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtElectiveName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerateTeachersReport;
        private System.Windows.Forms.Button btnDeleteTeacher;
        private System.Windows.Forms.Button btnCreateTeacher;
        private System.Windows.Forms.DataGridView dgvTeachers;
        private System.Windows.Forms.TextBox txtElectiveDescription;
        private System.Windows.Forms.Button btnGenerateStudentsReport;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.Button btnCreateStudent;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}