using System;

namespace Galaxy.Terminal.SampleVehicle
{
    public abstract class Veicolo
    {
        public string Colore { get; set; }

        public string Marca { get; set; }

        public void Accelera()
        {
            throw new NotImplementedException();
        }

        public void Frena()
        {
            throw new NotImplementedException();
        }
    }
}
