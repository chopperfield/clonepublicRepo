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
    public partial class PT_cardMultiEnd : Form
    {
        SqlConnection myConnection = new SqlConnection(Partner.configConnection);
    

        Bitmap gbr_inf = new Bitmap(Properties.Resources.info_icon, 25, 25);
        Bitmap gbr_warn = new Bitmap(Properties.Resources.warning, 25, 25);


        string _clubName;      
        DataTable _dt_student;
        string employeeStart;


        public PT_cardMultiEnd(string clubName, DataTable dt_student)
        {
            InitializeComponent();

            _clubName = clubName;
            _dt_student = dt_student;
        }

        private void PT_cardMultiEnd_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1 * 1000; //1detik per tick
            textBox1.Focus();
            Bitmap logo = new Bitmap(Properties.Resources.Logo_RSG);
            pictureEdit_Logo.Image = logo;

            lb_clubName.Text = _clubName;
            lb_productName.Text = _dt_student.Rows[0]["productName"].ToString();
            lb_Instructor_Name.Text = "Instructor: "+ _dt_student.Rows[0]["employeeStartName"].ToString();
            lb_PT_use.Text = "";

            employeeStart = _dt_student.Rows[0]["employeeStart"].ToString();


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
                if (employeeStart.Trim() == dt.Rows[0]["employeeStart"].ToString().Trim())
                {
                    timer1.Stop();
                    if (MessageBox.Show("Do you want to finish this private instruction session ?", "Axioma agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        update_Signin();                       
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Instructor does not match with instructor started the private instruction session", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        public void update_Signin()
        {

            try
            {
                foreach (DataRow dr in _dt_student.Rows)
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
                        command.CommandText = "update module.trainingUsage set memberEnd=@memberEnd, employeeEnd=@employeeEnd, note=@note where counter=@counter";
                        command.Parameters.AddWithValue("@memberEnd", dr["memberStart"]);
                        command.Parameters.AddWithValue("@employeeEnd", employeeStart);
                        command.Parameters.AddWithValue("@note", "");
                        command.Parameters.AddWithValue("@counter", dr["counter"]);
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
                MessageBox.Show("Data are not fully updated !", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void PT_cardMultiEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void PT_cardMultiEnd_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid);
        }

        private void PT_cardMultiEnd_Resize(object sender, EventArgs e)
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
