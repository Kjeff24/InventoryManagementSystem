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
    public partial class OrderModulePage : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand sqlcommand = new SqlCommand();
        SqlDataReader sqldr;
        int quantity;
        public OrderModulePage()
        {
            InitializeComponent();
            LoadCustomer();
            LoadProduct();
            
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadCustomer()
        {
            int j = 0;
            dgvCustomer.Rows.Clear();
            sqlcommand = new SqlCommand("SELECT cid,cname FROM tbCustomer WHERE CONCAT(cid, cname) LIKE '%" + txtsearchcust.Text + "%'", sqlcon);
            sqlcon.Open();
            sqldr = sqlcommand.ExecuteReader();
            while (sqldr.Read())
            {
                j++;
                dgvCustomer.Rows.Add(j, sqldr[0].ToString(), sqldr[1].ToString());
            }
            sqldr.Close();
            sqlcon.Close();
        }

        public void LoadProduct()
        {
            int j = 0;
            dgvProduct.Rows.Clear();
            sqlcommand = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pid, pname, pprice,pdescription,pcategory) LIKE '%" + txtsearchprod.Text + "%' ", sqlcon);
            sqlcon.Open();
            sqldr = sqlcommand.ExecuteReader();
            while (sqldr.Read())
            {
                j++;
                dgvProduct.Rows.Add(j, sqldr[0].ToString(), sqldr[1].ToString(), sqldr[2].ToString(), sqldr[3].ToString(), sqldr[4].ToString(), sqldr[5].ToString());
            }
            sqldr.Close();
            sqlcon.Close();
        }

        private void txtsearchcust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtsearchprod_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
 

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GetQty();
            if(Convert.ToInt16(numericUpDown1.Value) > quantity)
            {
                MessageBox.Show("Instock Quantity is not enough", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDown1.Value--;
                return;
            }
            if (Convert.ToInt16(numericUpDown1.Value) > 0)
            {
                int total = Convert.ToInt16(txtpprice.Text) * Convert.ToInt16(numericUpDown1.Value);
                txtptotal.Text = total.ToString();
            }

        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcid.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtcname.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtpid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtpname.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtpprice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            //quantity = Convert.ToInt16(dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        
        public void ClearInput()
        {
            ordDate.Value = DateTime.Now;
            txtpid.Clear();
            txtcid.Clear();
            numericUpDown1.Value = 0;
            txtpprice.Clear();
            txtptotal.Clear();
            txtcname.Clear();
            txtpname.Clear();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearInput();
            btnordins.Enabled = true;
        }

        private void btnordins_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcid.Text == "")
                {
                    MessageBox.Show("Please Select A Customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtpid.Text == "")
                {
                    MessageBox.Show("Please Select A Product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Do You " +
                "Want To Insert This Order", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcommand = new SqlCommand("INSERT INTO tbOrder(orderdate, pid, pname, cid, cname, quantity, price, total)VALUES(@orderdate,@pid, @pname, @cid, @cname, @quantity,@price,@total)", sqlcon);
                    sqlcommand.Parameters.AddWithValue("@orderdate", ordDate.Value);
                    sqlcommand.Parameters.AddWithValue("@pid", Convert.ToInt32(txtpid.Text));
                    sqlcommand.Parameters.AddWithValue("@pname", txtpname.Text);
                    sqlcommand.Parameters.AddWithValue("@cid", Convert.ToInt32(txtcid.Text));
                    sqlcommand.Parameters.AddWithValue("@cname", txtcname.Text);
                    sqlcommand.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown1.Value));
                    sqlcommand.Parameters.AddWithValue("@price", Convert.ToInt32(txtpprice.Text));
                    sqlcommand.Parameters.AddWithValue("@total", Convert.ToInt32(txtptotal.Text));
                    sqlcon.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show("Order has successfully been inserted.");


                    sqlcommand = new SqlCommand("UPDATE tbProduct SET pqty=(pqty-@pqty) WHERE pid LIKE '" + txtpid.Text + "'", sqlcon);
                    sqlcommand.Parameters.AddWithValue("@pqty", Convert.ToInt32(numericUpDown1.Value));

                    sqlcon.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlcon.Close();
                    ClearInput();
                    LoadProduct();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public void GetQty()
        {
            sqlcommand = new SqlCommand("SELECT  pqty FROM tbProduct WHERE pid= '" + txtpid.Text + "' ", sqlcon);
            sqlcon.Open();
            sqldr = sqlcommand.ExecuteReader();
            while (sqldr.Read())
            {
                quantity = Convert.ToInt32(sqldr[0].ToString());
            }
            sqldr.Close();
            sqlcon.Close();
        }
    }
}
