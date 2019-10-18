

using Galaxy.Core.BusinessLayers.JsonProvider.Common;
using Galaxy.Core.Entities;
using Galaxy.Terminal.SampleVehicle;

namespace Galaxy.Core.BusinessLayers.JsonProvider
    {
    public class JsonBiciclettaManager : JsonManagerBase<Bicicletta>
    {
        protected override void RemapNuoviValoriSuEntityInLista(Bicicletta targetEntity, Bicicletta sourceEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}

