using System;

namespace Galaxy.Terminal.SampleVehicle
{
    /// <summary>
    /// Classe che rappresenta una automobile
    /// </summary>
    public class Automobile : Veicolo
    {
        public int NumeroCavalli { get; set; }
        public bool IsDiesel { get; set; }
        public DateTime DataImmatricolazione { get; set; }


    }
}
