using System;

namespace Galaxy.Terminal.SampleVehicle
{
    /// <summary>
    /// Class che rappresenta un veicolo
    /// </summary>
    public abstract class Veicolo
    {
        /// <summary>
        /// Colore
        /// </summary>
        public string Colore { get; set; }

        /// <summary>
        /// Marca
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Velocità attuale
        /// </summary>
        public int Velocita { get; set; }

        /// <summary>
        /// Funzione di accelerazione
        /// </summary>
        public void Accelera()
        {
            //Incremento del campo Velocita (di 1 km/h)
            Velocita = Velocita + 1;
        }

        /// <summary>
        /// Funzione che frena il veicolo
        /// </summary>
        public void Frena()
        {
            //Se la velocità è zero, non fa nulla
            if (Velocita == 0)
                return;

            //Decremento del campo Velocita (di 1 km/h)
            Velocita = Velocita - 1;
        }
    }
}
