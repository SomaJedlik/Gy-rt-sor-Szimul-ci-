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

            List<Termék> TermékLista = new List<Termék>();

            Termék csúnyaTermék = new Termék();
            csúnyaTermék.termék("csúnya termék", 100);
            csúnyaTermék.receptÍrás(olcsóAlapanyag);
            csúnyaTermék.receptÍrás(drágaAlapanyag);
            TermékLista.Add(csúnyaTermék);

            Termék szépTermék = new Termék();
            szépTermék.termék("szépTermék", 100);
            szépTermék.receptÍrás(csúnyaAlalpanyag);
            TermékLista.Add(szépTermék);

            Termék hasznosTermék = new Termék();
            hasznosTermék.termék("hasznosTermék", 100);
            hasznosTermék.receptÍrás(drágaAlapanyag);
            hasznosTermék.receptÍrás(veszélyesAlapanyag);
            TermékLista.Add(hasznosTermék);

            Termék újrahsznosíthatóTermék = new Termék();
            újrahsznosíthatóTermék.termék("újrahsznosíthatóTermék", 100);
            újrahsznosíthatóTermék.receptÍrás(olcsóAlapanyag);
            újrahsznosíthatóTermék.receptÍrás(veszélyesAlapanyag);
            TermékLista.Add(újrahsznosíthatóTermék);

            Termék Sajt = new Termék();
            Sajt.termék("Sajt", 100);
            Sajt.receptÍrás(titokzatosEredetűAlapanyag);
            TermékLista.Add(Sajt);


                                                                                                 //Munkás
            Munkás simaMunkás = new Munkás();
            simaMunkás.Hozzáértés = "Sima Munkás";
            Munkás okosMunkás = new Munkás();
            okosMunkás.Hozzáértés = "Okos Munkás";

            gyár.Munkások.Add(simaMunkás);

            gyár.Munkások.Add(okosMunkás);

                                                                                               //Rendelés
            Rendelés A = new Rendelés();
            RendelésGenerálás(A, TermékLista);
            Rendelés B = new Rendelés();
            RendelésGenerálás(B, TermékLista);
            Rendelés C = new Rendelés();
            RendelésGenerálás(C, TermékLista);










            //                                                                                      --Futtattás--
            int aktív = 0;
            while (gyár.fut)
            {
                int b =MenuÍrás(aktív, A, B, C, gyár);
                aktív = b;
            }
            
        }






        static int MenuÍrás(int a, Rendelés A, Rendelés B, Rendelés C, Gyár gyár)
        {
            int aktív = a;
            List<string> Menü = new List<string> {"Infó              ","Fejlesztés          ","Rendelések          ","Nyersanyag beszerzés ","Start                ","Kilépés            "};
            
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
                        Infó(gyár);
                            break;
                    case 1:
                        Fejlesztés(gyár);
                        break;
                    case 2:
                        RendelésÍrás(A, B, C);
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:
                        gyár.fut = false;
                        break;
                }
            }







            return (aktív);

        }

        static void Fejlesztés(Gyár gyár)
        {
            bool fejlesztés = true;
            int aktív = 0;
            List<string> Menü = new List<string> { "sima munkás         ", "okos munkás   ", "hangos gép   ", "egyszerű gép        ", "csúnya gép      ", "Kilépés       " };
            while (fejlesztés)
            {
                
                for (int i = 0; i < Menü.Count; i++)
                {
                    if (i == 0) Console.WriteLine("Munkás bérlés");
                    if (i == aktív)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(Menü[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                    if (i == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Gép vásárlás");
                    }
                    if (i == 4) Console.WriteLine();

                }
                ConsoleKey Action = Console.ReadKey().Key;
                if (Action == ConsoleKey.UpArrow)
                {
                    aktív--;
                }
                else if (Action == ConsoleKey.DownArrow)
                {
                    aktív++;
                }
                if (aktív >= Menü.Count)
                {
                    aktív = 0;
                }
                else if (aktív < 0)
                {
                    aktív = Menü.Count - 1;
                }
                Console.Clear();
                if (Action == ConsoleKey.Enter)
                {
                    switch (aktív)
                    {
                        case 0:
                            gyár.Munkások[0].Létszám+=1;
                            break;
                        case 1:
                            gyár.Munkások[1].Létszám += 1;
                            break;
                        case 2:
                            if (gyár.Pénz >= gyár.Gépek[0].Ár)
                            {
                                gyár.Gépek[0].mennysiség += 1;
                                gyár.Pénz -= gyár.Gépek[0].Ár;
                            }
                            break;
                        case 3:
                            if (gyár.Pénz >= gyár.Gépek[1].Ár)
                            {
                                gyár.Gépek[1].mennysiség += 1;
                                gyár.Pénz -= gyár.Gépek[1].Ár;
                            }
                            break;
                        case 4:
                            if (gyár.Pénz >= gyár.Gépek[2].Ár)
                            {
                                gyár.Gépek[2].mennysiség += 1;
                                gyár.Pénz -= gyár.Gépek[2].Ár;
                            }
                            break;
                        case 5:
                            fejlesztés = false;
                            break;
                    }
                }
            }
            
        }

        static void RendelésGenerálás(Rendelés rendelés, List<Termék> TermékLista)
        {
            Random random = new Random();
            List<Termék> Lista = new List<Termék>();
            Lista = TermékLista;
            int Bónusz = random.Next(40);
            rendelés.Fizet = 0;

            int a = random.Next(0, Lista.Count);
            if (a<= Lista.Count)
            {
                rendelés.vásárol = Lista[a];
            }
            
            Lista.Remove(Lista[a]);
            rendelés.mennyiség=random.Next(50,100);


            rendelés.Fizet += rendelés.vásárol.Ár * Bónusz*rendelés.mennyiség;
        }

        static void RendelésÍrás(Rendelés rendelés1, Rendelés rendelés2, Rendelés rendelés3)
        {
            Console.Clear();
            Console.WriteLine($"{rendelés1.vásárol.Név} {rendelés1.vásárol.Mennyiség}");
            Console.WriteLine($"{rendelés1.Fizet}");
            Console.WriteLine();
            Console.WriteLine($"{rendelés2.vásárol.Név} {rendelés2.vásárol.Mennyiség}");
            Console.WriteLine($"{rendelés2.Fizet}");
            Console.WriteLine();
            Console.WriteLine($"{rendelés3.vásárol.Név} {rendelés3.vásárol.Mennyiség}");
            Console.WriteLine($"{rendelés3.Fizet}");
            Console.ReadKey();
            Console.Clear();
        }

        static void Infó(Gyár gyár)
        {
            Console.Clear();
            Console.WriteLine($"Pénz: {gyár.Pénz}");
            foreach (var item in gyár.Munkások)
            {
                Console.WriteLine($"{item.Hozzáértés} {item.Létszám}");
            }
            foreach (var item in gyár.Gépek)
            {
                Console.WriteLine($"{item.Név} {item.mennysiség}");
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void nyersanyag(Alapanyag olcsóAlapanyag, Alapanyag drágaAlapanyag, Alapanyag csúnyaAlalpanyag, Alapanyag újrahasznósítottAlapanyag, Alapanyag veszélyesAlapanyag, Alapanyag titokzatosEredetűAlapanyag)
        {




            {
                bool fejlesztés = true;
                int aktív = 0;
                List<string> Menü = new List<string> { "Olcsó Alapanyag         ", "Drága Alapanyag   ", "Csúnya Alapanyag   ", "Újrahasznósított Alapanyag        ", "Veszélyes Alapanyag      ", "Titokzatos Eredetű Alapanyag       ","Kilépés " };
                while (fejlesztés)
                {

                    for (int i = 0; i < Menü.Count; i++)
                    {
                        
                        if (i == aktív)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.White;
                        }

                        Console.WriteLine(Menü[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    ConsoleKey Action = Console.ReadKey().Key;
                    if (Action == ConsoleKey.UpArrow)
                    {
                        aktív--;
                    }
                    else if (Action == ConsoleKey.DownArrow)
                    {
                        aktív++;
                    }
                    if (aktív >= Menü.Count)
                    {
                        aktív = 0;
                    }
                    else if (aktív < 0)
                    {
                        aktív = Menü.Count - 1;
                    }
                    Console.Clear();
                    if (Action == ConsoleKey.Enter)
                    {
                        switch (aktív)
                        {
                            case 0:
                                
                                break;
                            case 1:
                                gyár.Munkások[1].Létszám += 1;
                                break;
                            case 2:
                                if (gyár.Pénz >= gyár.Gépek[0].Ár)
                                {
                                    gyár.Gépek[0].mennysiség += 1;
                                    gyár.Pénz -= gyár.Gépek[0].Ár;
                                }
                                break;
                            case 3:
                                if (gyár.Pénz >= gyár.Gépek[1].Ár)
                                {
                                    gyár.Gépek[1].mennysiség += 1;
                                    gyár.Pénz -= gyár.Gépek[1].Ár;
                                }
                                break;
                            case 4:
                                if (gyár.Pénz >= gyár.Gépek[2].Ár)
                                {
                                    gyár.Gépek[2].mennysiség += 1;
                                    gyár.Pénz -= gyár.Gépek[2].Ár;
                                }
                                break;
                            case 6:
                                fejlesztés = false;
                                break;
                        }
                    }
                }

            }
        }
    }
}
