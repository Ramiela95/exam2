using System;
using System.Collections.Generic;
using System.Text;

namespace HelloAcademy.Utils
{
    public static class ConsoleUtils
    {
        public static int LeggiNumeroInteroDaConsole(int minValue, int maxValue)
        {
            //Leggo il valore stringa da console
            string valoreString = Console.ReadLine();
            int valoreIntero = 0;

            //Predisposizione al fallimento
            bool isInteger = false;
            bool isInRange = false;

            do
            {
                try
                {
                    //Validazione e parsing del valore
                    valoreIntero = int.Parse(valoreString);
                    isInteger = true;

                    //Verifico se è nel range
                    if (valoreIntero >= minValue && valoreIntero <= maxValue)
                    {
                        //imposto il flag IsInRange
                        isInRange = true;
                    }
                }
                catch (Exception exc)
                {
                    //Messaggio di errore
                    Console.WriteLine("Attenzione! Il valore immesso non è valido!");
                    Console.Write("Inseriscilo di nuovo: ");

                    //RIchiesta nuovo valore
                    valoreString = Console.ReadLine();

                    //Ripristino condizioni di predisposizione fallimento iniziali
                    valoreIntero = 0;
                    isInteger = false;
                    isInRange = false;
                }
            }
            while (isInteger == false || isInRange == false);

            //Ritorno il valore intero
            return valoreIntero;
        }

        public static void ConfermaUscita()
        {
            Console.Write("Premi un pulsante per uscire");
            Console.ReadKey();
        }
    }
}
