using System;
using System.Drawing;
using System.Windows.Forms;

namespace RockStar.Training
{
    //Prompt Message Long, DONT DELETE
    public partial class Cst_Form_Long : Form
    {
        Bitmap gambr11 = new Bitmap(Properties.Resources.warning, 30, 30);

        public Cst_Form_Long(string cust_Message)
        {
            InitializeComponent();
            lb_Info.Text = cust_Message;
        }
        int disposeFormTimer;

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureEdit_Logo.Image = gambr11;

            btn_Yes.Enabled = false;
            disposeFormTimer = 6;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            disposeFormTimer--;

            if (disposeFormTimer >= 0)
            {
                btn_Yes.Text = "Yes (" + disposeFormTimer + ")";
            }
            if (disposeFormTimer == 0)
            {
                btn_Yes.Text = "Yes";
                btn_Yes.Enabled = true;
                timer1.Stop();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            timer1.Stop();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            timer1.Stop();
            this.Close();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                this.Close();
            }
        }
    }
}
