using Galaxy.Core.Entities;
using Galaxy.Core.Entities.Interfaces;
using System;

namespace Galaxy.Terminal.SampleVehicle
{

    public abstract class Veicolo : MonitorableEntityBase
    {
        public int Id { get; set; }
        public string Modello { get; set; }

        public string Marca { get; set; }




    }
}
