using Galaxy.Core.BusinessLayers.Common;
using Galaxy.Core.Entities;
using System;

namespace Galaxy.Core.BusinessLayers
{
    public class LibroManager: ManagerBase<Libro>
    {
        const string NomeFileDatabaseLibri = "libri.txt";  

        /// <summary>
        /// Rappresenta la "U" di CRUD
        /// </summary>
        /// <param name="libroDaModificare"></param>
        public void AggiornaLibro(Libro libroDaModificare)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rappresenta la "D" di CRUD
        /// </summary>
        /// <param name="libroDaCancellare"></param>
        public void CancellaLibro(Libro libroDaCancellare)
        {
            throw new NotImplementedException();
        }

        public override string GetNomeFileDatabase()
        {
            return NomeFileDatabaseLibri;
        }

        public override string ConvertiEntityInStringa(Libro entityDaConvertire)
        {
            //segmenti[0] => "Id"
            //segmenti[1] => "Codice"
            //segmenti[2] => "Titolo"
            //segmenti[3] => "Prezzo"
            //segmenti[4] => "Lingua"
            //segmenti[5] => "Autore"
            //segmenti[6] => "Anno"
            //segmenti[7] => "GenereAppartenenza"*
            //segmenti[8] => "Timestamp"
            //segmenti[9] => "UtenteCreatore"

            //Conversione del libro a string
            string libroStringa =
                entityDaConvertire.Id + "|" +
                entityDaConvertire.Codice + "|" +
                entityDaConvertire.Titolo + "|" +
                entityDaConvertire.Prezzo + "|" +
                entityDaConvertire.Lingua + "|" +
                entityDaConvertire.Autore + "|" +
                entityDaConvertire.Anno + "|" +
                entityDaConvertire.GenereAppartenenza.Id + "|" +
                entityDaConvertire.Timestamp + "|" +
                entityDaConvertire.UtenteCreatore;
            return libroStringa;
        }

        public override Libro ConvertSegmentiInEntity(string[] segments)
        {

            var libro = new Libro
            {
                Id = int.Parse(segments[0]),
                Codice = segments[1],
                Titolo = segments[2],
                Prezzo = double.Parse(segments[3]),
                Lingua = segments[4],
                Autore = segments[5],
                Anno = int.Parse(segments[6]),
                GenereAppartenenza = new Genere
                {
                    Id = int.Parse(segments[7])
                },
                Timestamp = DateTime.Parse(segments[8]),
                UtenteCreatore = segments[9],
            };

            //Ritorno l'entità generata
            return libro;
        }
    }
}
