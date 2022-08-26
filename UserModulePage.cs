using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagementSystem
{
    public partial class UserModulePage : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand sqlcommand = new SqlCommand();
        public UserModulePage()
        {
            InitializeComponent();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtpass.Text != txtconpass.Text)
                {
                    MessageBox.Show("Password Did Not Match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Do You " +
                "Want To Save This User", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcommand = new SqlCommand("INSERT INTO tbUser(username,fullname,email,phone,password)VALUES(@username,@fullname,@email,@phone,@password)", sqlcon);
                    sqlcommand.Parameters.AddWithValue("@username", txtUser.Text);
                    sqlcommand.Parameters.AddWithValue("@fullname", txtfull.Text);
                    sqlcommand.Parameters.AddWithValue("@email", txtemail.Text);
                    sqlcommand.Parameters.AddWithValue("@phone", txtphone.Text);
                    sqlcommand.Parameters.AddWithValue("@password", txtpass.Text);
                    sqlcon.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show("User has successfully been saved.");
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearInput();
            btnsave.Enabled = true;
            btnupd.Enabled = false;

        }

        public void ClearInput()
        {
            txtUser.Clear();
            txtfull.Clear();
            txtemail.Clear();
            txtphone.Clear();
            txtpass.Clear();
            txtconpass.Clear();
        }

        private void btnupd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtpass.Text != txtconpass.Text)
                {
                    MessageBox.Show("Password Did Not Match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Do You " +
                "Want To Update This User", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcommand = new SqlCommand("UPDATE tbUser SET username=@username,fullname=@fullname,email=@email,phone=@phone,password=@password WHERE username LIKE '"+ txtUser.Text  + "'", sqlcon);
                    sqlcommand.Parameters.AddWithValue("@username", txtUser.Text);
                    sqlcommand.Parameters.AddWithValue("@fullname", txtfull.Text);
                    sqlcommand.Parameters.AddWithValue("@email", txtemail.Text);
                    sqlcommand.Parameters.AddWithValue("@phone", txtphone.Text);
                    sqlcommand.Parameters.AddWithValue("@password", txtpass.Text);
                    sqlcon.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show("User has successfully been updated.");
                    ClearInput();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkpassword_CheckedChanged(object sender, EventArgs e)
        {

            if (checkpassword.Checked == false)
            {
                txtpass.UseSystemPasswordChar = true;
                txtconpass.UseSystemPasswordChar = true;
            }
            else
            {
                txtpass.UseSystemPasswordChar = false;
                txtconpass.UseSystemPasswordChar = false;
            }
        }
    }
}
