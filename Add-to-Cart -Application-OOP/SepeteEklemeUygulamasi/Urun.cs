using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B191200350
{
    abstract class Urun
    {
        public string Ad { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Ozellik { get; set; }
        public int StokAdet { get; set; }
        public double HamFiyat { get; set; }
        public uint SecilenAdet { get; set; }

        public virtual double KdvUygula()
        {
            return Math.Round(HamFiyat*1*SecilenAdet);
        }
        
    }
}
