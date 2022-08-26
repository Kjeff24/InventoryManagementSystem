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
    public partial class UserPage : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand sqlcommand = new SqlCommand();
        SqlDataReader sqldr;
        public UserPage()
        {
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()
        {
            int j = 0;
            dgvUser.Rows.Clear();
            sqlcommand = new SqlCommand("SELECT * FROM tbUser WHERE CONCAT(username,fullname,email,phone) LIKE '%" + txtsearch.Text + "%'", sqlcon);
            sqlcon.Open();
            sqldr = sqlcommand.ExecuteReader();
            while (sqldr.Read())
            {
                j++;
                dgvUser.Rows.Add(j, sqldr[0].ToString(), sqldr[1].ToString(), sqldr[2].ToString(), sqldr[3].ToString(), sqldr[4].ToString());
            }
            sqldr.Close();
            sqlcon.Close();
        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            UserModulePage userModule = new UserModulePage();
            userModule.btnsave.Enabled = true;
            userModule.btnupd.Enabled = false;
            userModule.ShowDialog();
            LoadUser();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                UserModulePage userModule = new UserModulePage();
                userModule.txtUser.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.txtfull.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.txtemail.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.txtphone.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();
                userModule.txtpass.Text = dgvUser.Rows[e.RowIndex].Cells[5].Value.ToString();

                userModule.btnsave.Enabled = false;
                userModule.btnupd.Enabled=true;
                userModule.txtUser.Enabled = false;
                userModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Do You Want To Delete This User", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcon.Open();
                    sqlcommand = new SqlCommand("DELETE FROM tbUser WHERE username LIKE'" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", sqlcon);
                    sqlcommand.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show("Record has been deleted");
                }
            }
            LoadUser();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            LoadUser();
        }
    }
}
