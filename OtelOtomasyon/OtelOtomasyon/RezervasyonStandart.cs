using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtelOtomasyon
{
     public class RezervasyonStandart: Rezervasyon
    {
     

          public RezervasyonStandart(Musteri m, Oda o, DateTime gelis, DateTime gidis): base(m, o, gelis, gidis)
        {
            
        }
    }
}
