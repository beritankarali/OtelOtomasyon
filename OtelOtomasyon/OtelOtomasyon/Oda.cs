using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtelOtomasyon
{
    public class Oda
    {
        public int No { get; set; }
        public Fiyat Fiyat { get; set; }
        public bool Durum { get; set; }
        public OdaOzellik Ozellikler { get; set; }

        public Oda(Fiyat f, OdaOzellik o)
        {
            Fiyat = f;
            Ozellikler = o;
            Durum = false;
        }
        public Oda()
        { }

    }
}
