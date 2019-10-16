namespace Galaxy.Core.Entities.Interfaces
{
    /// <summary>
    /// Interfaccia per entità con 
    /// id primario intero progressivo
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Id primario
        /// </summary>
        int Id { get; set; }
    }
}
