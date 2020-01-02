namespace RockStar.Training
{
    partial class Cst_Form_Long
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
            this.btn_No = new System.Windows.Forms.Button();
            this.btn_Yes = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_Info = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit_Logo = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Logo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_No
            // 
            this.btn_No.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_No.Location = new System.Drawing.Point(283, 120);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(100, 33);
            this.btn_No.TabIndex = 62;
            this.btn_No.Text = "No";
            this.btn_No.UseVisualStyleBackColor = true;
            this.btn_No.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Yes
            // 
            this.btn_Yes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Yes.Location = new System.Drawing.Point(92, 120);
            this.btn_Yes.Name = "btn_Yes";
            this.btn_Yes.Size = new System.Drawing.Size(100, 33);
            this.btn_Yes.TabIndex = 60;
            this.btn_Yes.Text = "Yes";
            this.btn_Yes.UseVisualStyleBackColor = true;
            this.btn_Yes.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lb_Info
            // 
            this.lb_Info.AllowHtmlString = true;
            this.lb_Info.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lb_Info.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lb_Info.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lb_Info.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_Info.Location = new System.Drawing.Point(76, 22);
            this.lb_Info.Name = "lb_Info";
            this.lb_Info.Size = new System.Drawing.Size(368, 58);
            this.lb_Info.TabIndex = 61;
            this.lb_Info.Text = "Messages: XXXX";
            // 
            // pictureEdit_Logo
            // 
            this.pictureEdit_Logo.Location = new System.Drawing.Point(11, 12);
            this.pictureEdit_Logo.Name = "pictureEdit_Logo";
            this.pictureEdit_Logo.Properties.AllowFocused = false;
            this.pictureEdit_Logo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit_Logo.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit_Logo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit_Logo.Properties.ShowMenu = false;
            this.pictureEdit_Logo.Size = new System.Drawing.Size(50, 50);
            this.pictureEdit_Logo.TabIndex = 63;
            // 
            // Cst_Form_Long
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 172);
            this.Controls.Add(this.btn_No);
            this.Controls.Add(this.btn_Yes);
            this.Controls.Add(this.lb_Info);
            this.Controls.Add(this.pictureEdit_Logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cst_Form_Long";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Axioma";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Logo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.Button btn_Yes;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit_Logo;
        private DevExpress.XtraEditors.LabelControl lb_Info;
    }
}