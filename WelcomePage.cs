using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class WelcomePage : Form
    {
        public WelcomePage()
        {
            InitializeComponent();
            timer.Start();
        }
        int startPoint = 0;
        
        // Progress Bar to load login in page from the welcome page
        private void timer_Tick(object sender, EventArgs e)
        {
            startPoint += 2;
            progressBar.Value = startPoint;
            if(progressBar.Value == 100)
            {
                progressBar.Value = 0;
                timer.Stop();
                LoginPage login = new LoginPage();
                this.Hide();
                login.ShowDialog();
            }
        }
    }
}
