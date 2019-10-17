using Galaxy.Core.BusinessLayers;
using Galaxy.Core.Managers.Providers.Enum;
using Galaxy.Terminal.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Terminal.Procedures
{
    public static class LaunchBusinessLayerMenu
    {
        public static void Summary() 
        {
            //Menu
            Console.WriteLine("***********************");
            Console.WriteLine("* Business Layer Menu *");
            Console.WriteLine("***********************");
            Console.WriteLine("* 1 - Crea libro (complessa)");

            //Recupero della selezione
            var selezione = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 1);

            //Avvio della procedura
            switch (selezione)
            {
                //********************************************************
                case 1:
                    CreaLibroComplessa();
                    break;

                //********************************************************
                default:
                    Console.WriteLine("Selezione non valida");
                    break;
            }
        }

        private static void CreaLibroComplessa()
        {
            //Richiedo all'utente il tipo di provider dati
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Provider storage(Json,Text,Sql):");
            string storageTypeAsString = ConsoleUtils.ReadLine<string>(e => e == "Sql" || e == "Json" || e == "Text");
            StorageType storageType = Enum.Parse<StorageType>(storageTypeAsString);

            //Richiediamo i dati da console
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Titolo:");
            string titolo = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Codice:");
            string codice = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Autore:");
            string autore = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Anno:");
            int anno = ConsoleUtils.ReadLine<int>(a => a > 0);
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Prezzo:");
            double prezzo = ConsoleUtils.ReadLine<double>(p => p > 0);
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Genere:");
            string genere = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));

            

            //Istanzio il business layer (che il cervello della 
            //nostra applicazione)
            MainBusinessLayer layer = new MainBusinessLayer(storageType);

            //Avvio la funzione di creazione
            string[] messaggiDiErrore = layer.CreaLibroESuoGenereSeNonEsiste(
                titolo, codice, autore, prezzo, anno, genere);

            //Se non ho messaggi di errore, confermo
            if (messaggiDiErrore.Length == 0)
                ConsoleUtils.WriteColorLine(ConsoleColor.Green, "TUTTOBBBENE!!!");
            else 
            {
                //Messaggio di errore generale
                ConsoleUtils.WriteColorLine(ConsoleColor.Yellow,
                    "Attenzione! Ci sono errori nella creazione!");

                //Scorriamo gli errori e li mostriamo all'utente
                foreach (var currentMessage in messaggiDiErrore)
                    ConsoleUtils.WriteColorLine(ConsoleColor.Yellow, currentMessage);
            }

        }
    }
}
