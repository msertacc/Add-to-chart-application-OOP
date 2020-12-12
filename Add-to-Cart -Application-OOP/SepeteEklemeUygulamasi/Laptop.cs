using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace B191200350
{
    class Laptop:Urun
    {
        private uint EkranBoyutu { get; set; }
        private string EkranCozunurluk { get; set; }
        private uint DahiliHafiza { get; set; }
        private uint RamKapasitesi { get; set; }
        private uint PilGucu { get; set; }

        Random laptopAdet = new Random();

        public Laptop(string Ad, string Marka, string Model, string Ozellik, double HamFiyat, uint SecilenAdet,uint EkranBoyutu,string EkranCozunurluk,uint DahiliHafiza,uint RamKapasitesi,uint PilGucu)
        {
            this.Ad = Ad;
            this.Marka = Marka;
            this.Model = Model;
            this.Ozellik = Ozellik;
            this.HamFiyat = HamFiyat;
            this.SecilenAdet = SecilenAdet;
            this.EkranBoyutu = EkranBoyutu;
            this.EkranCozunurluk = EkranCozunurluk;
            this.DahiliHafiza = DahiliHafiza;
            this.RamKapasitesi = RamKapasitesi;
            this.PilGucu = PilGucu;
            StokAdet = laptopAdet.Next(1, 100);
            Thread.Sleep(100);
        }

        public override double KdvUygula()
        {
            base.KdvUygula();
            return Math.Round(HamFiyat * 1.15 * SecilenAdet); 
        }
    }
}
