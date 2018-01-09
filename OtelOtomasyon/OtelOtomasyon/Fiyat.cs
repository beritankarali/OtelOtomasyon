using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtelOtomasyon
{
    public class Fiyat
    {
        public double Sezon1 { get; set; }
        public double Sezon2 { get; set; }
        public double Sezon3 { get; set; }
        public double Sezon4 { get; set; }
        public double Tatil { get; set; }

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


        public Fiyat(double s1,double s2,double s3,double s4,double t )
        {
            Sezon1 = s1;
            Sezon2 = s2;
            Sezon3 = s3;
            Sezon4 = s4;
            Tatil = t;
        }
    }


}
