namespace StudentRegistrationSystem
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // UI Controls declaration.
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.TextBox txtRoll;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.TextBox txtSemester;
        private System.Windows.Forms.Label lblRegID;
        private System.Windows.Forms.TextBox txtRegID;
        private System.Windows.Forms.Label lblBloodGroup;
        private System.Windows.Forms.TextBox txtBloodGroup;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbOther;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.PictureBox picStudentPhoto;
        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnToggleTheme;

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
        /// Method required for Designer support – do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblRoll = new System.Windows.Forms.Label();
            this.txtRoll = new System.Windows.Forms.TextBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.txtSemester = new System.Windows.Forms.TextBox();
            this.lblRegID = new System.Windows.Forms.Label();
            this.txtRegID = new System.Windows.Forms.TextBox();
            this.lblBloodGroup = new System.Windows.Forms.Label();
            this.txtBloodGroup = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbOther = new System.Windows.Forms.RadioButton();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.picStudentPhoto = new System.Windows.Forms.PictureBox();
            this.btnUploadPhoto = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnToggleTheme = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picStudentPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(130, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Student Registration";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(42, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 57);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 2;
            // 
            // lblRoll
            // 
            this.lblRoll.AutoSize = true;
            this.lblRoll.Location = new System.Drawing.Point(20, 95);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(30, 15);
            this.lblRoll.TabIndex = 3;
            this.lblRoll.Text = "Roll:";
            // 
            // txtRoll
            // 
            this.txtRoll.Location = new System.Drawing.Point(120, 92);
            this.txtRoll.Name = "txtRoll";
            this.txtRoll.Size = new System.Drawing.Size(200, 23);
            this.txtRoll.TabIndex = 4;
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Location = new System.Drawing.Point(20, 130);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(60, 15);
            this.lblSemester.TabIndex = 5;
            this.lblSemester.Text = "Semester:";
            // 
            // txtSemester
            // 
            this.txtSemester.Location = new System.Drawing.Point(120, 127);
            this.txtSemester.Name = "txtSemester";
            this.txtSemester.Size = new System.Drawing.Size(200, 23);
            this.txtSemester.TabIndex = 6;
            // 
            // lblRegID
            // 
            this.lblRegID.AutoSize = true;
            this.lblRegID.Location = new System.Drawing.Point(20, 165);
            this.lblRegID.Name = "lblRegID";
            this.lblRegID.Size = new System.Drawing.Size(45, 15);
            this.lblRegID.TabIndex = 7;
            this.lblRegID.Text = "Reg ID:";
            // 
            // txtRegID
            // 
            this.txtRegID.Location = new System.Drawing.Point(120, 162);
            this.txtRegID.Name = "txtRegID";
            this.txtRegID.Size = new System.Drawing.Size(200, 23);
            this.txtRegID.TabIndex = 8;
            // 
            // lblBloodGroup
            // 
            this.lblBloodGroup.AutoSize = true;
            this.lblBloodGroup.Location = new System.Drawing.Point(20, 200);
            this.lblBloodGroup.Name = "lblBloodGroup";
            this.lblBloodGroup.Size = new System.Drawing.Size(79, 15);
            this.lblBloodGroup.TabIndex = 9;
            this.lblBloodGroup.Text = "Blood Group:";
            // 
            // txtBloodGroup
            // 
            this.txtBloodGroup.Location = new System.Drawing.Point(120, 197);
            this.txtBloodGroup.Name = "txtBloodGroup";
            this.txtBloodGroup.Size = new System.Drawing.Size(200, 23);
            this.txtBloodGroup.TabIndex = 10;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(20, 235);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(50, 15);
            this.lblGender.TabIndex = 11;
            this.lblGender.Text = "Gender:";
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(120, 233);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(51, 19);
            this.rbMale.TabIndex = 12;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(190, 233);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(63, 19);
            this.rbFemale.TabIndex = 13;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbOther
            // 
            this.rbOther.AutoSize = true;
            this.rbOther.Location = new System.Drawing.Point(270, 233);
            this.rbOther.Name = "rbOther";
            this.rbOther.Size = new System.Drawing.Size(56, 19);
            this.rbOther.TabIndex = 14;
            this.rbOther.TabStop = true;
            this.rbOther.Text = "Other";
            this.rbOther.UseVisualStyleBackColor = true;
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(20, 270);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(42, 15);
            this.lblPhoto.TabIndex = 15;
            this.lblPhoto.Text = "Photo:";
            // 
            // picStudentPhoto
            // 
            this.picStudentPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStudentPhoto.Location = new System.Drawing.Point(120, 270);
            this.picStudentPhoto.Name = "picStudentPhoto";
            this.picStudentPhoto.Size = new System.Drawing.Size(150, 150);
            this.picStudentPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStudentPhoto.TabIndex = 16;
            this.picStudentPhoto.TabStop = false;
            // 
            // btnUploadPhoto
            // 
            this.btnUploadPhoto.Location = new System.Drawing.Point(280, 270);
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.Size = new System.Drawing.Size(75, 23);
            this.btnUploadPhoto.TabIndex = 17;
            this.btnUploadPhoto.Text = "Browse";
            this.btnUploadPhoto.UseVisualStyleBackColor = true;
            this.btnUploadPhoto.Click += new System.EventHandler(this.btnUploadPhoto_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(120, 440);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 27);
            this.btnRegister.TabIndex = 18;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Location = new System.Drawing.Point(210, 440);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(90, 27);
            this.btnViewDetails.TabIndex = 19;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(20, 480);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 27);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnToggleTheme
            // 
            this.btnToggleTheme.Location = new System.Drawing.Point(110, 480);
            this.btnToggleTheme.Name = "btnToggleTheme";
            this.btnToggleTheme.Size = new System.Drawing.Size(110, 27);
            this.btnToggleTheme.TabIndex = 21;
            this.btnToggleTheme.Text = "Toggle Theme";
            this.btnToggleTheme.UseVisualStyleBackColor = true;
            this.btnToggleTheme.Click += new System.EventHandler(this.btnToggleTheme_Click);
            // 
            // RegistrationForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 530);
            this.Controls.Add(this.btnToggleTheme);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnUploadPhoto);
            this.Controls.Add(this.picStudentPhoto);
            this.Controls.Add(this.lblPhoto);
            this.Controls.Add(this.rbOther);
            this.Controls.Add(this.rbFemale);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.txtBloodGroup);
            this.Controls.Add(this.lblBloodGroup);
            this.Controls.Add(this.txtRegID);
            this.Controls.Add(this.lblRegID);
            this.Controls.Add(this.txtSemester);
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.txtRoll);
            this.Controls.Add(this.lblRoll);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTitle);
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Registration";
            ((System.ComponentModel.ISupportInitialize)(this.picStudentPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}