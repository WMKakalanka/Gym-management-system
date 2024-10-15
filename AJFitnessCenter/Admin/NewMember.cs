using System;

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AJFitnessCenter.Admin
{
    public partial class NewMember : UserControl
    {
        // create connectionstring class obj
        ConnectionString_Funtions obj = new ConnectionString_Funtions();
        string query;
        public NewMember()
        {
            InitializeComponent();
        }


        //Member Save Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMID.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && dtpDOB.Text != "" && txtMobileNo.Text != "" && txtEmail.Text != "" && dtpJoinDate.Text != "" && rtxtAddress.Text != "" && cmbGymTime.Text != "" && cmbMembership.Text != "")
                try
            {
                string MID = txtMID.Text;
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
                string gymtime = cmbGymTime.Text;
                string address = rtxtAddress.Text;
                string membership = cmbMembership.Text;

                query = "insert into New_Member(MID,FName,LName,Gender,DOB,Mobile,Email,JoinDate,GymTime,MAddress,MembershipTime) values ('" + MID + "','" + Fname + "','" + Lname + "','" + gender + "','" + DOB + "','" + Mobile + "','" + Email + "','" + joindate + "','" + gymtime + "','" + address + "','" + membership + "')";
                obj.SetData(query, " Save Successfully!.");
                    txtMID.Clear();
                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtEmail.Clear();
                    txtMobileNo.Clear();
                    dtpDOB.ResetText();
                    rtxtAddress.Clear();
                    cmbMembership.SelectedIndex = -1;
                    cmbGymTime.SelectedIndex = -1;
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



        //clear button


        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtMID.Clear(); 
                txtFirstName.Clear();
                txtLastName.Clear();
                txtEmail.Clear();
                txtMobileNo.Clear();
                dtpDOB.ResetText();
                rtxtAddress.Clear();
                cmbMembership.SelectedIndex = -1;
                cmbGymTime.SelectedIndex = -1;
                dtpJoinDate.ResetText();
                rdbtnMale.Checked = false;
                rdbtnFemale.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void NewMember_Load(object sender, EventArgs e)
        {

           viewNewMember2.Visible = false;
        }



        //view button

        private void btnView_Click_1(object sender, EventArgs e)
        {
            viewNewMember2.Visible = true;
            BringToFront();
           

        }


        //Edit button

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtMID.Text != "")
                try
                {
                    string MID = txtMID.Text;
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
                    string gymtime = cmbGymTime.Text;
                    string address = rtxtAddress.Text;
                    string membership = cmbMembership.Text;

                    query = "Update New_Member Set FName='" + Fname + "', LName='" + Lname + "',Gender='" + gender + "',DOB='" + DOB + "',Mobile='" + Mobile + "',Email='" + Email + "',JoinDate='" + joindate + "',GymTime='" + gymtime + "',MAddress='" + address + "',MembershipTime='" + membership + "'  WHERE MID='" + MID + "'";
                    obj.SetData(query, " Update Successfully!.");
                    txtMID.Clear();
                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtEmail.Clear();
                    txtMobileNo.Clear();
                    dtpDOB.ResetText();
                    rtxtAddress.Clear();
                    cmbMembership.SelectedIndex = -1;
                    cmbGymTime.SelectedIndex = -1;
                    dtpJoinDate.ResetText();
                    rdbtnMale.Checked = false;
                    rdbtnFemale.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            else
            {
                MessageBox.Show("Please Enter Member ID First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            
        }
    }
    
}
