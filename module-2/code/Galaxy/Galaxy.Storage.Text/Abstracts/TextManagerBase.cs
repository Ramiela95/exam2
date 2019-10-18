using Galaxy.Core.BusinessLayers.Utils;
using Galaxy.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Galaxy.Core.BusinessLayers.Common
{
    public abstract class TextManagerBase<TEntity>: IManager<TEntity>
        where TEntity: MonitorableEntityBase
    {
        protected abstract string GetNomeFileDatabase();

        protected abstract string ConvertiEntityInStringa(TEntity entityDaConvertire);

        protected abstract TEntity ConvertSegmentiInEntity(string[] segments);

        protected abstract void RemapNuoviValoriSuEntityInLista(TEntity entitySorgente, TEntity entityDestinazione);

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
            IList<TEntity> tutti = Carica();
            var count = tutti.Count;

            //Prossimo "Id" => count + 1
            var prossimoId = count + 1;

            //Assegnazione Id al nuovo elemento
            entityDaCreare.Id = prossimoId;

            //Aggiungo la data di creazione del record
            entityDaCreare.Timestamp = DateTime.Now;

            string genereStringa = ConvertiEntityInStringa(entityDaCreare);

            AddDataToStorage(genereStringa);
        }

        private void AddDataToStorage(string entityContent) 
        {
            //Aggiungi stringa a file database
            var dbFileName = GetNomeFileDatabase();
            DatabaseUtils.AppendiStringaADatabase(entityContent, dbFileName);
        }

        public void Aggiorna(TEntity entityDaModificare)
        {
            //Validazione dell'input
            if (entityDaModificare == null)
                throw new ArgumentNullException(nameof(entityDaModificare));

            //Se non ho "Id" eccezione
            if (entityDaModificare.Id <= 0)
                throw new InvalidOperationException("Attenzione! L'oggetto " +
                    $"non ha il campo 'Id' valorizzato! Prima crearlo!");

            //Carico tutti in memoria
            IList<TEntity> tuttiIDati = Carica();

            //Scorro elenco generi esistenti
            foreach (var currentGenereInDatabase in tuttiIDati)
            {
                //Se l'id non corrisponde, continuo alla prossima iterazione
                if (currentGenereInDatabase.Id != entityDaModificare.Id)
                    continue;

                //Rimappo tutti i valori specifici sull'oggetto già 
                //presente sulla lista caricata dal database
                RemapNuoviValoriSuEntityInLista(entityDaModificare, currentGenereInDatabase);

                //Cambio i valori dell'oggetto esistente sui campi comuni tra le entità                
                currentGenereInDatabase.Timestamp = entityDaModificare.Timestamp;
                currentGenereInDatabase.UtenteCreatore = entityDaModificare.UtenteCreatore;
            }

            //Arrivato qui abbiamo la lista dati perfettamente aggiornata
            Salva(tuttiIDati);
        }

        public void Cancella(TEntity entityDaCancellare)
        {
            //Validazione dell'input
            if (entityDaCancellare == null)
                throw new ArgumentNullException(nameof(entityDaCancellare));

            //Se non ho "Id" eccezione
            if (entityDaCancellare.Id <= 0)
                throw new InvalidOperationException("Attenzione! L'oggetto " +
                    $"non ha il campo 'Id' valorizzato! Prima crearlo!");

            //Carico elementi da database
            var tutti = Carica();

            //Variabile per elemento da cancellare
            TEntity entityInListDaCancellare = null;

            //Scorro elementi esistenti
            foreach (var currentEntity in tutti)
            {
                //Se l'id non corrisponde, passa al prossimo
                if (currentEntity.Id != entityDaCancellare.Id)
                    continue;

                //Se arrivo qui, ho trovato l'elemento
                entityInListDaCancellare = currentEntity;
                break;
            }

            //Rimuovo da lista
            tutti.Remove(entityInListDaCancellare);

            //Riscrivo la lista sul database
            Salva(tutti);
        }

        public IList<TEntity> Carica() 
        {
            //Recupero tutte le righe
            var dbFileName = GetNomeFileDatabase();
            string[] righeInDatabase = DatabaseUtils
                .LeggiRigheDaDatabase(dbFileName);

            //Predisposizione lista di uscita
            IList<TEntity> listaUscita = new List<TEntity>();

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

        private void Salva(IList<TEntity> tutteLeEntityDaSalvare)
        {
            //Definizione della lista di stringhe
            IList<string> stringhe = new List<string>();

            //Scorro tutte le entità passate come parametro
            foreach (var currentEntity in tutteLeEntityDaSalvare)
            {
                //Conversione a stringa
                var targetString = ConvertiEntityInStringa(currentEntity);

                //Aggiunta della stringa in lista
                stringhe.Add(targetString);
            }

            //Genero il percorso del database
            var dbFile = GetNomeFileDatabase();
            var fileDb = DatabaseUtils
                .GeneraPercorsoFileDatabase(dbFile);

            //Scrivo tutte le righe sul file
            var arrayDiStringhe = stringhe.ToArray();
            File.WriteAllLines(fileDb, arrayDiStringhe);
        }
    }
}
