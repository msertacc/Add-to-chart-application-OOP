using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace B191200350
{
    class LedTv:Urun
    {
        private uint EkranBoyutu { get; set; }
        private string EkranCozunurlugu { get; set; }

        Random ledtvAdet = new Random();

        public LedTv(string Ad, string Marka, string Model, string Ozellik, double HamFiyat, uint SecilenAdet,uint EkranBoyutu,string EkranCozunurlugu)
        {
            this.Ad = Ad;
            this.Marka = Marka;
            this.Model = Model;
            this.Ozellik = Ozellik;
            this.HamFiyat = HamFiyat;
            this.SecilenAdet = SecilenAdet;
            this.EkranBoyutu = EkranBoyutu;
            this.EkranCozunurlugu = EkranCozunurlugu;
            StokAdet = ledtvAdet.Next(1, 100);
            Thread.Sleep(100);
        }
        public override double KdvUygula()
        {
            base.KdvUygula();
            return Math.Round(HamFiyat * 1.18 * SecilenAdet);
        }
    }
}
