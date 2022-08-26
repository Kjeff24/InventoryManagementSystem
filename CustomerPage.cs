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
    public partial class CustomerPage : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand sqlcommand = new SqlCommand();
        SqlDataReader sqldr;
        public CustomerPage()
        {
            InitializeComponent();
            LoadCustomer();
        }

        public void LoadCustomer()
        {
            int j = 0;
            dgvCustomer.Rows.Clear();
            sqlcommand = new SqlCommand("SELECT * FROM tbCustomer WHERE CONCAT(cid,cname,cemail,cphone) LIKE '%" + txtsearch.Text + "%'", sqlcon);
            sqlcon.Open();
            sqldr = sqlcommand.ExecuteReader();
            while (sqldr.Read())
            {
                j++;
                dgvCustomer.Rows.Add(j, sqldr[0].ToString(), sqldr[1].ToString(), sqldr[2].ToString(), sqldr[3].ToString());
            }
            sqldr.Close();
            sqlcon.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            CustomerModulePage moduleForm = new CustomerModulePage();
            moduleForm.btnsave.Enabled = true;
            moduleForm.btnupd.Enabled = false;
            moduleForm.ShowDialog();
            LoadCustomer();

        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                CustomerModulePage customerModule = new CustomerModulePage();
                customerModule.lblcust.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                customerModule.txtcname.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                customerModule.txtcemail.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();

                customerModule.btnsave.Enabled = false;
                customerModule.btnupd.Enabled = true;
                customerModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Do You Want To Delete This Customer", "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcon.Open();
                    sqlcommand = new SqlCommand("DELETE FROM tbCustomer WHERE cid LIKE'" + dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", sqlcon);
                    sqlcommand.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show("Record has been deleted");
                }
            }
            LoadCustomer();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }
    }
}
