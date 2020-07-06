using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Axioma.Celebrity.Fitness;

namespace RockStar.Training
{
    public partial class Cst_Note : Form
    {
        //Cover Note(class schedule) dicover
        //cancel class (classroom attendance) di tapcancel
        //Void instructor (Classroom attendance di tapvoid instructor & instructor attendance) 
        //void cancel class (class schedule)
        //DONT DELETE

        SqlConnection myConnection = new SqlConnection(Partner.configConnection);
        SqlCommand command = new SqlCommand();

        Bitmap gbr_inf = new Bitmap(Properties.Resources.info_icon, 25, 25);

        private string mNote;
        public string Note
        {
            get { return mNote; }
        }

        public Cst_Note(string productName, string information, string parentForm)
        {
            InitializeComponent();
            Bitmap logo = new Bitmap(Properties.Resources.Logo_RSG);
            pictureEdit_Logo.Image = logo;

            lb_ProductName.Text = string.Format(@"{0}", productName);
            lb_Info.Text = information;
            lb_ParentForm.Text = parentForm;
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
        private void Note_Load(object sender, EventArgs e)
        {
            mNote = "";
            btn_Save.Enabled = false;
        }

        private void Note_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                mNote = "";
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            mNote = memoEdit_Note.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            mNote = "";
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public void asad()
        {
            btn_Save.Enabled = !string.IsNullOrEmpty(memoEdit_Note.Text);
        }
        private void memoEdit1_TextChanged(object sender, EventArgs e)
        {
            asad();
        }

        private void Note_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid, Color.FromArgb(29, 26, 77), 2, ButtonBorderStyle.Solid);

        }

        private void Note_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }


    }
}
