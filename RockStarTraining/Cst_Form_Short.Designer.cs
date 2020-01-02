namespace RockStar.Training
{
    partial class Cst_Form_Short
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
            this.btn_Yes = new System.Windows.Forms.Button();
            this.btn_No = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureEdit_Logo = new DevExpress.XtraEditors.PictureEdit();
            this.lb_Info = new DevExpress.XtraEditors.LabelControl();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Logo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Yes
            // 
            this.btn_Yes.Location = new System.Drawing.Point(93, 76);
            this.btn_Yes.Name = "btn_Yes";
            this.btn_Yes.Size = new System.Drawing.Size(75, 23);
            this.btn_Yes.TabIndex = 0;
            this.btn_Yes.Text = "Yes";
            this.btn_Yes.UseVisualStyleBackColor = true;
            this.btn_Yes.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_No
            // 
            this.btn_No.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_No.Location = new System.Drawing.Point(202, 76);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(75, 23);
            this.btn_No.TabIndex = 1;
            this.btn_No.Text = "No";
            this.btn_No.UseVisualStyleBackColor = true;
            this.btn_No.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.pictureEdit_Logo.Size = new System.Drawing.Size(50, 50);
            this.pictureEdit_Logo.TabIndex = 59;
            // 
            // lb_Info
            // 
            this.lb_Info.AllowHtmlString = true;
            this.lb_Info.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lb_Info.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lb_Info.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lb_Info.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_Info.Location = new System.Drawing.Point(77, 22);
            this.lb_Info.Name = "lb_Info";
            this.lb_Info.Size = new System.Drawing.Size(246, 48);
            this.lb_Info.TabIndex = 0;
            this.lb_Info.Text = "Messages XXXXX";
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Cst_Form_Short
            // 
            this.AcceptButton = this.btn_Yes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_No;
            this.ClientSize = new System.Drawing.Size(331, 111);
            this.Controls.Add(this.lb_Info);
            this.Controls.Add(this.pictureEdit_Logo);
            this.Controls.Add(this.btn_No);
            this.Controls.Add(this.btn_Yes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cst_Form_Short";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Axioma";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Logo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Yes;
        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit_Logo;
        private DevExpress.XtraEditors.LabelControl lb_Info;
        private System.Windows.Forms.Timer timer2;
    }
}