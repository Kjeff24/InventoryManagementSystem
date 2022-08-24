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
    public partial class ProductModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public ProductModuleForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            comboQty.Items.Clear();
            cm = new SqlCommand("SELECT catname FROM tbCategory", con);
            con.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                comboQty.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void ClearInput()
        {
            txtprodName.Clear();
            txtprodQuan.Clear();
            txtprodPrice.Clear();
            txtprodDes.Clear();
            comboQty.Text = "";

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearInput();
            btnsave.Enabled = true;
            btnupd.Enabled = false;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Do You " +
                "Want To Save This Product", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbProduct(pname,pqty,pprice,pdescription,pcategory)VALUES(@pname,@pqty,@pprice,@pdescription,@pcategory)", con);
                    cm.Parameters.AddWithValue("@pname", txtprodName.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtprodQuan.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtprodPrice.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtprodDes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboQty.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has successfully been saved.");
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnupd_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You " +
                "Want To Update This Product", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbProduct SET pname=@pname,pqty=@pqty,pprice=@pprice,pdescription=@pdescription,pcategory=@pcategory WHERE pid LIKE '" + lblpid.Text + "'", con);
                    cm.Parameters.AddWithValue("@pname", txtprodName.Text);
                    cm.Parameters.AddWithValue("@pqty", txtprodQuan.Text);
                    cm.Parameters.AddWithValue("@pprice", txtprodPrice.Text);
                    cm.Parameters.AddWithValue("@pdescription", txtprodDes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboQty.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has successfully been updated.");
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
