using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtelOtomasyon
{
    public abstract class Kisi
    {
        public int No { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        private Iletisim iletisimBilgileri=new Iletisim();

        public Iletisim IletisimBilgileri
        {
            get { return iletisimBilgileri; }
            set { iletisimBilgileri = value; }
        }
        
        public bool Cinsiyet { get; set; }

    }
}
