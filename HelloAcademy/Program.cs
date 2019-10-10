using HelloAcademy.Utils;
using System;

namespace HelloAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            // => "HelloAcademy publish test"
            //args[0] = "publish"
            //args[1] = "test"

            //1) Parte il programma

            //2) Mostrare un menu utente
            Console.WriteLine("**************************");
            Console.WriteLine("*** HELLO ACADEMY MENU ***");
            Console.WriteLine("**************************");
            Console.WriteLine("");
            Console.WriteLine("* 1 - Divisione");
            Console.WriteLine("* 2 - Rubrica semplice");
            Console.WriteLine("* 3 - Rubrica complessa");
            Console.WriteLine("* 0 - Exit");
            Console.Write("* Selezione: ");
            var selezione = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 3);

            //Selezione della funzione da avviare
            switch (selezione) 
            {
                case 1:
                    FunzioniMatematiche.RecuperaDivisioneEDividendoEDividi();
                    break;
                case 2:
                    FunzioniRubrica.InserisciPersoneEMostraRubrica();
                    break;
                case 3:
                    FunzioniRubrica.InserisciNumeroArbitrarioPersoneInRubrica();
                    break;
                case 0:
                    Console.WriteLine("Uscita....");
                    break;
                default:
                    Console.WriteLine("Selezione non valida");
                    break;
            }

            //3) Se premo 1, parte "RecuperaDivisioneEDividendoEDividi"

            //4) Se premo 2, parte "InserisciPersoneEMostraRubrica"

            //5) Se premo 3, parte "InserisciNumeroArbitrarioPersoneInRubrica"


            //FunzioniMatematiche.RecuperaDivisioneEDividendoEDividi();

            //FunzioniRubrica.InserisciPersoneEMostraRubrica();

            //FunzioniRubrica.InserisciNumeroArbitrarioPersoneInRubrica();

        }
    }    
}
