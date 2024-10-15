using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AJFitnessCenter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        // Exit Button


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Clear Button

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();

        }


        //Login Button


        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            if (txtUserName.Text == "admin" && txtPassword.Text == "123")
            {
                // next page go
                Administrator obj = new Administrator();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username OR password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // messagebox designs
            }
        }

        
    }
}
