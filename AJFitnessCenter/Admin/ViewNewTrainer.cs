using System;
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
    public partial class ViewNewTrainer : UserControl
    {
        ConnectionString_Funtions obj = new ConnectionString_Funtions();
        string query;

        public ViewNewTrainer()
        {
            InitializeComponent();
            ViewNewTrainer_Load(this, null);
        }



        // Exit Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            ViewNewTrainer ve = new ViewNewTrainer();
            ve.Visible = false;
            this.Hide();
        }

        private void ViewNewTrainer_Load(object sender, EventArgs e)
        {
            try
            {
                query = "Select * from New_Trainer";
                DataSet dataSet = obj.GetData(query);
                dgvViewTrainer.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Search Button

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from New_Trainer where TID like'" + txtSearch.Text + "%'";
            DataSet dataSet = obj.GetData(query);
            dgvViewTrainer.DataSource = dataSet.Tables[0];
        }



        //Table

        string Equname;
        private void dgvViewTrainer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Equname = dgvViewTrainer.Rows[e.RowIndex].Cells[2].Value.ToString();
            }

            catch (Exception ex)

            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        //Delete Button

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            try
            {
                if (MessageBox.Show("Are You Sure? ", "Delete Confirmation !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        string query = "DELETE FROM New_Trainer WHERE TID = '" + txtSearch.Text + "'";
                        obj.SetData(query, "User Record Deleted.");
                        MessageBox.Show("Record deleted successfully.");
                        ViewNewTrainer_Load(this, null);
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
                MessageBox.Show("Please Select Trainer ID for Delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
    }
}
