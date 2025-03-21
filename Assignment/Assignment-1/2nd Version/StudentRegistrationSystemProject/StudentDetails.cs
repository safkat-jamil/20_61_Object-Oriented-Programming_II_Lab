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
    public partial class StudentDetails : Form
    {
        private bool isDarkMode;

        public StudentDetails(string name, string roll, string regID, string semester,
                              string bloodGroup, string gender, Image? photo, bool isDarkMode)
        {
            InitializeComponent();
            this.isDarkMode = isDarkMode;

            // Display the passed data
            lblName.Text = name;
            lblRoll.Text = roll;
            lblRegID.Text = regID;
            lblSemester.Text = semester;
            lblBloodGroup.Text = bloodGroup;
            lblGender.Text = gender;

            if (photo != null)
                pictureBoxPhoto.Image = photo;

            // Apply theme based on the flag
            ApplyTheme(isDarkMode);
        }

        private void ApplyTheme(bool darkMode)
        {
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

            this.BackColor = backColor;
            this.ForeColor = foreColor;

            foreach (Control ctrl in this.Controls)
            {
                ApplyThemeToControl(ctrl, backColor, foreColor, buttonColor);
            }
        }

        private void ApplyThemeToControl(Control ctrl, Color backColor, Color foreColor, Color buttonColor)
        {
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
            else if (ctrl is PictureBox || ctrl is Label)
            {
                ctrl.BackColor = backColor;
                ctrl.ForeColor = foreColor;
            }
            else
            {
                ctrl.BackColor = backColor;
                ctrl.ForeColor = foreColor;
            }

            foreach (Control child in ctrl.Controls)
            {
                ApplyThemeToControl(child, backColor, foreColor, buttonColor);
            }
        }
    }
}
