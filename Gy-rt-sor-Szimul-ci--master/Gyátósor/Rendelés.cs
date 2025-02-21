using Gyártósor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyátósor
{
    internal class Rendelés
    {
        public Termék vásárol { get; set; }
        public int mennyiség { get; set; } 
        public int Fizet;
        public bool Elfogadott { get; set; }
        
    }
}
