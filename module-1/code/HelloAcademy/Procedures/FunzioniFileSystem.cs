using HelloAcademy.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace HelloAcademy.Procedures
{
    public static class FunzioniFileSystem
    {
        public static string AssicuratiCheEsistaCartellaDiArchivio() 
        {
            //1) Compongo il percorso della cartella di lavoro
            var workingFolder = AppDomain.CurrentDomain.BaseDirectory;

            const string DataFolderName = "data";

            //Composizone del percorso della folder
            var folderPath = Path.Combine(workingFolder, DataFolderName);

            //Se non esiste, la creo
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            return folderPath;
        }

        private static string ComponiPercorsoFileDatabase(string archiveFolder) 
        {
            const string DataBaseFileName = "database.txt";

            //Composizione del percorso del file database
            string databasePath = Path.Combine(archiveFolder, DataBaseFileName);

            //Ritorno il percorso
            return databasePath;
        }

        internal static void AggiungiTestoAFileDatabase(string testoDiProva, string archiveFolder)
        {
            var databasePath = ComponiPercorsoFileDatabase(archiveFolder);

            //Se il file non esiste, creo il file e aggiungo il testo
            if (!File.Exists(databasePath))
            {
                //Creazione dello stream in Create
                using (StreamWriter writer = File.CreateText(databasePath))
                {
                    writer.WriteLine(testoDiProva);
                    writer.Close();
                }
            }
            else 
            {
                //Creazione dello stream in Append
                using (StreamWriter writer = File.AppendText(databasePath))
                {
                    writer.WriteLine(testoDiProva);
                    writer.Close();
                }
            }
        }


        public static void CreaStrutturaPerConservazioneDati() 
        {
            //1) Compongo il percorso della cartella di lavoro
            var workingFolder = AppDomain.CurrentDomain.BaseDirectory;

            const string DataFolderName = "data";
            const string DataBaseFileName = "database.txt";

            //Composizone del percorso della folder
            var folderPath = Path.Combine(workingFolder, DataFolderName);

            //Se non esiste, la creo
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            //Composizione del percorso del file database
            string databasePath = Path.Combine(folderPath, DataBaseFileName);
            Debug.WriteLine("databasePath:" + databasePath);

            //Se il file NON esiste, lo creo vuoto
            if (!File.Exists(databasePath))
            {
                //Creazione del file 
                using (StreamWriter writer = File.CreateText(databasePath))
                {
                    writer.WriteLine("Questa è una prova di creazione!!!");
                    writer.Close();
                }

            }
            else 
            {
                //Creazione del file 
                using (StreamWriter writer = File.AppendText(databasePath))
                {
                    writer.WriteLine("Questa è una prova di modifica!!!");
                    writer.Close();
                }
            }
        }

        internal static string[] OttieniRigheDaDatabase(string archiveFolder)
        {
            //Ottengo il percorso del file database
            var databasePath = ComponiPercorsoFileDatabase(archiveFolder);

            //Se il file non esiste
            if (!File.Exists(databasePath))
                return new string[0];

            //Predispongo una lista dei dati di uscita
            List<string> datiDiUscita = new List<string>();

            //Tento la lettura
            using (StreamReader reader = File.OpenText(databasePath)) 
            {
                //Variabile per la lettura
                string readLine = null;

                do
                {
                    //Lettura della riga corrente del file
                    readLine = reader.ReadLine();

                    //Aggiungo la riga letta alla lista di uscita
                    //solo se il valore è diverso da null
                    if (readLine != null)
                        datiDiUscita.Add(readLine);
                }
                while (readLine != null);                
            }

            //Ritorno la lista come array
            string[] arrayDiUscita = new string[datiDiUscita.Count];

            //Itero la lista e aggiungo i valori nell'array
            //foreach (string currentElementInList in datiDiUscita) 
            for (int i = 0; i < datiDiUscita.Count; i++)
            {
                arrayDiUscita[i] = datiDiUscita[i];
            }

            //Ritorno l'array richiesto
            return arrayDiUscita;
        }
    }
}
