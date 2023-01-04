using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;//import library

namespace WindowsFormsApp1
{
    public partial class frmLogin : Form
    {
        public static string username;
        public frmLogin()
        {
            InitializeComponent();
            //This is the log-in window.
            
        }
        // Declaration of database objects to use later in the login action
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //This will run the validations and the login query, when the log in button is clicked. 
                username = txtUsername.Text;
                con.Open();
                // //Selecting inputs from the database. 
                string login = "SELECT * FROM tbl_users WHERE username= '" + txtUsername.Text + "' and password= '" + txtPassword.Text + "'";
                cmd = new OleDbCommand(login, con);
                //Sends the CommandText to the Connection and builds a SqlDataReader.
                OleDbDataReader dr = cmd.ExecuteReader();
                

                if (dr.Read() == true)
                {
                    //The Form which will appear after loggin in
                    new loading().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Focus();
                }
            }
            catch (Exception ex) //Catching the open connection by closing it.
            { 
                MessageBox.Show("Error Occured: Please Try again, " + ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //This will clear every text box when the button is clicked.
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            //Check box function to show the password
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';

            }
            else
            {
                txtPassword.PasswordChar = '•';

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //This will send the user to the registration form when the label is clicked.
            new frmRegister().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //This will close and execute the form when the button is clicked.
            Environment.Exit(0);
        }
    }
}
