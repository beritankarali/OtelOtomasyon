using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtelOtomasyon
{
   public class TatillerSezonlar
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

    }
}
