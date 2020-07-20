using Axioma.Celebrity.Fitness;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace RockStar.Training
{
    public partial class PT_verify_Instructor : Form
    {
        //hanya untuk tap dan finger verify, ketika clubclass sudah diverify
        SqlConnection myConnection = new SqlConnection(Partner.configConnection);                
        Bitmap gbr_inf = new Bitmap(Properties.Resources.info_icon, 25, 25);
        
        DataTable _dt_verify;

        string _trainingUsage, _employeeCode, _clubName;

        public PT_verify_Instructor(DataTable dt_verify, string clubName)
        {
            InitializeComponent();            
            lb_Info.Text = "Instructor Verification";
            _dt_verify = dt_verify;
            _trainingUsage = dt_verify.Rows[0]["counter"].ToString().Trim();
            _employeeCode = _dt_verify.Rows[0]["employeeStart"].ToString().Trim();
            _clubName = clubName;

        }

        private void PT_verify_Instructor_Load(object sender, EventArgs e)
        {
            Bitmap logo = new Bitmap(Properties.Resources.Logo_RSG);
            pictureEdit_Logo.Image = logo;

            lb_ClubName.Text = _clubName;
            lb_Instructor_Room.Text = _dt_verify.Rows[0]["employeeStartName"].ToString().Trim() + " - " + _dt_verify.Rows[0]["room"].ToString().Trim();
            lb_productName.Text = _dt_verify.Rows[0]["productName"].ToString().Trim();
            lb_Student_Name.Text = _dt_verify.Rows[0]["memberName"].ToString().Trim();

            instructor_attendees();
            timer1.Start();
        }

        //===agar form yang muncul bisa di drag
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }
        //======

        private void PT_verify_Instructor_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid);
        }

        private void PT_verify_Instructor_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void PT_verify_Instructor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
            }
        }

        private void gridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null)
            {
                e.Handled = true;
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
        }

      
        public void instructor_attendees()
        {
            gridControl1.DataSource = _dt_verify;

            gridView1.BeginUpdate();
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            gridControl1.RepositoryItems.Add(checkEdit);

            checkEdit.AllowGrayed = false;
            checkEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Inactive;
            DataColumn col = _dt_verify.Columns.Add("isGenre", typeof(bool));
            DevExpress.XtraGrid.Columns.GridColumn column = gridView1.Columns.AddVisible(col.ColumnName);
            column.Caption = col.Caption;
            column.Name = col.ColumnName;
            column.ColumnEdit = checkEdit;
            gridView1.EndUpdate();

            gridView1.BeginUpdate();
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            gridControl1.RepositoryItems.Add(checkEdit2);
            checkEdit2.AllowGrayed = false;
            checkEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Inactive;
            DataColumn col2 = _dt_verify.Columns.Add("isUniform", typeof(bool));
            DevExpress.XtraGrid.Columns.GridColumn column2 = gridView1.Columns.AddVisible(col2.ColumnName);
            column2.Caption = col2.Caption;
            column2.Name = col2.ColumnName;
            column2.ColumnEdit = checkEdit2;
            gridView1.EndUpdate();

            gridView1.BeginUpdate();
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repo_textEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            gridControl1.RepositoryItems.Add(repo_textEdit);            
            DataColumn col3 = _dt_verify.Columns.Add("note", typeof(string));
            DevExpress.XtraGrid.Columns.GridColumn column3 = gridView1.Columns.AddVisible(col3.ColumnName);
            column3.Caption = col3.Caption;
            column3.Name = col3.ColumnName;
            column3.ColumnEdit = repo_textEdit;
            gridView1.EndUpdate();


            gridView1.Columns["counter"].Caption = "Usage No.";
            gridView1.Columns["counter"].Width = 100;
            gridView1.Columns["counter"].OptionsColumn.AllowEdit = false;

            gridView1.Columns["memberName"].Caption = "Student Name";
            gridView1.Columns["memberName"].Width = 100;
            gridView1.Columns["memberName"].OptionsColumn.AllowEdit = false;

            gridView1.Columns["employeeStart"].Caption = "Instructor Code";
            gridView1.Columns["employeeStart"].Width = 100;
            gridView1.Columns["employeeStart"].OptionsColumn.AllowEdit = false;

            gridView1.Columns["employeeStartName"].Width = 200;
            gridView1.Columns["employeeStartName"].Caption = "Instructor Name";
            gridView1.Columns["employeeStartName"].OptionsColumn.AllowEdit = false;

            gridView1.Columns["isGenre"].Caption = "Genre";
            gridView1.Columns["isUniform"].Caption = "Uniform";

            gridView1.Columns["productName"].Caption = "Product Name";
            gridView1.Columns["productName"].Visible = false;

            gridView1.Columns["room"].Caption = "Room";
            gridView1.Columns["room"].Visible = false;

            gridView1.Columns["memberName"].Caption = "Student Name";
            gridView1.Columns["memberName"].Visible = false;


            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, "isGenre", false);
                gridView1.SetRowCellValue(i, "isUniform", false);
            }


            gridView1.Columns["note"].Width = 230;
            gridView1.Columns["note"].Caption = "Note";
        }
       
      

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (gridView1.RowCount != 0)
            {
                verifyInstructor();
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void verifyInstructor()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                myConnection.Open();
                command.Connection = myConnection;
                command.Parameters.Clear();

                command.CommandText = "insert into module.instructorTrainingVerification (date, trainingUsage, employee, isGenre, isUniform, time, recid, note) values" +
                " (@date, @trainingUsage, @employee, @isGenre, @isUniform, GETDATE(), @recid, @note)";
                command.Parameters.AddWithValue("@date", DateTime.Today.Date);
                command.Parameters.AddWithValue("@trainingUsage", gridView1.GetRowCellValue(0,"counter").ToString().Trim());
                command.Parameters.AddWithValue("@employee", gridView1.GetRowCellValue(0, "employeeStart").ToString().Trim());
                command.Parameters.AddWithValue("@isGenre", Convert.ToBoolean(gridView1.GetRowCellValue(0, gridView1.Columns["isGenre"])));
                command.Parameters.AddWithValue("@isUniform", Convert.ToBoolean(gridView1.GetRowCellValue(0, gridView1.Columns["isUniform"])));
                command.Parameters.AddWithValue("@note", gridView1.GetRowCellDisplayText(0, gridView1.Columns["note"]));
                command.Parameters.AddWithValue("@recid", Partner.Userid);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert instructor outfit \n" + ex.Message);
            }
            finally
            {
                myConnection.Close();
                DialogResult = DialogResult.OK;
            }
        }

        private void alertControl1_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            e.AlertForm.Height = 100;
            e.AlertForm.Width = 300;
            e.AlertForm.OpacityLevel = 3;
        }

        private int tick1 = 2 * 60;// 2 meenit;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tick1 = tick1 - 1;
            if (tick1 == 0)
            {
                timer1.Stop();
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
