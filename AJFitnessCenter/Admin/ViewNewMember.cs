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
    public partial class ViewNewMember : UserControl
    {
        
        ConnectionString_Funtions obj = new ConnectionString_Funtions();
        string query;
        public ViewNewMember()
        {
            InitializeComponent();
            {
                ViewNewMember_Load(this, null);
            }
           
        }

        //Exit Button

        private void btnExit_Click(object sender, EventArgs e)
        {
            ViewNewMember ve = new ViewNewMember();
            ve.Visible = false;
            this.Hide();
        }

        private void ViewNewMember_Load(object sender, EventArgs e)
        {
               try
            {
                query = "Select * from New_Member";
                DataSet dataSet = obj.GetData(query);
                dgvViewMember.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }


        //Serach Button
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from New_Member where MID like'" + txtSearch.Text + "%'";
            DataSet dataSet = obj.GetData(query);
            dgvViewMember.DataSource = dataSet.Tables[0];
        }


        string Equname;
        private void dgvViewMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Equname = dgvViewMember.Rows[e.RowIndex].Cells[2].Value.ToString();
            }

            catch (Exception ex)

            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        // Delete Button


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            try
            {
                if (MessageBox.Show("Are You Sure? ", "Delete Confirmation !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                  
                    try
                    {
                        string query = "DELETE FROM New_Member WHERE MID = '" + txtSearch.Text + "'";
                        obj.SetData(query, "User Record Deleted.");
                        MessageBox.Show("Record deleted successfully.");
                        ViewNewMember_Load(this, null);
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
                MessageBox.Show("Please Select Member ID for Delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      


       
    }
}
