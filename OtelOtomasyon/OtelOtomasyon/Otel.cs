using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtelOtomasyon
{
    public class Otel
    {

        public DateTime Sezon1Baslama { get; set; }
        public DateTime Sezon2Baslama { get; set; }
        public DateTime Sezon3Baslama { get; set; }
        public DateTime Sezon4Baslama { get; set; }
        List<DateTime> tatiller = new List<DateTime>();

        public List<DateTime> Tatiller
        {
            get { return tatiller; }
            set { tatiller = value; }
        }

        List<Rezervasyon> rezervasyonlar = new List<Rezervasyon>();
        public  List<Rezervasyon> Rezervasyonlar
        {
            get { return rezervasyonlar; }
            
        }
        

        List<Oda> odalar = new List<Oda>();
        public List<Oda> Odalar
        {
            get { return odalar; }
           
        }

        List<Musteri> musteriler = new List<Musteri>();
        public List<Musteri> Musteriler
        {
            get { return musteriler; }

        }

        public void MusteriEkle(Musteri m)
        {
            m.No = musteriler.Count;
            musteriler.Add(m);
        }

        public void OdaEkle(Oda o)
        {
            o.No = odalar.Count;
            odalar.Add(o);
        }
        public void RezervasyonYap(Rezervasyon r)
        {
            r.Oda.Fiyat.Sezon1Baslama = Sezon1Baslama;
            r.Oda.Fiyat.Sezon2Baslama = Sezon2Baslama;
            r.Oda.Fiyat.Sezon3Baslama = Sezon3Baslama;
            r.Oda.Fiyat.Sezon4Baslama = Sezon4Baslama;
            r.Oda.Fiyat.Tatiller = Tatiller;

            r.No = rezervasyonlar.Count;
            rezervasyonlar.Add(r);

        }

        public List<Oda> BosOdalar(DateTime baslama, DateTime bitme)
        {
            List<Oda> bosOdalar = new List<Oda>();
            foreach (Oda o in odalar)
            {
                bool doluluk = false;
                for (int i = 0; i < rezervasyonlar.Count; i++)
                {
                    if (o == rezervasyonlar[i].Oda && rezervasyonlar[i].GelisTarihi > baslama && rezervasyonlar[i].GidisTarihi < bitme)
                        doluluk = true;
                }

                if (!doluluk)
                    bosOdalar.Add(o);
            }
            return bosOdalar;
        }

        public Rezervasyon RezervasyonAra(int no)
        {
            Rezervasyon rez = new Rezervasyon();
            foreach (Rezervasyon r in rezervasyonlar)
            {

                if (r.No == no)
                    rez = r;
            }

            return rez;
        }
        public Oda OdaAra(int odaNo)
        {
            Oda oda=new Oda ();
            foreach(Oda o in odalar)
            {
               
                if (o.No == odaNo)
                    oda = o;
            }

            return oda;
        }

    }
}
