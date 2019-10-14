using Galaxy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Core.BusinessLayers
{
    public class LibroManager
    {
        /// <summary>
        /// Rappresenta la "C" di CRUD
        /// </summary>
        /// <param name="libroDaAggiungere"></param>
        public void CreaLibro(Libro libroDaAggiungere)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rappresenta la "R" di CRUD
        /// </summary>
        /// <returns></returns>
        public IList<Libro> CaricaLibri()
        {
            //Creiamo una lista "finta" di libri
            List<Libro> libriFinti = new List<Libro>();
            libriFinti.Add(new Libro
            {
                Titolo = "Signore degli anelli",
                Anno = 1900,
                Autore = "JR Tolkien",
                Codice = "1234",
                Lingua = "English",
                Prezzo = 10
            });
            libriFinti.Add(new Libro
            {
                Titolo = "Lo Hobbit",
                Anno = 1910,
                Autore = "JR Tolkien",
                Codice = "5678",
                Lingua = "Italiano",
                Prezzo = 15
            });
            libriFinti.Add(new Libro
            {
                Titolo = "Le due torri",
                Anno = 1920,
                Autore = "JR Tolkien",
                Codice = "9999",
                Lingua = "Français",
                Prezzo = 18
            });
            return libriFinti;
        }

        /// <summary>
        /// Rappresenta la "U" di CRUD
        /// </summary>
        /// <param name="libroDaModificare"></param>
        public void AggiornaLibro(Libro libroDaModificare)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rappresenta la "D" di CRUD
        /// </summary>
        /// <param name="libroDaCancellare"></param>
        public void CancellaLibro(Libro libroDaCancellare)
        {
            throw new NotImplementedException();
        }

    }
}
