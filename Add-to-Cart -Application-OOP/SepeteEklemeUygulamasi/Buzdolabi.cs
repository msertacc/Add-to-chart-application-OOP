using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace B191200350
{
    class Buzdolabi:Urun
    {
        private uint IcHacim { get; set; }
        private string EnerjiSinifi { get; set; }

        Random buzdolabiAdet = new Random();

        public Buzdolabi(string Ad,string Marka,string Model,string Ozellik,double HamFiyat,uint SecilenAdet,uint IcHacim,string EnerjiSinifi)
        {
            this.Ad = Ad;
            this.Marka = Marka;
            this.Model = Model;
            this.Ozellik = Ozellik;
            this.HamFiyat = HamFiyat;
            this.SecilenAdet = SecilenAdet;
            this.IcHacim = IcHacim;
            this.EnerjiSinifi = EnerjiSinifi;
            StokAdet = buzdolabiAdet.Next(1, 100);
            Thread.Sleep(100);
        }

        public override double KdvUygula()
        {
            base.KdvUygula();
            return Math.Round(HamFiyat * 1.05 * SecilenAdet);
        }
    }
}
