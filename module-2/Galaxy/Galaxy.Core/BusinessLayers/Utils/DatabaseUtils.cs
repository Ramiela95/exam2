using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Galaxy.Core.BusinessLayers.Utils
{
    public static class DatabaseUtils
    {
        const string NomeCartella = "data";
        const string NomeFile = "generi.txt";

        public static void AppendiStringaADatabase(string stringaDaAppendere)
        {
            //Genero il percorso del database
            var fileDb = GeneraPercorsoFileDatabase();

            //Aggiunta della stringa
            File.AppendAllLines(fileDb,
                new string[] { stringaDaAppendere });
        }

        public static string GeneraPercorsoFileDatabase()
        {
            //Percorso cartella + "NomeFile"
            var cartella = GeneraPercorsoCartellaArchivioSeNonEsiste();
            var databaseFile = Path.Combine(cartella, NomeFile);
            return databaseFile;
        }

        private static string GeneraPercorsoCartellaArchivioSeNonEsiste()
        {
            //Composizione percorso cartella
            var folderPath = AppDomain.CurrentDomain.BaseDirectory;
            folderPath = Path.Combine(folderPath, NomeCartella);

            //Se la cartella non esiste, crea
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            //Ritorno il percorso che esiste sicuramente
            return folderPath;
        }

        public static string[] LeggiRigheDaDatabase()
        {
            //Genero il percorso del database
            var fileDb = GeneraPercorsoFileDatabase();

            //Se il file non esiste, esco con array vuoto
            if (!File.Exists(fileDb))
                return new string[0];

            //Lettura del contenuto
            string[] tutteLeRighe = File.ReadAllLines(fileDb);
            return tutteLeRighe;
        }
    }
}
