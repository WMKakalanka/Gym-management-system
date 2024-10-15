using System;
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
    public partial class ViewEquipments : UserControl

    {
        
        ConnectionString_Funtions obj = new ConnectionString_Funtions();
        string query;
        
        public ViewEquipments()
        {
            InitializeComponent();
        }

       

        //Exit Button
    
        private void btnExit_Click(object sender, EventArgs e)
        {
            ViewEquipments ve = new ViewEquipments();
            ve.Visible = false;
            this.Hide();
        }


        //Table 
        private void ViewEquipments_Load(object sender, EventArgs e)
        {
            try
            {
                query = "Select * from Equipment";
                DataSet dataSet = obj.GetData(query);
                dgvViewEquipment.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Search button
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from Equipment where EID like'"+txtSearch.Text+"%'";
            DataSet dataSet = obj.GetData(query);
            dgvViewEquipment.DataSource= dataSet.Tables[0];
        }

        string Equname;
        private void dgvViewEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Equname = dgvViewEquipment.Rows[e.RowIndex].Cells[2].Value.ToString();
            }

            catch (Exception ex)

            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
       
        }

        // Delete Button

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                try
            {
                if (MessageBox.Show("Are You Sure? ", "Delete Confirmation !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    try
                    {
                        string query = "DELETE FROM Equipment WHERE EID = '" + txtSearch.Text + "'";
                        obj.SetData(query, "User Record Deleted.");                       
                        MessageBox.Show("Record deleted successfully.");
                        ViewEquipments_Load(this, null);
                        txtSearch.Text = string.Empty; txtSearch.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting record: " + ex.Message);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Please Select Equipment ID for Delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
