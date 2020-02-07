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
    public partial class PT_formMultiStart : Form
    {
        SqlConnection myConnection = new SqlConnection(Partner.configConnection);
     
        Bitmap gbr_inf = new Bitmap(Properties.Resources.info_icon, 25, 25);
        Bitmap gbr_warn = new Bitmap(Properties.Resources.warning, 25, 25);
        Bitmap gbr_error = new Bitmap(Properties.Resources.close, 25, 25);

        setup_Datatable setup_Datatable;
        Utils utils;

        private string Img_member_Url;        
        DataTable dt_listPrivateInstruction = new DataTable();


        /// <summary>
        /// Scanning Student Card Only
        /// </summary>
        /// <param name="clubName"></param>
        /// <param name="code_clubUser"></param>
        public PT_formMultiStart(string clubName)
        {
            InitializeComponent();        
            lb_ClubName.Text = clubName;
        }

        private void PT_formMultiStart_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            Bitmap logo = new Bitmap(Properties.Resources.Logo_RSG);
            pictureEdit_Logo.Image = logo;

            setup_Datatable = new setup_Datatable();
            utils = new Utils();

            Utils.create_Img_Cached();

            lb_Student_RGP.Text = "";
            lb_Student_Name.Text = "";
            pictureEdit_Student_Attendees.Image = null;

            dr = null;

            foreach (Control ctl in this.Controls)//bgw
            {
                ctl.Enabled = false;
            }
        }

        private void PT_formMultiStart_Shown(object sender, EventArgs e)
        {           
            try
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormDescription("Getting Url address");
                Img_member_Url = utils.get_Student_Image_URL();
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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                splashScreenManager1.CloseWaitForm();
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
                    int RGP = Convert.ToInt32(dt.Rows[0]["RGP"].ToString().Trim());
                    lb_Student_RGP.Text =  "RGP: "+ RGP.ToString();
                    lb_Student_Name.Text = dt.Rows[0]["preferredName"].ToString();

                    try
                    {
                        string img_path = utils.get_Student_Image(Img_member_Url, RGP.ToString());
                        if (!string.IsNullOrEmpty(img_path))
                        {
                            using (var bmpTemp = new Bitmap(img_path))
                            {
                                Image imgs = new Bitmap(bmpTemp);
                                pictureEdit_Student_Attendees.Image = imgs;
                            }
                        }
                        else { pictureEdit_Student_Attendees.Image = Properties.Resources.Default_Image; }
                    }
                    catch (Exception ex)
                    {
                        pictureEdit_Student_Attendees.Image = null;
                        MessageBox.Show(ex.Message);
                    }


                    dt_listPrivateInstruction = setup_Datatable.datatable_PrivateInstruction(RGP);

                    if(dt_listPrivateInstruction.Rows.Count != 0)
                    {
                        gridControl1.DataSource = dt_listPrivateInstruction;
                        timer1.Stop();
                        gridView1.Focus();
                        gridView1.FocusedRowHandle = 0;
                        arrangeCol();
                        textBox1.Enabled = false;
                    }
                    else
                    {
                        gridControl1.DataSource = null;
                        alertControl1.Show(this, "Data center", "Training not found !", gbr_error);
                        timer1.Start();
                        textBox1.Focus();
                    }                    
                }
                else if (dt.Rows.Count == 0)
                {
                    lb_Student_RGP.Text = "";
                    lb_Student_Name.Text = "";
                    pictureEdit_Student_Attendees.Image = null;

                    gridControl1.DataSource = null;
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

        private void PT_formMultiStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void PT_formMultiStart_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid);
        }

        private void PT_formMultiStart_Resize(object sender, EventArgs e)
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

        private void arrangeCol()
        {
            if (gridControl1.DataSource != null)
            {
                gridView1.Columns["counter"].VisibleIndex = 0;
                gridView1.Columns["counter"].Caption = "Counter";
                gridView1.Columns["counter"].Width = 50;

                gridView1.Columns["productName"].VisibleIndex = 1;
                gridView1.Columns["productName"].Caption = "Product Name";
                gridView1.Columns["productName"].Width = 200;

                gridView1.Columns["instructorCode"].VisibleIndex = 2;
                gridView1.Columns["instructorCode"].Caption = "Instructor Code";
                gridView1.Columns["instructorCode"].Width = 150;

                gridView1.Columns["instructorName"].VisibleIndex = 3;
                gridView1.Columns["instructorName"].Caption = "Instructor Name";
                gridView1.Columns["instructorName"].Width = 150;

                gridView1.Columns["remain"].VisibleIndex = 4;
                gridView1.Columns["remain"].Caption = "Remain";
                gridView1.Columns["remain"].Width = 50;

                gridView1.Columns["expired"].VisibleIndex = 5;
                gridView1.Columns["expired"].Caption = "Expired Date";
                gridView1.Columns["expired"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["expired"].DisplayFormat.FormatString = "dd MMM yyyy";
                gridView1.Columns["expired"].Width = 100;

                gridView1.Columns["note"].VisibleIndex = 6;
                gridView1.Columns["note"].Caption = "Note";
                gridView1.Columns["note"].Width = 200;


                gridView1.Columns["approveBy"].Visible = false;
                gridView1.Columns["approveDate"].Visible = false;
                gridView1.Columns["clubName"].Visible = false;
                gridView1.Columns["code"].Visible = false;
                gridView1.Columns["barcode"].Visible = false;
                gridView1.Columns["agreement"].Visible = false;
                gridView1.Columns["memberName"].Visible = false;
                gridView1.Columns["firstName"].Visible = false;
                gridView1.Columns["lastName"].Visible = false;

            }
        }

        private void gridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null)
            {
                e.Handled = true;
            }
        }


        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(gridView1.RowCount != 0)
            {
                if(e.KeyCode == Keys.Enter)
                {
                    timer1.Stop();
                    timer2.Stop();

                    DataRow[] datarow = dt_listPrivateInstruction.Select("counter= "+gridView1.GetFocusedRowCellDisplayText("counter")+" ");
                    if (datarow.Length != 0)
                    {
                        dtschema = dt_listPrivateInstruction.Clone();
                        dr = datarow[0];
                        DialogResult = DialogResult.OK;
                    }
                    else { MessageBox.Show("Failed to get PI counter"); }

                }
            }
            else { e.Handled = true; }
        }


        private DataRow dr;
        public DataRow getDR
        {
            get { return dr; }
        }

        /// <summary>
        /// get dt schema
        /// </summary>
        private DataTable dtschema;
        public DataTable getdtSchema
        {
            get { return dtschema; }
        }

    }
}
