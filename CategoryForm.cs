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
    public partial class CategoryForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public CategoryForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            int j = 0;
            dgvCategory.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbCategory WHERE CONCAT(catid, catname) LIKE '%" + txtsearch.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                j++;
                dgvCategory.Rows.Add(j, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            CategoryModuleForm formModule= new CategoryModuleForm();
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
                CategoryModuleForm categoryrModule = new CategoryModuleForm();
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
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbCategory WHERE catid LIKE'" + dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
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
