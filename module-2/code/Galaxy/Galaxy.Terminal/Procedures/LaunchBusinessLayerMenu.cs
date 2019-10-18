using Galaxy.Core.BusinessLayers;
using Galaxy.Core.BusinessLayers.Common;
using Galaxy.Core.BusinessLayers.JsonProvider;
using Galaxy.Core.Entities;
using Galaxy.Core.Managers.Providers.Enum;

using Galaxy.Terminal.SampleVehicle;
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
            Console.WriteLine("* 1 - Crea bicicletta");

            //Recupero della selezione
            var selezione = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 1);

            //Avvio della procedura
            switch (selezione)
            {
                //********************************************************
                case 1:
                    CreaBicicletta();
                    break;

                //********************************************************
                default:
                    Console.WriteLine("Selezione non valida");
                    break;
            }
        }

        private static void CreaBicicletta()
        {
            //Richiedo all'utente il tipo di provider dati
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Provider storage(Json,Text,Sql):");
            string storageTypeAsString = ConsoleUtils.ReadLine<string>(e => e == "Sql" || e == "Json" || e == "Text");
            StorageType storageType = Enum.Parse<StorageType>(storageTypeAsString);

            //Richiediamo i dati da console
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Modello:");
            string modello = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Marca:");
            string marca = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "NumeroTelaio:");
            int numeroTelaio = ConsoleUtils.ReadLine<int>(a => a > 0);
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "IsElettrica:");
            bool isElettrica = ConsoleUtils.ReadLine<bool>(a => a == true || a == false);


            IManager<Libro> libroManager;
            IManager<Genere> genereManager;
            IManager<Bicicletta> biciclettaManager = new JsonBiciclettaManager();


            //Switch sul tipo di storage
            switch (storageType)
            {
                case StorageType.Json:
                    genereManager = new JsonGenereManager();
                    libroManager = new JsonLibroManager();
                    biciclettaManager = new JsonBiciclettaManager();
                    break;
                case StorageType.Text:
                    genereManager = new TextGenereManager();
                    libroManager = new TextLibroManager();

                    break;
                default:
                    throw new NotSupportedException($"Il provider {storageType} non è supportato");
            }

            //Istanzio il business layer (che il cervello della 
            //nostra applicazione)
            MainBusinessLayer layer = new MainBusinessLayer(genereManager, libroManager, biciclettaManager);

            //Avvio la funzione di creazione
            string[] messaggiDiErrore = layer.CreaLibroESuoGenereSeNonEsiste(
                modello, marca, numeroTelaio, isElettrica);

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
