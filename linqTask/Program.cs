using System;

namespace linqTask
{
    public class Program
    {
        #region Tekst_zadatka
        /*
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  
// TO DO //
Iz liste kupaca izdvaja kupca sa IDEM 3 
pronalazi najmladjeg kupca
iz liste kupaca izdvaja one koji su punoletni i imaju manje od 50
sortira listu kupaca po godinama
iz liste kupaca izdvaja one koji ne zive u bg
iz liste kupaca izdvaja one cije ime ne sadrzi slovo i 
iz liste kupaca izdvaja one cije ima sadrzi slovo a i sortira ih po imenu
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 
*/
        #endregion

        static void Main(string[] args)
        {
            Kupac k1 = new Kupac();
            //zadatak 1
            #region MetodeZadatak1

            k1.Ispis(k1.ListaKupca());
            k1.MetodaID(k1.ListaKupca());
            k1.NajmladjiKupac(k1.ListaKupca());
            k1.ProveraGodina(k1.ListaKupca());
            k1.OstatakZadatkaUJednoj(k1.ListaKupca());

            #endregion

            Console.WriteLine("\n~~~~~~~~~~~~ZADATAK 2~~~~~~~~~~~~");


            #region MetodeZadatak2
            k1.FluentVsQuery();
            k1.Grupisanje(k1.ListaKupca());
            k1.Ulancavanje();
            #endregion

            Console.ReadLine();
        }



    }
}
