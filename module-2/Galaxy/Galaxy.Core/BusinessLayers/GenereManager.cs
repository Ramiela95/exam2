using Galaxy.Core.BusinessLayers.Utils;
using Galaxy.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Galaxy.Core.BusinessLayers
{
    public class GenereManager
    {
        const string NomeFileDatabaseGeneri = "generi.txt";

        //VINCOLI: 
        //1) il file "database" sarà archivato sotto
        //   AppDomain.CurrentDomain.BaseDirectory + "/data/NomeFileDatabaseGeneri"
        //2) L'id primario del record viene assegnato dal manager
        //   sulla base di una logica del tipo [numero-elementi-esistenti] + 1
        //3) La codifica è basata su un record per ogni riga del file
        //4) Ogni campo è separato da "|"
        
        private void SalvaDati(List<Genere> dati) 
        {
            //Conversione di elementi in stringa
            string[] tutteLeRighe = ConvertiListaGeneriInStringhe(dati);

            //Genero il percorso del database
            var fileDb = DatabaseUtils
                .GeneraPercorsoFileDatabase(NomeFileDatabaseGeneri);

            //Scrivo tutte le righe sul file
            File.WriteAllLines(fileDb, tutteLeRighe);
        }

        private string[] ConvertiListaGeneriInStringhe(List<Genere> dati) 
        {
            //Lista di stringhe
            List<string> tutteLeStringhe = new List<string>();

            //Scorro tutti gli elementi
            foreach(var currentGenere in dati) 
            {
                string stringaCorrente = ConvertiSingoloGenereInStringa(currentGenere);

                //Aggiungo stringa corrente a lista
                tutteLeStringhe.Add(stringaCorrente);
            }

            return tutteLeStringhe.ToArray();
        }

        private string ConvertiSingoloGenereInStringa(Genere genereDaConvertire) 
        {
            //Conversione del genere a string
            string genereStringa =
                genereDaConvertire.Id + "|" +
                genereDaConvertire.Nome + "|" +
                genereDaConvertire.Descrizione + "|" +
                genereDaConvertire.Timestamp + "|" +
                genereDaConvertire.UtenteCreatore + "|";
            return genereStringa;
        }

        #region Funzioni da NON toccare 

        public void CreaGenere(Genere genereDaAggiungere) 
        {
            //Validazione dell'input
            if (genereDaAggiungere == null) 
                throw new ArgumentNullException(nameof(genereDaAggiungere));

            //Se ho già un "Id", eccezione
            if (genereDaAggiungere.Id > 0)
                throw new InvalidOperationException("Attenzione! L'oggetto " + 
                    $"ha già il campo 'Id' impostato al valore {genereDaAggiungere.Id}!");

            //Contiamo quanti record ci sono nel database esistente
            //(ci serve per sapere quale "Id" dare al nuovo elemento
            //=> Carico tutti gli elementi in archivio
            var tutti = CaricaGeneri();
            var count = tutti.Count;

            //Prossimo "Id" => count + 1
            var prossimoId = count + 1;

            //Assegnazione Id al nuovo elemento
            genereDaAggiungere.Id = prossimoId;

            //Aggiungo la data di creazione del record
            genereDaAggiungere.Timestamp = DateTime.Now;

            string genereStringa = ConvertiSingoloGenereInStringa(genereDaAggiungere);

            //Aggiungi stringa a file database
            DatabaseUtils.AppendiStringaADatabase(
                genereStringa, NomeFileDatabaseGeneri);
        }

        public List<Genere> CaricaGeneri()
        {
            //Recupero tutte le righe
            string[] righeInDatabase = DatabaseUtils
                .LeggiRigheDaDatabase(NomeFileDatabaseGeneri);

            //Predisposizione lista di uscita
            List<Genere> listaUscita = new List<Genere>();

            //Itero su tutte le righe
            foreach (string currentRiga in righeInDatabase) 
            {
                //Eseguo uno "split" per carattere "|"
                string[] segmenti = currentRiga.Split(new char[] { '|' });

                //segmenti[0] => "Id"
                //segmenti[1] => "Nome"
                //segmenti[2] => "Descrizione"
                //segmenti[3] => "Timestamp"
                //segmenti[4] => "UtenteCreatore"
                //segmenti[5] => Exception!

                var genere = new Genere
                {
                    Id = int.Parse(segmenti[0]), 
                    Nome = segmenti[1],
                    Descrizione = segmenti[2],
                    Timestamp = DateTime.Parse(segmenti[3]),
                    UtenteCreatore = segmenti[4],
                };

                //Aggiunta dell'oggetto alla lista
                listaUscita.Add(genere);
            }

            //Emettiamo la lista di uscita
            return listaUscita;
        }

        public void AggiornaGenere(Genere genereDaAggiornare)
        {
            //Validazione dell'input
            if (genereDaAggiornare == null)
                throw new ArgumentNullException(nameof(genereDaAggiornare));

            //Se non ho "Id" eccezione
            if (genereDaAggiornare.Id <= 0)
                throw new InvalidOperationException("Attenzione! L'oggetto " +
                    $"non ha il campo 'Id' valorizzato! Prima crearlo!");

            //Carico tutti in memoria
            var tuttiIDati = CaricaGeneri();

            //Scorro elenco generi esistenti
            foreach (var currentGenereInDatabase in tuttiIDati) 
            {
                //Se l'id non corrisponde, continuo alla prossima iterazione
                if (currentGenereInDatabase.Id != genereDaAggiornare.Id)
                    continue;

                //Cambio i valori dell'oggetto esistente
                currentGenereInDatabase.Nome = genereDaAggiornare.Nome;
                currentGenereInDatabase.Descrizione= genereDaAggiornare.Descrizione;
                currentGenereInDatabase.Timestamp= genereDaAggiornare.Timestamp;
                currentGenereInDatabase.UtenteCreatore = genereDaAggiornare.UtenteCreatore;
            }

            //Arrivato qui abbiamo la lista dati perfettamente aggiornata
            SalvaDati(tuttiIDati);
        }

        public void CancellaGenere(Genere genereDaCancellare)
        {
            //Validazione dell'input
            if (genereDaCancellare == null)
                throw new ArgumentNullException(nameof(genereDaCancellare));

            //Se non ho "Id" eccezione
            if (genereDaCancellare.Id <= 0)
                throw new InvalidOperationException("Attenzione! L'oggetto " +
                    $"non ha il campo 'Id' valorizzato! Prima crearlo!");

            //Carico elementi da database
            var tutti = CaricaGeneri();

            //Variabile per elemento da cancellare
            Genere genereInListaDaCancellare = null;

            //Scorro elementi esistenti
            foreach (var currentEntity in tutti) 
            {
                //Se l'id non corrisponde, passa al prossimo
                if (currentEntity.Id != genereDaCancellare.Id)
                    continue;

                //Se arrivo qui, ho trovato l'elemento
                genereInListaDaCancellare = currentEntity;
                break;
            }

            //Rimuovo da lista
            tutti.Remove(genereInListaDaCancellare);

            //Riscrivo la lista sul database
            SalvaDati(tutti);
        }

        #endregion
    }
}
