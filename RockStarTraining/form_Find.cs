using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace RockStar.Training
{
    public partial class form_Find : Form
    {
        GridView gridaaa;
        public form_Find(GridView grid)
        {
            InitializeComponent();
            this.gridaaa = grid;
            Bitmap logo = new Bitmap(Properties.Resources.Logo_RSG);
            pictureEdit1.Image = logo;
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

        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            lck = 0;
            gridaaa.FocusedRowHandle = lck;
            gridaaa.FindFilterText = textEdit1.Text;                           
        }
       public int lck = 0;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            lck = lck + 1;
            gridaaa.FocusedRowHandle = lck;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridaaa.FindFilterText = "";           
            this.Close();           
        }

        private void findform_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                gridaaa.FindFilterText = "";
                this.Close();
            }
        }

        private void findform_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid);

        }

        private void findform_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
