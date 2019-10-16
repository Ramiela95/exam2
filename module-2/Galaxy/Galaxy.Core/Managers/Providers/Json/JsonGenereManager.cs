using Galaxy.Core.BusinessLayers.JsonProvider.Common;
using Galaxy.Core.Entities;

namespace Galaxy.Core.BusinessLayers.JsonProvider
{
    public class JsonGenereManager : JsonManagerBase<Genere>
    {
        protected override void RemapNuoviValoriSuEntityInLista(
            Genere entitySorgente, Genere entityDestinazione)
        {
            entityDestinazione.Nome = entitySorgente.Nome;
            entityDestinazione.Descrizione = entitySorgente.Descrizione;
        }
    }
}
