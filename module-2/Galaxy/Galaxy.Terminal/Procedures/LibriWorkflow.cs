using Galaxy.Core.BusinessLayers;
using Galaxy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Terminal.Procedures
{
    public static class LibriWorkflow
    {
        public static void EseguiCreaModificaCancella()
        {
            //Istanzio il manager dei libri
            Console.WriteLine();
            Console.WriteLine("ESECUZIONE DEL WORKFLOW LIBRI...");
            Console.WriteLine();
            LibroManager manager = new LibroManager();

            //Visualizzazione contenuto database
            Console.WriteLine("Lettura del database...");
            var libriInArchivio = manager.Carica();
            Console.WriteLine($"Trovati {libriInArchivio.Count} libri in archivio");
            foreach (var currentLibro in libriInArchivio)
                Console.WriteLine($"Lettura: {currentLibro.Titolo} (ID:{currentLibro.Id})");
            Console.WriteLine("");

            //Creazione di un nuovo libro => "C" di CRUD
            Console.WriteLine("Creazione di un libro...");
            Random randomGenerator = new Random();
            var nuovoLibro = new Libro 
            { 
                Titolo = "Titolo di esempio numero " + randomGenerator.Next(),
                Anno = 1900, 
                Autore = "JR Tolkien", 
                Codice = "ABC", 
                Lingua = "English", 
                Prezzo = 10, 
                Timestamp = DateTime.Now, 
                UtenteCreatore = "mario.rossi", 
                GenereAppartenenza = new Genere { Id = 1 }
            };
            manager.Crea(nuovoLibro);
            Console.WriteLine("Il libro dovrebbe essere stato creato su disco!");
            Console.WriteLine();

            //Leggiamo i libri dal disco => "R" di CRUD
            Console.WriteLine("Lettura del database...");
            libriInArchivio = manager.Carica();
            Console.WriteLine($"Trovati {libriInArchivio.Count} libri in archivio");
            foreach (var currentLibro in libriInArchivio)
                Console.WriteLine($"Lettura: {currentLibro.Titolo} (ID:{currentLibro.Id})");
            Console.WriteLine("");

            //Modifico genere esistente e scrivo sui disco
            Console.WriteLine("Modifica di un libro esistente...");
            nuovoLibro.Titolo = nuovoLibro.Titolo + "_" + DateTime.Now.Second;
            nuovoLibro.Prezzo = nuovoLibro.Prezzo + 10;
            manager.Aggiorna(nuovoLibro);
            Console.WriteLine("Il titolo e prezzo cambiati dovrebbero essere sul disco!");
            Console.WriteLine();

            //Leggiamo i libri dal disco => "R" di CRUD
            Console.WriteLine("Lettura del database...");
            libriInArchivio = manager.Carica();
            Console.WriteLine($"Trovati {libriInArchivio.Count} libri in archivio");
            foreach (var currentLibro in libriInArchivio)
                Console.WriteLine($"Lettura: {currentLibro.Titolo} (ID:{currentLibro.Id})");
            Console.WriteLine("");

            //Cerchiamo un libro con "esempio" nel titolo
            Console.WriteLine("Caricamento dei soli libri con 'esempio' nel titolo...");
            libriInArchivio = manager.Carica("esempio");
            Console.WriteLine($"Trovati {libriInArchivio.Count} libri in archivio con 'esempio'...");
            foreach (var currentLibro in libriInArchivio)
                Console.WriteLine($"Lettura: {currentLibro.Titolo} (ID:{currentLibro.Id})");
            Console.WriteLine("");

            //Cancellazione del genere => "D" di CRUD
            Console.WriteLine("Cancellazione di un libro esistente...");
            manager.Cancella(nuovoLibro);
            Console.WriteLine("Il libro dovrebbe essere stato cancellato dal disco!");
            Console.WriteLine();

            //Leggiamo i libri dal disco => "R" di CRUD
            Console.WriteLine("Lettura del database...");
            libriInArchivio = manager.Carica();
            Console.WriteLine($"Trovati {libriInArchivio.Count} libri in archivio");
            foreach (var currentLibro in libriInArchivio)
                Console.WriteLine($"Lettura: {currentLibro.Titolo} (ID:{currentLibro.Id})");
            Console.WriteLine("");
        }
    }
}
