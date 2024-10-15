using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AJFitnessCenter
{
    public class ConnectionString_Funtions
    {
        //connection string 
        protected SqlConnection GetConnection()
        {

            {
                SqlConnection conobj = new SqlConnection();
                conobj.ConnectionString = @"data source = KAVEEN;initial catalog = GYM_db;User ID = admin;Password =123";
                return conobj;

            }

        }


        public DataSet GetData(string query)
        {


            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet;

        }


        public void SetData(String query, string msg)
        {

            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(msg, "information", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}

   
