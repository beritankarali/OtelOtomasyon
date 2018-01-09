using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtelOtomasyon
{
    public class Musteri :Kisi
    {
        public int ZiyaretSayisi { get; set; }
        private List<DateTime> tarihler=new List<DateTime> ();


        public List<DateTime> RezervasyonTarihleri
        {
            get { return tarihler; }
           
        }
        public void RezervasyonTarihiEkle(DateTime tarih)
        {
            tarihler.Add(tarih);
        }


        public Musteri(string ad, string soyad, DateTime dt, string tel,string mail, string adres, bool cinsiyet)
        {
            Ad = ad;
            Soyad = soyad;
            DogumTarihi = dt;
            IletisimBilgileri.TelefonNo = tel;
            IletisimBilgileri.Mail = mail; IletisimBilgileri.Adres = adres;
            Cinsiyet = cinsiyet;

        }
        
    }
}
