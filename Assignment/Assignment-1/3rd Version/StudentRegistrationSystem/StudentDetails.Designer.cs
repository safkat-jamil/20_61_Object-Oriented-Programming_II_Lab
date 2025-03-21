namespace StudentRegistrationSystem
{
    partial class StudentDetails
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.PictureBox picStudentPhoto;
        private System.Windows.Forms.Button btnClose;

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
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.picStudentPhoto = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStudentPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(12, 12);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowTemplate.Height = 25;
            this.dgvStudents.Size = new System.Drawing.Size(560, 250);
            this.dgvStudents.TabIndex = 0;
            this.dgvStudents.SelectionChanged += new System.EventHandler(this.dgvStudents_SelectionChanged);
            // 
            // picStudentPhoto
            // 
            this.picStudentPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStudentPhoto.Location = new System.Drawing.Point(12, 268);
            this.picStudentPhoto.Name = "picStudentPhoto";
            this.picStudentPhoto.Size = new System.Drawing.Size(150, 150);
            this.picStudentPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStudentPhoto.TabIndex = 1;
            this.picStudentPhoto.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(497, 395);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // StudentDetails
            // 
            this.ClientSize = new System.Drawing.Size(584, 430);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.picStudentPhoto);
            this.Controls.Add(this.dgvStudents);
            this.Name = "StudentDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Student Details";
            this.Load += new System.EventHandler(this.StudentDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStudentPhoto)).EndInit();
            this.ResumeLayout(false);
        }
    }
}