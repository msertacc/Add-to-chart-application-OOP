using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B191200350
{

    public partial class Form1 : Form
    {      
        LedTv ledTv = new LedTv("Led TV", "LG", "2020", "IPS Ekran", 4000, 0, 55, "1920x1080");
        Buzdolabi buzdolabi = new Buzdolabi("Buzdolabı", "SIEMENS", "2018BC", "Wifi Bağlantılı", 3500, 0, 8, "A+++");
        Laptop laptop = new Laptop("Laptop", "MSI", "GTX1065", "Turbo Fan", 6000, 0, 17, "1920x1080", 2, 16, 5000);
        CepTel cepTel = new CepTel("Cep Telefonu", "Samsung", "S10", "Android 9.0,", 2500, 0, 64, 6, 4000);

        uint gecicisecilenledTv = 0;
        uint gecicisecilenbuzdolabi = 0;
        uint gecicisecilenlaptop = 0;
        uint gecicisecilencepTel = 0;

        public uint[] geciciler;
        public NumericUpDown[] numericupdowns;
        public ListBox[] listboxs;
        
        public Form1()
        {
            InitializeComponent();
    
            numericupdowns = new NumericUpDown[4] { ledtvnumericUpDown, buzdolabinumericUpDown, laptopnumericUpDown, ceptelnumericUpDown };
            geciciler = new uint[4] { gecicisecilenledTv, gecicisecilenbuzdolabi, gecicisecilenlaptop, gecicisecilencepTel };
            listboxs = new ListBox[3] { adetlistBox, urunlistBox, kdvfiyatlistBox };

            ledtvhamlabel.Text = ledTv.HamFiyat.ToString();
            ledtvstoklabel.Text = ledTv.StokAdet.ToString();
            
            buzdolabihamlabel.Text = buzdolabi.HamFiyat.ToString();
            buzdolabistoklabel.Text = buzdolabi.StokAdet.ToString();

            laptophamlabel.Text = laptop.HamFiyat.ToString();
            laptopstoklabel.Text = laptop.StokAdet.ToString();

            ceptelhamlabel.Text = cepTel.HamFiyat.ToString();
            ceptelstoklabel.Text = cepTel.StokAdet.ToString();

        }
        Sepet sepet = new Sepet();
        
        private void button1_Click(object sender, EventArgs e)
        {                   
            uint secilenledTv = Convert.ToUInt32(ledtvnumericUpDown.Value);
            uint secilenbuzdolabi = Convert.ToUInt32(buzdolabinumericUpDown.Value);
            uint secilenlaptop = Convert.ToUInt32(laptopnumericUpDown.Value);
            uint secilencepTel = Convert.ToUInt32(ceptelnumericUpDown.Value);

            List<Urun> urunler = new List<Urun>();
            urunler.Add(ledTv);
            urunler.Add(buzdolabi);
            urunler.Add(laptop);
            urunler.Add(cepTel);

            ledTv.SecilenAdet = secilenledTv;
            buzdolabi.SecilenAdet = secilenbuzdolabi;
            laptop.SecilenAdet = secilenlaptop;
            cepTel.SecilenAdet = secilencepTel;

            //YENİ ÜRÜN SAYISI
            if (ledTv.StokAdet-secilenledTv >= 0 && buzdolabi.StokAdet-secilenbuzdolabi >= 0 && laptop.StokAdet-secilenlaptop >= 0 && cepTel.StokAdet-secilencepTel >= 0)
            {                
                if (numericupdowns[0].Value == 0 && numericupdowns[1].Value == 0 && numericupdowns[2].Value == 0 && numericupdowns[3].Value == 0)
                {
                    MessageBox.Show("Lütfen Yeniden Giriş Yapınız.");
                    //ekleButon.Enabled = true; (optional)
                }
                else 
                {
                    adetlistBox.Items.Clear();
                    urunlistBox.Items.Clear();
                    kdvfiyatlistBox.Items.Clear();
                    kdvtoplamlabel.Text = "";

                    //Sepet Sınıfı İşlemleri
                    sepet.ListeyeEkle(numericupdowns, listboxs, urunler, geciciler);
                    kdvtoplamlabel.Text = sepet.SepeteUrunEkle(urunler) + "TL";

                    ledtvstoklabel.Text = ledTv.StokAdet.ToString();     
                    buzdolabistoklabel.Text = buzdolabi.StokAdet.ToString();       
                    laptopstoklabel.Text = laptop.StokAdet.ToString();       
                    ceptelstoklabel.Text = cepTel.StokAdet.ToString();
                    //ekleButon.Enabled = false; (optional)
                }              
            }
            else
            {
                MessageBox.Show("Stok Yetersiz! Tekrar Giriş Yapınız.");
            }        
        }  

        private void button2_Click(object sender, EventArgs e)
        {
            if(adetlistBox.Items.Count > 0)
            {
                ledTv.StokAdet += (int)geciciler[0];
                buzdolabi.StokAdet += (int)geciciler[1];
                laptop.StokAdet += (int)geciciler[2];
                cepTel.StokAdet += (int)geciciler[3];

                ledtvstoklabel.Text = ledTv.StokAdet.ToString();          
                buzdolabistoklabel.Text = buzdolabi.StokAdet.ToString();           
                laptopstoklabel.Text = laptop.StokAdet.ToString();         
                ceptelstoklabel.Text = cepTel.StokAdet.ToString();

                for (int i = 0; i < geciciler.Length; i++) { geciciler[i] = 0; }
                    
                adetlistBox.Items.Clear();
                urunlistBox.Items.Clear();
                kdvfiyatlistBox.Items.Clear();
                kdvtoplamlabel.Text = "";
                //ekleButon.Enabled = true; (optional)
            }
            else
            {
                MessageBox.Show("Sepetiniz Boş.");
            }
        }
        #region OtoDüzeltme -- Default Value : 0
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ledtvnumericUpDown != null)
            {
                if (ledtvnumericUpDown.Text == string.Empty)
                {
                    ledtvnumericUpDown.Value = ledtvnumericUpDown.Minimum;
                    ledtvnumericUpDown.Text = ledtvnumericUpDown.Value.ToString();
                }
            }

            if (buzdolabinumericUpDown != null)
            {
                if(buzdolabinumericUpDown.Text == string.Empty)
                {
                    buzdolabinumericUpDown.Value = buzdolabinumericUpDown.Minimum;
                    buzdolabinumericUpDown.Text = buzdolabinumericUpDown.Value.ToString();
                }
            }

            if (laptopnumericUpDown != null)
            {
                if (laptopnumericUpDown.Text == string.Empty)
                {
                    laptopnumericUpDown.Value = laptopnumericUpDown.Minimum;
                    laptopnumericUpDown.Text = laptopnumericUpDown.Value.ToString();
                }
            }
            if (ceptelnumericUpDown != null)
            {
                if (ceptelnumericUpDown.Text == string.Empty)
                {
                    ceptelnumericUpDown.Value = ceptelnumericUpDown.Minimum;
                    ceptelnumericUpDown.Text = ceptelnumericUpDown.Value.ToString();
                }
            }
        }
        #endregion
    }

    class Sepet
    {
        public Sepet() { }
        // Listeye Ekleme İşlemi
        public void ListeyeEkle(NumericUpDown[] numerics, ListBox[] lists, List<Urun> products, uint[] gecici)
        {
            for (int i = 0; i < numerics.Length; i++)
            {
                if (numerics[i].Value > 0)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == 0)
                            lists[j].Items.Add(numerics[i].Value);
                        if (j == 1)
                            lists[j].Items.Add(products[i].Ad);
                        if (j == 2)
                            lists[j].Items.Add(products[i].KdvUygula());
                    }
                    gecici[i] = Convert.ToUInt32(numerics[i].Value);
                    products[i].StokAdet -= (int)products[i].SecilenAdet;
                }
            }
            if (!lists[1].Items.Contains("Led TV"))
                gecici[0] = 0;
            if (!lists[1].Items.Contains("Buzdolabı"))
                gecici[1] = 0;
            if (!lists[1].Items.Contains("Laptop"))
                gecici[2] = 0;
            if (!lists[1].Items.Contains("Cep Telefonu"))
                gecici[3] = 0;
        }
        public double SepeteUrunEkle(List<Urun> urun)
        {
            //KDVTOPLAM Hesaplama
            double toplamKDV = 0;
            foreach (var item in urun)
            {
                toplamKDV += item.KdvUygula();
            }
            return toplamKDV;
        }
    }
}
