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
    public partial class PT_listMultiEnd_Alt : Form
    {
        SqlConnection myConnection = new SqlConnection(Partner.configConnection);
     
        Bitmap gbr_inf = new Bitmap(Properties.Resources.info_icon, 25, 25);
        Bitmap gbr_warn = new Bitmap(Properties.Resources.warning, 25, 25);
        Bitmap gbr_error = new Bitmap(Properties.Resources.close, 25, 25);
           

        DataTable _dt_finger_employees;
        private string _code_UserClubName;
        private bool _isFinger;

        DataTable _dt_student;//dt copy from parent SP

        /// <summary>
        /// used as gridview datasource
        /// </summary>
        DataTable dt_grid;//main

        public PT_listMultiEnd_Alt(string code_UserClubName, DataTable dt_finger_employees, bool isFinger, DataTable dt_student)
        {
            InitializeComponent();

            _code_UserClubName = code_UserClubName;
            _dt_finger_employees = new DataTable();
            _dt_finger_employees = dt_finger_employees;
            _isFinger = isFinger;

            _dt_student = new DataTable();
            _dt_student = dt_student;
        }

        private void PT_listMultiEnd_Alt_Load(object sender, EventArgs e)
        {
            lb_ClubName.Text = _code_UserClubName;
            Bitmap logo = new Bitmap(Properties.Resources.Logo_RSG);
            pictureEdit_Logo.Image = logo;

            lb_productName.Text = "";
            lb_Usage.Text = "Finish Usage";

            dt_grid = new DataTable();
            dt_grid = _dt_student.Clone();
            gridControl1.DataSource = dt_grid;
            arrangeCol();
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

        private void PT_listMultiEnd_Alt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void PT_listMultiEnd_Alt_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid);
        }

        private void PT_listMultiEnd_Alt_Resize(object sender, EventArgs e)
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
                gridView1.Columns["employeeStartName"].VisibleIndex = 6 ;
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
            int exist = 0;//0 = tidak ada sama sekali ,1 = data ada (rgp cocok-package sama), 2= data tapi beda package ;
            using (PT_studentMultiEnd_Alt pt_studentMultiEnd_Alt = new PT_studentMultiEnd_Alt(_code_UserClubName))
            {
                if (pt_studentMultiEnd_Alt.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataRow dr in _dt_student.Rows)
                    {
                        if (gridView1.RowCount == 0) //kalau masi kosong,maka tidak ada perbandingan package dan instructor
                        {
                            if (dr["memberStart"].ToString().Trim() == pt_studentMultiEnd_Alt.getRGP.Trim())
                            {
                                exist = 1;
                                dt_grid.ImportRow(dr);
                                break;
                            }
                        }
                        else //kalau sudah ada data
                        {
                            //rgp, productName dan Instructor harus sama
                            if (dr["memberStart"].ToString().Trim() == pt_studentMultiEnd_Alt.getRGP.Trim() && dr["productName"].ToString() == gridView1.GetRowCellDisplayText(0, "productName").ToString() && dr["employeeStart"].ToString() == gridView1.GetRowCellDisplayText(0, "employeeStart").ToString())
                            {
                                exist = 1;
                                dt_grid.ImportRow(dr);
                                break;
                            }
                            if (dr["memberStart"].ToString().Trim() == pt_studentMultiEnd_Alt.getRGP.Trim() && dr["productName"].ToString() != gridView1.GetRowCellDisplayText(0, "productName").ToString())
                            {
                                exist = 2;//rgp sama, product name beda
                                break;
                            }
                            if (dr["memberStart"].ToString().Trim() == pt_studentMultiEnd_Alt.getRGP.Trim() && dr["productName"].ToString() == gridView1.GetRowCellDisplayText(0, "productName").ToString() && dr["employeeStart"].ToString() != gridView1.GetRowCellDisplayText(0, "employeeStart").ToString())
                            {
                                exist = 3;//rgp sama, product nama sama, instructor beda
                                break;
                            }
                        }
                    }

                    if (exist == 0 && gridView1.RowCount == 0)
                    {
                        MessageBox.Show("Student does not have any private instruction session running", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (exist == 0 && gridView1.RowCount != 0)
                    {
                        MessageBox.Show("Student does not have any private instruction session running", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (exist == 2 && gridView1.RowCount != 0)
                    {
                        MessageBox.Show("You can only finish multiple private instruction session within the same package", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (exist == 3 && gridView1.RowCount != 0)
                    {
                        MessageBox.Show("You can only finish multiple private instruction session within the same package and same instructor", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (exist == 1)
                    {
                        lb_productName.Text = dt_grid.Rows[0]["productName"].ToString();
                        lb_Usage.Text = dt_grid.Rows[0]["employeeStartName"].ToString() + " - Finish Usage";
                    }



                    gridView1.RefreshData();
                }
            }
        }


        private void btn_Done_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount != 0)
            {

                DataTable dt_tick = new DataTable();
                dt_tick = dt_grid.Clone();//dari import
                foreach (DataRow dr in dt_grid.Rows)
                {
                    dt_tick.ImportRow(dr);
                    ModelsCollection.Add(new model(dr["counter"].ToString(), dr["memberName"].ToString(), dr["memberStart"].ToString()));
                }
                if (dt_tick.Rows.Count == 0)
                {
                    MessageBox.Show("Please scan student card", "Axioma Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (_isFinger)
                {
                    PT_fingerMultiEnd_Alt pt_fingerMultiStart = new PT_fingerMultiEnd_Alt(_dt_finger_employees, lb_ClubName.Text, dt_grid);
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
                //else
                //{
                //    PT_cardMultiEnd pt_cardMultiEnd = new PT_cardMultiEnd(lb_ClubName.Text, _dt_student);
                //    if (pt_cardMultiEnd.ShowDialog() == DialogResult.OK)
                //    {
                //        this.DialogResult = DialogResult.OK;
                //        this.Close();
                //    }
                //    else
                //    {
                //        this.DialogResult = DialogResult.Cancel;
                //        this.Close();
                //    }
                //}
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (View.RowCount != 0)
            {              
                //bool Check = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["Check"]));
                //if (Check == true)
                //{
                    e.Appearance.BackColor = Color.MediumSeaGreen;                    
                //}
            }
        }



        public List<model> ModelsCollection = new List<model>();
        public class model
        {
            public model(string trainingUsage, string name, string rgp)
            {
                TrainingUsage = trainingUsage;
                StudentName = name;
                StudentRGP = rgp;
            }
            public string TrainingUsage { get; }
            public string StudentName { get; }
            public string StudentRGP { get; }
        }
    }
}

