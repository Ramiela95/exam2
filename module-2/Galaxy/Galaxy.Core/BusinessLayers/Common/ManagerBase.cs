using Galaxy.Core.BusinessLayers.Utils;
using Galaxy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Core.BusinessLayers.Common
{
    public abstract class ManagerBase<TEntity>
        where TEntity: EntitaMonitorabile
    {
        public abstract string GetNomeFileDatabase();

        public abstract string ConvertiEntityInStringa(TEntity entityDaConvertire);

        public void Crea(TEntity entityDaCreare) 
        {
            //Validazione dell'input
            if (entityDaCreare == null)
                throw new ArgumentNullException(nameof(entityDaCreare));

            //Se ho già un "Id", eccezione
            if (entityDaCreare.Id > 0)
                throw new InvalidOperationException("Attenzione! L'oggetto " +
                    $"ha già il campo 'Id' impostato al valore {entityDaCreare.Id}!");

            //Contiamo quanti record ci sono nel database esistente
            //(ci serve per sapere quale "Id" dare al nuovo elemento
            //=> Carico tutti gli elementi in archivio
            List<TEntity> tutti = Carica();
            var count = tutti.Count;

            //Prossimo "Id" => count + 1
            var prossimoId = count + 1;

            //Assegnazione Id al nuovo elemento
            entityDaCreare.Id = prossimoId;

            //Aggiungo la data di creazione del record
            entityDaCreare.Timestamp = DateTime.Now;

            string genereStringa = ConvertiEntityInStringa(entityDaCreare);

            //Aggiungi stringa a file database
            var dbFileName = GetNomeFileDatabase();
            DatabaseUtils.AppendiStringaADatabase(genereStringa, dbFileName);
        }

        

        public void Aggiorna(TEntity entityDaModificare)
        {
        }

        public void Cancella(TEntity entityDaCancellare)
        {
        }

        public List<TEntity> Carica() 
        {
            //Recupero tutte le righe
            var dbFileName = GetNomeFileDatabase();
            string[] righeInDatabase = DatabaseUtils
                .LeggiRigheDaDatabase(dbFileName);

            //Predisposizione lista di uscita
            List<TEntity> listaUscita = new List<TEntity>();

            //Itero su tutte le righe
            foreach (string currentRiga in righeInDatabase)
            {
                //Eseguo uno "split" per carattere "|"
                string[] segmenti = currentRiga.Split(new char[] { '|' });

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

                TEntity entityGenerataDaStringa = ConvertSegmentiInEntity(segmenti);

                //Aggiunta dell'oggetto alla lista
                listaUscita.Add(entityGenerataDaStringa);
            }

            //Emettiamo la lista di uscita
            return listaUscita;
        }

        public abstract TEntity ConvertSegmentiInEntity(string[] segments);
    }
}
