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
        List<SellItem> listSell = new List<SellItem>();
        List<Add> listBarang = new List<Add>();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgv.DataSource = listSell;
            string kode = txtKode.Text;
            string nama = txtNama.Text;
            int jumlah = Int32.Parse(txtQuantity.Text);
            double harga = Double.Parse(txtPrice.Text);
            double tax = Double.Parse(txtTax.Text);
            double taxValue = tax / 100;
            double subTotal = ((jumlah * harga) * taxValue);
            double bsc = 0;

            dgv.DataSource = null;
            listSell.Add(new SellItem
            {
                Code = kode,
                Nama = nama,
                Quantity = jumlah,
                Price = harga,
                Tax = tax,
                SubTotal = subTotal
            });
            dgv.DataSource = listSell;

            dgv.Columns[0].DataPropertyName = "Code";
            dgv.Columns[1].DataPropertyName = "Nama";
            dgv.Columns[2].DataPropertyName = "Quantity";
            dgv.Columns[3].DataPropertyName = "Price";
            dgv.Columns[4].DataPropertyName = "Tax";
            dgv.Columns[5].DataPropertyName = "SubTotal";

            foreach (var item in listSell)
            {
                bsc += item.SubTotal;
            }
            lblBSC.Text = bsc.ToString();
            lblSC.Text = (bsc * 0.1).ToString();
            lblTTL.Text = (bsc + (bsc * 0.1)).ToString();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_tambah frm = new Form_tambah(listBarang);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void txtKode_TextChanged(object sender, EventArgs e)
        {
            string kode = txtKode.Text;
            foreach (var item in listBarang)
            {
                if(kode == item.Code)
                {
                    this.txtNama.Text = item.Name;
                    this.txtPrice.Text = item.Price.ToString();
                }
            }
        }

        private void lblBSC_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            dgv.DataSource = null;
            dgv.DataSource = listBarang;
        }
    }
}
