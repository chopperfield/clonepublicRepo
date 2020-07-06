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
    public partial class PT_formEnd2 : Form
    {
        SqlConnection myConnection = new SqlConnection(Partner.configConnection);
     
        Bitmap gbr_inf = new Bitmap(Properties.Resources.info_icon, 25, 25);
        Bitmap gbr_warn = new Bitmap(Properties.Resources.warning, 25, 25);
        Bitmap gbr_error = new Bitmap(Properties.Resources.close, 25, 25);

        setup_Datatable setup_Datatable;
        Utils utils;

        private string Img_member_Url;
        
        DataTable _dt_finger_employees;

        private string _clubName;
        private string _counter_PTSession;
        private string _student_Name;
        private string _student_RGP;
        private string _product_Name;

        private string _employee_Start;
        private string _employee_StartName;
        private bool _isFinger;

        private string _room;
        /// <summary>
        /// Input Datatable if using finger, if not null
        /// </summary>
        /// <param name="clubName"></param>
        /// <param name="counter_PTSession"></param>
        /// <param name="student_Name"></param>
        /// <param name="student_RGP"></param>
        /// <param name="product_Name"></param>
        /// <param name="dt_finger_employees"></param>
        /// <param name="employee_Start"></param>
        /// <param name="isFinger"></param>
        public PT_formEnd2(string clubName, string room, string counter_PTSession, string student_Name, string student_RGP, string product_Name, DataTable dt_finger_employees, string employee_Start, string employee_StartName, bool isFinger)
        {
            InitializeComponent();        
            _dt_finger_employees = new DataTable();
            _dt_finger_employees = dt_finger_employees;

            _clubName = clubName;
            _counter_PTSession = counter_PTSession;
            _student_Name = student_Name;
            _student_RGP = student_RGP;
            _product_Name = product_Name;
            _employee_Start = employee_Start;
            _employee_StartName = employee_StartName;
            _isFinger = isFinger;
            _room = room;
        }

        private void PT_formEnd2_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            Bitmap logo = new Bitmap(Properties.Resources.Logo_RSG);
            pictureEdit_Logo.Image = logo;

            lb_ClubName.Text = _clubName;
            lb_Student_Name.Text = _student_Name;
            lb_Student_RGP.Text = "RGP: " + _student_RGP;
            lb_productName.Text = _product_Name;
            lb_Instructor_Name.Text = "Instructor: " + _employee_StartName; 
            pictureEdit_Student_Attendees.Image = null;

            setup_Datatable = new setup_Datatable();
            utils = new Utils();
            Utils.create_Img_Cached();

            foreach (Control ctl in this.Controls)
            {
                ctl.Enabled = false;
            }
            lb_Room.Text = "Room: "+ _room;

        }

        private void PT_formEnd2_Shown(object sender, EventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormDescription("Getting Url address");
                Img_member_Url = utils.get_Student_Image_URL();

                //set image
                string img_path = utils.get_Student_Image(Img_member_Url, _student_RGP.ToString());
                if (!string.IsNullOrEmpty(img_path))
                {
                    using (var bmpTemp = new Bitmap(img_path))
                    {
                        Image imgs = new Bitmap(bmpTemp);
                        pictureEdit_Student_Attendees.Image = imgs;
                    }
                }
                else { pictureEdit_Student_Attendees.Image = Properties.Resources.Default_Image; }
              

                foreach (Control ctl in this.Controls)
                {
                    ctl.Enabled = true;
                }
                textBox1.Focus();
                timer1.Start();
                timer2.Start();
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

                    if( RGP.Trim() == _student_RGP.Trim())
                    {
                        timer1.Stop();
                        timer2.Stop();
                        if (_isFinger)
                        {
                            PT_fingerEnd pt_fingerend = new PT_fingerEnd(_dt_finger_employees, _clubName, _room, _product_Name, _employee_Start, _employee_StartName, _counter_PTSession, _student_RGP);
                            if (pt_fingerend.ShowDialog() == DialogResult.OK)
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                            }
                        }
                        else
                        {
                            PT_cardEnd PT_cardEnd = new PT_cardEnd(_clubName, _room, _product_Name, _employee_Start, _employee_StartName, _counter_PTSession, _student_RGP);
                            if (PT_cardEnd.ShowDialog() == DialogResult.OK)
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        alertControl1.Show(this, "Data center", "Miss match student !", gbr_error);
                        MessageBox.Show("Student does not have any private instruction session running", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

       

        private void alertControl1_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            e.AlertForm.Height = 100;
            e.AlertForm.Width = 300;
            e.AlertForm.OpacityLevel = 3;
        }

        private void PT_formEnd2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void PT_formEnd2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid);
        }

        private void PT_formEnd2_Resize(object sender, EventArgs e)
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


        private void PT_formEnd2_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }            

    }
}
