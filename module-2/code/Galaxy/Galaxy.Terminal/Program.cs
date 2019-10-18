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
            Console.WriteLine("* 1 -Lavora su catalogo biciclette ");
            Console.WriteLine("* 2 -Lavora su catalogo machhine");
            
            var selezione = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 2);

            //Selezione dell'opzione
            switch (selezione) 
            {
                case 1:
                    LaunchBusinessLayerMenu.Summary();
                    break;
                case 2:
                    LibriWorkflow.EseguiCreaModificaCancella();
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
