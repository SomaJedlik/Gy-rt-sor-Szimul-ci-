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



        public int MenuÍrás(int a, Rendelés A, Rendelés B, Rendelés C, Gyár gyár, Alapanyag olcsóAlapanyag, Alapanyag drágaAlapanyag, Alapanyag csúnyaAlalpanyag, Alapanyag újrahasznósítottAlapanyag, Alapanyag veszélyesAlapanyag, Alapanyag titokzatosEredetűAlapanyag)
        {
            int aktív = a;
            List<string> Menü = new List<string> { "Infó              ", "Fejlesztés          ", "Rendelések          ", "Nyersanyag beszerzés ", "Start                ", "Kilépés            " };

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
                        Infó(gyár, olcsóAlapanyag, drágaAlapanyag, csúnyaAlalpanyag, újrahasznósítottAlapanyag, veszélyesAlapanyag, titokzatosEredetűAlapanyag);
                        break;
                    case 1:
                        Fejlesztés(gyár);
                        break;
                    case 2:
                        RendelésÍrás(A, B, C);
                        break;
                    case 3:
                        nyersanyag(olcsóAlapanyag, drágaAlapanyag, csúnyaAlalpanyag, újrahasznósítottAlapanyag, veszélyesAlapanyag, titokzatosEredetűAlapanyag, gyár);
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

        public void Fejlesztés(Gyár gyár)
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
                            gyár.Munkások[0].Létszám += 1;
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

        public void RendelésGenerálás(Rendelés rendelés, List<Termék> TermékLista)
        {
            Random random = new Random();
            List<Termék> Lista = new List<Termék>();
            Lista = TermékLista;
            int Bónusz = random.Next(10,40);
            rendelés.Fizet = 0;

            int a = random.Next(0, Lista.Count);
            if (a <= Lista.Count)
            {
                rendelés.vásárol = Lista[a];
            }

            Lista.Remove(Lista[a]);
            rendelés.mennyiség = random.Next(50, 100);


            rendelés.Fizet += rendelés.vásárol.Ár * Bónusz * rendelés.mennyiség;
        }

        public void RendelésÍrás(Rendelés rendelés1, Rendelés rendelés2, Rendelés rendelés3)
        {
            Console.Clear();
            Console.WriteLine($"{rendelés1.vásárol.Név} {rendelés1.mennyiség}");
            Console.WriteLine($"{rendelés1.Fizet}");
            Console.WriteLine();
            Console.WriteLine($"{rendelés2.vásárol.Név} {rendelés2.mennyiség}");
            Console.WriteLine($"{rendelés2.Fizet}");
            Console.WriteLine();
            Console.WriteLine($"{rendelés3.vásárol.Név} {rendelés3.mennyiség}");
            Console.WriteLine($"{rendelés3.Fizet}");
            Console.ReadKey();
            Console.Clear();
        }

        public void Infó(Gyár gyár, Alapanyag olcsóAlapanyag, Alapanyag drágaAlapanyag, Alapanyag csúnyaAlalpanyag, Alapanyag újrahasznósítottAlapanyag, Alapanyag veszélyesAlapanyag, Alapanyag titokzatosEredetűAlapanyag)
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
            Console.WriteLine();
            Console.WriteLine($"{olcsóAlapanyag.Név} {olcsóAlapanyag.Mennyiség}");
            Console.WriteLine($"{drágaAlapanyag.Név} {drágaAlapanyag.Mennyiség}");
            Console.WriteLine($"{csúnyaAlalpanyag.Név} {csúnyaAlalpanyag.Mennyiség}");
            Console.WriteLine($"{újrahasznósítottAlapanyag.Név} {újrahasznósítottAlapanyag.Mennyiség}");
            Console.WriteLine($"{veszélyesAlapanyag.Név} {veszélyesAlapanyag.Mennyiség}");
            Console.WriteLine($"{titokzatosEredetűAlapanyag.Név} {titokzatosEredetűAlapanyag.Mennyiség}");



            Console.ReadKey();
            Console.Clear();
        }

        public void nyersanyag(Alapanyag olcsóAlapanyag, Alapanyag drágaAlapanyag, Alapanyag csúnyaAlalpanyag, Alapanyag újrahasznósítottAlapanyag, Alapanyag veszélyesAlapanyag, Alapanyag titokzatosEredetűAlapanyag, Gyár gyár)
        {




            {
                bool fejlesztés = true;
                int aktív = 0;
                List<string> Menü = new List<string> { "Olcsó Alapanyag         ", "Drága Alapanyag   ", "Csúnya Alapanyag   ", "Újrahasznósított Alapanyag        ", "Veszélyes Alapanyag      ", "Titokzatos Eredetű Alapanyag       ", "Kilépés " };
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
                                if (gyár.Pénz >= olcsóAlapanyag.Ár)
                                {
                                    olcsóAlapanyag.Mennyiség += 1;
                                    gyár.Pénz -= olcsóAlapanyag.Ár;
                                }
                                break;
                            case 1:
                                if (gyár.Pénz >= drágaAlapanyag.Ár)
                                {
                                    drágaAlapanyag.Mennyiség += 1;
                                    gyár.Pénz -= drágaAlapanyag.Ár;
                                }
                                break;
                            case 2:
                                if (gyár.Pénz >= csúnyaAlalpanyag.Ár)
                                {
                                    csúnyaAlalpanyag.Mennyiség += 1;
                                    gyár.Pénz -= csúnyaAlalpanyag.Ár;
                                }
                                break;
                            case 3:
                                if (gyár.Pénz >= újrahasznósítottAlapanyag.Ár)
                                {
                                    újrahasznósítottAlapanyag.Mennyiség += 1;
                                    gyár.Pénz -= újrahasznósítottAlapanyag.Ár;
                                }
                                break;
                            case 4:
                                if (gyár.Pénz >= veszélyesAlapanyag.Ár)
                                {
                                    veszélyesAlapanyag.Mennyiség += 1;
                                    gyár.Pénz -= veszélyesAlapanyag.Ár;
                                }
                                break;
                            case 5:
                                if (gyár.Pénz >= titokzatosEredetűAlapanyag.Ár)
                                {
                                    titokzatosEredetűAlapanyag.Mennyiség += 1;
                                    gyár.Pénz -= titokzatosEredetűAlapanyag.Ár;
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
