using Galaxy.Terminal.Structures;
using Galaxy.Terminal.Utils;
using System;
using System.IO;

namespace Galaxy.Terminal.Procedures
{
    public static class RecursiveProcedures
    {
        public static void Summary() 
        {
            //Menu
            Console.WriteLine("******************************");
            Console.WriteLine("* Recursive procedures demos *");
            Console.WriteLine("******************************");
            Console.WriteLine("* 1 - Demo ricorsione");

            //Recupero della selezione
            var selezione = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 1);

            //Avvio della procedura
            switch (selezione) 
            {
                //********************************************************
                case 1:
                    LaunchRecursionDemo();
                    break;

                //********************************************************
                default:
                    Console.WriteLine("Selezione non valida");
                    break;
            }
        }

        private static void LaunchRecursionDemo() 
        {
            //Inserire il percorso di partenza
            Console.Write("Percorso base da cui partire per la ricerca dei file: ");
            string basePath = Console.ReadLine();
            Console.Write("Estensione dei file da cercare (es. 'cs'): ");
            string extension = Console.ReadLine();
            Console.Write("Seconda estensione dei file da cercare (es. 'csproj'): ");
            string secondExtension = Console.ReadLine();

            //Creo istanza di FileSystemHandler
            FileSystemHandler handler = new FileSystemHandler();

            //Evento da gestire
            // - "+=" è l'aggiunta della gestione dell'evento
            // - dopo il "+=" c'è il DELEGATO
            handler.FileWithSecondExtensionFound += Handler_FileWithSecondExtensionFound;

            //Evento di inizio ricerca in directory
            handler.SearchInDirectoryStarted += Handler_SearchInDirectoryStarted;

            //Avvio la procedura sul percorso base
            handler.ListAllFilesWithProvidedExtension(
                basePath, new string[] { extension, secondExtension });
        }

        private static void Handler_SearchInDirectoryStarted(object sender, DirectoryInfo e)
        {
            //1) Elenco tutti i files presenti nella cartella "basePath"
            ConsoleUtils.WriteColorLine(ConsoleColor.Yellow, 
                $"Ricerca in folder '{e.FullName}'...");
        }

        private static void Handler_FileWithSecondExtensionFound(object sender, FileInfo e)
        {
            //Se l'estensione del file è "cs", stampo a console
            if (e.Extension == ".cs")
            {
                //Scrittura a console in verde
                ConsoleUtils.WriteColorLine(ConsoleColor.Green, $" => {e.Name}");
            }
            else 
            {
                //Apro il file di testo, aggiungo il percorso
                File.AppendAllLines("E:\\prova.txt", new string[] { e.FullName });
            }
        }
    }
}
