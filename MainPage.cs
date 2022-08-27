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
    public partial class MainPage : Form
    {
        public string setrole;
        public MainPage(String setRole )
        {
            setrole = setRole;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Displays product page in the child form
            openChildForm(new ProductPage());
            lbltitle.Text = "MANAGE PRODUCTS";
            pane1.BackColor = Color.Black;
            pane2.BackColor = Color.Cyan;
            pane3.BackColor = Color.Cyan;
            pane4.BackColor = Color.Cyan;
            pane5.BackColor = Color.Cyan;
            
        }   

        private void closebtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You " +
                "Want To Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void minbtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Show subform in main form
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Displays Product page
        private void labprod_MouseClick(object sender, MouseEventArgs e)
        {
            openChildForm(new ProductPage());
            lbltitle.Text = "MANAGE PRODUCTS";
            pane1.BackColor = Color.Black;
            pane2.BackColor = Color.Cyan;
            pane3.BackColor = Color.Cyan;
            pane4.BackColor = Color.Cyan;
            pane5.BackColor = Color.Cyan;
        }

        // Displays customer page 
        private void labcust_MouseClick(object sender, MouseEventArgs e)
        {
            openChildForm(new CustomerPage());
            lbltitle.Text = "MANAGE CUSTOMERS";
            pane1.BackColor = Color.Cyan;
            pane2.BackColor = Color.Black;
            pane3.BackColor = Color.Cyan;
            pane4.BackColor = Color.Cyan;
            pane5.BackColor = Color.Cyan;
        }

        // Displays category page
        private void labcats_MouseClick(object sender, MouseEventArgs e)
        {
            openChildForm(new CategoryPage());
            lbltitle.Text = "MANAGE CATEGORIES";
            pane1.BackColor = Color.Cyan;
            pane2.BackColor = Color.Cyan;
            pane3.BackColor = Color.Black;
            pane4.BackColor = Color.Cyan;
            pane5.BackColor = Color.Cyan;
        }

        // Display user page
        private void labusers_MouseClick(object sender, MouseEventArgs e)
        {
            if (setrole == "Attendant")
            {
                MessageBox.Show("You are unauthorized to access this page", "UNAUTHORIZED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                openChildForm(new UserPage());
                lbltitle.Text = "MANAGE USERS";
                pane1.BackColor = Color.Cyan;
                pane2.BackColor = Color.Cyan;
                pane3.BackColor = Color.Cyan;
                pane4.BackColor = Color.Black;
                pane5.BackColor = Color.Cyan;
            }
        }

        // Displays order page
        private void laborders_MouseClick(object sender, MouseEventArgs e)
        {
            openChildForm(new OrderPage());
            lbltitle.Text = "MANAGE ORDERS";
            pane1.BackColor = Color.Cyan;
            pane2.BackColor = Color.Cyan;
            pane3.BackColor = Color.Cyan;
            pane4.BackColor = Color.Cyan;
            pane5.BackColor = Color.Black;
        }
        
        // An icon clicked should perform the same action as it's label.
        private void btnprod_Click(object sender, EventArgs e)
        {
            labprod_MouseClick(sender, null);
        }

        private void btncust_Click(object sender, EventArgs e)
        {
            labcust_MouseClick(sender, null);
        }

        private void btncat_Click(object sender, EventArgs e)
        {
            labcats_MouseClick(sender, null);
        }

        private void btnusers_Click(object sender, EventArgs e)
        {
            labusers_MouseClick(sender, null);
        }

        private void btnorders_Click(object sender, EventArgs e)
        {
            laborders_MouseClick(sender, null);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You " +
                "Want To Log Out", "LOG OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                LoginPage login = new LoginPage();
                
                login.ShowDialog();
            }
        }
    }
}
