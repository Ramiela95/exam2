using Galaxy.Terminal.Procedures;
using Galaxy.Terminal.Utils;
using System;

namespace Galaxy.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Visualizzo menu e richiedo selezione
            Console.WriteLine("*******************************");
            Console.WriteLine("* MENU                        *");
            Console.WriteLine("*******************************");
            Console.WriteLine("* 1 - Esegui CRUD Genere");
            Console.WriteLine("* 2 - Esegui CRUD Libro");
            Console.WriteLine("* 3 - Esegui CRUD Utenti");
            Console.WriteLine("* 4 - Procedure ricorsive");
            Console.WriteLine("* 5 - Business Layer Menu");
            var selezione = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 5);

            //Selezione dell'opzione
            switch (selezione) 
            {
                case 1:
                    GeneriWorkflow.EseguiCreaModificaCancella();
                    break;
                case 2:
                    LibriWorkflow.EseguiCreaModificaCancella();
                    break;
                case 4:
                    RecursiveProcedures.Summary();
                    break;
                case 5:
                    LaunchBusinessLayerMenu.Summary();
                    break;
                default:
                    Console.WriteLine("Opzione non valida!");
                    break;
            }

            //Richiedo conferma di uscita
            ConsoleUtils.ConfermaUscita();
        }
    }
}
