using System;

namespace Galaxy.Terminal.Utils
{
    public static class ConsoleUtils
    {
        public static int LeggiNumeroInteroDaConsole(int minValue, int maxValue)
        {
            //Leggo il valore stringa da console
            string valoreString;
            int valoreIntero = 0;

            //Predisposizione al fallimento
            bool isInteger = false;
            bool isInRange = false;

            do
            {
                try
                {
                    //Eseguo la lettura del valore da console
                    Console.Write("- selezione: ");
                    valoreString = Console.ReadLine();

                    //Validazione e parsing del valore
                    valoreIntero = int.Parse(valoreString);
                    isInteger = true;

                    //Verifico se è nel range
                    if (valoreIntero >= minValue && valoreIntero <= maxValue)
                    {
                        //imposto il flag IsInRange
                        isInRange = true;
                    }
                    else 
                    {
                        //Messaggio di errore
                        Console.WriteLine("Attenzione! Il valore immesso non è nel range indicato");

                        //Ripristino condizioni di predisposizione fallimento iniziali
                        valoreIntero = 0;
                        isInteger = false;
                        isInRange = false;
                    }
                }
                catch (Exception exc)
                {
                    //Messaggio di errore
                    Console.WriteLine("Attenzione! Il valore immesso NON è un numero!");
                    
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

        /// <summary>
        /// Esegue la lettura di standard input (console)
        /// di un valore e tenta di eseguire la conversione
        /// nel tipo specificato come generico
        /// </summary>
        /// <typeparam name="TOutput">Tipo a cui convertire</typeparam>
        /// <returns>Ritorna il valore convertito</returns>
        public static TOutput ReadLine<TOutput>(Func<TOutput, bool> acceptanceCondition)
        {
            //Predisposizione valori            
            TOutput valoreConvertito = default(TOutput);
            bool isValidCast = false;
            bool isAccepted = false;

            //Se il valore NON è stato correttamente covertito OPPURE
            //la condizione NON è stata accettata, eseguo il ciclo
            while (!isValidCast || !isAccepted) 
            {
                //Try perchè il cast potrebbe fallire
                try
                {
                    //Lettura da console
                    string valueFromConsole = Console.ReadLine();

                    //Tento il casting forzato
                    valoreConvertito = (TOutput)Convert
                        .ChangeType(valueFromConsole, typeof(TOutput));

                    //Il cast è andato bene
                    isValidCast = true;

                    //Verifico la condizione di accettazione
                    isAccepted = acceptanceCondition(valoreConvertito);

                    //La condizione è stata accetta o meno
                    if (!isAccepted) 
                    {
                        //Mostro un messaggio utente con l'errore di parsing
                        WriteColorLine(ConsoleColor.Yellow, "Condizione non valida. Riprova: ");
                    }
                }
                catch (Exception exc)
                {
                    //Mostro un messaggio utente con l'errore di parsing
                    WriteColorLine(ConsoleColor.Yellow, "Selezione non valida. Riprova: ");

                    //Il cast non è valido
                    isValidCast = false;
                }
            }

            //Se arrivo qui, il casting ok, ed esco
            return valoreConvertito;
        }

        public static void ConfermaUscita()
        {
            Console.Write("Premi un pulsante per uscire");
            Console.ReadKey();
        }

        public static void WriteColorLine(ConsoleColor color, string message) 
        {
            WriteColorBase(color, message,
                s => Console.WriteLine(s)
            );
        }

        public static void WriteColor(ConsoleColor color, string message)
        {
            WriteColorBase(color, message,
                s => Console.Write(s)
            );
        }

        private static void WriteColorBase(ConsoleColor color, string message,
            Action<string> actionToExecute)
        {
            //Salvo il vecchio colore (quello di default)
            var vecchioColore = Console.ForegroundColor;

            //Impostiamo il nuovo colore della console per la scrittura
            Console.ForegroundColor = color;

            //Lanciamo la funzione delegata (Lambda Expression)
            actionToExecute(message);

            //Reimpostiamo il vecchio colore
            Console.ForegroundColor = vecchioColore;
        }
    }
}
