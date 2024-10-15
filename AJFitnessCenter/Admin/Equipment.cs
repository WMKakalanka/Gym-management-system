using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AJFitnessCenter.Admin
{
    public partial class Equipment : UserControl

        //Connection
    {
        ConnectionString_Funtions obj = new ConnectionString_Funtions();
        string query;
       
        public Equipment()
        {
            InitializeComponent();
        }

       




        //Save Button

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEID.Text != "" && txtEquipmentName.Text != "" && rtxtDescription.Text != "" && txtMusclesUse.Text != "" && txtCost.Text != "" && cmbQuantity.Text != "" && dtpOrderDate.Text != "")
            {
                try
                {
                    string EID = txtEID.Text;
                    string EName = txtEquipmentName.Text;
                    string Description = rtxtDescription.Text;
                    string Muscles = txtMusclesUse.Text;
                    string Cost = txtCost.Text;
                    string OrderDate = dtpOrderDate.Text;
                    string Quantity = cmbQuantity.Text;

                    query = "insert into Equipment(EID,EName,EDescription,MusclesUse,Cost,OrderDate,Quantity) values ('" + EID + "','" + EName + "','" + Description + "','" + Muscles + "','" + Cost + "','" + OrderDate + "','" + Quantity + "')";
                    obj.SetData(query, " Save Successfully!.");
                    txtEID.Clear();
                    txtEquipmentName.Clear();
                    rtxtDescription.Clear();
                    txtMusclesUse.Clear();
                    txtCost.Clear();
                    cmbQuantity.SelectedIndex = -1;
                    dtpOrderDate.ResetText();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Please Enter All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
           
        }




        //Clear Button


        private void btnClear_Click(object sender, EventArgs e)
        {

            try
            {
                txtEID.Clear();
                txtEquipmentName.Clear();
                rtxtDescription.Clear();
                txtMusclesUse.Clear();
                txtCost.Clear();
                cmbQuantity.SelectedIndex = -1;
                dtpOrderDate.ResetText();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //View Button



        private void btnView_Click(object sender, EventArgs e)
        {
            viewEquipments1.Visible = true;
            BringToFront();
        }

        private void Equipment_Load(object sender, EventArgs e)
        {
            viewEquipments1.Visible=false;
        }



        // Edit Button

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtEID.Text != "")

                try
                {
                    string EID = txtEID.Text;
                    string EName = txtEquipmentName.Text;
                    string Description = rtxtDescription.Text;
                    string Muscles = txtMusclesUse.Text;
                    string Cost = txtCost.Text;
                    string OrderDate = dtpOrderDate.Text;
                    string Quantity = cmbQuantity.Text;

                    query = "Update Equipment Set EName='" + EName + "',EDescription='" + Description + "',MusclesUse='" + Muscles + "',Cost='" + Cost + "',OrderDate='" + OrderDate + "',Quantity='" + Quantity + "'  WHERE EID ='" + EID + "'";
                    obj.SetData(query, " Update Successfully!.");
                    txtEID.Clear();
                    txtEquipmentName.Clear();
                    rtxtDescription.Clear();
                    txtMusclesUse.Clear();
                    txtCost.Clear();
                    cmbQuantity.SelectedIndex = -1;
                    dtpOrderDate.ResetText();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            else
            {
                MessageBox.Show("Please Enter Equipment ID First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
