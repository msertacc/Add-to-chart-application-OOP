using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace B191200350
{
    class CepTel:Urun
    {
        private uint DahiliHafiza { get; set; }
        private uint RamKapasitesi { get; set; }
        private uint PilGucu { get; set; }

        Random ceptelAdet = new Random();

        public CepTel(string Ad, string Marka, string Model, string Ozellik, double HamFiyat, uint SecilenAdet, uint DahiliHafiza, uint RamKapasitesi, uint PilGucu)
        {
            this.Ad = Ad;
            this.Marka = Marka;
            this.Model = Model;
            this.Ozellik = Ozellik;
            this.HamFiyat = HamFiyat;
            this.SecilenAdet = SecilenAdet;
            this.DahiliHafiza = DahiliHafiza;
            this.RamKapasitesi = RamKapasitesi;
            this.PilGucu = PilGucu;
            StokAdet = ceptelAdet.Next(1, 100);
            Thread.Sleep(100);
        }

        public override double KdvUygula()
        {
            base.KdvUygula();
            return Math.Round(HamFiyat * 1.20 * SecilenAdet); 
        }
    }
}
