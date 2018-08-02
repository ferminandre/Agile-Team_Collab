using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Penjualan
{
    public partial class Main : Form
    {
        List<SellItem> listSell = null;
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
            string kode = txtKode.Text;
            string nama = txtNama.Text;
            int jumlah = Int32.Parse(txtQuantity.Text);
            double harga = Double.Parse(txtPrice.Text);
            double tax = Double.Parse(txtTax.Text);
            double taxValue = tax / 100;
            double subTotal = ((jumlah * harga) * taxValue);
            double bsc = 0;
            
                listSell.Add(new SellItem
                {
                    Kode = kode,
                    Nama = nama,
                    Jumlah = jumlah,
                    Harga = harga,
                    Tax = tax,
                    SubTotal = subTotal
                });

                dgv.DataSource = listSell;

                foreach (var item in listSell)
                {
                    bsc += item.SubTotal;
                }
                lblSC.Text = (bsc * 0.1).ToString();
                lblTTL.Text = (bsc + (bsc * 0.1)).ToString();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
