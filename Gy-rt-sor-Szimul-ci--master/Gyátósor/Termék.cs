using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gyártósor
{
    internal class Termék
    {
        public string Név { get; set; }
        public List<Alapanyag> Recept { get; set; } = new List<Alapanyag> { };

        public int Ár { get; set; }

        public Gép eszközök { get; set; }
        public int Mennyiség {  get; set; }

        public void termék(string név, int ár)
        {
            Név = név;
            Ár = ár;
        }
        public void receptÍrás(Alapanyag új)
        {
            Recept.Add(új);
        }
    }
}
