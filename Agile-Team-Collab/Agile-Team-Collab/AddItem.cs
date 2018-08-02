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
    public partial class Form_tambah : Form
    {
        List<Add> listBarang = null;
        public Form_tambah()
        {
            InitializeComponent();
            listBarang = new List<Add>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txtboxName.Text == "")
            {
                MessageBox.Show("Data Tidak Boleh kosong", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView1.DataSource = null;
                
                dataGridView1.DataSource = listBarang;
                dataGridView1.Columns[0].DataPropertyName = "dgvCode";
                dataGridView1.Columns[1].DataPropertyName = "Name";
                dataGridView1.Columns[2].DataPropertyName = "Price";
                
            }
        }
    }
}
