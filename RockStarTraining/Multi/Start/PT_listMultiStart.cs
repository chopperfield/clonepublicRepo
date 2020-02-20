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
    public partial class PT_listMultiStart : Form
    {
        SqlConnection myConnection = new SqlConnection(Partner.configConnection);
     
        Bitmap gbr_inf = new Bitmap(Properties.Resources.info_icon, 25, 25);
        Bitmap gbr_warn = new Bitmap(Properties.Resources.warning, 25, 25);
        Bitmap gbr_error = new Bitmap(Properties.Resources.close, 25, 25);
           

        DataTable _dt_finger_employees;
        private string _code_clubUser;
        private string _code_UserClubName;
        private bool _isFinger;

        /// <summary>
        /// Input Datatable if using finger, if not null
        /// </summary>
        /// <param name="clubName"></param>
        /// <param name="code_clubUser"></param>
        /// <param name="dt_finger_employees"></param>        
        public PT_listMultiStart(string code_UserClubName, string code_clubUser,DataTable dt_finger_employees, bool isFinger)
        {
            InitializeComponent();

            _code_UserClubName = code_UserClubName;
            _dt_finger_employees = new DataTable();
            _dt_finger_employees = dt_finger_employees;
            _code_clubUser = code_clubUser;
            _isFinger = isFinger;
        }

        private void PT_listMultiStart_Load(object sender, EventArgs e)
        {
            lb_ClubName.Text = _code_UserClubName;
            Bitmap logo = new Bitmap(Properties.Resources.Logo_RSG);
            pictureEdit_Logo.Image = logo;

            cmb_Room.DataSource = PT_Session.get_Datatable_Club_RoomList();
            cmb_Room.SelectedIndex = -1;
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
  
      

        private void alertControl1_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            e.AlertForm.Height = 100;
            e.AlertForm.Width = 300;
            e.AlertForm.OpacityLevel = 3;
        }

        private void PT_listMultiStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void PT_listMultiStart_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid);
        }

        private void PT_listMultiStart_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
     

        private void arrangeCol()
        {
            if (gridControl1.DataSource != null)
            {
                gridView1.Columns["counter"].VisibleIndex = 0;
                gridView1.Columns["counter"].Caption = "Counter";
                gridView1.Columns["counter"].Width = 50;

                gridView1.Columns["memberName"].VisibleIndex = 1;
                gridView1.Columns["memberName"].Caption = "Student Name";
                gridView1.Columns["memberName"].Width = 200;

                gridView1.Columns["productName"].VisibleIndex = 2;
                gridView1.Columns["productName"].Caption = "Product Name";
                gridView1.Columns["productName"].Width = 200;

                gridView1.Columns["instructorCode"].VisibleIndex = 3;
                gridView1.Columns["instructorCode"].Caption = "Instructor Code";
                gridView1.Columns["instructorCode"].Width = 150;

                gridView1.Columns["instructorName"].VisibleIndex = 4;
                gridView1.Columns["instructorName"].Caption = "Instructor Name";
                gridView1.Columns["instructorName"].Width = 150;

                gridView1.Columns["remain"].VisibleIndex = 5;
                gridView1.Columns["remain"].Caption = "Remain";
                gridView1.Columns["remain"].Width = 50;

                gridView1.Columns["expired"].VisibleIndex = 6;
                gridView1.Columns["expired"].Caption = "Expired Date";
                gridView1.Columns["expired"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["expired"].DisplayFormat.FormatString = "dd MMM yyyy";
                gridView1.Columns["expired"].Width = 100;

                gridView1.Columns["note"].VisibleIndex = 7;
                gridView1.Columns["note"].Caption = "Note";
                gridView1.Columns["note"].Width = 200;


                gridView1.Columns["approveBy"].Visible = false;
                gridView1.Columns["approveDate"].Visible = false;
                gridView1.Columns["clubName"].Visible = false;
                gridView1.Columns["code"].Visible = false;
                gridView1.Columns["barcode"].Visible = false;
                gridView1.Columns["agreement"].Visible = false;
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


        private void btn_StartScan_Click(object sender, EventArgs e)
        {
            string productName = "";
            if(gridView1.RowCount != 0)
            {
                productName = gridView1.GetRowCellDisplayText(0, "productName");//limitation product yg sma
            }

            using (PT_studentMultiStart pt_formStart = new PT_studentMultiStart(_code_UserClubName, productName))
            {
                if (pt_formStart.ShowDialog() == DialogResult.OK)
                {
                    if(gridControl1.DataSource == null)
                    {
                        dt_dataList = pt_formStart.getdtSchema.Clone();
                        gridControl1.DataSource = dt_dataList;
                        arrangeCol();
                    }
                    dt_dataList.ImportRow(pt_formStart.getDR);
                    gridView1.RefreshData();
                }
            }
        }

        DataTable dt_dataList = new DataTable();

        private void btn_Done_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount != 0)
            {             
                if(cmb_Room.SelectedIndex == -1 || string.IsNullOrEmpty(cmb_Room.Text))
                {
                    MessageBox.Show("Select room to start private sessions", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string productName = gridView1.GetRowCellDisplayText(0, "productName");
                string instructorCode = gridView1.GetRowCellDisplayText(0, "instructorCode");
                string instructorName = gridView1.GetRowCellDisplayText(0, "instructorName");
                if (_isFinger)
                {
                    PT_fingerMultiStart pt_fingerMultiStart = new PT_fingerMultiStart(_dt_finger_employees, lb_ClubName.Text, _code_clubUser, cmb_Room.Text.Trim(),productName , dt_dataList, instructorCode, instructorName);
                    if (pt_fingerMultiStart.ShowDialog() == DialogResult.OK)
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
                    PT_cardMultiStart pt_cardMultistart = new PT_cardMultiStart(lb_ClubName.Text, _code_clubUser, cmb_Room.Text.Trim(),productName, dt_dataList, instructorCode, instructorName);
                    if (pt_cardMultistart.ShowDialog() == DialogResult.OK)
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
        }

 

    }
}

