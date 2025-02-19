using Gyátósor;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Gyártósor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gyár gyár = new Gyár();
            gyár.Pénz = 1000000000;


                                                                                            //Alapanyagok
            Alapanyag olcsóAlapanyag = new Alapanyag();
            olcsóAlapanyag.alapanyag("Olcsó Alapanyag", 10, 0);

            Alapanyag drágaAlapanyag = new Alapanyag();
            drágaAlapanyag.alapanyag("Drága Alapanyag", 10, 0);

            Alapanyag csúnyaAlalpanyag = new Alapanyag();
            csúnyaAlalpanyag.alapanyag("Csúnya Alapanyag", 10, 0);

            Alapanyag újrahasznósítottAlapanyag = new Alapanyag();
            újrahasznósítottAlapanyag.alapanyag("Újrahasznósított Alapanyag", 0, 0);

            Alapanyag veszélyesAlapanyag = new Alapanyag();
            veszélyesAlapanyag.alapanyag("Veszélyes Alapanyag", 10, 0);

            Alapanyag titokzatosEredetűAlapanyag = new Alapanyag();
            titokzatosEredetűAlapanyag.alapanyag("Titokzatos Eredetű Alapanyag", 10, 0);






                                                                                            //Gépek
            Gép hangosGép = new Gép();
            hangosGép.gép("Hangos Gép", 10, 3, 2);
            gyár.Gépek.Add(hangosGép);

            Gép egysszerűGép = new Gép();
            egysszerűGép.gép("Egyszerű Gép", 8, 4, 1);
            gyár.Gépek.Add(egysszerűGép);

            Gép csúnyaGép = new Gép();
            csúnyaGép.gép("Csúnya Gép", 13, 9, 5);
            gyár.Gépek.Add(csúnyaGép);





                                                                                            //Termékek

            

            Termék csúnyaTermék = new Termék();
            csúnyaTermék.termék("csúnya termék", 50);
            csúnyaTermék.receptÍrás(olcsóAlapanyag);
            csúnyaTermék.receptÍrás(drágaAlapanyag);
            gyár.TermékLista.Add(csúnyaTermék);

            Termék szépTermék = new Termék();
            szépTermék.termék("szépTermék", 30);
            szépTermék.receptÍrás(csúnyaAlalpanyag);
            gyár.TermékLista.Add(szépTermék);

            Termék hasznosTermék = new Termék();
            hasznosTermék.termék("hasznosTermék", 120);
            hasznosTermék.receptÍrás(drágaAlapanyag);
            hasznosTermék.receptÍrás(veszélyesAlapanyag);
            gyár.TermékLista.Add(hasznosTermék);

            Termék újrahsznosíthatóTermék = new Termék();
            újrahsznosíthatóTermék.termék("újrahsznosíthatóTermék", 10);
            újrahsznosíthatóTermék.receptÍrás(olcsóAlapanyag);
            újrahsznosíthatóTermék.receptÍrás(veszélyesAlapanyag);
            gyár.TermékLista.Add(újrahsznosíthatóTermék);

            Termék Sajt = new Termék();
            Sajt.termék("Sajt", 1000);
            Sajt.receptÍrás(titokzatosEredetűAlapanyag);
            gyár.TermékLista.Add(Sajt);


                                                                                                 //Munkás
            Munkás simaMunkás = new Munkás();
            simaMunkás.Hozzáértés = "Sima Munkás";
            Munkás okosMunkás = new Munkás();
            okosMunkás.Hozzáértés = "Okos Munkás";

            gyár.Munkások.Add(simaMunkás);

            gyár.Munkások.Add(okosMunkás);

                                                                                               //Rendelés
            Rendelés A = new Rendelés();
            gyár.RendelésGenerálás(A, gyár.TermékLista);
            Rendelés B = new Rendelés();
            gyár.RendelésGenerálás(B, gyár.TermékLista);
            Rendelés C = new Rendelés();
            gyár.RendelésGenerálás(C, gyár.TermékLista);










            //                                                                                      --Futtattás--
            int aktív = 0;
            while (gyár.fut)
            {
                int b =gyár.MenuÍrás(aktív, A, B, C, gyár, olcsóAlapanyag, drágaAlapanyag, csúnyaAlalpanyag, újrahasznósítottAlapanyag, veszélyesAlapanyag, titokzatosEredetűAlapanyag);
                aktív = b;
            }
            
        }






        
        
    }
}
