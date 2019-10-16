using System;
using System.Collections.Generic;
using System.IO;

namespace Galaxy.Terminal.Structures
{
    public class FileSystemHandler
    {
        public event EventHandler<FileInfo> FileWithSecondExtensionFound;

        public event EventHandler<DirectoryInfo> SearchInDirectoryStarted;

        /// <summary>
        /// Esegue la stampa a schermo di tutte le 
        /// </summary>
        /// <param name="basePath"></param>
        public void ListAllFilesWithProvidedExtension(string basePath, string[] searchExtensions)
        {
            //Validazione degli input
            if (string.IsNullOrEmpty(basePath))
                throw new ArgumentNullException(nameof(basePath));
            if (searchExtensions == null)
                throw new ArgumentNullException(nameof(searchExtensions));

            //Istanza delle info della directory
            DirectoryInfo dirInfo = new DirectoryInfo(basePath);

            //Se è gestito l'evento di segnalazione inizio ricerca in una directory
            SearchInDirectoryStarted?.Invoke(this, dirInfo);

            //Ricerca dei files nella directory
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

                //Iterazione su tutte le estensioni ricercate
                foreach (var currentSearchedExtension in searchExtensions) 
                {
                    //Se non è quella ricercata, continuo
                    if (currentFileExtension != currentSearchedExtension)
                        continue;

                    //Se arrivo qui, è una estensione cercata

                    //Se l'evento non è gestito, esco
                    if (FileWithSecondExtensionFound == null)
                        continue;

                    //Sollevo l'evento passando i fileInfo trovato
                    FileWithSecondExtensionFound(this, currentFileInfo);
                }
            }

            //4) Elenco le sotto-cartelle presenti nella folder corrente
            IEnumerable<DirectoryInfo> subDirsInFolder = dirInfo.EnumerateDirectories();

            //5) Per ciascuna cartella applico la stessa funzione
            foreach (DirectoryInfo currentSubDirectory in subDirsInFolder)
            {
                //Applico la funzione ricorsivamente
                ListAllFilesWithProvidedExtension(
                    currentSubDirectory.FullName, searchExtensions);
            }

            //6) Fine
        }
    }
}
