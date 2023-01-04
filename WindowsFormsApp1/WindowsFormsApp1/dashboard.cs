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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
            //This is the dashboard.

        }
        //Database connection objects declaration
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button2_Click(object sender, EventArgs e)
        {
            //This will send the user to the loading form when the button is clicked.
            new load().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This will close and execute the form when the button is clicked.
            Environment.Exit(0);
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            //Will get the public string data to display the username in the dashboard.
            label1.Text = "Welcome back, " + frmLogin.username;
        }
    }
}
