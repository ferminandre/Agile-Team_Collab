using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penjualan
{
    class SellItem
    {
        public string Kode { get; set; }
        public string Nama { get; set; }
        public int Jumlah { get; set; }
        public double  Harga { get; set; }
        public double Tax { get; set; }
        public double SubTotal { get; set; }

    }
}
