using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace RockStar.Training
{
    public partial class form_Print : Form
    {
        GridView gridaaa;

        public form_Print(GridView grid)
        {
            InitializeComponent();
            this.gridaaa = grid;
        }

        private void print12_Load(object sender, EventArgs e)
        {
            
        }
    }
}
