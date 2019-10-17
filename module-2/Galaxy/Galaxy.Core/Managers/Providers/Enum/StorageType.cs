using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Core.Managers.Providers.Enum
{
    /// <summary>
    /// Enumerazione di tutti i possibili 
    /// provider supportati dalla piattaforma
    /// </summary>
    public enum StorageType
    {
        /// <summary>
        /// Provider che scrive su file JSON
        /// </summary>
        Json = 0, 

        /// <summary>
        /// Provider che scrive su file TXT
        /// </summary>
        Text = 1, 

        /// <summary>
        /// Provider che scrive su SQL Server
        /// </summary>
        Sql = 2
    }
}
