using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Core.Entities
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
