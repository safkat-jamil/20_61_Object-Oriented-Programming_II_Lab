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
using System.IO;

namespace StudentRegistrationSystem
{
    public partial class RegistrationForm : Form
    {
        private byte[] photoBytes = null;
        private bool isDarkMode = false;

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtRoll.Text) ||
                string.IsNullOrWhiteSpace(txtSemester.Text) ||
                string.IsNullOrWhiteSpace(txtRegID.Text) ||
                string.IsNullOrWhiteSpace(txtBloodGroup.Text) ||
                (!rbMale.Checked && !rbFemale.Checked && !rbOther.Checked))
            {
                MessageBox.Show("All fields are required!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string gender = rbMale.Checked ? "Male" :
                            rbFemale.Checked ? "Female" : "Other";

            try
            {
                DatabaseHelper.InsertStudent(
                    txtName.Text.Trim(),
                    txtRoll.Text.Trim(),
                    txtSemester.Text.Trim(),
                    txtRegID.Text.Trim(),
                    txtBloodGroup.Text.Trim(),
                    gender,
                    photoBytes
                );

                MessageBox.Show("Registration Successful!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                using (StudentDetails detailsForm = new StudentDetails(isDarkMode))
                {
                    detailsForm.ShowDialog();
                }

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picStudentPhoto.Image = Image.FromFile(openFileDialog.FileName);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picStudentPhoto.Image.Save(ms, picStudentPhoto.Image.RawFormat);
                        photoBytes = ms.ToArray();
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtName.Clear();
            txtRoll.Clear();
            txtSemester.Clear();
            txtRegID.Clear();
            txtBloodGroup.Clear();
            rbMale.Checked = false;
            rbFemale.Checked = false;
            rbOther.Checked = false;
            picStudentPhoto.Image = null;
            photoBytes = null;
        }

        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme(isDarkMode);
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

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            using (StudentDetails detailsForm = new StudentDetails(isDarkMode))
            {
                detailsForm.ShowDialog();
            }
        }
    }
}