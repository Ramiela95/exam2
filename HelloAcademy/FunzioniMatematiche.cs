using System;
using System.Collections.Generic;
using System.Text;

namespace HelloAcademy
{
    public static class FunzioniMatematiche
    {
        public static void RecuperaDivisioneEDividendoEDividi()
        {
            //Raccolta da input dei due numeri da dividere
            Console.Write("Inserisci il primo numero: ");
            string firstElementToDivide = Console.ReadLine();
            Console.Write("Inserisci il secondo numero: ");
            string secondElementToDivide = Console.ReadLine();

            //Conversione dei due numeri letti in interi
            int firstAsInteger;
            int secondAsInteger;
            firstAsInteger = int.Parse(firstElementToDivide);
            secondAsInteger = int.Parse(secondElementToDivide);

            //Controllo se è stato immesso 0 come divisore
            if (secondAsInteger == 0)
            {
                //Se è stato immesso 0, messaggio di errore e uscita
                Console.WriteLine("Attenzione! Non puoi mettere 0 come divisore");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }
            else
            {
                //Se i numeri sono validi, eseguo divisione

                //1) Istanzio la calcolatrice
                Calculator istanza = new Calculator();

                //2) RIchiamo il metodo di divisione
                double risultatoDivisione;
                risultatoDivisione = istanza.Divide(firstAsInteger, secondAsInteger);

                //Mostro risultato a video
                Console.WriteLine("Il risultato è :" + risultatoDivisione);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

        }
    }
}
