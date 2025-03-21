using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StudentRegistrationSystemProject
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;

        private TextBox txtName;
        private TextBox txtRoll;
        private TextBox txtRegID;
        private TextBox txtSemester;

        private ComboBox comboBloodGroup;

        private RadioButton radioMale;
        private RadioButton radioFemale;
        private RadioButton radioOther;

        private PictureBox pictureBox1;

        private Button btnUpload;
        private Button btnReset;
        private Button btnSubmit;
        private Button btnToggleTheme;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtRoll = new TextBox();
            label3 = new Label();
            txtRegID = new TextBox();
            label4 = new Label();
            txtSemester = new TextBox();
            label5 = new Label();
            comboBloodGroup = new ComboBox();
            label6 = new Label();
            radioMale = new RadioButton();
            radioFemale = new RadioButton();
            radioOther = new RadioButton();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            btnUpload = new Button();
            btnReset = new Button();
            btnSubmit = new Button();
            btnToggleTheme = new Button();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(100, 30);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 70);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 2;
            label2.Text = "Roll:";
            // 
            // txtRoll
            // 
            txtRoll.Location = new Point(100, 70);
            txtRoll.Name = "txtRoll";
            txtRoll.Size = new Size(200, 23);
            txtRoll.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 110);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 4;
            label3.Text = "Reg. ID:";
            // 
            // txtRegID
            // 
            txtRegID.Location = new Point(100, 110);
            txtRegID.Name = "txtRegID";
            txtRegID.Size = new Size(200, 23);
            txtRegID.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 150);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 6;
            label4.Text = "Semester:";
            // 
            // txtSemester
            // 
            txtSemester.Location = new Point(100, 150);
            txtSemester.Name = "txtSemester";
            txtSemester.Size = new Size(200, 23);
            txtSemester.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 190);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 8;
            label5.Text = "Blood Group:";
            // 
            // comboBloodGroup
            // 
            comboBloodGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBloodGroup.Location = new Point(120, 190);
            comboBloodGroup.Name = "comboBloodGroup";
            comboBloodGroup.Size = new Size(180, 23);
            comboBloodGroup.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 230);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 10;
            label6.Text = "Gender:";
            // 
            // radioMale
            // 
            radioMale.AutoSize = true;
            radioMale.Location = new Point(100, 230);
            radioMale.Name = "radioMale";
            radioMale.Size = new Size(51, 19);
            radioMale.TabIndex = 11;
            radioMale.Text = "Male";
            // 
            // radioFemale
            // 
            radioFemale.AutoSize = true;
            radioFemale.Location = new Point(160, 230);
            radioFemale.Name = "radioFemale";
            radioFemale.Size = new Size(63, 19);
            radioFemale.TabIndex = 12;
            radioFemale.Text = "Female";
            // 
            // radioOther
            // 
            radioOther.AutoSize = true;
            radioOther.Location = new Point(230, 230);
            radioOther.Name = "radioOther";
            radioOther.Size = new Size(55, 19);
            radioOther.TabIndex = 13;
            radioOther.Text = "Other";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 270);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 14;
            label7.Text = "Photo:";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(100, 270);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(71, 74);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(210, 270);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(75, 23);
            btnUpload.TabIndex = 16;
            btnUpload.Text = "Upload";
            btnUpload.Click += btnUpload_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(30, 350);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 17;
            btnReset.Text = "Reset";
            btnReset.Click += btnReset_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(120, 350);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 18;
            btnSubmit.Text = "Submit";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnToggleTheme
            // 
            btnToggleTheme.Location = new Point(210, 350);
            btnToggleTheme.Name = "btnToggleTheme";
            btnToggleTheme.Size = new Size(100, 23);
            btnToggleTheme.TabIndex = 19;
            btnToggleTheme.Text = "Switch to Dark Mode";
            btnToggleTheme.Click += btnToggleTheme_Click;
            // 
            // RegistrationForm
            // 
            ClientSize = new Size(679, 505);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtRoll);
            Controls.Add(label3);
            Controls.Add(txtRegID);
            Controls.Add(label4);
            Controls.Add(txtSemester);
            Controls.Add(label5);
            Controls.Add(comboBloodGroup);
            Controls.Add(label6);
            Controls.Add(radioMale);
            Controls.Add(radioFemale);
            Controls.Add(radioOther);
            Controls.Add(label7);
            Controls.Add(pictureBox1);
            Controls.Add(btnUpload);
            Controls.Add(btnReset);
            Controls.Add(btnSubmit);
            Controls.Add(btnToggleTheme);
            Name = "RegistrationForm";
            Text = "Registration Form";
            Load += RegistrationForm_Load;
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}