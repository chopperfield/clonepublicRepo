using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Axioma.Celebrity.Fitness;
using System.IO;
using System.Media;
using FastCodeSDK;

namespace RockStar.Training
{
    public partial class PT_fingerVerify : Form
    {
        SqlConnection myConnection = new SqlConnection(Partner.configConnection);

        Bitmap gbr_inf = new Bitmap(Properties.Resources.info_icon, 25, 25);
        Bitmap gbr_warn = new Bitmap(Properties.Resources.warning, 25, 25);

        //finger
        DataTable _dt_ins_fingerPrint;
        FastCodeSDK.FPReader myReader;
        fingerPrint_Device fingerPrint_Device = new fingerPrint_Device();


        string _studentName;
        string _clubName;
        string _productName;
        string _instructorName;
        string _room;

        public PT_fingerVerify(DataTable dt_finger,string clubName, string room ,string productName, string studentName, string instructorName)
        {
            InitializeComponent();            
            _dt_ins_fingerPrint = dt_finger;           

            _clubName = clubName;
            _productName = productName;        
            _studentName = studentName;
            _instructorName = instructorName;
            _room = room;
        }

        private void PT_fingerVerify_Load(object sender, EventArgs e)
        {
            Bitmap logo = new Bitmap(Properties.Resources.Logo_RSG);
            pictureEdit_Logo.Image = logo;

            lb_clubName.Text = _clubName;
            lb_productName.Text = _productName;
            lb_Instructor_Name.Text = "Instructor: "+_instructorName;
            lb_Room.Text = "Room: " + _room;
            lb_Student_Name.Text = _studentName.Trim();

            try //cuman buat getFileCode (pakai throw) karena pada event load execute tiap code sblom di close)
            {
                myReader = new FPReader();
                myReader.GetReaders();
                list_event();

                fingerPrint_Device.get_FileCode();

                if (myReader.ReaderCount > 0)
                {
                    myReader.SelectReader(fingerPrint_Device.VerificationCode, fingerPrint_Device.SerialNumber, fingerPrint_Device.ActivationCode.Trim(), FPReader.ReaderPriority.Low);
                  
                    foreach (Control ctl in this.Controls)
                    {
                        ctl.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Fingerprint reader device not found", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void PT_fingerVerify_Shown(object sender, EventArgs e)
        {
            try
            {
                string TemplateSafetyKey = fingerPrint_Device.TemplateSafetyKey;
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(form_Wait));
                
                foreach (DataRow row in _dt_ins_fingerPrint.Rows)
                {
                    int finger = Convert.ToInt32(row["fingerID"]);//get fingerindexes
                    FPReader.FingerIndex fingerIndex = (FPReader.FingerIndex)finger;//convert fingerindex
                    string employeeID = row["employee"].ToString();
                    string fingerTemplate = row["fingerprint"].ToString();//template
                    myReader.FPLoad(employeeID, fingerIndex, fingerTemplate, TemplateSafetyKey);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                foreach (Control ctl in this.Controls)
                {
                    ctl.Enabled = true;
                }
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
                myReader.FPIdentificationID += new FPReader.FPIdentificationIDEventHandler(MyReader_FPIdentificationID);
                myReader.FPIdentificationStatus += new FPReader.FPIdentificationStatusEventHandler(MyReader_FPIdentificationStatus);
                myReader.FPIdentificationStart(5);
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       

        private void list_event()
        {
            myReader.ErrorEvent += new FPReader.ErrorEventEventHandler(myReader_FPErrorEvent);//show error
            myReader.FPReaderStatus += new FPReader.FPReaderStatusEventHandler(myReader_FPReaderStatus);// perintah selectreader akan memicu FPReaderStatus             
          
        }

        private void MyReader_FPIdentificationStatus(FPReader.IdentificationStatus Status)
        {            
            if(Status == FPReader.IdentificationStatus.EmptyTemplateList || Status == FPReader.IdentificationStatus.Fail || Status == FPReader.IdentificationStatus.MultiCandidates)
            {
                MessageBox.Show(Status.ToString(),"Axioma Agent",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if(Status == FPReader.IdentificationStatus.OneCandidate)
            {
                if (!string.IsNullOrEmpty(instructor_FingerID))
                {
                    authorization_verifyClubClass(instructor_FingerID);
                }
            }
            if (Status == FPReader.IdentificationStatus.NoCandidate)                
            {            
                MessageBox.Show("Fingerprint does not match with any candidate", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string instructor_FingerID;
        private void MyReader_FPIdentificationID(string ID, FPReader.FingerIndex FpIndex)
        {
            instructor_FingerID = ID.Trim();         
        }

        private void myReader_FPReaderStatus(FPReader.ReaderStatus Status)
        {
            if (Status == FPReader.ReaderStatus.NoReaderSelected || Status == FPReader.ReaderStatus.ReaderDisconnected || Status == FPReader.ReaderStatus.InvalidActivationCode || Status == FPReader.ReaderStatus.NoReader)
            {
                MessageBox.Show(Status.ToString(), "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            if(Status == FPReader.ReaderStatus.PleaseRescan)
            {
                MessageBox.Show(Status.ToString(), "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void myReader_FPErrorEvent(string ErrorMessage, int ErrorNumber)
        {
            MessageBox.Show(ErrorMessage.ToString() + ", " + ErrorNumber.ToString(), "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }

        //======= agar form yang muncul, bisa di drag
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }


        public void authorization_verifyClubClass(string employee_FingerID)
        {
            DataTable dt = new DataTable();
            dt = fingerPrint_Device.auth_ClubClass_Finger(employee_FingerID);

            if (dt.Rows.Count != 0)
            {
                string info_Text = "Are you sure to <b><color=green>verify</color></b> this private instruction session?";
                Cst_Form_Short f1 = new Cst_Form_Short(info_Text);
                if (f1.ShowDialog() == DialogResult.Yes)
                {                  
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                MessageBox.Show("You are not authorize", "Verify Class", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void alertControl1_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            e.AlertForm.Height = 100;
            e.AlertForm.Width = 300;
            e.AlertForm.OpacityLevel = 3;
        }

        private void PT_fingerVerify_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void PT_fingerVerify_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid);
        }

        private void PT_fingerVerify_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void PT_fingerVerify_FormClosed(object sender, FormClosedEventArgs e)
        {
            myReader.FPRemoveAll();
            myReader.FPIdentificationStop();
            myReader.Dispose();                        
        }

        private int tick1 = 2 * 60;// 2 meenit;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tick1 = tick1 - 1;
            if (tick1 == 0)
            {
                timer1.Stop();
                this.Close();                
            }
        }

    }
}
