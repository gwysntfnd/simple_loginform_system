using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class load : Form
    {
        public load()
        {
            InitializeComponent();
            //This is the loading window.
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //This will set the size of the panel that will create a loading-like movement.
            panel3.Width += 3;
            if (panel3.Width >= 700)
            {
                //Execute the window when the timer stopped and bring the user to the log in form.
                timer1.Stop();
                new frmLogin().Show();
                this.Hide();
            }
        }
    }
}
