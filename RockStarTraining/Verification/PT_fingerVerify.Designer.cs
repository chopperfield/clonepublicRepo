namespace RockStar.Training
{
    partial class PT_fingerVerify
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
            this.lb_productName = new DevExpress.XtraEditors.LabelControl();
            this.lb_clubName = new DevExpress.XtraEditors.LabelControl();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.pictureEdit_Logo = new DevExpress.XtraEditors.PictureEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_Instructor_Name = new DevExpress.XtraEditors.LabelControl();
            this.lb_Room = new DevExpress.XtraEditors.LabelControl();
            this.lb_Student_Name = new DevExpress.XtraEditors.LabelControl();
            this.lb_authorize = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Logo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(26)))), ((int)(((byte)(77)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lb_Info);
            this.panelControl1.Controls.Add(this.lb_Usage);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 136);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(648, 26);
            this.panelControl1.TabIndex = 73;
            // 
            // lb_Info
            // 
            this.lb_Info.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Info.Appearance.ForeColor = System.Drawing.Color.White;
            this.lb_Info.Location = new System.Drawing.Point(12, 5);
            this.lb_Info.Name = "lb_Info";
            this.lb_Info.Size = new System.Drawing.Size(134, 14);
            this.lb_Info.TabIndex = 54;
            this.lb_Info.Text = "Please Scan Your Finger";
            // 
            // lb_Usage
            // 
            this.lb_Usage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Usage.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Usage.Appearance.ForeColor = System.Drawing.Color.White;
            this.lb_Usage.Location = new System.Drawing.Point(456, 5);
            this.lb_Usage.Name = "lb_Usage";
            this.lb_Usage.Size = new System.Drawing.Size(180, 14);
            this.lb_Usage.TabIndex = 71;
            this.lb_Usage.Text = "Verify Private Instruction Session";
            // 
            // lb_productName
            // 
            this.lb_productName.AllowHtmlString = true;
            this.lb_productName.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_productName.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lb_productName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lb_productName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lb_productName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_productName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lb_productName.Location = new System.Drawing.Point(12, 84);
            this.lb_productName.Name = "lb_productName";
            this.lb_productName.Size = new System.Drawing.Size(301, 46);
            this.lb_productName.TabIndex = 70;
            this.lb_productName.Text = "Jump Start - Welcome";
            this.lb_productName.UseMnemonic = false;
            // 
            // lb_clubName
            // 
            this.lb_clubName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_clubName.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lb_clubName.Appearance.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lb_clubName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lb_clubName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lb_clubName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lb_clubName.Location = new System.Drawing.Point(236, 12);
            this.lb_clubName.Name = "lb_clubName";
            this.lb_clubName.Size = new System.Drawing.Size(400, 23);
            this.lb_clubName.TabIndex = 69;
            this.lb_clubName.Text = "Kota Kasablanka";
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
            // lb_Instructor_Name
            // 
            this.lb_Instructor_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Instructor_Name.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lb_Instructor_Name.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lb_Instructor_Name.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lb_Instructor_Name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lb_Instructor_Name.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lb_Instructor_Name.Location = new System.Drawing.Point(319, 80);
            this.lb_Instructor_Name.Name = "lb_Instructor_Name";
            this.lb_Instructor_Name.Size = new System.Drawing.Size(317, 19);
            this.lb_Instructor_Name.TabIndex = 84;
            this.lb_Instructor_Name.Text = "Instructor: Director Fury";
            // 
            // lb_Room
            // 
            this.lb_Room.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Room.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lb_Room.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lb_Room.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lb_Room.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lb_Room.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lb_Room.Location = new System.Drawing.Point(472, 105);
            this.lb_Room.Name = "lb_Room";
            this.lb_Room.Size = new System.Drawing.Size(164, 19);
            this.lb_Room.TabIndex = 85;
            this.lb_Room.Text = "Room: Gymnastics";
            // 
            // lb_Student_Name
            // 
            this.lb_Student_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Student_Name.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Student_Name.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.lb_Student_Name.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lb_Student_Name.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lb_Student_Name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lb_Student_Name.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lb_Student_Name.Location = new System.Drawing.Point(12, 53);
            this.lb_Student_Name.Name = "lb_Student_Name";
            this.lb_Student_Name.Size = new System.Drawing.Size(430, 21);
            this.lb_Student_Name.TabIndex = 88;
            this.lb_Student_Name.Text = "Student Name";
            // 
            // lb_authorize
            // 
            this.lb_authorize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_authorize.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lb_authorize.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lb_authorize.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lb_authorize.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lb_authorize.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lb_authorize.Location = new System.Drawing.Point(472, 41);
            this.lb_authorize.Name = "lb_authorize";
            this.lb_authorize.Size = new System.Drawing.Size(164, 19);
            this.lb_authorize.TabIndex = 89;
            this.lb_authorize.Text = "GM/AGM";
            // 
            // PT_fingerVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 162);
            this.Controls.Add(this.lb_authorize);
            this.Controls.Add(this.lb_Student_Name);
            this.Controls.Add(this.lb_Room);
            this.Controls.Add(this.lb_Instructor_Name);
            this.Controls.Add(this.pictureEdit_Logo);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.lb_productName);
            this.Controls.Add(this.lb_clubName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "PT_fingerVerify";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PT_fingerVerify";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PT_fingerVerify_FormClosed);
            this.Load += new System.EventHandler(this.PT_fingerVerify_Load);
            this.Shown += new System.EventHandler(this.PT_fingerVerify_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PT_fingerVerify_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PT_fingerVerify_KeyDown);
            this.Resize += new System.EventHandler(this.PT_fingerVerify_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Logo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraEditors.LabelControl lb_Info;
        public DevExpress.XtraEditors.LabelControl lb_Usage;
        public DevExpress.XtraEditors.LabelControl lb_productName;
        public DevExpress.XtraEditors.LabelControl lb_clubName;
        private DevExpress.XtraEditors.PictureEdit pictureEdit_Logo;
        public DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private System.Windows.Forms.Timer timer1;
        public DevExpress.XtraEditors.LabelControl lb_Instructor_Name;
        public DevExpress.XtraEditors.LabelControl lb_Room;
        private DevExpress.XtraEditors.LabelControl lb_Student_Name;
        public DevExpress.XtraEditors.LabelControl lb_authorize;
    }
}