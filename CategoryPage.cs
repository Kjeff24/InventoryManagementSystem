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
    public partial class CategoryPage : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand sqlcommand = new SqlCommand();
        SqlDataReader sqldr;
        public CategoryPage()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            int j = 0;
            dgvCategory.Rows.Clear();
            sqlcommand = new SqlCommand("SELECT * FROM tbCategory WHERE CONCAT(catid, catname) LIKE '%" + txtsearch.Text + "%'", sqlcon);
            sqlcon.Open();
            sqldr = sqlcommand.ExecuteReader();
            while (sqldr.Read())
            {
                j++;
                dgvCategory.Rows.Add(j, sqldr[0].ToString(), sqldr[1].ToString());
            }
            sqldr.Close();
            sqlcon.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            CategoryModulePage formModule= new CategoryModulePage();
            formModule.btnsave.Enabled = true;
            formModule.btnupd.Enabled = false;
            formModule.ShowDialog();
            LoadCategory();
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCategory.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                CategoryModulePage categoryrModule = new CategoryModulePage();
                categoryrModule.lblcat.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                categoryrModule.txtcatname.Text = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString();
              

                categoryrModule.btnsave.Enabled = false;
                categoryrModule.btnupd.Enabled = true;
                categoryrModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Do You Want To Delete This Category", "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlcon.Open();
                    sqlcommand = new SqlCommand("DELETE FROM tbCategory WHERE catid LIKE'" + dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", sqlcon);
                    sqlcommand.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show("Record has been deleted");
                }
            }
            LoadCategory();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            LoadCategory();
        }
    }
}
