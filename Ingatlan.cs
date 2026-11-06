using System;
using System.Collections.Generic;
using System.Text;

namespace Ingatlan
{
    public class Ingatlan
    {
        private int alapteruletM2;
        private int arEzerFt;
        private static int osszesRegisztraltIngatlan = 0;
        public string Azonosito;
        public string Cim;
        public string Kategoria;
        public int AlapteruletM2
        {
            get { return alapteruletM2; }
            set
            {
                if (alapteruletM2 < 0)
                {
                    alapteruletM2 = 0;
                }
                else
                {
                    alapteruletM2 = value;
                }
            }
            //
        }
        }
        public int ArEzerFt
        {
            get { return arEzerFt; }
            set
            {
                if (arEzerFt < 0)
                {
                    arEzerFt = 0;
                }
                else
                {
                   arEzerFt = value;
                }
            }
        }
        public static int OsszesRegisztraltIngatlan
        {
            get { return osszesRegisztraltIngatlan; }
        }
        public Ingatlan(string azonosito, string cim, string kategoria, int alapteruletM2):this(azonosito,cim,kategoria,alapteruletM2,alapteruletM2*500)
        {

        }
        public Ingatlan(string azonosito, string cim, string kategoria, int alapteruletM2, int arEzerFt)
        {
            Azonosito = azonosito;
            Cim = cim;
            Kategoria = kategoria;
            AlapteruletM2 = alapteruletM2;
            ArEzerFt = arEzerFt;
            osszesRegisztraltIngatlan++;
        }
        public override string ToString()
        {
            return $"{Azonosito} {Cim} {Kategoria} - Terület: {AlapteruletM2} m2 | Ár: {ArEzerFt} ezer Ft";
        }
        public double NegyzetmeterAr()
        {
            return ((ArEzerFt * 1000.0) / AlapteruletM2);
        }
    }
}
