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
    public partial class LoginPage : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KJEFF\Documents\DBMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand sqlcommand = new SqlCommand();
        SqlDataReader sqldr;
        public LoginPage()
        {
            InitializeComponent();
        }

        // Close button closes the application
        private void closebtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You " +
                "Want To Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        // Checkbox to show password
        private void checkpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkpassword.Checked == false)
                textbPassword.UseSystemPasswordChar = true;
            else
                textbPassword.UseSystemPasswordChar = false;
        }

        // Allows users to log into the application
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcommand = new SqlCommand("SELECT * FROM tbUser WHERE username=@username AND password=@password", sqlcon);
                sqlcommand.Parameters.AddWithValue("@username", textbUsername.Text);
                sqlcommand.Parameters.AddWithValue("@password", textbPassword.Text);
                sqlcon.Open();
                sqldr = sqlcommand.ExecuteReader();
                sqldr.Read();
                if (sqldr.HasRows)
                {
                    MessageBox.Show("Hello " + sqldr["fullname"].ToString(), "AUTHORIZED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainPage main = new MainPage();
                    this.Hide();
                    main.ShowDialog();  
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "UNAUTHORIZED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MainPage main = new MainPage();
                }
                sqlcon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Enter key calls the btnlogin_Click method
        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnlogin_Click(sender, null);
            }
        }

        
    }
}