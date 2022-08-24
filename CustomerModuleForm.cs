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
    public partial class CustomerModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        public CustomerModuleForm()
        {
            InitializeComponent();
        }

        private void closebtn_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You " +
                "Want To Save This Customer", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbCustomer(cname,cemail,cphone)VALUES(@cname,@cemail,@cphone)", con);
                    cm.Parameters.AddWithValue("@cname", txtcname.Text);
                    cm.Parameters.AddWithValue("@cemail", txtcemail.Text);
                    cm.Parameters.AddWithValue("@cphone", txtcphone.Text);
                    
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customer has been successfully saved.");
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
        }

        public void ClearInput()
        {
            txtcname.Clear();
            txtcemail.Clear();
            txtcphone.Clear();
            btnsave.Enabled = true;
            btnupd.Enabled = false;

        }

        private void btnupd_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You " +
                "Want To Update This Customer", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbCustomer SET cname=@cname,cemail=@cemail,cphone=@cphone WHERE cid LIKE '" + lblcust.Text + "'", con);
                    cm.Parameters.AddWithValue("@cname", txtcname.Text);
                    cm.Parameters.AddWithValue("@cemail", txtcemail.Text);
                    cm.Parameters.AddWithValue("@cphone", txtcphone.Text);
                   
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customer has successfully been updated.");
                    ClearInput();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
