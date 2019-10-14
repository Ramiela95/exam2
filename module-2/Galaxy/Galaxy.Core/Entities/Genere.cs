using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Core.Entities
{
    /// <summary>
    /// Entità che esprime il genere dei libri (es. Fantasy, Saggistica, ecc)
    /// </summary>
    public class Genere: EntitaMonitorabile
    {
        public int Id { get; set; }

        /// <summary>
        /// Nome del genere
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descrizione sintetica del genere
        /// </summary>
        public string Descrizione { get; set; }

        
    }
}
