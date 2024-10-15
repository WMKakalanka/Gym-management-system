using AJFitnessCenter.Admin;
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
    public partial class Administrator : Form
    {
        
        public Administrator()
        {
            InitializeComponent();
        }
        

        //Log out button
        private void btnLogOutMain_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();

        }


        //load weddi penna ona eka home page eka 
        private void Administrator_Load(object sender, EventArgs e)
        {
            btnHome.PerformClick();
            
            newMember1.Visible = false;
            newTrainer1.Visible = false;
            equipment1.Visible = false;
            
            
           
        }


        //Member Button Click event

        private void btnMember_Click(object sender, EventArgs e)
        {
            newMember1.Visible = true;
            newMember1.BringToFront();

        }



        //Trainer Button Click event

        private void btnNewTrainer_Click(object sender, EventArgs e)
        {
            newTrainer1.Visible = true;
            newTrainer1.BringToFront();

        }


        //Equipment Button Click event

        private void btnEquipment_Click(object sender, EventArgs e)
        {
            equipment1.Visible = true;
            equipment1.BringToFront();
        }



        //Home Button Click event
        private void btnHome_Click(object sender, EventArgs e)
        {
           equipment1.Visible=false;
            newMember1 .Visible=false;
            newTrainer1.Visible=false;
            

        }

        private void newMember1_Load(object sender, EventArgs e)
        {

        }
    }
    
}
