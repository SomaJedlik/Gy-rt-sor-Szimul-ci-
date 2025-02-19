using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
        
namespace Gyártósor
{       
    internal class Alapanyag
    {   
        public string Név;
        public int Ár {  get; set; }
        public int Mennyiség {  get; set; }

        public void alapanyag(string név, int ár, int mennyiség)
        {
            Név=név;
            Ár=ár;
            Mennyiség=mennyiség;
        }

        
    }   
}       