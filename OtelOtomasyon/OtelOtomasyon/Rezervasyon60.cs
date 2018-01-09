using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtelOtomasyon
{
    public class Rezervasyon60:Rezervasyon
    {
         public override void UcretHesapla()
        {
            base.UcretHesapla();
            Ucret *= 0.85;
        }

         public Rezervasyon60(Musteri m, Oda o, DateTime gelis, DateTime gidis) : base(m, o, gelis, gidis)
        {
            UcretHesapla();
        }
    }
}
