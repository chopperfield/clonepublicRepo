using System;
using System.Drawing;
using System.Windows.Forms;

namespace RockStar.Training
{
    //Prompt Message Short, DONT DELETE

    public partial class Cst_Form_Short : Form
    {
        Bitmap gambr11 = new Bitmap(Properties.Resources.warning, 30, 30);

        public Cst_Form_Short(string cust_Message)
        {
            InitializeComponent();
            lb_Info.Text = cust_Message;
        }
        int disposeFormTimer;
        private void Form1_Load(object sender, EventArgs e)
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
                timer2.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            DialogResult = DialogResult.No;            
            this.Close();
        }

        private int tick1 = 20;// 20 detik;
        private void timer2_Tick(object sender, EventArgs e)
        {
            tick1 = tick1 - 1;
            if (tick1 == 0)
            {
                timer2.Stop();
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
