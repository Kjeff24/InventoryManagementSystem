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
    public partial class OrderModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public OrderModuleForm()
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
            cm = new SqlCommand("SELECT cid,cname FROM tbCustomer WHERE CONCAT(cid, cname) LIKE '%" + txtsearchcust.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                j++;
                dgvCustomer.Rows.Add(j, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }

        public void LoadProduct()
        {
            int j = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pid, pname, pprice,pdescription,pcategory) LIKE '%" + txtsearchprod.Text + "%' ", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                j++;
                dgvProduct.Rows.Add(j, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void txtsearchcust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtsearchprod_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        int quantity;
 

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt16(numericUpDown1.Value) > quantity)
            {
                MessageBox.Show("Instock Quantity is not enough", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDown1.Value--;
                return;
            }
            int total = Convert.ToInt16(txtpprice.Text) + Convert.ToInt16(numericUpDown1.Value);
            txtptotal.Text = total.ToString();

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
            quantity = Convert.ToInt16(dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString());
        }
    }
}
