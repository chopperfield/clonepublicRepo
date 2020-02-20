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
    public partial class PT_cardMultiStart : Form
    {
        SqlConnection myConnection = new SqlConnection(Partner.configConnection);
    

        Bitmap gbr_inf = new Bitmap(Properties.Resources.info_icon, 25, 25);
        Bitmap gbr_warn = new Bitmap(Properties.Resources.warning, 25, 25);

        string _clubName;
        string _clubCode;

        string _productName;
        DataTable _dt_listData = new DataTable();
        string _totalParticipants;
        string _instructorCode;
        string _instructorName;
        string _room;

        public PT_cardMultiStart(string clubName, string clubCode, string room, string productName, DataTable dt_listData, string instructorCode, string instructorName)
        {

            InitializeComponent();

            _clubName = clubName;
            _clubCode = clubCode;
            _productName = productName;
            _dt_listData = dt_listData;
            _totalParticipants = dt_listData.Rows.Count.ToString();

            _instructorCode = instructorCode;
            _instructorName = instructorName;
            _room = room;
        }

        private void PT_cardMultiStart_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1 * 1000; //1detik per tick
            textBox1.Focus();
            Bitmap logo = new Bitmap(Properties.Resources.Logo_RSG);
            pictureEdit_Logo.Image = logo;

            lb_clubName.Text = _clubName;
            lb_productName.Text = _productName;
            lb_PT_participants.Text = "Participants: " + _totalParticipants;
            lb_Instructor_Name.Text = "Instructor: "+_instructorName;
            lb_Room.Text = "Room: " + _room;
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
               

                //cek registered package instructor with instructor finger
                List<string> list_instructorName = new List<string>();
                foreach (DataRow data in _dt_listData.Rows)
                {
                    if (data["instructorCode"].ToString().Trim() != dt.Rows[0]["employeeStart"].ToString().Trim())
                    {
                        if (!list_instructorName.Contains(data["instructorName"].ToString().Trim()))
                        {
                            list_instructorName.Add(data["instructorName"].ToString().Trim());
                        }
                    }
                }

                string msg = "";
                if (list_instructorName.Count == 0)
                {
                    msg = "Do you want to start using <b>" + _productName + "</b> private session with total participants <b>" + _totalParticipants + "</b>, teach by <b>" + dt.Rows[0]["preferredName"].ToString().Trim() + "</b> ?";
                }
                else
                {
                    msg = "<b>" + string.Join(";", list_instructorName.ToArray()) + "</b> is the registered instructor for this private instruction package. \nDo you want to start using <b>" + _productName + "</b> private session with total participants <b>" + _totalParticipants + "</b>, teach by <b>" + dt.Rows[0]["preferredName"].ToString().Trim() + "</b> ?";
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
            try
            {
                foreach (DataRow dr in _dt_listData.Rows)
                {
                    SqlCommand command = new SqlCommand();
                    try
                    {
                        command.Parameters.Clear();
                        if (myConnection.State == ConnectionState.Open)
                        {
                            myConnection.Close();
                        }
                        myConnection.Open();

                        command.Connection = myConnection;
                        command.CommandText = "insert into module.trainingUsage (type,date,club,room,training,memberStart,employeeStart,recid) values " +
                                              " (@type, getDate(), @club, @room, @training,@memberStart,@employeeStart,@recid)  ";
                        command.Parameters.AddWithValue("@type", "FTU");
                        command.Parameters.AddWithValue("@club", _clubCode.Trim());
                        command.Parameters.AddWithValue("@room", _room.Trim());
                        command.Parameters.AddWithValue("@training", dr["counter"].ToString().Trim());
                        command.Parameters.AddWithValue("@memberStart", dr["code"].ToString().Trim());
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
                }
            }
            catch
            {
                MessageBox.Show("Data are not fully insert !", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                return;
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

        private void PT_cardMultiStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void PT_cardMultiStart_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid);
        }

        private void PT_cardMultiStart_Resize(object sender, EventArgs e)
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
