using HelloAcademy.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloAcademy.Procedures
{
    public static class FunzioniArray
    {
        public static void RiempiArrayECopia() 
        {
            string[] sourceArray = new string[3];

            //Inserimento di 3 elementi nell'array
            for (var i = 0; i < 3; i++) 
            {
                //Leggo da console
                var valore = Console.ReadLine();

                //Inserisco in array sorgente
                sourceArray[i] = valore;
            }

            //Copio array in array più grande
            var targetArray = ArrayUtils.CopyToArray(sourceArray, 4);

            //Aggiungo elemento nuovo "slot"
            targetArray[3] = Console.ReadLine();

            //Stampo array
            foreach (var current in targetArray) 
            {
                Console.WriteLine(current);
            }

        }
    }
}
