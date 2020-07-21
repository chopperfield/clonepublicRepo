using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Axioma.Celebrity.Fitness;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.IO;
using System.Drawing.Drawing2D;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraBars.Alerter;

namespace RockStar.Training
{
    class check_Integrity
    {
        SqlConnection myConnection = new SqlConnection(Partner.configConnection);

        /// <summary>
        /// check Integrity void PI usage
        /// </summary>               
        public DataTable integrity_void_PI(int trainingUsage)
        {
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            try
            {
                dt.Clear();
                command.Parameters.Clear();
                myConnection.Open();
                command.Connection = myConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Module.SP_Integrity_Training_Running";
                command.Parameters.Add("@counter",SqlDbType.BigInt).Value = trainingUsage;
                adapter.SelectCommand = command;
                adapter.Fill(dt);                
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
            finally
            {
                myConnection.Close();
            }        
            return dt;          
        }
       
    }
}