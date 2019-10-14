using System;
using System.Collections.Generic;
using System.Text;

namespace HelloAcademy.Utils
{
    public static class ArrayUtils
    {
        public static string[] CopyToArray(string[] sourceArray, int newLength) 
        {
            //Controllo che l'array sia valido
            if (sourceArray == null)
                throw new ArgumentNullException(nameof(sourceArray));

            //Controllo che la lunghezza sia maggiore uguale a 0
            if (newLength < 0)
                throw new ArgumentOutOfRangeException(nameof(newLength));

            //Se la lunghezza dell'array di destinazione è minore 
            //di quella dell'array originale, non procedo
            if (sourceArray.Length > newLength)
                throw new InvalidOperationException("La lunghezza dell'array di " +
                    "destinazione deve essere maggiore o uguale a quella dell'array sorgente");

            //Creazione array con nuova dimensione
            string[] targetArray = new string[newLength];

            //Scorro tutti i dati dell'array originale e li copio
            for (int index = 0; index < sourceArray.Length; index++) 
            {
                //Inserisco il valore in array target
                targetArray[index] = sourceArray[index];                
            }

            //Mando in uscita il nuovo array
            return targetArray;            
        }
    }
}
