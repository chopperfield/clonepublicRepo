using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Axioma.Celebrity.Fitness;
using System.Media;

namespace RockStar.Training
{
    public partial class PT_cardStart : Form
    {
        SqlConnection myConnection = new SqlConnection(Partner.configConnection);
    

        Bitmap gbr_inf = new Bitmap(Properties.Resources.info_icon, 25, 25);
        Bitmap gbr_warn = new Bitmap(Properties.Resources.warning, 25, 25);


        string _clubCode;
        string _trainingCounter;
        string _studentRGP;
        string _studentName;

        string _clubName;
        string _productName;
        string _PT_remain;

        string _instructorCode;
        string _instructorName;
        public PT_cardStart(string clubName, string clubCode, string productName, string PT_remain, string trainingCounter, string studentRGP, string studentName, string instructorCode, string instructorName)
        {

            InitializeComponent();

            _clubCode = clubCode;
            _trainingCounter = trainingCounter;
            _studentRGP = studentRGP;

            _clubName = clubName;
            _productName = productName;
            _PT_remain = PT_remain;
            _studentName = studentName;
            _instructorCode = instructorCode;
            _instructorName = instructorName;
        }

        private void PT_cardStart_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1 * 1000; //1detik per tick
            textBox1.Focus();
            Bitmap logo = new Bitmap(Properties.Resources.Logo_RSG);
            pictureEdit_Logo.Image = logo;

            lb_clubName.Text = _clubName;
            lb_productName.Text = _productName;
            lb_PT_remain.Text = "Remaining Session(s): " + _PT_remain;
            lb_Instructor_Name.Text = "Instructor: "+_instructorName;

            timer1.Start();
            timer2.Start();
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
                get_Employee_Status(rfid);
                textBox1.Text = "";
            }
        }


        public void get_Employee_Status(string rfid)
        {
            setup_Datatable setup = new setup_Datatable();
            DataTable dt = setup.datatable_instructor_RFID(rfid);

            if (dt.Rows.Count == 0)
            {                
                alertControl1.Show(this, "Data center", "Instructor not found", gbr_warn);
                return;
            }
            else
            {
                timer1.Stop();
                string msg = "";
                if (_instructorCode.Trim() == dt.Rows[0]["employeeStart"].ToString().Trim())
                {
                    msg = "Do you want to start using <b>" + _studentName + " - " + _productName + "</b> private session, teach by <b>" + dt.Rows[0]["preferredName"].ToString().Trim() + "</b> ?";
                }
                else
                {
                    msg = "<b>" + _instructorName + "</b> is the registered instructor for this private instruction package. \nDo you want to start using <b>" + _studentName + " - " + _productName + "</b> private session, teach by <b>" + dt.Rows[0]["preferredName"].ToString().Trim() + "</b> ?";
                }

                Cst_Form_Long form = new Cst_Form_Long(msg);
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    insert_signin(dt.Rows[0]["employeeStart"].ToString().Trim());                   
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
        }


        public void insert_signin(string instructorCode)
        {
            SqlCommand command = new SqlCommand();
            try
            {
                command.Parameters.Clear();
                myConnection.Open();

                command.Connection = myConnection;
                command.CommandText = "insert into module.trainingUsage (type,date,club,training,memberStart,employeeStart,recid) values " +
                                      " (@type, getDate(), @club, @training,@memberStart,@employeeStart,@recid)  ";

                command.Parameters.AddWithValue("@type", "FTU");
                command.Parameters.AddWithValue("@club", _clubCode.Trim());
                command.Parameters.AddWithValue("@training", _trainingCounter.Trim());
                command.Parameters.AddWithValue("@memberStart", _studentRGP.Trim());
                command.Parameters.AddWithValue("@employeeStart", instructorCode.Trim());
                command.Parameters.AddWithValue("@recid", Partner.Userid);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
                return;
            }
            finally
            {
                myConnection.Close();
            }
            SoundPlayer audio = new SoundPlayer();
            audio.Stream = Properties.Resources.msg_ins;
            audio.Play();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void alertControl1_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            e.AlertForm.Height = 100;
            e.AlertForm.Width = 300;
            e.AlertForm.OpacityLevel = 3;
        }

        private void PT_cardStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void PT_cardStart_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid);
        }

        private void PT_cardStart_Resize(object sender, EventArgs e)
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
    }
}
