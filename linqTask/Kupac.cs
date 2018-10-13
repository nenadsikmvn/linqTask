using System;
using System.Collections.Generic;
using System.Linq;

namespace linqTask
{
    public class Kupac
    {
        public int KupacId { get; set; }
        public string Ime { get; set; }
        public int Godine { get; set; }
        public string Grad { get; set; }


        public List<Kupac> ListaKupca()
        {
            List<Kupac> kupac = new List<Kupac>
                  {
                              new Kupac { KupacId = 1, Ime = "Nenad", Godine = 23, Grad = "Novi Sad" },
                              new Kupac { KupacId = 2, Ime = "Milan", Godine = 21, Grad = "Beć" },
                              new Kupac { KupacId = 3, Ime = "Nemanja", Godine = 42, Grad = "Bijeljina" },
                              new Kupac { KupacId = 4, Ime = "Pera", Godine = 50, Grad = "Becej" },
                              new Kupac { KupacId = 5, Ime = "Stojan", Godine = 19, Grad = "Beograd" },
                              new Kupac { KupacId = 6, Ime = "Bojan", Godine = 102, Grad = "Beograd" },
                              new Kupac { KupacId = 7, Ime = "Ivan", Godine = 21, Grad = "Novi Sad" },
                              new Kupac { KupacId = 8, Ime = "Darko", Godine = 23, Grad = "Beograd" },
                              new Kupac { KupacId = 9, Ime = "Slavko", Godine = 25, Grad = "Novi Sad" },
                              new Kupac { KupacId = 10, Ime = "Pavko", Godine = 30, Grad = "Becej" },
                              new Kupac { KupacId = 11, Ime = "Istvan", Godine = 27, Grad = "Cenej" },
                              new Kupac { KupacId = 12, Ime = "Borko", Godine = 29, Grad = "Beograd" },
                              new Kupac { KupacId = 13, Ime = "Mladen", Godine = 30, Grad = "Zrenjanin" },
                              new Kupac { KupacId = 14, Ime = "Mladen", Godine = 25, Grad = "Zrenjanin" },
                              new Kupac { KupacId = 15, Ime = "Dario", Godine = 30, Grad = "Arandjelovac" },
                              new Kupac { KupacId = 16, Ime = "Todor", Godine = 30, Grad = "Becej" },
                  };

            return kupac;

        }

        public void MetodaID(List<Kupac> kupac)
        {
            var metoda = kupac.Where(k => k.KupacId == 3);

            foreach (var k in metoda)
            {
                Console.WriteLine("\n\nKupac pod rednim brojem ID 3 je " + k.Ime + ".\n");
            }

        }

        public void NajmladjiKupac(List<Kupac> kupac)
        {
            int metoda = kupac.Min(k => k.Godine);
            Kupac kp = (from element in kupac
                        orderby element.Godine
                        select element).First();

            Console.WriteLine("\nNajmladji kupac je " + kp.Ime + "." + "\n\n");

            #region alternativa
            /* ili nesto ovako 
            var metodza = kupac.OrderByDescending(k => k.Godine).First();
            */
            #endregion
        }

        public void ProveraGodina(List<Kupac> kupac)
        {
            var metoda = kupac.Where(k => k.Godine >= 18 && k.Godine < 50);
            Console.Write("Korisnici koji spadaju u punoletne a pritom nisu stariji od 50 godina su: \n");
            Console.ReadLine();
            foreach (var k in metoda)
            {
                Console.WriteLine("{0}\t{1}", k.Ime, k.Godine);
            }

            var sortiranje = metoda.OrderBy(k => k.Godine);

            Console.Write("\nSortiraj ih po godinama: \n");
            Console.ReadLine();
            foreach (var s in sortiranje)
            {
                Console.WriteLine("{0}\t {1} ", s.Ime, s.Godine);
            }
        }

        public void OstatakZadatkaUJednoj(List<Kupac> kupac)
        {
            var bezBeograda = kupac.Where(k => k.Grad != "Beograd");
            Console.Write("\nKorisnici koji nisu iz Beograda:\n");
            Console.ReadLine();
            foreach (var k in bezBeograda)
            {
                Console.WriteLine("{0} / {1}", k.Ime, k.Grad);
            }

            var neSadrzi = kupac.Where(k => !k.Ime.Contains("I") && !k.Ime.Contains("i"));
            Console.WriteLine("\nBez slova {i} u imenu:");
            Console.ReadLine();

            foreach (var k in neSadrzi)
            {
                Console.WriteLine(k.Ime);
            }

            var sadrziA = kupac.Where(k => k.Ime.Contains("a")).OrderBy(k => k.Ime);

            Console.WriteLine("\nSva imena koja sadrze slovo {a} u sebi i sortira ih po imenu:");
            Console.ReadLine();
            foreach (var k in sadrziA)
            {
                Console.WriteLine(k.Ime);
            }
        }

        public void FluentVsQuery()
        {

            List<Kupac> kupac = new List<Kupac>
                        {
                              new Kupac { KupacId = 1, Ime = "Jovan", Godine = 20, Grad = "Novi Sad" },
                              new Kupac { KupacId = 2, Ime = "Jovan", Godine = 21, Grad = "Beć" },
                              new Kupac { KupacId = 3, Ime = "Marko", Godine = 42, Grad = "Bijeljina" },
                              new Kupac { KupacId = 4, Ime = "Marko", Godine = 55, Grad = "Becej" },
                              new Kupac { KupacId = 5, Ime = "Mirjana", Godine = 19, Grad = "Beograd" }
        };
            Console.WriteLine("\nKupci poredjani po imenu ali i po godinama: ");
            var orderByResult = from k in kupac
                                orderby k.Ime, k.Godine
                                select k;
            foreach (var k in orderByResult)
            {
                Console.WriteLine("{0},{1}", k.Ime, k.Godine);
            }
        }

        public void Grupisanje(List<Kupac> kupac)

        {
            var grupeKupca = from k in kupac
                             group k by k.Godine;
            Console.WriteLine("\nGrupisi kupce po starosnom dobu: \n");
            foreach (var group in grupeKupca)
            {
                Console.WriteLine("\nStarosno doba kupca: {0}", group.Key);
                foreach (var imeKupca in group)
                {
                    Console.WriteLine("Ime kupca: "+imeKupca.Ime + "\t");
                    
                }
            }


        }

        public void Ulancavanje()
        {
            Console.WriteLine("\nPronalazi sva imena koja u sebi imaju slovo I malo ili velika i sortira ih po opadajucem broju slova: \n");


            string[] imena = { "Bojana", "Ivana", "Draga", "Milica", "Tina" };
            //pronalazi sva imena koja u sebi imaju slovo i malo ili velika
            //sortira ta imena po duzini u op

            IEnumerable<string> query = imena.Where(i => i.Contains("i") || i.Contains("I"))
                .OrderByDescending(i=>imena.Length);
            foreach (string i in query)
            {
                Console.WriteLine(i.ToArray());
            }
               

        }



        public void Ispis(List<Kupac> kupac)
        {
            Console.WriteLine("~~~~~~~~~~[[LISTA KUPACA]]~~~~~~~~~~\n");
            kupac.ForEach(k => Console.WriteLine("{0}\t Ime:{1}\tGodine:{2}\t Grad:{3}\t"
                , k.KupacId, k.Ime, k.Godine, k.Grad));
            Console.WriteLine("\nPritisnite enter za dalji rad programa..");
            Console.ReadLine();
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~\t");
            Console.WriteLine("Broj kupaca je trenutno {0}", kupac.Count.ToString());
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~\t");
        }
    }
}
