using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StudentRegistrationSystem
{
    public partial class StudentDetails : Form
    {
        private bool isDarkMode;

        public StudentDetails(bool isDarkMode)
        {
            InitializeComponent();
            this.isDarkMode = isDarkMode;
        }

        private void StudentDetails_Load(object sender, EventArgs e)
        {
            ApplyTheme(isDarkMode);

            dgvStudents.DataSource = DatabaseHelper.GetStudents();
            if (dgvStudents.Columns["Photo"] != null)
            {
                dgvStudents.Columns["Photo"].Visible = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow != null)
            {
                var row = dgvStudents.CurrentRow;
                if (row.Cells["Photo"].Value != DBNull.Value)
                {
                    byte[] photoBytes = (byte[])row.Cells["Photo"].Value;
                    using (MemoryStream ms = new MemoryStream(photoBytes))
                    {
                        picStudentPhoto.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picStudentPhoto.Image = null;
                }
            }
        }

        private void ApplyTheme(bool darkMode)
        {
            if (darkMode)
            {
                this.BackColor = Color.FromArgb(45, 45, 45);
                this.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = Color.Black;
            }

            foreach (Control ctrl in this.Controls)
            {
                if (darkMode)
                {
                    ctrl.BackColor = Color.FromArgb(45, 45, 45);
                    ctrl.ForeColor = Color.White;
                }
                else
                {
                    ctrl.BackColor = SystemColors.Control;
                    ctrl.ForeColor = Color.Black;
                }
            }
        }
    }
}