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
    public partial class RegistrationForm : Form
    {
        // A variable to store the selected photo
        private Image? selectedPhoto;
        // Field to keep track of the current theme mode
        private bool isDarkMode = false;

        public RegistrationForm()
        {
            InitializeComponent();
            // Apply the initial (light) theme
            ApplyTheme(isDarkMode);
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            // Pre-populate the Blood Group ComboBox
            comboBloodGroup.Items.AddRange(new string[] {
                "A(+ve)", "A(-ve)", "B(+ve)", "B(-ve)", "AB(+ve)", "AB(-ve)", "O(+ve)", "O(-ve)"
            });

            // Set default selections
            radioMale.Checked = true;  // default gender
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Use OpenFileDialog to choose an image
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedPhoto = Image.FromFile(ofd.FileName);
                    pictureBox1.Image = selectedPhoto;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Clear all fields
            txtName.Clear();
            txtRoll.Clear();
            txtRegID.Clear();
            txtSemester.Clear();
            comboBloodGroup.SelectedIndex = -1;
            radioMale.Checked = true;
            radioFemale.Checked = false;
            radioOther.Checked = false;
            pictureBox1.Image = null;
            selectedPhoto = null;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Gather data from fields
            string name = txtName.Text;
            string roll = txtRoll.Text;
            string regID = txtRegID.Text;
            string semester = txtSemester.Text;
            string bloodGroup = comboBloodGroup.SelectedIndex >= 0
                ? comboBloodGroup.SelectedItem.ToString() : "";
            string gender = radioMale.Checked ? "Male" :
                            radioFemale.Checked ? "Female" :
                            radioOther.Checked ? "Other" : "";

            // Create StudentDetails and pass data (including current theme mode)
            StudentDetails details = new StudentDetails(name, roll, regID, semester, bloodGroup, gender, selectedPhoto, isDarkMode);
            details.Show();
        }

        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            // Toggle the theme mode and update the UI
            isDarkMode = !isDarkMode;
            ApplyTheme(isDarkMode);
            btnToggleTheme.Text = isDarkMode ? "Switch to Light Mode" : "Switch to Dark Mode";
        }

        private void ApplyTheme(bool darkMode)
        {
            // Define colors for light vs. dark mode
            Color backColor, foreColor, buttonColor;
            if (darkMode)
            {
                backColor = Color.FromArgb(45, 45, 48);
                foreColor = Color.White;
                buttonColor = Color.FromArgb(63, 63, 70);
            }
            else
            {
                backColor = Color.White;
                foreColor = Color.Black;
                buttonColor = Color.LightGray;
            }

            // Apply to the form itself
            this.BackColor = backColor;
            this.ForeColor = foreColor;

            // Recursively apply theme to all child controls
            foreach (Control ctrl in this.Controls)
            {
                ApplyThemeToControl(ctrl, backColor, foreColor, buttonColor);
            }
        }

        private void ApplyThemeToControl(Control ctrl, Color backColor, Color foreColor, Color buttonColor)
        {
            // Customize based on control type for a flat, modern look
            if (ctrl is Button)
            {
                ctrl.BackColor = buttonColor;
                ctrl.ForeColor = foreColor;
                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                }
            }
            else if (ctrl is ComboBox || ctrl is TextBox || ctrl is PictureBox)
            {
                ctrl.BackColor = backColor;
                ctrl.ForeColor = foreColor;
            }
            else if (ctrl is RadioButton || ctrl is Label)
            {
                ctrl.BackColor = backColor;
                ctrl.ForeColor = foreColor;
            }
            else
            {
                ctrl.BackColor = backColor;
                ctrl.ForeColor = foreColor;
            }

            // Recursively update any nested controls
            foreach (Control child in ctrl.Controls)
            {
                ApplyThemeToControl(child, backColor, foreColor, buttonColor);
            }
        }
    }
}
