using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Axioma.Celebrity.Fitness;

namespace RockStar.Training
{
    class fingerPrint_Device
    {
        private string mSerialNumber;
        private string mVerificationCode;
        private string mActivationCode;

        private const string mTemplateSafetyKey = "IT-RockStarGym"; //untuk finger print

        public string SerialNumber
        {
            get { return mSerialNumber; }
        }

        public string VerificationCode
        {
            get { return mVerificationCode; }
        }
        public string ActivationCode
        {
            get { return mActivationCode; }
        }
        public string TemplateSafetyKey
        {
            get { return mTemplateSafetyKey; }
        }


        /// <summary>
        /// get SerialNumber, VerificationCode, ActivationNumber from fpReader
        /// </summary>
        public void get_FileCode()
        {
            List<string> list = new List<string>();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\fpReader.txt"))
            {
                var fileStream = new System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory + @"\fpReader.txt", System.IO.FileMode.Open, System.IO.FileAccess.Read);
                using (var streamReader = new System.IO.StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Trim() != "")
                        {
                            list.Add(line);
                        }
                    }

                }
                fileStream.Close();
                if (list.Count == 3)
                {
                    mSerialNumber = list[0].Trim();//SN
                    mVerificationCode = list[1].Trim();//VC
                    mActivationCode = list[2].Trim();//AC
                }
                else
                {
                    mSerialNumber = "";//SN
                    mVerificationCode = "";//VC
                    mActivationCode = "";//AC
                    throw new Exception("File code not complete");
                }
            }
            else
            {
                throw new Exception("File activation code not found");
            }
        }


        SqlConnection myConnection = new SqlConnection(Partner.configConnection);
        /// <summary>
        /// check isInstructor, check Instructor already SignIn - FOR FINGER DEVICE
        /// </summary> 
        public DataTable integrity_ClassCheckTrainer_Finger(string instructor_NIK, int code_ClubClass, string ins_Type)
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
                command.Parameters.Clear();
                myConnection.Open();
                command.Connection = myConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 160;
                command.CommandText = "Module.SP_ClassCheckTrainer";
                command.Parameters.Add("@code", SqlDbType.NChar, 10).Value = instructor_NIK;
                command.Parameters.Add("@rfid", SqlDbType.NChar, 10).Value = "0";//0
                command.Parameters.Add("@useRfid", SqlDbType.NChar, 3).Value = "no";//no
                command.Parameters.Add("@clubClass", SqlDbType.BigInt).Value = code_ClubClass;
                command.Parameters.Add("@lead", SqlDbType.NChar, 1).Value = ins_Type;//" "
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
        /// check isInstructor, check Instructor already SignIn - FOR CARD
        /// </summary> 
        public DataTable integrity_ClassCheckTrainer_Card(string RFID, int code_ClubClass, string ins_Type)
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
                command.Parameters.Clear();
                myConnection.Open();
                command.Connection = myConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 160;
                command.CommandText = "Module.SP_ClassCheckTrainer";
                command.Parameters.Add("@code", SqlDbType.NChar, 10).Value = "0";
                command.Parameters.Add("@rfid", SqlDbType.NChar, 10).Value = RFID;
                command.Parameters.Add("@useRfid", SqlDbType.NChar, 3).Value = "yes";
                command.Parameters.Add("@clubClass", SqlDbType.BigInt).Value = code_ClubClass;
                command.Parameters.Add("@lead", SqlDbType.NChar, 1).Value = ins_Type;
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
        /// authorization cancel clubClass - For Finger
        /// </summary> 
        public DataTable auth_ClubClass_Finger(string employeeCode)
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
                command.Parameters.Clear();
                myConnection.Open();
                command.Connection = myConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 160;
                command.CommandText = "Module.SP_Authorization_Check_Code";
                command.Parameters.Add("@employeeCode", SqlDbType.NChar, 10).Value = employeeCode;

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
        /// authorization cancel clubClass - For Card
        /// </summary> 
        public DataTable auth_ClubClass_Card(string RFID)
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
                command.Parameters.Clear();
                myConnection.Open();
                command.Connection = myConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 160;
                command.CommandText = "Module.SP_Authorization_Check";
                command.Parameters.Add("@rfid", SqlDbType.NVarChar, 50).Value = RFID;

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
