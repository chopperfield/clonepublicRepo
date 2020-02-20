using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Axioma.Celebrity.Fitness;
using System.Media;
using DevExpress.XtraGrid.Views.Grid;

namespace RockStar.Training
{
    public partial class PT_listMultiEnd : Form
    {
        SqlConnection myConnection = new SqlConnection(Partner.configConnection);

        Bitmap gbr_inf = new Bitmap(Properties.Resources.info_icon, 25, 25);
        Bitmap gbr_warn = new Bitmap(Properties.Resources.warning, 25, 25);
        Bitmap gbr_error = new Bitmap(Properties.Resources.close, 25, 25);


        DataTable _dt_finger_employees;
        private string _code_UserClubName;
        private bool _isFinger;

        DataTable _dt_student;//dt copy from parent SP

        private string str_room;

        public PT_listMultiEnd(string code_UserClubName, DataTable dt_finger_employees, bool isFinger, DataTable dt_student)
        {
            InitializeComponent();

            _code_UserClubName = code_UserClubName;
            _dt_finger_employees = new DataTable();
            _dt_finger_employees = dt_finger_employees;
            _isFinger = isFinger;

            _dt_student = new DataTable();
            _dt_student = dt_student;
        }

        private void PT_listMultiEnd_Load(object sender, EventArgs e)
        {
            lb_ClubName.Text = _code_UserClubName;
            Bitmap logo = new Bitmap(Properties.Resources.Logo_RSG);
            pictureEdit_Logo.Image = logo;

            lb_productName.Text = _dt_student.Rows[0]["productName"].ToString().Trim(); //product name same - already filter
            _dt_student.Columns.Add("Check", typeof(bool));//for display
            foreach (DataRow dr in _dt_student.Rows)
            {
                dr.SetField("Check", false);
            }
            gridControl1.DataSource = _dt_student;
            arrangeCol();
            lb_Instructor_Room.Text = _dt_student.Rows[0]["employeeStartName"].ToString() + " - " + _dt_student.Rows[0]["room"].ToString();                         
            str_room = _dt_student.Rows[0]["room"].ToString().Trim();
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

        private void PT_listMultiEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void PT_listMultiEnd_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid);
        }

