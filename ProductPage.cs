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
    public partial class ProductPage : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand sqlcommand = new SqlCommand();
        SqlDataReader sqldr;
        public ProductPage()
        {
            InitializeComponent();
            LoadProduct();
        }

        public void LoadProduct()
        {
            int j = 0;
            dgvProduct.Rows.Clear();
            sqlcommand = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pid, pname,pprice,pdescription,pcategory, pbarcode) LIKE '%" + txtsearch.Text + "%' ", sqlcon);
            sqlcon.Open();
            sqldr = sqlcommand.ExecuteReader();
            while (sqldr.Read())
            {
                j++;
                dgvProduct.Rows.Add(j, sqldr[0].ToString(), sqldr[1].ToString(), sqldr[2].ToString(), sqldr[3].ToString(), sqldr[4].ToString(), sqldr[5].ToString(), sqldr[6].ToString());
            }
            sqldr.Close();
            sqlcon.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            ProductModulePage userModule = new ProductModulePage();
            userModule.btnsave.Enabled = true;
            userModule.btnupd.Enabled = false;
            userModule.ShowDialog();
            LoadProduct();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                ProductModulePage productModule = new ProductModulePage(); 
                productModule.lblpid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule.txtprodName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.txtprodQuan.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                productModule.txtprodPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.txtprodDes.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.comboQty.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                productModule.txtbarcode.Text = dgvProduct.Rows[e.RowIndex].Cells[7].Value.ToString();

                productModule.btnsave.Enabled = false;
                productModule.btnupd.Enabled = true;
                productModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Do You Want To Delete This Product", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcon.Open();
                    sqlcommand = new SqlCommand("DELETE FROM tbProduct WHERE pid LIKE'" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", sqlcon);
                    sqlcommand.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show("Record has been deleted");
                }
            }
            LoadProduct();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
