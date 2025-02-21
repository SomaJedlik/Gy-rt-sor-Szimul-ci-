using Gyátósor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gyártósor
{
    internal class Gyár
    {
        public int Pénz { get; set; }
        public List<Gép> Gépek = new List<Gép> { };
        public List<Munkás> Munkások = new List<Munkás> { };
        public bool fut = true;
        public List<Termék> TermékLista = new List<Termék>();
        public List<Rendelés> Elfogadott = new List<Rendelés>();



        public int MenuÍrás(int a, Rendelés A, Rendelés B, Rendelés C, Gyár gyár, Alapanyag olcsóAlapanyag, Alapanyag drágaAlapanyag, Alapanyag csúnyaAlalpanyag, Alapanyag újrahasznósítottAlapanyag, Alapanyag veszélyesAlapanyag, Alapanyag titokzatosEredetűAlapanyag, Gép hangos, Gép egyszerű, Gép csúnya)
        {
            int aktív = a;
            List<string> Menü = new List<string> { "Infó              ", "Fejlesztés          ", "Rendelések          ", "Alapanyag beszerzés ", "Start                ", "Kilépés            " };

            for (int i = 0; i < Menü.Count; i++)
            {
                if (i == aktív)
                {
                    Console.Write(" > ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else Console.Write(" - ");

                Console.WriteLine(Menü[i]);
                Console.ForegroundColor = ConsoleColor.DarkGray;
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
                        Infó(gyár, olcsóAlapanyag, drágaAlapanyag, csúnyaAlalpanyag, újrahasznósítottAlapanyag, veszélyesAlapanyag, titokzatosEredetűAlapanyag, A, B, C, hangos, egyszerű, csúnya);
                        break;
                    case 1:
                        Fejlesztés(gyár);
                        break;
                    case 2:
                        RendelésÍrás(A, B, C, gyár);
                        break;
                    case 3:
                        nyersanyag(olcsóAlapanyag, drágaAlapanyag, csúnyaAlalpanyag, újrahasznósítottAlapanyag, veszélyesAlapanyag, titokzatosEredetűAlapanyag, gyár);
                        break;
                    case 4:
                        Start(gyár, olcsóAlapanyag, drágaAlapanyag, csúnyaAlalpanyag, újrahasznósítottAlapanyag, veszélyesAlapanyag, titokzatosEredetűAlapanyag, A, B, C, hangos, egyszerű, csúnya);
                        break;
                    case 5:
                        gyár.fut = false;
                        break;
                }
            }






            return (aktív);

        }

        public void Fejlesztés(Gyár gyár)
        {
            bool fejlesztés = true;
            int aktív = 0;
            List<string> Menü = new List<string> { "sima munkás         ", "okos munkás   ", "hangos gép   ", "egyszerű gép        ", "csúnya gép      ", "Vissza       " };
            while (fejlesztés)
            {

                for (int i = 0; i < Menü.Count; i++)
                {
                    if (i == 0) Console.WriteLine("Munkás bérlés");
                    if (i == aktív)
                    {
                        Console.Write(" > ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }else Console.Write(" - ");

                    Console.WriteLine(Menü[i]);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
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
                    int a = 0;
                    switch (aktív)
                    {
                        case 0:
                            gyár.Munkások[0].Létszám += Bekérés();
                            break;
                        case 1:
                            gyár.Munkások[1].Létszám += Bekérés();
                            break;
                        case 2:
                            a = Bekérés();
                            if (gyár.Pénz >= gyár.Gépek[0].Ár*a)
                            {
                                gyár.Gépek[0].mennysiség += a;
                                gyár.Pénz -= gyár.Gépek[0].Ár*a;
                            }
                            break;
                        case 3:
                            a = Bekérés();
                            if (gyár.Pénz >= gyár.Gépek[1].Ár*a)
                            {
                                gyár.Gépek[1].mennysiség +=a;
                                gyár.Pénz -= gyár.Gépek[1].Ár * a;
                            }
                            break;
                        case 4:
                            a = Bekérés();
                            if (gyár.Pénz >= gyár.Gépek[2].Ár * a)
                            {
                                gyár.Gépek[2].mennysiség += a;
                                gyár.Pénz -= gyár.Gépek[2].Ár * a;
                            }
                            break;
                        case 5:
                            fejlesztés = false;
                            break;
                    }
                }
            }

        }

        public void RendelésGenerálás(Rendelés rendelés, List<Termék> TermékLista)
        {
            Random random = new Random();
            List<Termék> Lista = new List<Termék>();
            Lista = TermékLista;
            int Bónusz = random.Next(10,40);

            int a = random.Next(0, Lista.Count);
            if (a <= Lista.Count)
            {
                rendelés.vásárol = Lista[a];
            }

            rendelés.mennyiség = random.Next(50, 100);


            rendelés.Fizet = rendelés.vásárol.Ár * Bónusz * rendelés.mennyiség;
            rendelés.Elfogadott = false;
        }

        public void RendelésÍrás(Rendelés rendelés1, Rendelés rendelés2, Rendelés rendelés3, Gyár gyár)
        {
            Console.Clear();

            bool fejlesztés = true;
            int aktív = 0;
            List<Rendelés> Menü = new List<Rendelés> { rendelés1, rendelés2, rendelés3};
            while (fejlesztés)
            {
                Console.WriteLine("---------------------------------------------------");

                for (int i = 0; i < Menü.Count; i++)
                {

                    if (i == aktív)
                    {
                        
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" > ");
                    }
                    else Console.Write(" - ");
                    if (i<3 && Menü[i].Elfogadott)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }else if (i < 3) Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine($"Rendelés {i+1}");

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{Menü[i].vásárol.Név} {Menü[i].mennyiség}");
                    Console.WriteLine($"{Menü[i].Fizet}");
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine();


                }

                if (3 == aktív)
                {
                    Console.Write(" > ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else Console.Write(" - ");

                Console.WriteLine($"Vissza");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.Black;



                ConsoleKey Action = Console.ReadKey().Key;
                if (Action == ConsoleKey.UpArrow)
                {
                    aktív--;
                }
                else if (Action == ConsoleKey.DownArrow)
                {
                    aktív++;
                }
                if (aktív >= Menü.Count+1)
                {
                    aktív = 0;
                }
                else if (aktív < 0)
                {
                    aktív = Menü.Count;
                }
                Console.Clear();
                if (Action == ConsoleKey.Enter)
                {
                    switch (aktív)
                    {
                        case 0:
                            if (!rendelés1.Elfogadott)
                            {
                                rendelés1.Elfogadott = true;
                            }
                            else rendelés1.Elfogadott = false;
                            break;
                        case 1:
                            if (!rendelés2.Elfogadott)
                            {
                                rendelés2.Elfogadott = true;
                            }
                            else rendelés2.Elfogadott = false;
                            break;
                        case 2:
                            if (!rendelés3.Elfogadott)
                            {
                                rendelés3.Elfogadott = true;
                            }
                            else rendelés3.Elfogadott = false;
                            break;
                        case 3:
                            fejlesztés = false;
                            break;
                    }
                }
            }




        }

        public void Infó(Gyár gyár, Alapanyag olcsóAlapanyag, Alapanyag drágaAlapanyag, Alapanyag csúnyaAlalpanyag, Alapanyag újrahasznósítottAlapanyag, Alapanyag veszélyesAlapanyag, Alapanyag titokzatosEredetűAlapanyag, Rendelés rendelés1, Rendelés rendelés2, Rendelés rendelés3, Gép hangos, Gép egyszerű, Gép csúnya)
        {
            Console.Clear();
            Console.WriteLine($"Pénz: {gyár.Pénz}");
            Console.WriteLine();
            foreach (var item in gyár.Munkások)
            {
                Console.WriteLine($"{item.Hozzáértés} {item.Létszám}");
            }
            foreach (var item in gyár.Gépek)
            {
                Console.WriteLine($"{item.Név} {item.mennysiség}");
            }
            Console.WriteLine();
            Console.WriteLine($"{olcsóAlapanyag.Név} {olcsóAlapanyag.Mennyiség}");
            Console.WriteLine($"{drágaAlapanyag.Név} {drágaAlapanyag.Mennyiség}");
            Console.WriteLine($"{csúnyaAlalpanyag.Név} {csúnyaAlalpanyag.Mennyiség}");
            Console.WriteLine($"{újrahasznósítottAlapanyag.Név} {újrahasznósítottAlapanyag.Mennyiség}");
            Console.WriteLine($"{veszélyesAlapanyag.Név} {veszélyesAlapanyag.Mennyiség}");
            Console.WriteLine($"{titokzatosEredetűAlapanyag.Név} {titokzatosEredetűAlapanyag.Mennyiség}");

            Console.WriteLine();

            ren(rendelés1);
            ren(rendelés2);
            ren(rendelés3);

            //Ellenörzés

            drágaAlapanyag.szükséges = 0;
            olcsóAlapanyag.szükséges = 0;
            csúnyaAlalpanyag.szükséges = 0;
            veszélyesAlapanyag.szükséges = 0;
            újrahasznósítottAlapanyag.szükséges = 0;
            titokzatosEredetűAlapanyag.szükséges = 0;
            hangos.foglalt = 0;
            csúnya.foglalt = 0;
            egyszerű.foglalt = 0;
            hangos.Munkás.Foglalt = 0;
            csúnya.Munkás.Foglalt = 0;


            if (rendelés1.Elfogadott)
            {
                ellenörzés(rendelés1);

            }
            if (rendelés2.Elfogadott)
            {
                ellenörzés(rendelés2);
            }
            if (rendelés3.Elfogadott)
            {
                ellenörzés(rendelés3);
            }
            if (hangos.mennysiség < hangos.foglalt || egyszerű.mennysiség < egyszerű.foglalt || csúnya.mennysiség < csúnya.foglalt) Console.WriteLine("Nincsen elég gép");
            if (alapanyagEllenörzés(drágaAlapanyag) && alapanyagEllenörzés(olcsóAlapanyag) && alapanyagEllenörzés(csúnyaAlalpanyag) && alapanyagEllenörzés(veszélyesAlapanyag) && alapanyagEllenörzés(újrahasznósítottAlapanyag) && alapanyagEllenörzés(titokzatosEredetűAlapanyag)) { } else Console.WriteLine("Nincsen elég alapanyag");
            if (hangos.Munkás.Létszám < hangos.Munkás.Foglalt || egyszerű.Munkás.Létszám < egyszerű.Munkás.Foglalt || csúnya.Munkás.Létszám < csúnya.Munkás.Foglalt) Console.WriteLine("Nincsen elég Munkás");























            Console.ReadKey();
            Console.Clear();
        }
        public bool alapanyagEllenörzés(Alapanyag alapanyag)

        {
            if (alapanyag.Mennyiség < alapanyag.szükséges)
            {
                return false;
            }
            else return true;
        }
        public void ellenörzés(Rendelés rendelés1)
        {
            {
                rendelés1.vásárol.eszközök.foglalt += rendelés1.mennyiség / rendelés1.vásárol.eszközök.Termelés;
                rendelés1.vásárol.eszközök.Munkás.Foglalt = rendelés1.vásárol.eszközök.foglalt;
                foreach (var item in rendelés1.vásárol.Recept)
                {
                    item.szükséges += rendelés1.mennyiség;
                }

            }
        }


        public void nyersanyag(Alapanyag olcsóAlapanyag, Alapanyag drágaAlapanyag, Alapanyag csúnyaAlalpanyag, Alapanyag újrahasznósítottAlapanyag, Alapanyag veszélyesAlapanyag, Alapanyag titokzatosEredetűAlapanyag, Gyár gyár)
        {




            {
                bool fejlesztés = true;
                int aktív = 0;
                List<string> Menü = new List<string> { "Olcsó Alapanyag         ", "Drága Alapanyag   ", "Csúnya Alapanyag   ", "Újrahasznósított Alapanyag        ", "Veszélyes Alapanyag      ", "Titokzatos Eredetű Alapanyag       ", "Vissza " };
                while (fejlesztés)
                {

                    for (int i = 0; i < Menü.Count; i++)
                    {

                        if (i == aktív)
                        {
                            Console.Write(" > ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else Console.Write(" - ");


                        Console.WriteLine(Menü[i]);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
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
                        int a = 0;
                        switch (aktív)
                        {
                            case 0:
                                a = Bekérés();
                                if (gyár.Pénz >= olcsóAlapanyag.Ár * a)
                                {
                                    olcsóAlapanyag.Mennyiség += a;
                                    gyár.Pénz -= olcsóAlapanyag.Ár * a;
                                }
                                break;
                            case 1:
                                a = Bekérés();
                                if (gyár.Pénz >= drágaAlapanyag.Ár * a)
                                {
                                    drágaAlapanyag.Mennyiség += a;
                                    gyár.Pénz -= drágaAlapanyag.Ár * a;
                                }
                                break;
                            case 2:
                                a = Bekérés();
                                if (gyár.Pénz >= csúnyaAlalpanyag.Ár * a)
                                {
                                    csúnyaAlalpanyag.Mennyiség += a;
                                    gyár.Pénz -= csúnyaAlalpanyag.Ár * a;
                                }
                                break;
                            case 3:
                                a = Bekérés();
                                if (gyár.Pénz >= újrahasznósítottAlapanyag.Ár * a)
                                {
                                    újrahasznósítottAlapanyag.Mennyiség += a;
                                    gyár.Pénz -= újrahasznósítottAlapanyag.Ár * a;
                                }
                                break;
                            case 4:
                                a = Bekérés();
                                if (gyár.Pénz >= veszélyesAlapanyag.Ár*a)
                                {
                                    veszélyesAlapanyag.Mennyiség += a;
                                    gyár.Pénz -= veszélyesAlapanyag.Ár*a;
                                }
                                break;
                            case 5:
                                a = Bekérés();
                                if (gyár.Pénz >= titokzatosEredetűAlapanyag.Ár*a)
                                {
                                    titokzatosEredetűAlapanyag.Mennyiség += a;
                                    gyár.Pénz -= titokzatosEredetűAlapanyag.Ár*a;
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

        public int Bekérés()
        {
            int a = 0;
            try
            {
                Console.Clear();
                Console.Write(" > ");
                a = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                return a;
            } catch (Exception e)
            {
                Console.WriteLine("Hibás érték");
                Console.ReadKey();
                Console.Clear();
                return 0;
            }
            
        }




        public void Start(Gyár gyár, Alapanyag olcsóAlapanyag, Alapanyag drágaAlapanyag, Alapanyag csúnyaAlalpanyag, Alapanyag újrahasznósítottAlapanyag, Alapanyag veszélyesAlapanyag, Alapanyag titokzatosEredetűAlapanyag, Rendelés rendelés1, Rendelés rendelés2, Rendelés rendelés3, Gép hangos, Gép egyszerű, Gép csúnya)
        {
            
            hangos.foglalt = 0;
            csúnya.foglalt = 0;
            egyszerű.foglalt = 0;
            hangos.Munkás.Foglalt = 0;
            csúnya.Munkás.Foglalt = 0;
            bool lehet = true;
            if (rendelés1.Elfogadott)
            {
                ellenörzés(rendelés1);

            }
            if (rendelés2.Elfogadott)
            {
                ellenörzés(rendelés2);
            }
            if (rendelés3.Elfogadott)
            {
                ellenörzés(rendelés3);
            }
            if (hangos.mennysiség < hangos.foglalt || egyszerű.mennysiség < egyszerű.foglalt || csúnya.mennysiség < csúnya.foglalt) lehet=false;
            if (alapanyagEllenörzés(drágaAlapanyag) && alapanyagEllenörzés(olcsóAlapanyag) && alapanyagEllenörzés(csúnyaAlalpanyag) && alapanyagEllenörzés(veszélyesAlapanyag) && alapanyagEllenörzés(újrahasznósítottAlapanyag) && alapanyagEllenörzés(titokzatosEredetűAlapanyag)) { } else lehet = false;
            if (hangos.Munkás.Létszám < hangos.Munkás.Foglalt || egyszerű.Munkás.Létszám < egyszerű.Munkás.Foglalt || csúnya.Munkás.Létszám < csúnya.Munkás.Foglalt) lehet = false;


            if (lehet)
            {
                if (rendelés1.Elfogadott)
                {
                    gyár.Pénz+=rendelés1.Fizet;

                }
                if (rendelés2.Elfogadott)
                {
                    gyár.Pénz += rendelés2.Fizet;
                }
                if (rendelés3.Elfogadott)
                {
                    gyár.Pénz += rendelés3.Fizet;
                }
                gyár.Pénz -= (hangos.Munkás.Foglalt * hangos.Munkás.Fizetés) + (csúnya.Munkás.Foglalt * csúnya.Munkás.Fizetés)+(hangos.foglalt*hangos.Karbantartás) + (csúnya.foglalt * csúnya.Karbantartás) + (egyszerű.foglalt * egyszerű.Karbantartás);
                drágaAlapanyag.Mennyiség -= drágaAlapanyag.szükséges;
                olcsóAlapanyag.Mennyiség -= olcsóAlapanyag.szükséges;
                csúnyaAlalpanyag.Mennyiség -= csúnyaAlalpanyag.szükséges;
                veszélyesAlapanyag.Mennyiség -= veszélyesAlapanyag.szükséges;
                újrahasznósítottAlapanyag.Mennyiség -= újrahasznósítottAlapanyag.szükséges;
                titokzatosEredetűAlapanyag.Mennyiség -= titokzatosEredetűAlapanyag.szükséges;

                drágaAlapanyag.szükséges = 0;
                olcsóAlapanyag.szükséges = 0;
                csúnyaAlalpanyag.szükséges = 0;
                veszélyesAlapanyag.szükséges = 0;
                újrahasznósítottAlapanyag.szükséges = 0;
                titokzatosEredetűAlapanyag.szükséges = 0;

                gyár.RendelésGenerálás(rendelés1, gyár.TermékLista);
                gyár.RendelésGenerálás(rendelés2, gyár.TermékLista);
                gyár.RendelésGenerálás(rendelés3, gyár.TermékLista);


                
                for (int j=0; j<30; j++)
                {
                    
                    Thread.Sleep(100);
                    
                    Console.Write("-");
                    
                        
                }
                Console.Clear();

            }
            else
            {
                Console.WriteLine("Nem lehet befejezni a művelete");
            }

        }

        public void ren(Rendelés rendelés1)
        {
            if (rendelés1.Elfogadott)
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine($"{rendelés1.vásárol.Név} {rendelés1.mennyiség}");
                Console.WriteLine($"Bevétel: {rendelés1.Fizet}");
                Console.Write($"Alapanyagok: ");
                foreach (var item in rendelés1.vásárol.Recept)
                {
                    Console.Write($"{item.Név} ");
                }
                Console.WriteLine("");
                Console.WriteLine($"Gép: {rendelés1.vásárol.eszközök.Név}");

                Console.WriteLine();
                Console.WriteLine();
            }
        }


    }

}
