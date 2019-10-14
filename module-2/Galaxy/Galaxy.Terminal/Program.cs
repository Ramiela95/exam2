using Galaxy.Core.BusinessLayers;
using Galaxy.Core.Entities;
using System;
using System.Collections.Generic;

namespace Galaxy.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            //var listaLibri = new List<Libro>();
            //var listaGeneri = new List<Genere>();

            //listaLibri.Add(new Libro { Titolo = "Signore anelli" });
            //listaGeneri.Add(new Genere { Nome = "Fantasy" });

            //var listaGenerica = new List<EntitaMonitorabile>();
            //listaGenerica.Add(new Libro { Titolo = "Signore anelli" });
            //listaGenerica.Add(new Genere { Nome = "Fantasy" });



            ////2) Richiamo la funzione di lettura dei dati dei libri
            //Genere genere = new Genere();
            //var libri = genere.CaricaLibriDelGenere();

            ////3) Visualizzo i libri in archivio
            //foreach (var currentLibro in libri)
            //{
            //    Console.WriteLine($"Libro: {currentLibro.Titolo}");
            //}

            //Creazione dell'istanza del manager dei generi
            GenereManager managerDeiGeneri = new GenereManager();

            //Creazione di un nuovo genere => "C" di CRUD
            var nuovoGenere = new Genere { Nome = "Fantasy", Descrizione = "Chissenefrega" };
            managerDeiGeneri.CreaGenere(nuovoGenere);
            Console.WriteLine("Il genere dovrebbe essere stato creato su disco!");

            //Leggiamo i generi dal disco => "R" di CRUD
            var tuttiIGeneri = managerDeiGeneri.CaricaGeneri();
            Console.WriteLine($"Numero generi trovati: {tuttiIGeneri.Count}");
            foreach (var currentGenere in tuttiIGeneri)
                Console.WriteLine($"Lettura genere: {currentGenere.Nome} (ID:{currentGenere.Id})");

            //Modifico genere esistente e scrivo sui disco
            nuovoGenere.Nome = "Fantasy Due";
            managerDeiGeneri.AggiornaGenere(nuovoGenere);
            Console.WriteLine("Il nome cambiato dovrebbe essere sul disco!");

            //Rileggiamo per vedere se effettivamente è cambiato
            var tuttiIGeneriDiNuovo = managerDeiGeneri.CaricaGeneri();
            Console.WriteLine($"Numero generi trovati: {tuttiIGeneriDiNuovo.Count}");
            foreach (var currentGenere in tuttiIGeneriDiNuovo)
                Console.WriteLine($"Lettura genere: {currentGenere.Nome} (ID:{currentGenere.Id})");

            //Cancellazione del genere => "D" di CRUD
            managerDeiGeneri.CancellaGenere(nuovoGenere);
            Console.WriteLine("Il genere dovrebbe essere stato cancellato dal disco!");

            //Rileggiamo per vedere se effettivamente è cambiato
            var tuttiIGeneriUltimaVolta = managerDeiGeneri.CaricaGeneri();
            Console.WriteLine($"Numero generi trovati: {tuttiIGeneriUltimaVolta.Count}");
            foreach (var currentGenere in tuttiIGeneriUltimaVolta)
                Console.WriteLine($"Lettura genere: {currentGenere.Nome} (ID:{currentGenere.Id})");


            //Creazione di un nuovo genere
            //var nuovoGenere = new Genere { Nome = "Fantasy", Descrizione = "Chissenefrega" };
            //managerDeiGeneri.CreaGenere(nuovoGenere);
            //Console.WriteLine("Il genere dovrebbe essere stato creato su disco!");


        }
    }
}
