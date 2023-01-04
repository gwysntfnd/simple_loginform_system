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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
            //This is the registration window.

        }
        //Database connection objects declaration
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Register button funtion to run the validations and register query.
                if (txtUsername.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "")//Show message if the fields are empty
                {
                    MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                //Inserting inputs to the database in the SQL query string
                else if (txtPassword.Text == txtComPassword.Text)
                {
                    con.Open();
                    string register = "INSERT INTO tbl_users VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "')";
                    cmd = new OleDbCommand(register, con);
                    //Executes a Transact-SQL statement against the connection and returns the number of rows affected.
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtComPassword.Text = "";

                    MessageBox.Show("Your Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Passwords does not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = "";
                    txtComPassword.Text = "";
                    txtPassword.Focus();
                }
            }
            catch(Exception ex) //To catch the error when user input an existing account or data
            {
                MessageBox.Show("Error Occured: " + ex.Message, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtComPassword.Text = "";
            }  
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            //Check box function to show the password
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtComPassword.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Clear button function. This will clear every text box when the button is clicked.
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //This will send the user to the Login form when the label is clicked.
            new frmLogin().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //This will close and execute the form when the button is clicked.
            Environment.Exit(0);
        }
    }
}
