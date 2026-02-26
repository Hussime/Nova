using System.Drawing;
using System.Windows.Forms;

namespace ReHub
{
    partial class EditElectiveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditElectiveForm));
            this.txtElectiveName = new System.Windows.Forms.TextBox();
            this.txtElectiveDescription = new System.Windows.Forms.TextBox();
            this.numMaxStudents = new System.Windows.Forms.NumericUpDown();
            this.cmbTeachers = new System.Windows.Forms.ComboBox();
            this.dtpLessonDate = new System.Windows.Forms.DateTimePicker();
            this.txtLessonTime = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // txtElectiveName
            // 
            this.txtElectiveName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtElectiveName.Location = new System.Drawing.Point(172, 38);
            this.txtElectiveName.Name = "txtElectiveName";
            this.txtElectiveName.Size = new System.Drawing.Size(250, 23);
            this.txtElectiveName.TabIndex = 0;
            // 
            // txtElectiveDescription
            // 
            this.txtElectiveDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtElectiveDescription.Location = new System.Drawing.Point(172, 67);
            this.txtElectiveDescription.Multiline = true;
            this.txtElectiveDescription.Name = "txtElectiveDescription";
            this.txtElectiveDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtElectiveDescription.Size = new System.Drawing.Size(250, 114);
            this.txtElectiveDescription.TabIndex = 1;
            // 
            // numMaxStudents
            // 
            this.numMaxStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numMaxStudents.Location = new System.Drawing.Point(170, 187);
            this.numMaxStudents.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxStudents.Name = "numMaxStudents";
            this.numMaxStudents.Size = new System.Drawing.Size(100, 23);
            this.numMaxStudents.TabIndex = 2;
            this.numMaxStudents.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // cmbTeachers
            // 
            this.cmbTeachers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbTeachers.FormattingEnabled = true;
            this.cmbTeachers.Location = new System.Drawing.Point(170, 217);
            this.cmbTeachers.Name = "cmbTeachers";
            this.cmbTeachers.Size = new System.Drawing.Size(250, 24);
            this.cmbTeachers.TabIndex = 3;
            // 
            // dtpLessonDate
            // 
            this.dtpLessonDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpLessonDate.Location = new System.Drawing.Point(170, 247);
            this.dtpLessonDate.Name = "dtpLessonDate";
            this.dtpLessonDate.Size = new System.Drawing.Size(150, 23);
            this.dtpLessonDate.TabIndex = 4;
            // 
            // txtLessonTime
            // 
            this.txtLessonTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtLessonTime.Location = new System.Drawing.Point(170, 277);
            this.txtLessonTime.Name = "txtLessonTime";
            this.txtLessonTime.Size = new System.Drawing.Size(100, 23);
            this.txtLessonTime.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(46, 317);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 52);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancel.Location = new System.Drawing.Point(278, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(142, 50);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(43, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Название:*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(43, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Описание:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(43, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Макс. студентов:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(43, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Преподаватель:*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(43, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Дата занятия:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(43, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Время занятия:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(457, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "X";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(118, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(216, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Редактирование факультатива";
            // 
            // EditElectiveForm
            // 
            this.ClientSize = new System.Drawing.Size(486, 386);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLessonTime);
            this.Controls.Add(this.dtpLessonDate);
            this.Controls.Add(this.cmbTeachers);
            this.Controls.Add(this.numMaxStudents);
            this.Controls.Add(this.txtElectiveDescription);
            this.Controls.Add(this.txtElectiveName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditElectiveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование факультатива";
            ((System.ComponentModel.ISupportInitialize)(this.numMaxStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtElectiveName;
        private System.Windows.Forms.TextBox txtElectiveDescription;
        private System.Windows.Forms.NumericUpDown numMaxStudents;
        private System.Windows.Forms.ComboBox cmbTeachers;
        private System.Windows.Forms.DateTimePicker dtpLessonDate;
        private System.Windows.Forms.TextBox txtLessonTime;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Label label7;
        private Label label8;
    }
}