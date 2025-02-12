using System.Security.Cryptography.X509Certificates;

namespace Gyártósor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gyár gyár = new Gyár();


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

            Gép egysszerűGép = new Gép();
            egysszerűGép.gép("Egyszerű Gép", 8, 4, 1);

            Gép csúnyaGép = new Gép();
            csúnyaGép.gép("Csúnya Gép", 13, 9, 5);





                                                                                            //Termékek
            Termék csúnyaTermék = new Termék();
            csúnyaTermék.receptÍrás(olcsóAlapanyag);
            csúnyaTermék.receptÍrás(drágaAlapanyag);

            Termék szépTermék = new Termék();
            szépTermék.receptÍrás(csúnyaAlalpanyag);

            Termék hasznosTermék = new Termék();
            hasznosTermék.receptÍrás(drágaAlapanyag);
            hasznosTermék.receptÍrás(veszélyesAlapanyag);

            Termék újrahsznosíthatóTermék = new Termék();
            újrahsznosíthatóTermék.receptÍrás(olcsóAlapanyag);
            újrahsznosíthatóTermék.receptÍrás(veszélyesAlapanyag);

            Termék Sajt = new Termék();
            Sajt.receptÍrás(titokzatosEredetűAlapanyag);


                                                                                                //Munkás
            Munkás simaMunkás = new Munkás();
            Munkás okosMunkás = new Munkás();

            gyár.Munkások.Add(simaMunkás);

            gyár.Munkások.Add(okosMunkás);

            Char a = Console.ReadKey().KeyChar;
            Console.WriteLine(a);
            bool fut = true;
            int aktív = 0;
            while (fut)
            {
                int b =MenuÍrás(aktív);
                aktív = b;
            }
            
        }
        static int MenuÍrás(int a)
        {
            int aktív = a;
            List<string> Menü = new List<string> {"Infó","Fejlesztés","Rendelések","Start","Kilépés" };
            
            for(int i=0; i<Menü.Count; i++)
            {
                if(i==aktív)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.White;
                }

                Console.WriteLine(Menü[i]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            ConsoleKey Action = Console.ReadKey().Key;
            if (Action==ConsoleKey.UpArrow)
            {
                aktív--;
            }else if (Action == ConsoleKey.DownArrow)
            {
                aktív++;
            }
            if (aktív >= Menü.Count)
            {
                aktív = 0;
            }else if(aktív < 0)
            {
                aktív = Menü.Count - 1;
            }
            Console.Clear();
            if (Action== ConsoleKey.Enter)
            {
                switch(aktív)
                {
                    case 0:
                        Console.WriteLine("Hi");
                            break;
                    case 1: Console.WriteLine("bye");
                        break;
                }
            }







            return (aktív);

        }
    }
}
