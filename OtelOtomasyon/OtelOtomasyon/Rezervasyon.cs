using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtelOtomasyon
{
    public  class Rezervasyon
    {
        public int No { get; set; }
        public Musteri Musteri { get; set; }
        public DateTime KayitTarihi { get; set; }
        public DateTime GelisTarihi { get; set; }
        public DateTime GidisTarihi { get; set; }
        public Oda Oda { get; set; }
        public double Ucret { get; set; }
 
        public Rezervasyon(Musteri m, Oda o, DateTime gelis, DateTime gidis )
        {
            Musteri = m;
            Oda = o;
            GelisTarihi = gelis;
            GidisTarihi = gidis;
            Musteri.RezervasyonTarihiEkle(DateTime.Now);
            Musteri.ZiyaretSayisi++;
            UcretHesapla();
        }
        public Rezervasyon()
        {

        }

        public virtual void UcretHesapla()
        {
            double ucret = 0;
            for (DateTime t = GelisTarihi; t < GidisTarihi; t= t.AddDays(1))
            {
                if (Oda.Fiyat.Tatiller.FindIndex(d => d == t) != -1)
                    ucret += Oda.Fiyat.Tatil;
                else
                {

                    if (t > Oda.Fiyat.Sezon1Baslama && t < Oda.Fiyat.Sezon2Baslama)
                        ucret += Oda.Fiyat.Sezon1;
                    if (t > Oda.Fiyat.Sezon2Baslama && t < Oda.Fiyat.Sezon3Baslama)
                        ucret += Oda.Fiyat.Sezon1;
                    if (t > Oda.Fiyat.Sezon3Baslama && t < Oda.Fiyat.Sezon4Baslama)
                        ucret += Oda.Fiyat.Sezon1;
                    if (t > Oda.Fiyat.Sezon4Baslama && t < Oda.Fiyat.Sezon1Baslama.AddYears(1))
                        ucret += Oda.Fiyat.Sezon1;
                }
            }

            Ucret = ucret;
        }

    }
}
