using Galaxy.Terminal.Structures;
using Galaxy.Terminal.Utils;
using System;
using System.Collections.Generic;
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
            Console.WriteLine("* 2 - Demo Memory leak");
            Console.WriteLine("* 3 - Demo matrice");
            Console.WriteLine("* 4 - Demo dizionario");

            //Recupero della selezione
            var selezione = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 4);

            //Avvio della procedura
            switch (selezione) 
            {
                //********************************************************
                case 1:
                    LaunchRecursionDemo();
                    break;

                //********************************************************
                case 2:
                    GenerateMemoryLeak();
                    break;

                //********************************************************
                case 3:
                    DemoMatrice();
                    break;

                //********************************************************
                case 4:
                    DemoDizionario();
                    break;

                //********************************************************
                default:
                    Console.WriteLine("Selezione non valida");
                    break;
            }
        }

        private static void DemoDizionario() 
        {
            IDictionary<string, int> dizionario = new Dictionary<string, int>();
            dizionario.Add("Uno", 1);
            dizionario.Add("Due", 2);
            dizionario.Add("Tre", 3);
            //dizionario.Add("Tre", 4); => ERRORE (chiave già esistente!)

            int uno = dizionario["Uno"];
            int due = dizionario["Due"];
            int tre = dizionario["Tre"];
        }

        private static void DemoMatrice() 
        {
            int[] arrayDiInteri = new int[3];
            arrayDiInteri[0] = 33;
            arrayDiInteri[1] = 22;
            arrayDiInteri[2] = 11;

            int[][] matriceDiInteri = new int[3][];
            matriceDiInteri[0] = new int[8];
            matriceDiInteri[1] = new int[5];
            matriceDiInteri[2] = new int[3];

            matriceDiInteri[0][0] = 12;
            matriceDiInteri[0][1] = 100;
            matriceDiInteri[0][2] = 5000;
            matriceDiInteri[0][0] = 17;
            matriceDiInteri[0][1] = 90;
            matriceDiInteri[0][2] = 4000;

            int[,] matriceTridimensionale = new int[2, 2];
            matriceTridimensionale[0, 0] = 0; 
            matriceTridimensionale[0, 1] = 1;
            matriceTridimensionale[1, 0] = 2;
            matriceTridimensionale[1, 1] = 2;
            /// ==> matriceTridimensionale[3, 0] = 2; //ERRORE

            DatiAutomobile[] arrayDiDatiAuto = new DatiAutomobile[2];

            //arrayDiDatiAuto[0].Speed = 12;
            //arrayDiDatiAuto[0].HorsePower = 100;
            //arrayDiDatiAuto[0].EngineRotation = 5000;
            //arrayDiDatiAuto[1].Speed = 17;
            //arrayDiDatiAuto[1].HorsePower = 90;
            //arrayDiDatiAuto[1].EngineRotation = 5400;
        }

        private class DatiAutomobile 
        {
            public int Speed { get; set; }
            public int HorsePower { get; set; }
            public int EngineRotation { get; set; }
        }

        private static void GenerateMemoryLeak() 
        {
            //Totake oggetti creati
            IList<FileSystemHandler> collezione = new List<FileSystemHandler>();
            long totalCreatedObjects = 0;

            while (true) 
            {
                //Inizializzo un oggetto
                FileSystemHandler handler = new FileSystemHandler();
                totalCreatedObjects++;

                handler.FileWithSecondExtensionFound += Handler_FileWithSecondExtensionFound;

                //Aggiunta a lista
                //collezione.Add(handler);

                //Ogni 1000 elementi scrivo
                if (totalCreatedObjects % 1000 == 0)
                    Console.WriteLine($"Creati {totalCreatedObjects} elementi...");
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
