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
    public partial class MainForm : Form
    {
        public MainForm()
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

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

        private void labprod_MouseClick(object sender, MouseEventArgs e)
        {
            openChildForm(new ProductForm());
            pane1.BackColor = Color.Black;
            pane2.BackColor = Color.Cyan;
            pane3.BackColor = Color.Cyan;
            pane4.BackColor = Color.Cyan;
            pane5.BackColor = Color.Cyan;
        }

        private void labcust_MouseClick(object sender, MouseEventArgs e)
        {
            openChildForm(new CustomerForm());
            pane1.BackColor = Color.Cyan;
            pane2.BackColor = Color.Black;
            pane3.BackColor = Color.Cyan;
            pane4.BackColor = Color.Cyan;
            pane5.BackColor = Color.Cyan;
        }

        private void labcats_MouseClick(object sender, MouseEventArgs e)
        {
            openChildForm(new CategoryForm());
            pane1.BackColor = Color.Cyan;
            pane2.BackColor = Color.Cyan;
            pane3.BackColor = Color.Black;
            pane4.BackColor = Color.Cyan;
            pane5.BackColor = Color.Cyan;
        }

        private void labusers_MouseClick(object sender, MouseEventArgs e)
        {
            openChildForm(new UserForm());
            pane1.BackColor = Color.Cyan;
            pane2.BackColor = Color.Cyan;
            pane3.BackColor = Color.Cyan;
            pane4.BackColor = Color.Black;
            pane5.BackColor = Color.Cyan;
        }

        private void laborders_MouseClick(object sender, MouseEventArgs e)
        {
            openChildForm(new OrderForm());
            pane1.BackColor = Color.Cyan;
            pane2.BackColor = Color.Cyan;
            pane3.BackColor = Color.Cyan;
            pane4.BackColor = Color.Cyan;
            pane5.BackColor = Color.Black;
        }

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
    }
}
