﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Axioma.Celebrity.Fitness;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using System.Globalization;

namespace RockStar.Training
{
    public partial class PT_Session : Form
    {
        SqlConnection myConnection = new SqlConnection(Partner.configConnection);
        setup_Datatable setup_Datatable;

        private ToolStripProgressBar myProgressBar4;
        private NotifyIcon myNotify4;
     
        Bitmap gbr_inf = new Bitmap(Properties.Resources.info_icon, 25, 25);


        CultureInfo ci = new CultureInfo("EN-us");

        private string code_UserClub="";
        private string code_UserClubName = "";
        bool _isSingleClub = false;

        private DataTable dt_ins_fingerPrint;//instantiate on get fingerinstructor
        
        public PT_Session(ToolStripProgressBar statusProgressBar4, NotifyIcon statusNotify4)
        {
            InitializeComponent();
            myProgressBar4 = statusProgressBar4;
            myNotify4 = statusNotify4;

            ////menambahkan event click pada repository itemcombobox
            repositoryItemComboBox1.ButtonClick += RepositoryItemComboBox1_ButtonClick;
            repositoryItemComboBox2.ButtonClick += RepositoryItemComboBox2_ButtonClick;
            repositoryItemComboBox3.ButtonClick += RepositoryItemComboBox3_ButtonClick;
            repositoryItemComboBox4.ButtonClick += RepositoryItemComboBox4_ButtonClick;
            repositoryItemComboBox5.ButtonClick += RepositoryItemComboBox5_ButtonClick;
            repositoryItemComboBox6.ButtonClick += RepositoryItemComboBox6_ButtonClick;
            repositoryItemComboBox7.ButtonClick += RepositoryItemComboBox7_ButtonClick;
            repositoryItemComboBox8.ButtonClick += RepositoryItemComboBox8_ButtonClick;
            repositoryItemComboBox9.ButtonClick += RepositoryItemComboBox9_ButtonClick;
            repositoryItemComboBox10.ButtonClick += RepositoryItemComboBox10_ButtonClick;
            repositoryItemComboBox11.ButtonClick += RepositoryItemComboBox11_ButtonClick;
            repositoryItemComboBox12.ButtonClick += RepositoryItemComboBox12_ButtonClick;
            repositoryItemComboBox13.ButtonClick += RepositoryItemComboBox13_ButtonClick;
            repositoryItemComboBox14.ButtonClick += RepositoryItemComboBox14_ButtonClick;
            repositoryItemComboBox15.ButtonClick += RepositoryItemComboBox15_ButtonClick;
            repositoryItemComboBox16.ButtonClick += RepositoryItemComboBox16_ButtonClick;
            repositoryItemComboBox17.ButtonClick += RepositoryItemComboBox17_ButtonClick;
            repositoryItemComboBox18.ButtonClick += RepositoryItemComboBox18_ButtonClick;
            repositoryItemComboBox19.ButtonClick += RepositoryItemComboBox19_ButtonClick;

            repositoryItemComboBox20.ButtonClick += RepositoryItemComboBox20_ButtonClick; 
            repositoryItemComboBox21.ButtonClick += RepositoryItemComboBox21_ButtonClick;
            repositoryItemComboBox22.ButtonClick += RepositoryItemComboBox22_ButtonClick;


            ci.DateTimeFormat.ShortDatePattern = "dd MMM yyyy";
            ci.DateTimeFormat.LongDatePattern = "dd MMM yyyy";
            ci.DateTimeFormat.ShortTimePattern = "HH:mm:ss";
            ci.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            ci.DateTimeFormat.FullDateTimePattern = "dd MM yyyy HH:mm:ss";
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            DevExpress.Utils.FormatInfo.AlwaysUseThreadFormat = true;
        }


