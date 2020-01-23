using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Axioma.Celebrity.Fitness;
using System.Media;
using FastCodeSDK;

namespace RockStar.Training
{
    /// <summary>
    /// Process in one windows (no popupwindow)
    /// </summary>
    public partial class PT_formEnd : Form
    {
        SqlConnection myConnection = new SqlConnection(Partner.configConnection);

        Bitmap gbr_inf = new Bitmap(Properties.Resources.info_icon, 25, 25);
        Bitmap gbr_warn = new Bitmap(Properties.Resources.warning, 25, 25);
        Bitmap gbr_error = new Bitmap(Properties.Resources.close, 25, 25);

        setup_Datatable setup_Datatable;
        Utils utils;

        private string Img_member_Url;

        DataTable dt_finger_employees;

        private string clubName;
        private string counter_PTSession;
        private string student_Name;
        private string student_RGP;
        private string product_Name;

        private string employee_Start;

        FastCodeSDK.FPReader myReader;
        fingerPrint_Device fingerPrint_Device = new fingerPrint_Device();

        public PT_formEnd(string clubName, string counter_PTSession, string student_Name, string student_RGP, string product_Name, DataTable dt_finger_employees, string employee_Start)
        {
            InitializeComponent();
            this.dt_finger_employees = new DataTable();
            this.dt_finger_employees = dt_finger_employees;

            this.clubName = clubName;
            this.counter_PTSession = counter_PTSession;
            this.student_Name = student_Name;
            this.student_RGP = student_RGP;
            this.product_Name = product_Name;
            this.employee_Start = employee_Start;
        }

        private void PT_formEnd_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            Bitmap logo = new Bitmap(Properties.Resources.Logo_RSG);
            pictureEdit_Logo.Image = logo;

            lb_ClubName.Text = clubName;
            lb_Student_Name.Text = student_Name;
            lb_Student_RGP.Text = "RGP: " + student_RGP;
            lb_productName.Text = product_Name;

            pictureEdit_Student_Attendees.Image = null;

            setup_Datatable = new setup_Datatable();
            utils = new Utils();
            Utils.create_Img_Cached();

            foreach (Control ctl in this.Controls)
            {
                ctl.Enabled = false;
            }            
        }

