using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyártósor
{
    internal class Gyár
    {
        public int Pénz { get; set; }
        public List<Gép> Gépek = new List<Gép> { };
        public List<Munkás> Munkások = new List<Munkás> { };



        public void gyár(int pénz)
        {
            Pénz=pénz;
        }
        public void Hiring(Munkás munk)
        {
            Munkások.Add(munk);
        }
    }
}
