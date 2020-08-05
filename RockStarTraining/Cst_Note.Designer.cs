namespace RockStar.Training { 

    partial class Cst_Note
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
            this.pictureEdit_Logo = new DevExpress.XtraEditors.PictureEdit();
            this.lb_Note = new System.Windows.Forms.Label();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lb_ParentForm = new DevExpress.XtraEditors.LabelControl();
            this.memoEdit_Note = new DevExpress.XtraEditors.MemoEdit();
            this.lb_ProductName = new DevExpress.XtraEditors.LabelControl();
            this.lb_Info = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Logo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Note.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.pictureEdit_Logo.TabIndex = 58;
            // 
            // lb_Note
            // 
            this.lb_Note.AutoSize = true;
            this.lb_Note.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lb_Note.Location = new System.Drawing.Point(45, 85);
            this.lb_Note.Name = "lb_Note";
            this.lb_Note.Size = new System.Drawing.Size(37, 16);
            this.lb_Note.TabIndex = 59;
            this.lb_Note.Text = "Note";
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Location = new System.Drawing.Point(232, 199);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "save";
            this.btn_Save.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btn_Cancel.Appearance.Options.UseFont = true;
            this.btn_Cancel.Location = new System.Drawing.Point(313, 199);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "cancel";
            this.btn_Cancel.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(26)))), ((int)(((byte)(77)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lb_ParentForm);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 239);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(430, 26);
            this.panelControl1.TabIndex = 63;
            // 
            // lb_ParentForm
            // 
            this.lb_ParentForm.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lb_ParentForm.Appearance.ForeColor = System.Drawing.Color.White;
            this.lb_ParentForm.Location = new System.Drawing.Point(12, 3);
            this.lb_ParentForm.Name = "lb_ParentForm";
            this.lb_ParentForm.Size = new System.Drawing.Size(73, 16);
            this.lb_ParentForm.TabIndex = 56;
            this.lb_ParentForm.Text = "Parent Form";
            // 
            // memoEdit_Note
            // 
            this.memoEdit_Note.Location = new System.Drawing.Point(106, 84);
            this.memoEdit_Note.Name = "memoEdit_Note";
            this.memoEdit_Note.Size = new System.Drawing.Size(282, 96);
            this.memoEdit_Note.TabIndex = 64;
            this.memoEdit_Note.TextChanged += new System.EventHandler(this.memoEdit1_TextChanged);
            // 
            // lb_ProductName
            // 
            this.lb_ProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_ProductName.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ProductName.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lb_ProductName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lb_ProductName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lb_ProductName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lb_ProductName.Location = new System.Drawing.Point(106, 12);
            this.lb_ProductName.Name = "lb_ProductName";
            this.lb_ProductName.Size = new System.Drawing.Size(282, 23);
            this.lb_ProductName.TabIndex = 72;
            this.lb_ProductName.Text = "Gymnastic U/8";
            this.lb_ProductName.UseMnemonic = false;
            // 
            // lb_Info
            // 
            this.lb_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Info.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lb_Info.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lb_Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lb_Info.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lb_Info.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lb_Info.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lb_Info.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lb_Info.Location = new System.Drawing.Point(106, 62);
            this.lb_Info.Name = "lb_Info";
            this.lb_Info.Size = new System.Drawing.Size(282, 16);
            this.lb_Info.TabIndex = 86;
            this.lb_Info.Text = "info";
            // 
            // Cst_Note
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 265);
            this.ControlBox = false;
            this.Controls.Add(this.lb_Info);
            this.Controls.Add(this.lb_ProductName);
            this.Controls.Add(this.memoEdit_Note);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lb_Note);
            this.Controls.Add(this.pictureEdit_Logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Cst_Note";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Note";
            this.Load += new System.EventHandler(this.Note_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Note_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Note_KeyDown);
            this.Resize += new System.EventHandler(this.Note_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Logo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Note.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit_Logo;
        private System.Windows.Forms.Label lb_Note;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.MemoEdit memoEdit_Note;
        private DevExpress.XtraEditors.LabelControl lb_ParentForm;
        private DevExpress.XtraEditors.LabelControl lb_ProductName;
        public DevExpress.XtraEditors.LabelControl lb_Info;
    }
}