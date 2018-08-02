using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agile_Team_Collab
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnTmbhQuantity_Click(object sender, EventArgs e)
        {
            int Jlh = Int32.Parse(this.txtQuantity.Text);
            Jlh = Jlh + 1;
            this.txtQuantity.Text = Jlh.ToString();
        }

        private void btnKrangQuantity_Click(object sender, EventArgs e)
        {
            int Jlh = Int32.Parse(this.txtQuantity.Text);
            if (Jlh > 0)
            {
                Jlh = Jlh - 1;
                this.txtQuantity.Text = Jlh.ToString();
            }
        }
    }
}
