using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyártósor
{
    internal class Gép
    {
        public string Név {  get; set; }
        public  int Ár {  get; set; }
        public string Munkás {  get; set; }
        public int Termelés { get; set; }
        public int Javítás { get; set; }
        public int Karbantartás { get; set; }
        public int mennysiség {  get; set; }


        public void gép(string név, int ár, int termelés, int karbantartás)
        {
            Név=név;
            Ár=ár;
            Termelés=termelés;
            Karbantartás=karbantartás;
        }
        public void munkás(string n)
        {
            Munkás=n;
        }
    }
}