        private void PT_Session_Load(object sender, EventArgs e)
        {
            setup_Datatable = new setup_Datatable();

            Bitmap logo = new Bitmap(Properties.Resources.Logo_RSG);
            pictureEdit_Logo.Image = logo;

            this.Text = Partner.FormName.TrimStart();

            _isSingleClub = System.Text.RegularExpressions.Regex.IsMatch(Partner.FormParameter, @"\bclub\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
     
            if (Partner.AllowOther1 == false)//start PI
            {
                pictureEdit_PI_Start.Visible = false;
                pictureEdit_PI_Start.Enabled = false;
            }
            if (Partner.AllowOther2 == false)//finish PI
            {
                pictureEdit_PI_End.Visible = false;
                pictureEdit_PI_End.Enabled = false;
            }
            if (Partner.AllowPrint == false)
            {
                pictureEdit_Print.Visible = false;
                pictureEdit_Print.Enabled = false;
            }
            if (Partner.AllowSheet == false)
            {
                pictureEdit_Sheet.Visible = false;
                pictureEdit_Sheet.Enabled = false;
           }

            repositoryItemComboBox1.AutoComplete = false;
            repositoryItemComboBox2.AutoComplete = false;
            repositoryItemComboBox3.AutoComplete = false;
            repositoryItemComboBox4.AutoComplete = false;
            repositoryItemComboBox5.AutoComplete = false;
            repositoryItemComboBox6.AutoComplete = false;
            repositoryItemComboBox7.AutoComplete = false;
            repositoryItemComboBox8.AutoComplete = false;
            repositoryItemComboBox9.AutoComplete = false;
            repositoryItemComboBox10.AutoComplete = false;
            repositoryItemComboBox11.AutoComplete = false;
            repositoryItemComboBox12.AutoComplete = false;
            repositoryItemComboBox13.AutoComplete = false;
            repositoryItemComboBox14.AutoComplete = false;
            repositoryItemComboBox15.AutoComplete = false;
            repositoryItemComboBox16.AutoComplete = false;
            repositoryItemComboBox17.AutoComplete = false;
            repositoryItemComboBox18.AutoComplete = false;
            repositoryItemComboBox19.AutoComplete = false;
            repositoryItemComboBox20.AutoComplete = false;
            repositoryItemComboBox21.AutoComplete = false;
            repositoryItemComboBox22.AutoComplete = false;

            lb_Version.Text = Utils.getVersion();
            foreach (Control ctl in this.Controls)
            {
                ctl.Enabled = false;
            }
        }

        private void PT_Session_Shown(object sender, EventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormDescription("Fetching Data");
                get_UserClub();

                if (!_isSingleClub)//all club
                {
                    lb_UserClub.Text = "All Clubs";
                }            
                
                load_PrivateSession();
                arrangeCol();

                splashScreenManager1.SetWaitFormDescription("Fetching Biometric Data");
                get_Finger_Instructor();

            }
            catch (Exception ex)
            {
                splashScreenManager1.CloseWaitForm();
                MessageBox.Show(ex.Message);
            }
            try
            {

                splashScreenManager1.CloseWaitForm();               
                filterControl1.SourceControl = gridControl1;

                if (gridView1.RowCount != 0)
                {
                    gridControl1.Focus();
                    gridView1.Focus();
                    gridView1.FocusedRowHandle = 0;
                }
                foreach (Control ctl in this.Controls)
                {
                    ctl.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void get_UserClub()
        {
            DataTable dt = new DataTable();
            dt = setup_Datatable.dataTable_code_UserClub(Partner.Userid);
            code_UserClub = dt.Rows[0]["club"].ToString();
            lb_UserClub.Text = dt.Rows[0]["clubName"].ToString();
            code_UserClubName = dt.Rows[0]["clubName"].ToString();
        }

        private void get_Finger_Instructor()
        {
            dt_ins_fingerPrint = new DataTable();
            dt_ins_fingerPrint = setup_Datatable.dataTable_fingerPrint(true, "");
        }

        private void load_PrivateSession()
        {
            clear_repo();
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            bool allClub = !_isSingleClub;
            dt = setup_Datatable.datatable_Training_Running(allClub, code_UserClub);          

            if (dt != null || dt.Rows.Count != 0)
            {
                gridControl1.DataSource = dt;
                fill_repo();
            }
            else
            {
                gridControl1.DataSource = null;
            }
        }
         
        private void arrangeCol()
        {
            gridView1.Columns["onClubName"].VisibleIndex = 0;
            gridView1.Columns["onClubName"].Width = 150;
            gridView1.Columns["onClubName"].Caption = "On Club";

            gridView1.Columns["clubName"].VisibleIndex = 1;//4
            gridView1.Columns["clubName"].Width = 150;
            gridView1.Columns["clubName"].Caption = "Club";//Club Name

            gridView1.Columns["counter"].VisibleIndex = 2;//1
            gridView1.Columns["counter"].Width = 70;
            gridView1.Columns["counter"].Caption = "Usage No";            

            gridView1.Columns["date"].VisibleIndex = 3;//2
            gridView1.Columns["date"].Width = 100;
            gridView1.Columns["date"].Caption = "Date";
            gridView1.Columns["date"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["date"].DisplayFormat.FormatString = "dd MMM yyyy";
            gridView1.Columns["date"].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Equals;
            gridView1.Columns["date"].ColumnEdit = repositoryItemComboBox3;
            gridView1.Columns["date"].ColumnEdit.EditFormat.FormatType = FormatType.DateTime;
            gridView1.Columns["date"].ColumnEdit.EditFormat.FormatString = "dd MMM yyyy";

            gridView1.Columns["memberStart"].Caption = "RGP";
            gridView1.Columns["memberStart"].VisibleIndex = 4;//1
            gridView1.Columns["memberStart"].Width = 70;
            gridView1.Columns["memberStart"].Caption = "RGP";

            gridView1.Columns["memberName"].VisibleIndex = 5;
            gridView1.Columns["memberName"].Width = 150;
            gridView1.Columns["memberName"].Caption = "Member Name";

            gridView1.Columns["training"].VisibleIndex = 6;//3
            gridView1.Columns["training"].Width = 70;
            gridView1.Columns["training"].Caption = "Package No";
            
            gridView1.Columns["productName"].VisibleIndex = 7;//6
            gridView1.Columns["productName"].Width = 200;
            gridView1.Columns["productName"].Caption = "Package Name";

            gridView1.Columns["trainingStart"].VisibleIndex = 8;//7
            gridView1.Columns["trainingStart"].Width = 150;
            gridView1.Columns["trainingStart"].Caption = "Time Start";
            gridView1.Columns["trainingStart"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["trainingStart"].DisplayFormat.FormatString = "dd MMM yyyy HH:mm:ss";
            gridView1.Columns["trainingStart"].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Equals;
            gridView1.Columns["trainingStart"].ColumnEdit = repositoryItemComboBox8;
            gridView1.Columns["trainingStart"].ColumnEdit.EditFormat.FormatType = FormatType.DateTime;
            gridView1.Columns["trainingStart"].ColumnEdit.EditFormat.FormatString = "dd MMM yyyy HH:mm:ss";

            gridView1.Columns["trainingEnd"].VisibleIndex = 9;//8
            gridView1.Columns["trainingEnd"].Width = 150;
            gridView1.Columns["trainingEnd"].Caption = "Time End";
            gridView1.Columns["trainingEnd"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["trainingEnd"].DisplayFormat.FormatString = "dd MMM yyyy HH:mm:ss";
            gridView1.Columns["trainingEnd"].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Equals;
            gridView1.Columns["trainingEnd"].ColumnEdit = repositoryItemComboBox9;
            gridView1.Columns["trainingEnd"].ColumnEdit.EditFormat.FormatType = FormatType.DateTime;
            gridView1.Columns["trainingEnd"].ColumnEdit.EditFormat.FormatString = "dd MMM yyyy HH:mm:ss";

            gridView1.Columns["session"].VisibleIndex = 10;//9
            gridView1.Columns["session"].Width = 150;
            gridView1.Columns["session"].Caption = "Session";

            gridView1.Columns["note"].VisibleIndex = 11;//10
            gridView1.Columns["note"].Width = 150;
            gridView1.Columns["note"].Caption = "Note";

            gridView1.Columns["type"].Caption = "Type";
            gridView1.Columns["type"].Visible = false;

            gridView1.Columns["club"].Caption = "Club";
            gridView1.Columns["club"].Visible = false;
         
            gridView1.Columns["employeeStart"].Caption = "Employee Start";
            gridView1.Columns["employeeStart"].Visible = false;
            gridView1.Columns["memberEnd"].Caption = "Member End";
            gridView1.Columns["memberEnd"].Visible = false;
            gridView1.Columns["employeeEnd"].Caption = "Employee End";
            gridView1.Columns["employeeEnd"].Visible = false;
            gridView1.Columns["recid"].Caption = "Recid";
            gridView1.Columns["recid"].Visible = false;
            gridView1.Columns["code"].Caption = "Code";
            gridView1.Columns["code"].Visible = false;
            gridView1.Columns["agreement"].Caption = "Agreement";
            gridView1.Columns["agreement"].Visible = false;
            gridView1.Columns["firstName"].Caption = "First Name";
            gridView1.Columns["firstName"].Visible = false;
            gridView1.Columns["lastName"].Caption = "Last Name";
            gridView1.Columns["lastName"].Visible = false;
        }

                


        public void clear_repo()
        {
            repositoryItemComboBox1.Items.Clear();
            repositoryItemComboBox2.Items.Clear();
            repositoryItemComboBox3.Items.Clear();
            repositoryItemComboBox4.Items.Clear();
            repositoryItemComboBox5.Items.Clear();
            repositoryItemComboBox6.Items.Clear();
            repositoryItemComboBox7.Items.Clear();
            repositoryItemComboBox8.Items.Clear();
            repositoryItemComboBox9.Items.Clear();
            repositoryItemComboBox10.Items.Clear();
            repositoryItemComboBox11.Items.Clear();
            repositoryItemComboBox12.Items.Clear();
            repositoryItemComboBox13.Items.Clear();
            repositoryItemComboBox14.Items.Clear();
            repositoryItemComboBox15.Items.Clear();
            repositoryItemComboBox16.Items.Clear();
            repositoryItemComboBox17.Items.Clear();
            repositoryItemComboBox18.Items.Clear();
            repositoryItemComboBox19.Items.Clear();
            repositoryItemComboBox20.Items.Clear();
            repositoryItemComboBox21.Items.Clear();
            repositoryItemComboBox22.Items.Clear();
        }
        private void pictureEdit2_MouseClick(object sender, MouseEventArgs e)
        {                        
            printview();
        }
        private void printview()
        {
            Utils.printView(gridControl1, gridView1, this.Text);

        }

        private void pictureEdit3_MouseClick(object sender, MouseEventArgs e)
        {
            savefile();
        }
        private void savefile()
        {
            Utils.saveFile(gridControl1);
        }

        private void pictureEdit4_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void PT_Session_KeyDown(object sender, KeyEventArgs e)
        {
            GridView view = sender as GridView;        
            if(e.KeyCode == Keys.F7 && pictureEdit_PI_Start.Visible == true)
            {
                startPI();
            }
            if(e.KeyCode == Keys.F8 && pictureEdit_PI_End.Visible == true)
            {
                endPI();
            }
            if (e.Control && e.KeyCode == Keys.T && pictureEdit_Print.Visible == true)
            {
                savefile();
            }
            if (e.Control && e.KeyCode == Keys.P && pictureEdit_Sheet.Visible == true)
            {
                printview();
            }
            if (e.Control && e.KeyCode == Keys.Q)
            {
                Close();
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //GridView View = sender as GridView;
           
            //if (e.RowHandle >= 0)
            //{ 
            //    string voidBy = View.GetRowCellDisplayText(e.RowHandle, View.Columns["voidBy"]);
            //    if (voidBy.Trim() != string.Empty)
            //    {
            //        e.Appearance.ForeColor = Color.DimGray;
            //        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Italic);
            //        View.Appearance.HideSelectionRow.ForeColor = Color.DimGray;

            //    }
            //}
            
        }



        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            load_PrivateSession();
            splashScreenManager1.CloseWaitForm();

            alertControl1.Show(this, "Data center", "Data refreshed", gbr_inf);
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            if (filterToolStripMenuItem.Checked == true)
            {
                splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
                gridView1.OptionsView.ShowAutoFilterRow = true;
                gridView1.OptionsCustomization.AllowFilter = true;

            }
            else if (filterToolStripMenuItem.Checked == false)
            {
                splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
                splitContainerControl1.Panel1.Visible = false;
                gridView1.OptionsView.ShowAutoFilterRow = false;
                gridView1.ActiveFilter.Clear();
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f_frm = new form_Find(gridView1);
            f_frm.Show(this);
            f_frm.labelControl6.Text = this.Text;
        }

        private void hideOrShowPanelGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hideOrShowPanelGroupToolStripMenuItem.Checked == true)
            {
                gridView1.OptionsView.ShowGroupPanel = true;


            }
            else if (hideOrShowPanelGroupToolStripMenuItem.Checked == false)
            {
                gridView1.OptionsView.ShowGroupPanel = false;

            }
        }

        private void expandAllGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.ExpandAllGroups();
        }

        private void collapseAllGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.CollapseAllGroups();

        }

        private void hideOrShowTotalGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hideOrShowTotalGroupToolStripMenuItem.Checked == true)
            {

                GridGroupSummaryItem item = new GridGroupSummaryItem();
                item.FieldName = "counter";
                item.SummaryType = DevExpress.Data.SummaryItemType.Count;
                gridView1.GroupSummary.Add(item);

            }
            else if (hideOrShowTotalGroupToolStripMenuItem.Checked == false)
            {
                gridView1.GroupSummary.Clear();

            }
        }

        private void hideOrShowTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hideOrShowTotalToolStripMenuItem.Checked == true)
            {
                gridView1.OptionsView.ShowFooter = true;
                gridView1.Columns["counter"].Summary.Add(DevExpress.Data.SummaryItemType.Count);

            }
            else if (hideOrShowTotalToolStripMenuItem.Checked == false)
            {
                gridView1.OptionsView.ShowFooter = false;
                gridView1.Columns["counter"].Summary.Clear();

            }
        }

