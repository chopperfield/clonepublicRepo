namespace RockStar.Training
{
    partial class PT_formMultiStart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lb_ClubName = new DevExpress.XtraEditors.LabelControl();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.pictureEdit_Logo = new DevExpress.XtraEditors.PictureEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::RockStar.Training.form_Wait), true, true);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Logo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_ClubName
            // 
            this.lb_ClubName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_ClubName.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lb_ClubName.Appearance.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lb_ClubName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lb_ClubName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lb_ClubName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_ClubName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lb_ClubName.Location = new System.Drawing.Point(344, 12);
            this.lb_ClubName.Name = "lb_ClubName";
            this.lb_ClubName.Size = new System.Drawing.Size(419, 73);
            this.lb_ClubName.TabIndex = 69;
            this.lb_ClubName.Text = "Kota Kasablanka";
            // 
            // alertControl1
            // 
            this.alertControl1.AllowHotTrack = false;
            this.alertControl1.AutoFormDelay = 5000;
            this.alertControl1.FormMaxCount = 1;
            this.alertControl1.FormShowingEffect = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.SlideHorizontal;
            this.alertControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.alertControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.alertControl1.ShowCloseButton = false;
            this.alertControl1.ShowPinButton = false;
            this.alertControl1.ShowToolTips = false;
            this.alertControl1.BeforeFormShow += new DevExpress.XtraBars.Alerter.AlertFormEventHandler(this.alertControl1_BeforeFormShow);
            // 
            // pictureEdit_Logo
            // 
            this.pictureEdit_Logo.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit_Logo.Name = "pictureEdit_Logo";
            this.pictureEdit_Logo.Properties.AllowFocused = false;
            this.pictureEdit_Logo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit_Logo.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit_Logo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit_Logo.Properties.ShowMenu = false;
            this.pictureEdit_Logo.Size = new System.Drawing.Size(72, 41);
            this.pictureEdit_Logo.TabIndex = 83;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(0, 20);
            this.textBox1.TabIndex = 84;
            this.textBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox1_PreviewKeyDown);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 101);
            this.gridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(769, 274);
            this.gridControl1.TabIndex = 85;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.CornflowerBlue;
            this.gridView1.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(this.gridView1_CustomDrawColumnHeader);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(117, 29);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(87, 56);
            this.simpleButton1.TabIndex = 88;
            this.simpleButton1.Text = "Start Scan";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(238, 29);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(87, 56);
            this.simpleButton2.TabIndex = 89;
            this.simpleButton2.Text = "Done";
            // 
            // PT_formMultiStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 378);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureEdit_Logo);
            this.Controls.Add(this.lb_ClubName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "PT_formMultiStart";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PT_formMultiStart";
            this.Load += new System.EventHandler(this.PT_formMultiStart_Load);
            this.Shown += new System.EventHandler(this.PT_formMultiStart_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PT_formMultiStart_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PT_formMultiStart_KeyDown);
            this.Resize += new System.EventHandler(this.PT_formMultiStart_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Logo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit_Logo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer2;
        private DevExpress.XtraEditors.LabelControl lb_ClubName;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}