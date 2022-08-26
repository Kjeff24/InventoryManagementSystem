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
    public partial class OrderPage : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand sqlcommand = new SqlCommand();
        SqlDataReader sqldr;
        public OrderPage()
        {
            InitializeComponent();
            LoadOrder();
        }

        public void LoadOrder()
        {
            double totalAmt = 0;
            int j = 0;
            dgvOrder.Rows.Clear();
            sqlcommand = new SqlCommand("SELECT * FROM tbOrder WHERE CONCAT(orderid, orderdate, pid, pname, cid, cname, quantity, price, total) LIKE '%" + txtsearch.Text + "%'", sqlcon);
            sqlcon.Open();
            sqldr = sqlcommand.ExecuteReader();
            while (sqldr.Read())
            {
                j++;
                dgvOrder.Rows.Add(j, sqldr[0].ToString(), Convert.ToDateTime(sqldr[1].ToString()).ToString("dd/MM/yyyy"), sqldr[2].ToString(), sqldr[3].ToString(), sqldr[4].ToString(), sqldr[5].ToString(), sqldr[6].ToString(), sqldr[7].ToString(), sqldr[8].ToString());
                totalAmt += Convert.ToInt32(sqldr[8].ToString());
            }
            sqldr.Close();
            sqlcon.Close();

            lblOQty.Text = j.ToString();
            lblOAmnt.Text = totalAmt.ToString();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            OrderModulePage moduleForm = new OrderModulePage();
            moduleForm.ShowDialog();
            LoadOrder();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Do You Want To Delete This User", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcon.Open();
                    sqlcommand = new SqlCommand("DELETE FROM tbOrder WHERE orderid LIKE'" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", sqlcon);
                    sqlcommand.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show("Record has been deleted");

                    sqlcommand = new SqlCommand("UPDATE tbProduct SET pqty=(pqty+@pqty) WHERE pid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString() + "'", sqlcon);
                    sqlcommand.Parameters.AddWithValue("@pqty", Convert.ToInt32(dgvOrder.Rows[e.RowIndex].Cells[7].Value.ToString()));

                    sqlcon.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlcon.Close();
                   
                }
            }
            LoadOrder();
        }
    }
}
