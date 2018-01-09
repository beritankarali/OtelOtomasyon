using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtelOtomasyon
{
    class RezervasyonTesvik:Rezervasyon
    {
        public RezervasyonTesvik(Musteri m, Oda o, DateTime gelis, DateTime gidis): base(m, o, gelis, gidis)
        {
            
        }
    }
}