        private void PT_formEnd_Shown(object sender, EventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormDescription("Getting Url address");
                Img_member_Url = utils.get_Student_Image_URL();

                //set image
                string img_path = utils.get_Student_Image(Img_member_Url, student_RGP.ToString());
                if (!string.IsNullOrEmpty(img_path))
                {
                    using (var bmpTemp = new Bitmap(img_path))
                    {
                        Image imgs = new Bitmap(bmpTemp);
                        pictureEdit_Student_Attendees.Image = imgs;
                    }
                }
                else { pictureEdit_Student_Attendees.Image = Properties.Resources.Default_Image; }
                //

                //fingerdevice
                //myReader = new FastCodeSDK.FPReader();
                //myReader.GetReaders();
                //if (myReader.ReaderCount <= 0)
                //{
                //    throw new Exception("Fingerprint device not found");
                //}
                //

                foreach (Control ctl in this.Controls)
                {
                    ctl.Enabled = true;
                }
                textBox1.Focus();
                timer1.Start();
                //timer2.Start();
            }
            catch (Exception ex)
            {
                splashScreenManager1.CloseWaitForm();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (splashScreenManager1.IsSplashFormVisible == true)
                {
                    splashScreenManager1.CloseWaitForm();
                }
            }
        }

        private void list_event()
        {
            myReader.ErrorEvent += new FPReader.ErrorEventEventHandler(myReader_FPErrorEvent);//show error
            myReader.FPReaderStatus += new FPReader.FPReaderStatusEventHandler(myReader_FPReaderStatus);// perintah selectreader akan memicu FPReaderStatus             

        }

        int tick1 = 2;//konter detik buat text edit fockus dan ""
        private void timer1_Tick(object sender, EventArgs e)
        {
            tick1 = tick1 - 1;
            if (tick1 == 0)
            {
                timer1.Stop();
                textBox1.Text = "";
                textBox1.Focus();
                tick1 = 2;
                timer1.Start();
            }
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

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //textbox can't mask, tapi bisa prevent shortcut           
            if (textBox1.Text.Length == 10)
            {
                string rfid = textBox1.Text;
                get_Student_RGP(rfid);
                textBox1.Text = "";
            }
        }

        private void get_Student_RGP(string rfid)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = setup_Datatable.datatable_Student_RGP(rfid);
                if (dt.Rows.Count == 1)
                {
                    string RGP = dt.Rows[0]["RGP"].ToString().Trim();

                    if (RGP.Trim() == student_RGP.Trim())
                    {
                        timer1.Stop();
                        lb_Info.Text = "Please Scan Your Finger";
                        textBox1.Enabled = false;
                        setup_fingerPrint();
                    }
                    else
                    {
                        alertControl1.Show(this, "Data center", "Miss match student !", gbr_error);
                        MessageBox.Show("Student does not match with RFID card", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (dt.Rows.Count == 0)
                {
                    lb_Info.Text = "Please Tap Student Card";
                    alertControl1.Show(this, "Data center", "Student not found !", gbr_error);
                    timer1.Start();
                    textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }
        }

        private void setup_fingerPrint()
        {

            try
            {
                myReader = new FastCodeSDK.FPReader();
                myReader.GetReaders();
                if (myReader.ReaderCount <= 0)
                {
                    throw new Exception("Fingerprint device not found");
                }

                if (myReader.ReaderCount > 0)
                {
                    list_event();
                    fingerPrint_Device.get_FileCode();
                    myReader.SelectReader(fingerPrint_Device.VerificationCode, fingerPrint_Device.SerialNumber, fingerPrint_Device.ActivationCode.Trim(), FPReader.ReaderPriority.Low);
                }
                else
                {
                    MessageBox.Show("finger print device not found", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

                string TemplateSafetyKey = fingerPrint_Device.TemplateSafetyKey;
                //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this,typeof(form_Wait),true,true,false);                
                foreach (DataRow row in dt_finger_employees.Rows)
                {
                    int finger = Convert.ToInt32(row["fingerID"]);//get fingerindexes
                    FPReader.FingerIndex fingerIndex = (FPReader.FingerIndex)finger;//convert fingerindex
                    string employeeID = row["employee"].ToString();
                    string fingerTemplate = row["fingerprint"].ToString();//template
                    myReader.FPLoad(employeeID, fingerIndex, fingerTemplate, TemplateSafetyKey);
                }
                myReader.FPIdentificationID += new FPReader.FPIdentificationIDEventHandler(MyReader_FPIdentificationID);
                myReader.FPIdentificationStatus += new FPReader.FPIdentificationStatusEventHandler(MyReader_FPIdentificationStatus);
                myReader.FPIdentificationStart(5);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            timer2.Start();
        }

        private void alertControl1_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            e.AlertForm.Height = 100;
            e.AlertForm.Width = 300;
            e.AlertForm.OpacityLevel = 3;
        }

        private void PT_formEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void PT_formEnd_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid);
        }

        private void PT_formEnd_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private int tick2 = 2 * 60;// 2 meenit;
        private void timer2_Tick(object sender, EventArgs e)
        {
            tick2 = tick2 - 1;
            if (tick2 == 0)
            {
                timer2.Stop();
                this.Close();
            }
        }


        private void myReader_FPErrorEvent(string ErrorMessage, int ErrorNumber)
        {
            MessageBox.Show(ErrorMessage.ToString() + ", " + ErrorNumber.ToString(), "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }

        private void myReader_FPReaderStatus(FPReader.ReaderStatus Status)
        {
            if (Status == FPReader.ReaderStatus.NoReaderSelected || Status == FPReader.ReaderStatus.ReaderDisconnected || Status == FPReader.ReaderStatus.InvalidActivationCode || Status == FPReader.ReaderStatus.NoReader)
            {
                MessageBox.Show(Status.ToString(), "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            if (Status == FPReader.ReaderStatus.PleaseRescan)
            {
                MessageBox.Show(Status.ToString(), "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        string instructor_FingerID;
        private void MyReader_FPIdentificationID(string ID, FPReader.FingerIndex FpIndex)
        {
            instructor_FingerID = ID.Trim();
        }

        private void MyReader_FPIdentificationStatus(FPReader.IdentificationStatus Status)
        {
            if (Status == FPReader.IdentificationStatus.EmptyTemplateList || Status == FPReader.IdentificationStatus.Fail || Status == FPReader.IdentificationStatus.MultiCandidates)
            {
                MessageBox.Show(Status.ToString(), "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Status == FPReader.IdentificationStatus.OneCandidate)
            {
                if (!string.IsNullOrEmpty(instructor_FingerID))
                {
                    check_Instructor();
                }
            }
            if (Status == FPReader.IdentificationStatus.NoCandidate)
            {
                MessageBox.Show("Fingerprint does not match with any candidate", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PT_formEnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (myReader != null)
            {
                myReader.FPRemoveAll();
                myReader.FPIdentificationStop();
                myReader.Dispose();
            }
        }

        bool berhasil_insert = false; //alasan kasi ini karena, threading si alertcontrol dan indikasi berhasil update
        private void check_Instructor()
        {
            if (employee_Start.Trim() == instructor_FingerID.Trim())
            {
                if (MessageBox.Show("Finish Training ?", "Axioma agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    update_Signin();
                    if (berhasil_insert == true)
                    {
                        //alertControl1.Show(this, "Data center", "Class assistant attend \n" + info + "\n" + labelControl2.Text + "", gbr_inf);
                        //thread problem, https://stackoverflow.com/questions/7360453/alertcontrol-doesnt-show, (ketika pakai fingerprint)
                        Action action = () =>
                        {
                            DevExpress.XtraBars.Alerter.AlertControl control = new DevExpress.XtraBars.Alerter.AlertControl();
                            control = alertControl1;
                            control.FormLocation = DevExpress.XtraBars.Alerter.AlertFormLocation.BottomRight;
                            control.Show(this, "Data center", "Training has end \n" + "\nProductName: " + lb_productName.Text + "", gbr_inf); // "this" being a Form
                        };
                        this.Invoke(action);
                        this.DialogResult = DialogResult.OK;
                    }
                    this.Close();
                }
                else
                {

                    this.DialogResult = DialogResult.None;

                    this.Close();
                }
            }
            else
            {
                //alertControl1.Show(this, "Data center", "Miss match instructor !", gbr_error);
                MessageBox.Show("Instructor does not match fingerprint", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void update_Signin()
        {

            SqlCommand command = new SqlCommand();

            try
            {
                command.Parameters.Clear();
                myConnection.Open();

                command.Connection = myConnection;
                command.CommandText = "update module.trainingUsage set memberEnd=@memberEnd, employeeEnd=@employeeEnd, note=@note where counter=@counter";
                command.Parameters.AddWithValue("@memberEnd", student_RGP);
                command.Parameters.AddWithValue("@employeeEnd", instructor_FingerID);
                command.Parameters.AddWithValue("@note", "");
                command.Parameters.AddWithValue("@counter", counter_PTSession);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                berhasil_insert = false;
                MessageBox.Show("error" + ex);
                return;
            }
            finally
            {
                myConnection.Close();
            }
            berhasil_insert = true;
            SoundPlayer audio = new SoundPlayer();
            audio.Stream = Properties.Resources.msg_ins;
            audio.Play();
        }


    }
}