        private void columnSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.ShowCustomization();
        }

        private void filterControl1_FilterChanged(object sender, FilterChangedEventArgs e)
        {
            filterControl1.ApplyFilter();           
            
        }

        RepositoryItemComboBox repositoryItemComboBox1 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox2 = new RepositoryItemComboBox();        
        RepositoryItemComboBox repositoryItemComboBox3 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox4 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox5 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox6 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox7 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox8 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox9 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox10 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox11 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox12 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox13 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox14 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox15 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox16 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox17 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox18 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox19 = new RepositoryItemComboBox();
        RepositoryItemComboBox repositoryItemComboBox20 = new RepositoryItemComboBox(); 
        RepositoryItemComboBox repositoryItemComboBox21 = new RepositoryItemComboBox(); 
        RepositoryItemComboBox repositoryItemComboBox22 = new RepositoryItemComboBox(); 

        EditorButton clr = new EditorButton(ButtonPredefines.Close);

        private void RepositoryItemComboBox1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["onClubName"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox2_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["counter"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox3_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["date"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox4_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["training"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox5_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["clubName"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox6_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["memberName"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox7_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["productName"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox8_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["trainingStart"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox9_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["trainingEnd"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox10_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["session"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox11_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["note"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox12_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["type"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox13_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["club"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox14_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["memberStart"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox15_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["employeeStart"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox16_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["memberEnd"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox17_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["employeeEnd"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox18_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["recid"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox19_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["code"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox20_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["agreement"].ClearFilter();
            }
        }
        private void RepositoryItemComboBox21_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["firstName"].ClearFilter();
            }
        }

        private void RepositoryItemComboBox22_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridView1.Columns["lastEnd"].ClearFilter();
            }
        }

        public void button_repo()
        {
            repositoryItemComboBox1.Buttons.Add(clr);
            repositoryItemComboBox2.Buttons.Add(clr);
            repositoryItemComboBox3.Buttons.Add(clr);
            repositoryItemComboBox4.Buttons.Add(clr);
            repositoryItemComboBox5.Buttons.Add(clr);
            repositoryItemComboBox6.Buttons.Add(clr);
            repositoryItemComboBox7.Buttons.Add(clr);
            repositoryItemComboBox8.Buttons.Add(clr);
            repositoryItemComboBox9.Buttons.Add(clr);
            repositoryItemComboBox10.Buttons.Add(clr);
            repositoryItemComboBox11.Buttons.Add(clr);
            repositoryItemComboBox12.Buttons.Add(clr);
            repositoryItemComboBox13.Buttons.Add(clr);
            repositoryItemComboBox14.Buttons.Add(clr);
            repositoryItemComboBox15.Buttons.Add(clr);
            repositoryItemComboBox16.Buttons.Add(clr);
            repositoryItemComboBox17.Buttons.Add(clr);
            repositoryItemComboBox18.Buttons.Add(clr);
            repositoryItemComboBox19.Buttons.Add(clr);

            repositoryItemComboBox20.Buttons.Add(clr); 
            repositoryItemComboBox21.Buttons.Add(clr); 
            repositoryItemComboBox22.Buttons.Add(clr);

        }

        public void fill_repo()
        {          
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetDataRow(i) == null)
                {
                    break;
                }

                string onClubName = gridView1.GetDataRow(i)["onClubName"].ToString();
                if (!repositoryItemComboBox1.Items.Contains(onClubName))
                {
                    repositoryItemComboBox1.Items.Add(onClubName);
                }


                int counter = int.Parse(gridView1.GetDataRow(i)["counter"].ToString());
                if (!repositoryItemComboBox2.Items.Contains(counter))
                {
                    repositoryItemComboBox2.Items.Add(counter);
                }

                if (gridView1.GetDataRow(i)["date"] != DBNull.Value)
                {
                    DateTime date = Convert.ToDateTime(gridView1.GetDataRow(i)["date"]);
                    if (!repositoryItemComboBox3.Items.Contains(date.ToShortDateString()))
                    {
                        repositoryItemComboBox3.Items.Add(date.ToShortDateString());
                    }
                }

                int training = int.Parse(gridView1.GetDataRow(i)["training"].ToString());
                if (!repositoryItemComboBox4.Items.Contains(training))
                {
                    repositoryItemComboBox4.Items.Add(training);
                }

                string clubName = gridView1.GetDataRow(i)["clubName"].ToString();
                if (!repositoryItemComboBox5.Items.Contains(clubName))
                {
                    repositoryItemComboBox5.Items.Add(clubName);
                }

                string memberName = gridView1.GetDataRow(i)["memberName"].ToString();
                if (!repositoryItemComboBox6.Items.Contains(memberName))
                {
                    repositoryItemComboBox6.Items.Add(memberName);
                }

                string productName = gridView1.GetDataRow(i)["productName"].ToString();
                if (!repositoryItemComboBox7.Items.Contains(productName))
                {
                    repositoryItemComboBox7.Items.Add(productName);
                }


                if (gridView1.GetDataRow(i)["trainingStart"] != DBNull.Value)
                {
                    DateTime trainingStart = Convert.ToDateTime(gridView1.GetDataRow(i)["trainingStart"]);
                    if (!repositoryItemComboBox8.Items.Contains(trainingStart))
                    {
                        repositoryItemComboBox8.Items.Add(trainingStart);
                    }
                }

                if (gridView1.GetDataRow(i)["trainingEnd"] != DBNull.Value)
                {
                    DateTime trainingEnd = Convert.ToDateTime(gridView1.GetDataRow(i)["trainingEnd"]);
                    if (!repositoryItemComboBox9.Items.Contains(trainingEnd))
                    {
                        repositoryItemComboBox9.Items.Add(trainingEnd);
                    }
                }


                int session = int.Parse(gridView1.GetDataRow(i)["session"].ToString());
                if (!repositoryItemComboBox10.Items.Contains(session))
                {
                    repositoryItemComboBox10.Items.Add(session);
                }

                string note = gridView1.GetDataRow(i)["note"].ToString();
                if (!repositoryItemComboBox11.Items.Contains(note))
                {
                    repositoryItemComboBox11.Items.Add(note);
                }

                string type = gridView1.GetDataRow(i)["type"].ToString();
                if (!repositoryItemComboBox12.Items.Contains(type))
                {
                    repositoryItemComboBox12.Items.Add(type);
                }

                string club = gridView1.GetDataRow(i)["club"].ToString();
                if (!repositoryItemComboBox13.Items.Contains(club))
                {
                    repositoryItemComboBox13.Items.Add(club);
                }

                string memberStart =gridView1.GetDataRow(i)["memberStart"].ToString();
                if (!repositoryItemComboBox14.Items.Contains(memberStart))
                {
                    repositoryItemComboBox14.Items.Add(memberStart);
                }

                string employeeStart = gridView1.GetDataRow(i)["employeeStart"].ToString();
                if (!repositoryItemComboBox15.Items.Contains(employeeStart))
                {
                    repositoryItemComboBox15.Items.Add(employeeStart);
                }

                string memberEnd = gridView1.GetDataRow(i)["memberEnd"].ToString();
                if (!repositoryItemComboBox16.Items.Contains(memberEnd))
                {
                    repositoryItemComboBox16.Items.Add(memberEnd);
                }

                string employeeEnd = gridView1.GetDataRow(i)["employeeEnd"].ToString();
                if (!repositoryItemComboBox17.Items.Contains(employeeEnd))
                {
                    repositoryItemComboBox17.Items.Add(employeeEnd);
                }

                string recid = gridView1.GetDataRow(i)["recid"].ToString();
                if (!repositoryItemComboBox18.Items.Contains(recid))
                {
                    repositoryItemComboBox18.Items.Add(recid);
                }

                string code = gridView1.GetDataRow(i)["code"].ToString();
                if (!repositoryItemComboBox19.Items.Contains(code))
                {
                    repositoryItemComboBox19.Items.Add(code);
                }

                string agreement = gridView1.GetDataRow(i)["agreement"].ToString();
                if (!repositoryItemComboBox20.Items.Contains(agreement))
                {
                    repositoryItemComboBox20.Items.Add(agreement);
                }

                string firstName = gridView1.GetDataRow(i)["firstName"].ToString();
                if (!repositoryItemComboBox21.Items.Contains(firstName))
                {
                    repositoryItemComboBox21.Items.Add(firstName);
                }

                string lastName = gridView1.GetDataRow(i)["lastName"].ToString();
                if (!repositoryItemComboBox22.Items.Contains(lastName))
                {
                    repositoryItemComboBox22.Items.Add(lastName);
                }
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {

            clr.Visible = true;
            GridView view = sender as GridView;

            if (e.Column.FieldName == "onClubName" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox1;
                repositoryItemComboBox1.Sorted = true;
            }
            if (e.Column.FieldName == "counter" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox2;
            }
            if (e.Column.FieldName == "date" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox3;
                repositoryItemComboBox3.Sorted = true;
            }
            if (e.Column.FieldName == "training" && view.IsFilterRow(e.RowHandle))
            {

                e.RepositoryItem = repositoryItemComboBox4;
                repositoryItemComboBox4.Sorted = true;

            }
            if (e.Column.FieldName == "clubName" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox5;
                repositoryItemComboBox5.Sorted = true;
            }
            if (e.Column.FieldName == "memberName" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox6;
                repositoryItemComboBox6.Sorted = true;

            }
            if (e.Column.FieldName == "productName" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox7;
                repositoryItemComboBox7.Sorted = true;

            }
            if (e.Column.FieldName == "trainingStart" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox8;
                repositoryItemComboBox8.Sorted = true;

            }
            if (e.Column.FieldName == "trainingEnd" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox9;
                repositoryItemComboBox9.Sorted = true;
            }
            if (e.Column.FieldName == "session" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox10;
                repositoryItemComboBox10.Sorted = true;
            }
            if (e.Column.FieldName == "note" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox11;
                repositoryItemComboBox11.Sorted = true;
            }
            if (e.Column.FieldName == "type" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox12;
                repositoryItemComboBox12.Sorted = true;
            }
            if (e.Column.FieldName == "club" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox13;
                repositoryItemComboBox13.Sorted = true;
            }
            if (e.Column.FieldName == "memberStart" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox14;
                repositoryItemComboBox14.Sorted = true;
            }
            if (e.Column.FieldName == "employeeStart" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox15;
                repositoryItemComboBox15.Sorted = true;
            }
            if (e.Column.FieldName == "memberEnd" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox16;
                repositoryItemComboBox16.Sorted = true;
            }
            if (e.Column.FieldName == "employeeEnd" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox17;
                repositoryItemComboBox17.Sorted = true;
            }
            if (e.Column.FieldName == "recid" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox18;
                repositoryItemComboBox18.Sorted = true;
            }
            if (e.Column.FieldName == "code" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox19;
                repositoryItemComboBox19.Sorted = true;
            }

            if (e.Column.FieldName == "agreement" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox20;
                repositoryItemComboBox20.Sorted = true;
            }
            if (e.Column.FieldName == "firstName" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox21;
                repositoryItemComboBox21.Sorted = true;
            }
            if (e.Column.FieldName == "lastName" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox22;
                repositoryItemComboBox22.Sorted = true;
            }
        }

        private void filterControl1_BeforeShowValueEditor(object sender, DevExpress.XtraEditors.Filtering.ShowValueEditorEventArgs e)
        {
            clr.Visible = false;
            if (e.CurrentNode.Property.Name == "onClubName")
            {               
                e.CustomRepositoryItem = repositoryItemComboBox1;
            }
            if (e.CurrentNode.Property.Name == "counter")
            {               
                e.CustomRepositoryItem = repositoryItemComboBox2;                
            }
            if (e.CurrentNode.Property.Name == "date")
            {             
                e.CustomRepositoryItem = repositoryItemComboBox3;
            }
            if (e.CurrentNode.Property.Name == "training")
            {
                e.CustomRepositoryItem = repositoryItemComboBox4;
            }
            if (e.CurrentNode.Property.Name == "clubName")
            {
                e.CustomRepositoryItem = repositoryItemComboBox5;
            }
            if (e.CurrentNode.Property.Name == "memberName")
            {
                e.CustomRepositoryItem = repositoryItemComboBox6;
            }
            if (e.CurrentNode.Property.Name == "productName")
            {
                e.CustomRepositoryItem = repositoryItemComboBox7;
            }
            if (e.CurrentNode.Property.Name == "trainingStart")
            {
                e.CustomRepositoryItem = repositoryItemComboBox8;
            }
            if (e.CurrentNode.Property.Name == "trainingEnd")
            {

                e.CustomRepositoryItem = repositoryItemComboBox9;
            }
            if (e.CurrentNode.Property.Name == "session")
            {
                e.CustomRepositoryItem = repositoryItemComboBox10;
            }
            if (e.CurrentNode.Property.Name == "note")
            {
                e.CustomRepositoryItem = repositoryItemComboBox11;
            }
            if (e.CurrentNode.Property.Name == "type")
            {
                e.CustomRepositoryItem = repositoryItemComboBox12;
            }
            if (e.CurrentNode.Property.Name == "club")
            {
                e.CustomRepositoryItem = repositoryItemComboBox13;
            }
            if (e.CurrentNode.Property.Name == "memberStart")
            {
                e.CustomRepositoryItem = repositoryItemComboBox14;
            }
            if (e.CurrentNode.Property.Name == "employeeStart")
            {
                e.CustomRepositoryItem = repositoryItemComboBox15;
            }
            if (e.CurrentNode.Property.Name == "memberEnd")
            {
                e.CustomRepositoryItem = repositoryItemComboBox16;
            }
            if (e.CurrentNode.Property.Name == "employeeEnd")
            {
                e.CustomRepositoryItem = repositoryItemComboBox17;
            }
            if (e.CurrentNode.Property.Name == "recid")
            {
                e.CustomRepositoryItem = repositoryItemComboBox18;
            }
            if (e.CurrentNode.Property.Name == "code")
            {
                e.CustomRepositoryItem = repositoryItemComboBox19;
               
            }
            if (e.CurrentNode.Property.Name == "agreement")
            {
                e.CustomRepositoryItem = repositoryItemComboBox20;
            }
            if (e.CurrentNode.Property.Name == "firstName")
            {
                e.CustomRepositoryItem = repositoryItemComboBox21;
            }
            if (e.CurrentNode.Property.Name == "lsatName")
            {
                e.CustomRepositoryItem = repositoryItemComboBox22;
            }
        }


        private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (gridView1.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem.Appearance.Assign(gridView1.PaintAppearance.FocusedCell);
            }
        }

        private void alertControl1_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            e.AlertForm.Height = 100;
            e.AlertForm.Width = 300;
            e.AlertForm.OpacityLevel = 3;
        }

        private void pictureEdit_PI_Start_MouseClick(object sender, MouseEventArgs e)
        {
            startPI();  
        }

        private void startPI()
        {
            PT_formStart pt_formStart = new PT_formStart(code_UserClubName, code_UserClub, dt_ins_fingerPrint);
            if (pt_formStart.ShowDialog() == DialogResult.OK)
            {
                load_PrivateSession();
                alertControl1.Show(this, "Data center", "Data refreshed", gbr_inf);
            }
        }

        private void pictureEdit_PI_End_Click(object sender, EventArgs e)
        {
            endPI();
        }

        private void endPI()
        {
            try
            {
                string counter_Session = gridView1.GetFocusedRowCellDisplayText("counter").ToString().Trim();
                string student_Name = gridView1.GetFocusedRowCellDisplayText("memberName").ToString().Trim();
                string student_RGP = gridView1.GetFocusedRowCellDisplayText("code").ToString().Trim();
                string product_Name = gridView1.GetFocusedRowCellDisplayText("productName").ToString().Trim();
                string employee_Start = gridView1.GetFocusedRowCellDisplayText("employeeStart").ToString().Trim();

                PT_formEnd pt_formEnd = new PT_formEnd(code_UserClubName, counter_Session, student_Name, student_RGP, product_Name, dt_ins_fingerPrint, employee_Start);
                if (pt_formEnd.ShowDialog() == DialogResult.OK)
                {
                    load_PrivateSession();
                    alertControl1.Show(this, "Data center", "Data refreshed", gbr_inf);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }

    
}
