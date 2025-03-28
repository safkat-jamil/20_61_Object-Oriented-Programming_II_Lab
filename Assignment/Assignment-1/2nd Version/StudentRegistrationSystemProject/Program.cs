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
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Configure application for high DPI settings and visual styles
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start the application with the RegistrationForm
            Application.Run(new RegistrationForm());
        }
    }
}
