using Galaxy.Terminal.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Galaxy.Terminal.Structures
{
    public class FileSystemHandler
    {
        public event EventHandler<FileInfo> FileWithSecondExtensionFound;


        /// <summary>
        /// Esegue la stampa a schermo di tutte le 
        /// </summary>
        /// <param name="basePath"></param>
        public void ListAllFilesWithProvidedExtension(
            string basePath, string searchExtension, string secondExtension = null)
        {
            //Validazione degli input
            if (string.IsNullOrEmpty(basePath))
                throw new ArgumentNullException(nameof(basePath));
            if (string.IsNullOrEmpty(searchExtension))
                throw new ArgumentNullException(nameof(searchExtension));

            DirectoryInfo dirInfo = new DirectoryInfo(basePath);

            //1) Elenco tutti i files presenti nella cartella "basePath"
            ConsoleUtils.WriteColorLine(ConsoleColor.Yellow, $"Ricerca in folder '{dirInfo.FullName}'...");
            IEnumerable<FileInfo> filesInCartella = dirInfo.EnumerateFiles();

            //1-BIS) Enumero tutti i files nella cartella
            foreach (FileInfo currentFileInfo in filesInCartella)
            {
                //2) I files che non terminano con l'estensione richiesta, li scarto
                //Repero l'estensione del file corrente
                int dotIndex = currentFileInfo.Name.LastIndexOf(".");

                //Se non trovo il punto, continuo
                if (dotIndex < 0)
                    continue;

                //Taglio la parte successiva al punto
                string currentFileExtension = currentFileInfo.Name.Substring(dotIndex + 1);

                //Se l'estensione è uguale a quella specificata, stampo
                if (currentFileExtension == searchExtension)
                {
                    //3) Stampo a video (Console.WriteLine(...)) i percorso del file 
                    //con l'estensione desiderata
                    ConsoleUtils.WriteColorLine(ConsoleColor.Green, $" => {currentFileInfo.FullName}");
                }
                else
                {
                    //Se è gestito la seconda estensione di ricerca
                    if (secondExtension != null)
                    {
                        //Se il file corrisponde alla ricerca
                        if (currentFileExtension == secondExtension)
                        {
                            //Se l'evento è gestito
                            if (FileWithSecondExtensionFound != null) 
                            {
                                //Sollevo l'evento passando i fileInfo trovato
                                FileWithSecondExtensionFound(this, currentFileInfo);
                            }                            
                        }
                    }
                }
            }

            //4) Elenco le sotto-cartelle presenti nella folder corrente
            IEnumerable<DirectoryInfo> subDirsInFolder = dirInfo.EnumerateDirectories();

            //5) Per ciascuna cartella applico la stessa funzione
            foreach (DirectoryInfo currentSubDirectory in subDirsInFolder)
            {
                //Applico la funzione ricorsivamente
                ListAllFilesWithProvidedExtension(currentSubDirectory.FullName, searchExtension, secondExtension);
            }

            //6) Fine
        }

    }
}
