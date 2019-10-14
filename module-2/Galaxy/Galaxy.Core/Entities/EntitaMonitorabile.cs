using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Core.Entities
{
    public abstract class EntitaMonitorabile
    {
        public int Id { get; set; }

        /// <summary>
        /// Data di creazione dell'entità
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Utente che ha fisicamente creato dell'entità nel catalogo
        /// </summary>
        public string UtenteCreatore { get; set; }
    }
}
