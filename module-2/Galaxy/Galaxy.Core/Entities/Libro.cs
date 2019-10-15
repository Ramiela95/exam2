using System;

namespace Galaxy.Core.Entities
{
    /// <summary>
    /// Entità libro venduto
    /// </summary>
    public class Libro: EntitaMonitorabile
    {        
        /// <summary>
        /// Codice del libro (es. ISBN)
        /// </summary>
        public string Codice { get; set; }

        /// <summary>
        /// Titolo del libro per esteso
        /// </summary>
        public string Titolo { get; set; }

        /// <summary>
        /// Prezzo attuale del libro
        /// </summary>
        public double Prezzo { get; set; }

        /// <summary>
        /// Lingua del libro
        /// </summary>
        public string Lingua { get; set; }

        /// <summary>
        /// Autore o autori del libro
        /// </summary>
        public string Autore { get; set; }

        /// <summary>
        /// Anno di pubblicazione
        /// </summary>
        public int Anno { get; set; }

        /// <summary>
        /// Riferimento al genere di appartenenza
        /// </summary>
        public Genere GenereAppartenenza { get; set; }        
    }
}
