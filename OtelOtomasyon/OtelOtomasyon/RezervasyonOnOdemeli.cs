using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtelOtomasyon
{
    public class RezervasyonOnOdemeli:Rezervasyon
    {

        public override void UcretHesapla()
        {
            base.UcretHesapla();
            Ucret *= 0.75;
        }

        public RezervasyonOnOdemeli(Musteri m, Oda o, DateTime gelis, DateTime gidis):base(m,o,gelis,gidis)
        {
            UcretHesapla();
        }
        public RezervasyonOnOdemeli()
        {

        }
        public void CezaHesapla()
        {
            Ucret += Ucret * 1.1;
        }

        
    }
}
