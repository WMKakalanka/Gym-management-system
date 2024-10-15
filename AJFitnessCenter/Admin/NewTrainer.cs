using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AJFitnessCenter.Admin
{
    public partial class NewTrainer : UserControl
    {// create connectionstring class obj
        ConnectionString_Funtions obj = new ConnectionString_Funtions();
        string query;
        public NewTrainer()
        {
            InitializeComponent();
        }


        //Save Button

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTID.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && dtpDOB.Text != "" && txtMobileNo.Text != "" && txtEmail.Text != "" && dtpJoinDate.Text != "" && rtxtAddress.Text != "" && txtCity.Text != "" )
                try
            {
                string TID = txtTID.Text;
                string Fname = txtFirstName.Text;
                string Lname = txtLastName.Text;
                string gender = "";
                bool ischecked = rdbtnMale.Checked;
                if (ischecked)
                {
                    gender = rdbtnMale.Text;
                }
                else
                {
                    gender = rdbtnFemale.Text;
                }
                string DOB = dtpDOB.Text;
                Int64 Mobile = Int64.Parse(txtMobileNo.Text);
                string Email = txtEmail.Text;
                string joindate = dtpJoinDate.Text;
                string address = rtxtAddress.Text;
                string City = txtCity.Text;
         

                query = "insert into New_Trainer(TID,FName,LName,Gender,DOB,Mobile,Email,JoinDate,TAddress,City) values ('" + TID + "','" + Fname + "','" + Lname + "','" + gender + "','" + DOB + "','" + Mobile + "','" + Email + "','" + joindate + "','" + address + "','" + City + "')";
                obj.SetData(query, " Save Successfully!.");
                    txtTID.Clear();
                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtEmail.Clear();
                    txtMobileNo.Clear();
                    dtpDOB.ResetText();
                    rtxtAddress.Clear();
                    txtCity.Clear();
                    dtpJoinDate.ResetText();
                    rdbtnMale.Checked = false;
                    rdbtnFemale.Checked = false;
                }
            catch (Exception ex)
            {
                MessageBox.Show("Please Enter Mobile Number Correctly !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
            {
                MessageBox.Show("Please Enter All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        //Clear Button

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtTID.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtEmail.Clear();
                txtMobileNo.Clear();
                dtpDOB.ResetText();
                rtxtAddress.Clear();
                txtCity.Clear();
                dtpJoinDate.ResetText();
                rdbtnMale.Checked = false;
                rdbtnFemale.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void NewTrainer_Load(object sender, EventArgs e)
        {
            viewNewTrainer1.Visible = false;
        }


        //View Button

        private void btnView_Click_1(object sender, EventArgs e)
        {
            viewNewTrainer1.Visible = true;
            BringToFront();
        }



        //Edit Button


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtTID.Text != "")
                try
            {
                string TID = txtTID.Text;
                string Fname = txtFirstName.Text;
                string Lname = txtLastName.Text;
                string gender = "";
                bool ischecked = rdbtnMale.Checked;
                if (ischecked)
                {
                    gender = rdbtnMale.Text;
                }
                else
                {
                    gender = rdbtnFemale.Text;
                }
                string DOB = dtpDOB.Text;
                Int64 Mobile = Int64.Parse(txtMobileNo.Text);
                string Email = txtEmail.Text;
                string joindate = dtpJoinDate.Text;
                string address = rtxtAddress.Text;
                string City = txtCity.Text;

                query = "Update New_Trainer Set FName='" + Fname + "', LName='" + Lname + "',Gender='" + gender + "',DOB='" + DOB + "',Mobile='" + Mobile + "',Email='" + Email + "',JoinDate='" + joindate + "',TAddress='" + address + "',City='" + City + "'  WHERE TID='" + TID + "'";
                obj.SetData(query, " Update Successfully!.");
                txtTID.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtEmail.Clear();
                txtMobileNo.Clear();
                dtpDOB.ResetText();
                rtxtAddress.Clear();
                txtCity.Clear();
                dtpJoinDate.ResetText();
                rdbtnMale.Checked = false;
                rdbtnFemale.Checked = false;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            { MessageBox.Show("Please Enter Trainer ID First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
            
        }
    }
}
