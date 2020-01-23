namespace RockStar.Training
{
    partial class PT_formEnd2
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lb_Info = new DevExpress.XtraEditors.LabelControl();
            this.lb_Usage = new DevExpress.XtraEditors.LabelControl();
            this.lb_ClubName = new DevExpress.XtraEditors.LabelControl();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.pictureEdit_Logo = new DevExpress.XtraEditors.PictureEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureEdit_Student_Attendees = new DevExpress.XtraEditors.PictureEdit();
            this.lb_Student_Name = new DevExpress.XtraEditors.LabelControl();
            this.lb_Student_RGP = new DevExpress.XtraEditors.LabelControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::RockStar.Training.form_Wait), true, true);
            this.lb_productName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Logo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Student_Attendees.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(26)))), ((int)(((byte)(77)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lb_Info);
            this.panelControl1.Controls.Add(this.lb_Usage);
            this.panelControl1.Location = new System.Drawing.Point(3, 197);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(769, 32);
            this.panelControl1.TabIndex = 73;
            // 
            // lb_Info
            // 
            this.lb_Info.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Info.Appearance.ForeColor = System.Drawing.Color.White;
            this.lb_Info.Location = new System.Drawing.Point(12, 5);
            this.lb_Info.Name = "lb_Info";
            this.lb_Info.Size = new System.Drawing.Size(166, 18);
            this.lb_Info.TabIndex = 54;
            this.lb_Info.Text = "Please Tap Student Card";
            // 
            // lb_Usage
            // 
            this.lb_Usage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Usage.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Usage.Appearance.ForeColor = System.Drawing.Color.White;
            this.lb_Usage.Location = new System.Drawing.Point(677, 5);
            this.lb_Usage.Name = "lb_Usage";
            this.lb_Usage.Size = new System.Drawing.Size(83, 18);
            this.lb_Usage.TabIndex = 71;
            this.lb_Usage.Text = "Finish Usage";
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
            this.lb_ClubName.Location = new System.Drawing.Point(297, 12);
            this.lb_ClubName.Name = "lb_ClubName";
            this.lb_ClubName.Size = new System.Drawing.Size(466, 73);
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
            // pictureEdit_Student_Attendees
            // 
            this.pictureEdit_Student_Attendees.Location = new System.Drawing.Point(9, 59);
            this.pictureEdit_Student_Attendees.Name = "pictureEdit_Student_Attendees";
            this.pictureEdit_Student_Attendees.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit_Student_Attendees.Properties.ShowMenu = false;
            this.pictureEdit_Student_Attendees.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit_Student_Attendees.Size = new System.Drawing.Size(100, 120);
            this.pictureEdit_Student_Attendees.TabIndex = 86;
            // 
            // lb_Student_Name
            // 
            this.lb_Student_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Student_Name.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Student_Name.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.lb_Student_Name.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lb_Student_Name.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lb_Student_Name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_Student_Name.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lb_Student_Name.Location = new System.Drawing.Point(115, 91);
            this.lb_Student_Name.Name = "lb_Student_Name";
            this.lb_Student_Name.Size = new System.Drawing.Size(648, 47);
            this.lb_Student_Name.TabIndex = 87;
            this.lb_Student_Name.Text = "Student Name";
            // 
            // lb_Student_RGP
            // 
            this.lb_Student_RGP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Student_RGP.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Student_RGP.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lb_Student_RGP.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lb_Student_RGP.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lb_Student_RGP.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_Student_RGP.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lb_Student_RGP.Location = new System.Drawing.Point(115, 59);
            this.lb_Student_RGP.Name = "lb_Student_RGP";
            this.lb_Student_RGP.Size = new System.Drawing.Size(317, 26);
            this.lb_Student_RGP.TabIndex = 88;
            this.lb_Student_RGP.Text = "RGP : 825";
            // 
            // lb_productName
            // 
            this.lb_productName.AllowHtmlString = true;
            this.lb_productName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_productName.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_productName.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lb_productName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lb_productName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lb_productName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_productName.Location = new System.Drawing.Point(115, 144);
            this.lb_productName.Name = "lb_productName";
            this.lb_productName.Size = new System.Drawing.Size(648, 35);
            this.lb_productName.TabIndex = 89;
            this.lb_productName.Text = "Jump Start - Welcome";
            // 
            // PT_formEnd2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 232);
            this.Controls.Add(this.lb_productName);
            this.Controls.Add(this.lb_Student_RGP);
            this.Controls.Add(this.lb_Student_Name);
            this.Controls.Add(this.pictureEdit_Student_Attendees);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureEdit_Logo);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.lb_ClubName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "PT_formEnd2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PT_formEnd2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PT_formEnd2_FormClosed);
            this.Load += new System.EventHandler(this.PT_formEnd2_Load);
            this.Shown += new System.EventHandler(this.PT_formEnd2_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PT_formEnd2_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PT_formEnd2_KeyDown);
            this.Resize += new System.EventHandler(this.PT_formEnd2_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Logo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Student_Attendees.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraEditors.LabelControl lb_Info;
        public DevExpress.XtraEditors.LabelControl lb_Usage;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit_Logo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer2;
        private DevExpress.XtraEditors.LabelControl lb_ClubName;
        private DevExpress.XtraEditors.PictureEdit pictureEdit_Student_Attendees;
        private DevExpress.XtraEditors.LabelControl lb_Student_Name;
        private DevExpress.XtraEditors.LabelControl lb_Student_RGP;
        public DevExpress.XtraEditors.LabelControl lb_productName;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}