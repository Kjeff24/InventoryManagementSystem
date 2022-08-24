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
    public partial class UserForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public UserForm()
        {
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()
        {
            int j = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbUser WHERE CONCAT(username,fullname,email,phone) LIKE '%" + txtsearch.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                j++;
                dgvUser.Rows.Add(j, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            }
            dr.Close();
            con.Close();
        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            UserModuleForm userModule = new UserModuleForm();
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
                UserModuleForm userModule = new UserModuleForm();
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
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbUser WHERE username LIKE'" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
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
