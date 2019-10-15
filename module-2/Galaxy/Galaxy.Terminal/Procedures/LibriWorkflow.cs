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
            var nuovoLibro = new Libro 
            { 
                Titolo = "Le due Torri",
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

            //TODO Inserire modifica, elimina
        }
    }
}
