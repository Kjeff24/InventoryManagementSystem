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
    
    public partial class CategoryModulePage : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand sqlcommand = new SqlCommand();
        public CategoryModulePage()
        {
            InitializeComponent();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void ClearInput()
        {
            txtcatname.Clear();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Do You " +
                "Want To Save This Category", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcommand = new SqlCommand("INSERT INTO tbCategory(catname)VALUES(@catname)", sqlcon);
                    sqlcommand.Parameters.AddWithValue("@catname", txtcatname.Text);

                    sqlcon.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show("Category has been successfully saved.");
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

        private void btnupd_Click(object sender, EventArgs e)
        { 
            try
            {
                if (MessageBox.Show("Do You " +
                "Want To Update This Category", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcommand = new SqlCommand("UPDATE tbCategory SET catname=@catname WHERE catid LIKE '" + lblcat.Text + "'", sqlcon);
                    sqlcommand.Parameters.AddWithValue("@catname", txtcatname.Text);

                    sqlcon.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show("Category has successfully been updated.");
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
