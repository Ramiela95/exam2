using Galaxy.Core.Entities.Interfaces;

namespace Galaxy.Core.Entities
{
    /// <summary>
    /// Entità utente
    /// </summary>
    public class Utente: IEntity
    {
        /// <summary>
        /// Id primario
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string UserName { get; set; }

        //1) Definire classe Utente con campi "Username" (string), 
        //"Nome" (string), "Cognome" (string) e "IsAbilitato" (bool)

        //2) La classe deve derivare da EntitaMonitorabile

        //3) Definire UtenteManager come derivato da ManagerBase<Utente>

        //4) Copiare LibriWorkflow e creare UtentiWorkflow

        //5) Aggiungere menu "3" a Galaxy.Terminal\Program.cs
    }
}
