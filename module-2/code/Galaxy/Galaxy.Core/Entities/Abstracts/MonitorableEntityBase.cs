using Galaxy.Core.Entities.Interfaces;
using System;

namespace Galaxy.Core.Entities
{
    /// <summary>
    /// Classe astratta per tutte le entità monitorabili
    /// </summary>
    public abstract class MonitorableEntityBase: IEntity, IMonitorableEntity
    {
        /// <summary>
        /// Id primario
        /// </summary>
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
