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
    public partial class ProductModulePage : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand sqlcommand = new SqlCommand();
        SqlDataReader sqldr;

        public ProductModulePage()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            comboQty.Items.Clear();
            sqlcommand = new SqlCommand("SELECT catname FROM tbCategory", sqlcon);
            sqlcon.Open();
            sqldr = sqlcommand.ExecuteReader();

            while (sqldr.Read())
            {
                comboQty.Items.Add(sqldr[0].ToString());
            }
            sqldr.Close();
            sqlcon.Close();

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
            txtbarcode.Clear();

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
                    sqlcommand = new SqlCommand("INSERT INTO tbProduct(pname,pqty,pprice,pdescription,pcategory, pbarcode)VALUES(@pname,@pqty,@pprice,@pdescription,@pcategory, @pbarcode)", sqlcon);
                    sqlcommand.Parameters.AddWithValue("@pname", txtprodName.Text);
                    sqlcommand.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtprodQuan.Text));
                    sqlcommand.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtprodPrice.Text));
                    sqlcommand.Parameters.AddWithValue("@pdescription", txtprodDes.Text);
                    sqlcommand.Parameters.AddWithValue("@pcategory", comboQty.Text);
                    sqlcommand.Parameters.AddWithValue("@pbarcode", Convert.ToInt64(txtbarcode.Text));
                    sqlcon.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlcon.Close();
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
                    sqlcommand = new SqlCommand("UPDATE tbProduct SET pname=@pname,pqty=@pqty,pprice=@pprice,pdescription=@pdescription,pcategory=@pcategory, pbarcode=@pbarcode WHERE pid LIKE '" + lblpid.Text + "'", sqlcon);
                    sqlcommand.Parameters.AddWithValue("@pname", txtprodName.Text);
                    sqlcommand.Parameters.AddWithValue("@pqty", txtprodQuan.Text);
                    sqlcommand.Parameters.AddWithValue("@pprice", txtprodPrice.Text);
                    sqlcommand.Parameters.AddWithValue("@pdescription", txtprodDes.Text);
                    sqlcommand.Parameters.AddWithValue("@pcategory", comboQty.Text);
                    sqlcommand.Parameters.AddWithValue("@pbarcode", txtbarcode.Text);
                    sqlcon.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlcon.Close();
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

        private void bntgenerate_Click(object sender, EventArgs e)
        {
            string barcode = txtbarcode.Text;
            try
            {
                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pboxbarcode.Image = brCode.Draw(barcode, 100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