        private void PT_listMultiEnd_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }


        private void arrangeCol()
        {
            if (gridControl1.DataSource != null)
            {
                gridView1.Columns["onClubName"].Visible = false;
                gridView1.Columns["clubName"].Visible = false;

                gridView1.Columns["counter"].VisibleIndex = 0;
                gridView1.Columns["counter"].Width = 70;
                gridView1.Columns["counter"].Caption = "Usage No";

                gridView1.Columns["date"].VisibleIndex = 1;
                gridView1.Columns["date"].Width = 100;
                gridView1.Columns["date"].Caption = "Date";
                gridView1.Columns["date"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["date"].DisplayFormat.FormatString = "dd MMM yyyy";

                gridView1.Columns["memberStart"].Caption = "RGP";
                gridView1.Columns["memberStart"].VisibleIndex = 2;
                gridView1.Columns["memberStart"].Width = 70;
                gridView1.Columns["memberStart"].Caption = "RGP";

                gridView1.Columns["memberName"].VisibleIndex = 3;
                gridView1.Columns["memberName"].Width = 150;
                gridView1.Columns["memberName"].Caption = "Member Name";

                gridView1.Columns["training"].VisibleIndex = 4;
                gridView1.Columns["training"].Width = 70;
                gridView1.Columns["training"].Caption = "Package No";

                gridView1.Columns["productName"].VisibleIndex = 5;
                gridView1.Columns["productName"].Width = 200;
                gridView1.Columns["productName"].Caption = "Package Name";

                gridView1.Columns["trainingStart"].VisibleIndex = 7;
                gridView1.Columns["trainingStart"].Width = 150;
                gridView1.Columns["trainingStart"].Caption = "Time Start";
                gridView1.Columns["trainingStart"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["trainingStart"].DisplayFormat.FormatString = "dd MMM yyyy HH:mm:ss";

                gridView1.Columns["trainingEnd"].Visible = false;
                gridView1.Columns["session"].Visible = false;
                gridView1.Columns["note"].Visible = false;
                gridView1.Columns["type"].Visible = false;
                gridView1.Columns["club"].Visible = false;

                gridView1.Columns["employeeStart"].Caption = "Employee Start";
                gridView1.Columns["employeeStart"].Visible = false;
                gridView1.Columns["memberEnd"].Visible = false;
                gridView1.Columns["employeeEnd"].Visible = false;
                gridView1.Columns["recid"].Visible = false;
                gridView1.Columns["code"].Visible = false;
                gridView1.Columns["agreement"].Visible = false;
                gridView1.Columns["firstName"].Visible = false;
                gridView1.Columns["lastName"].Visible = false;
                gridView1.Columns["employeeStartName"].Caption = "Instructor Start Name";
                gridView1.Columns["employeeStartName"].VisibleIndex = 6;
                gridView1.Columns["employeeStartName"].Width = 150;
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
            if (gridView1.RowCount == 0)
            {
                return;
            }
            if (Convert.ToBoolean(gridView1.GetFocusedRowCellValue("Check")) == true)
            {
                return;
            }
            string student_Name = gridView1.GetFocusedRowCellDisplayText("memberName").ToString().Trim();
            string student_RGP = gridView1.GetFocusedRowCellDisplayText("code").ToString().Trim();
            string product_Name = gridView1.GetFocusedRowCellDisplayText("productName").ToString().Trim();
            string employee_StartName = gridView1.GetFocusedRowCellDisplayText("employeeStartName").ToString().Trim();

            using (PT_studentMultiEnd pt_studentMultiEnd = new PT_studentMultiEnd(_code_UserClubName, student_Name, student_RGP, product_Name, employee_StartName))
            {
                if (pt_studentMultiEnd.ShowDialog() == DialogResult.OK)
                {
                    gridView1.SetFocusedRowCellValue("Check", true);//for display
                    gridView1.RefreshData();
                }
            }
        }


        private void btn_Done_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount != 0)
            {
                #region all card must be scan
                //int i = 0;
                //while (i < gridView1.RowCount)
                //{
                //    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, "Check")) == false)
                //    {
                //        return;
                //    }
                //    i++;
                //}    
                #endregion

                DataTable dt_tick = new DataTable();
                dt_tick = _dt_student.Clone();
                foreach(DataRow dr in _dt_student.Rows)
                {
                    if(Convert.ToBoolean(dr["Check"]) == true)
                    {
                        dt_tick.ImportRow(dr);
                        ModelsCollection.Add(new model(dr["counter"].ToString(), dr["memberName"].ToString(), dr["memberStart"].ToString()));
                    }
                }
                
                if(dt_tick.Rows.Count == 0)
                {
                    MessageBox.Show("Please scan student card", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }                              
       

                if (_isFinger)
                {
                    PT_fingerMultiEnd pt_fingerMultiStart = new PT_fingerMultiEnd(_dt_finger_employees, _code_UserClubName, str_room ,dt_tick);
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
                    PT_cardMultiEnd pt_cardMultiEnd = new PT_cardMultiEnd(_code_UserClubName,str_room, dt_tick);
                    if (pt_cardMultiEnd.ShowDialog() == DialogResult.OK)
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

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (View.RowCount != 0)
            {
                bool Check = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["Check"]));
                if (Check == true)
                {
                    e.Appearance.BackColor = Color.MediumSeaGreen;
                }
            }
        }

        public List<model> ModelsCollection = new List<model>();//untuk report, after dialog result=ok
        public class model
        {
            public model(string trainingUsage, string name, string rgp)
            {
                TrainingUsage = trainingUsage;
                StudentName = name;
                StudentRGP = rgp;
            }
            public string TrainingUsage { get; }
            public string StudentName { get;}
            public string StudentRGP { get; }
        }
    }   
}

