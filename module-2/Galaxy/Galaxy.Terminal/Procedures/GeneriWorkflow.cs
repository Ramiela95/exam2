using Galaxy.Core.BusinessLayers;
using Galaxy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Terminal.Procedures
{
    public static class GeneriWorkflow
    {
        public static void EseguiCreaModificaCancella() 
        {
            //Creazione dell'istanza del manager dei generi
            Console.WriteLine();
            Console.WriteLine("ESECUZIONE DEL WORKFLOW GENERI...");
            Console.WriteLine();
            GenereManager managerDeiGeneri = new GenereManager();

            //Creazione di un nuovo genere => "C" di CRUD
            Console.WriteLine("Creazione di un genere...");
            var nuovoGenere = new Genere { Nome = "Fantasy", Descrizione = "Chissenefrega" };
            managerDeiGeneri.CreaGenere(nuovoGenere);
            Console.WriteLine("Il genere dovrebbe essere stato creato su disco!");
            Console.WriteLine();

            //Leggiamo i generi dal disco => "R" di CRUD
            Console.WriteLine("Lettura del database...");
            var tuttiIGeneri = managerDeiGeneri.CaricaGeneri();
            Console.WriteLine($"Numero generi trovati: {tuttiIGeneri.Count}");
            foreach (var currentGenere in tuttiIGeneri)
                Console.WriteLine($"Lettura genere: {currentGenere.Nome} (ID:{currentGenere.Id})");
            Console.WriteLine();

            //Modifico genere esistente e scrivo sui disco
            Console.WriteLine("Modifica di un genere esistente...");
            nuovoGenere.Nome = "Fantasy Due";
            managerDeiGeneri.AggiornaGenere(nuovoGenere);
            Console.WriteLine("Il nome cambiato dovrebbe essere sul disco!");
            Console.WriteLine();

            //Rileggiamo per vedere se effettivamente è cambiato
            Console.WriteLine("Lettura del database...");
            var tuttiIGeneriDiNuovo = managerDeiGeneri.CaricaGeneri();
            Console.WriteLine($"Numero generi trovati: {tuttiIGeneriDiNuovo.Count}");
            foreach (var currentGenere in tuttiIGeneriDiNuovo)
                Console.WriteLine($"Lettura genere: {currentGenere.Nome} (ID:{currentGenere.Id})");
            Console.WriteLine();

            //Cancellazione del genere => "D" di CRUD
            Console.WriteLine("Cancellazione di un genere esistente...");
            managerDeiGeneri.CancellaGenere(nuovoGenere);
            Console.WriteLine("Il genere dovrebbe essere stato cancellato dal disco!");
            Console.WriteLine();

            //Rileggiamo per vedere se effettivamente è cambiato
            Console.WriteLine("Lettura del database...");
            var tuttiIGeneriUltimaVolta = managerDeiGeneri.CaricaGeneri();
            Console.WriteLine($"Numero generi trovati: {tuttiIGeneriUltimaVolta.Count}");
            foreach (var currentGenere in tuttiIGeneriUltimaVolta)
                Console.WriteLine($"Lettura genere: {currentGenere.Nome} (ID:{currentGenere.Id})");
            Console.WriteLine();
        }
        
    }
}
