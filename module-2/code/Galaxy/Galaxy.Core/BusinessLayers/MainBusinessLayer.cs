using Galaxy.Core.BusinessLayers.Common;
using Galaxy.Core.Entities;
using Galaxy.Terminal.SampleVehicle;
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
        private IManager<Bicicletta> _BiciclettaManager;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="genereMan">Istanza Genere manager</param>
        /// <param name="libroMan">Istanza Libro manager</param>
        public MainBusinessLayer(IManager<Genere> genereMan, IManager<Libro> libroMan, IManager<Bicicletta> biciclettaMan) 
        {
            _GenereManager = genereMan;
            _LibroManager = libroMan;
            _BiciclettaManager= biciclettaMan;
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
            string modello, string marca, int numeroTelaio, 
            bool isElettrica)
        {
            //1) Validazione degli input
            if (string.IsNullOrEmpty(modello))
                throw new ArgumentNullException(nameof(modello));
            if (string.IsNullOrEmpty(marca))
                throw new ArgumentNullException(nameof(marca));
           
            if (numeroTelaio <= 0)
                throw new ArgumentOutOfRangeException(nameof(numeroTelaio));
            

            //Predisposizione messaggi di uscita
            IList<string> messaggi = new List<string>();

         
            Bicicletta nuovaBicicletta = new Bicicletta
            {
                Modello = modello,
                Marca = marca,
                NumeroTelaio = numeroTelaio,
                IsElettrica = isElettrica
            };

            //Aggiungo il libro
            _BiciclettaManager.Crea(nuovaBicicletta);

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
