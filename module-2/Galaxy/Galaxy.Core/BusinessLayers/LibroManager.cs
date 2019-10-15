using Galaxy.Core.BusinessLayers.Common;
using Galaxy.Core.Entities;
using System;
using System.Collections.Generic;

namespace Galaxy.Core.BusinessLayers
{
    public class LibroManager: ManagerBase<Libro>
    {
        const string NomeFileDatabaseLibri = "libri.txt";

        protected override string GetNomeFileDatabase()
        {
            return NomeFileDatabaseLibri;
        }

        protected override string ConvertiEntityInStringa(Libro entityDaConvertire)
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

        protected override Libro ConvertSegmentiInEntity(string[] segments)
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

        protected override void RemapNuoviValoriSuEntityInLista(
            Libro entitySorgente, Libro entityDestinazione)
        {
            entityDestinazione.Titolo = entitySorgente.Titolo;
            entityDestinazione.Lingua = entitySorgente.Lingua;
            entityDestinazione.Prezzo = entitySorgente.Prezzo;
            entityDestinazione.Anno = entitySorgente.Anno;
            entityDestinazione.Autore= entitySorgente.Autore;
            entityDestinazione.Codice= entitySorgente.Codice;
            entityDestinazione.GenereAppartenenza = entitySorgente.GenereAppartenenza;

            //Posso fare il remapping anche dei campi comuni, ma è meglio farlo 
            //nella funzione base perchè è in grado di manipolare i campi in questione
            // => entityDestinazione.Timestamp = entitySorgente.Timestamp;
            // => entityDestinazione.UtenteCreatore = entitySorgente.UtenteCreatore;
        }

        public List<Libro> Carica(string testoDaCercareNelTitolo)
        {
            //Uso il metodo base per ottenere tutti i libri
            List<Libro> tuttiILibri = base.Carica();
            List<Libro> libriCorrispondentiAlCriterioDiRicerca = new List<Libro>();

            //Scorro tutti i libri
            foreach (Libro currentLibro in tuttiILibri) 
            {
                //Se il libro corrente contiene nel Titolo il 
                //testo specificato, aggiungo il libro "libriCorrispondentiAlCriterioDiRicerca"

                //Recupero l'indice del testo ricercato nel titolo
                var indiceTesto = currentLibro.Titolo.IndexOf(testoDaCercareNelTitolo);

                //Se l'indice è >= 0
                if (indiceTesto < 0)
                    continue;

                //Aggiungo l'elemento in uscita
                libriCorrispondentiAlCriterioDiRicerca.Add(currentLibro);
            }

            //Ritorno la lista di quelli corrispondenti
            return libriCorrispondentiAlCriterioDiRicerca;
        }
    }
}
