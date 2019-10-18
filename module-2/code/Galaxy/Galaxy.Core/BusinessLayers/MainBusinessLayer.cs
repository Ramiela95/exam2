using Galaxy.Core.BusinessLayers.Common;
using Galaxy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy.Core.BusinessLayers
{
    /// <summary>
    /// Classe che contiene il flusso funzionale di Galaxy
    /// </summary>
    public class MainBusinessLayer
    {
        #region Private fields
        private IManager<Genere> _GenereManager;
        private IManager<Libro> _LibroManager;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="genereMan">Istanza Genere manager</param>
        /// <param name="libroMan">Istanza Libro manager</param>
        public MainBusinessLayer(IManager<Genere> genereMan, IManager<Libro> libroMan) 
        {
            _GenereManager = genereMan;
            _LibroManager = libroMan;
        }

        /// <summary>
        /// Esegue la creazione di un libro usando le informazioni
        /// passate (e validandole) e del genere associato se
        /// il genere non è già presente nel sistema
        /// </summary>
        /// <param name="titolo">Titolo del libro</param>
        /// <param name="codice">Codice del libro</param>
        /// <param name="autore">Autore</param>
        /// <param name="prezzo">Prezzo (maggiore di 0)</param>
        /// <param name="anno">Anno (1000-now)</param>
        /// <param name="nomeGenere">Nome del genere</param>
        /// <returns>Ritorna una lista di validazioni fallite</returns>
        public string[] CreaLibroESuoGenereSeNonEsiste(
            string titolo, string codice, string autore, 
            double prezzo, int anno, string nomeGenere)
        {
            //1) Validazione degli input
            if (string.IsNullOrEmpty(titolo))
                throw new ArgumentNullException(nameof(titolo));
            if (string.IsNullOrEmpty(codice))
                throw new ArgumentNullException(nameof(codice));
            if (string.IsNullOrEmpty(autore))
                throw new ArgumentNullException(nameof(autore));
            if (string.IsNullOrEmpty(nomeGenere))
                throw new ArgumentNullException(nameof(nomeGenere));
            if (prezzo <= 0)
                throw new ArgumentOutOfRangeException(nameof(prezzo));
            if (anno <= 0)
                throw new ArgumentOutOfRangeException(nameof(anno));

            //Predisposizione messaggi di uscita
            IList<string> messaggi = new List<string>();

            //2)  Verifico che l'anno sia tra 1000 e oggi
            if (anno < 1000 || anno > DateTime.Now.Year)
            {
                //Aggiungo il messaggio di errore, ed esco
                messaggi.Add($"L'anno deve essere compreso tra 1000 e {DateTime.Now.Year}");
                return messaggi.ToArray();
            }

            //3)  Verifico che il prezzo sia > 1
            if (prezzo < 1)
            {
                //Aggiungo il messaggio di errore, ed esco
                messaggi.Add($"Il prezzo deve essere almeno 1 euro");
                return messaggi.ToArray();
            }

            //4) Verifico che il codice non sia già usato
            Libro libroConStessoCodice = GetLibroByCodice(codice);
            if (libroConStessoCodice != null)
            {
                //Aggiungo il messaggio di errore, ed esco
                messaggi.Add($"Esiste già un libro con il " + 
                    $"codice '{codice}' (ha l'id {libroConStessoCodice.Id})");
                return messaggi.ToArray();
            }

            //5) Ricerco il genere in archivio
            Genere existingGenere = 
                GetGenereByNome(nomeGenere) 
                ?? CreateGenereWithName(nomeGenere);

            //7) Creo l'oggetto con tutti i dati
            Libro nuovoLibro = new Libro
            {
                Titolo = titolo,
                Autore = autore,
                Codice = codice,
                Anno = anno,
                Prezzo = prezzo,
                Lingua = "Italiano",
                GenereAppartenenza = existingGenere
            };

            //Aggiungo il libro
            _LibroManager.Crea(nuovoLibro);

            //8) Ritorno in uscita le validazioni (vuote se non ho errori)
            return messaggi.ToArray();
        }

        /// <summary>
        /// Esegue la creazione di un genere con il nome indicato
        /// </summary>
        /// <param name="nomeGenere">Nome del genere</param>
        /// <returns>Ritorna il genere creato</returns>
        private Genere CreateGenereWithName(string nomeGenere)
        {
            //Creo oggetto genere con nome
            Genere nuovoGenere = new Genere
            {
                Nome = nomeGenere,
                Descrizione = "no description"
            };

            //Creo il genere
            // => Qui "Id" = 0
            _GenereManager.Crea(nuovoGenere);

            //Ritorno il genere creato
            return nuovoGenere;
        }

        /// <summary>
        /// Recupera un libro usando il codice
        /// </summary>
        /// <param name="codice">Codice del libro</param>
        /// <returns>Ritorna il libro o null</returns>
        public Libro GetLibroByCodice(string codice)
        {
            //4-2) Carico tutti i libri
            IList<Libro> libri = _LibroManager.Carica();

            //4-3) Verifico che esista un libro con codice specificato
            Libro libroConStessoCodice = libri
                .SingleOrDefault(l => l.Codice == codice);
            return libroConStessoCodice;
        }

        /// <summary>
        /// Recupera un genere usando il nome
        /// </summary>
        /// <param name="nome">Nome del genere</param>
        /// <returns>Ritorna un genere o null</returns>
        public Genere GetGenereByNome(string nome)
        {
            //4-2) Carico tutti i generi
            IList<Genere> generi = _GenereManager.Carica();

            //4-3) Verifico se esiste un genere con il nome
            Genere genereConNomeIndicato = generi
                .SingleOrDefault(l => l.Nome == nome);
            return genereConNomeIndicato;
        }

        /// <summary>
        /// Distruttore (rilascia le risorse locali)
        /// </summary>
        ~MainBusinessLayer() 
        {
            //Rilascio delle risorse
            _GenereManager = null;
            _LibroManager = null;
        }
    }
}
