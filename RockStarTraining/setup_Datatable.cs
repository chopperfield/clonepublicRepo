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


namespace RockStar.Training
{
    class setup_Datatable
    {
        SqlConnection myConnection = new SqlConnection(Partner.configConnection);
        Axioma.Celebrity.Fitness.Partner partner = new Partner();

            
        /// <summary>
        /// Retrieve ALL Stundent Private Session that is currently running
        /// </summary>
        /// <returns>Bool</returns>
        public DataTable datatable_Training_Running(bool isAll, string codeClub)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
            try
            {
                myConnection.Open();

                command.Connection = myConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                command.CommandText = "Module.SP_Training_Running";
                command.Parameters.Add("@isAll", SqlDbType.Bit).Value = isAll;
                command.Parameters.Add("@club", SqlDbType.NChar, 3).Value = codeClub;
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


        /// <summary>
        /// Retrieve limit1,limit2,loadDate1 and loadDate2 based on transaction period name
        /// </summary>
        /// <returns>Datatable</returns>
        public DataTable dataTable_TransactionPeriod(string trans_Name)
        {
            SqlCommand command = new SqlCommand();

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
            try
            {
                dt.Clear();
                myConnection.Open();
                command.CommandTimeout = 180;

                command.Connection = myConnection;
                command.CommandText = "select limit1,limit2,loadDate1,loadDate2 from Platform.period with (nolock) where period = @period";
                command.Parameters.AddWithValue("@period", trans_Name);

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

        /// <summary>
        /// Retrieve codeClubUser
        /// </summary>
        /// <returns>Datatable</returns>
        public DataTable dataTable_code_UserClub(string NIK)
        {
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
            try
            {
                dt.Clear();
                myConnection.Open();
                command.CommandTimeout = 180;

                command.Connection = myConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Module.SP_PassClub";
                command.Parameters.Add("@userid", SqlDbType.NChar, 10).Value = NIK;
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


        /// <summary>
        /// retrive RGP and StudentName by RFID
        /// </summary>
        /// <param name="RFID"></param>
        /// <returns></returns>
        public DataTable datatable_Student_RGP(string RFID)
        {
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
            try
            {
                dt.Clear();
                myConnection.Open();
                command.CommandTimeout = 180;

                command.Connection = myConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT code AS RGP, preferredName" +
                                    " FROM Module.member with (nolock) " +
                                    " WHERE rfid = @rfid";
                command.Parameters.AddWithValue("@rfid", RFID);
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

        /// <summary>
        /// Retrieve list of student's Private instruction 
        /// </summary>
        /// <param name="RGP"></param>
        /// <returns></returns>
        public DataTable datatable_PrivateInstruction(int RGP)
        {
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
            try
            {
                dt.Clear();
                myConnection.Open();
                command.CommandTimeout = 180;

                command.Connection = myConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Module.SP_Training_Help_MemberControl";
                command.Parameters.Add("@member", SqlDbType.BigInt).Value= RGP;
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


         /// <summary>
        /// Retrieve finger Print, 1 = isAll, 0 = specific
        /// </summary>
        /// <returns>Datatable</returns>
        public DataTable dataTable_fingerPrint(bool isAll, string employee)
        {
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
            try
            {
                dt.Clear();
                myConnection.Open();
                command.Parameters.Clear();
                command.Connection = myConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                command.CommandText = "Addon.SP_EmployeeFingerprint_Load";
                command.Parameters.Add("@isAll", SqlDbType.Bit).Value = isAll;
                command.Parameters.Add("@employee", SqlDbType.NChar, 10).Value = employee;
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


        /// <summary>
        /// get instructor rfid info
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public DataTable datatable_instructor_RFID(string rfid)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
            try
            {
                myConnection.Open();

                command.Connection = myConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 180;
                command.CommandText = "Module.SP_TrainingCheckTrainer";
                command.Parameters.Add("@rfid", SqlDbType.NChar, 10).Value = rfid;
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
