using System;
using System.Collections.Generic;
using System.Text;

namespace HelloAcademy
{
    public static class FunzioniRubrica
    {
        public static void InserisciNumeroArbitrarioPersoneInRubrica()
        {
            //1) Richiedo il numero di persone da inserire
            Console.Write("Quante persone vuoi inserire (da 1 a 9)? ");
            int totalPersons = LeggiNumeroInteroDaConsole(1, 9);

            //Dimensionamento della rubrica
            Person[] rubrica = new Person[totalPersons];

            //4) Itero per il numero di persone richiesto
            for (int index = 0; index < totalPersons; index++)
            {
                //Richiamo una funzione a cui passo la rubrica
                //e l'indice corrente e questa mi aggiunge la persona
                AggiungiPersonaARubricaInPosizione(rubrica, index);
            }

            //9) Itero la rubrica e stampo a video (con for) tutte le persone
            StampaRubrica(rubrica);

            //Cerimonia finale
            ConfermaUscita();
        }

        private static int LeggiNumeroInteroDaConsole(int minValue, int maxValue)
        {
            //Leggo il valore stringa da console
            string valoreString = Console.ReadLine();
            int valoreIntero = 0;

            //Predisposizione al fallimento
            bool isInteger = false;
            bool isInRange = false;

            do
            {
                try
                {
                    //Validazione e parsing del valore
                    valoreIntero = int.Parse(valoreString);
                    isInteger = true;

                    //Verifico se è nel range
                    if (valoreIntero >= minValue && valoreIntero <= maxValue) 
                    {
                        //imposto il flag IsInRange
                        isInRange = true;
                    }
                }
                catch (Exception exc)
                {
                    //Messaggio di errore
                    Console.WriteLine("Attenzione! Il valore immesso non è valido!");
                    Console.Write("Inseriscilo di nuovo: ");

                    //RIchiesta nuovo valore
                    valoreString = Console.ReadLine();

                    //Ripristino condizioni di predisposizione fallimento iniziali
                    valoreIntero = 0;
                    isInteger = false;                    
                    isInRange = false;
                }
            }
            while (isInteger == false || isInRange == false);

            //Ritorno il valore intero
            return valoreIntero;
        }

        private static void ConfermaUscita()
        {
            Console.Write("Premi un pulsante per uscire");
            Console.ReadKey();
        }

        private static void StampaRubrica(Person[] rubrica)
        {
            Console.WriteLine("*** Visualizzazione contenuto rubrica***");
            for (var index = 0; index < rubrica.Length; index++)
            {
                Console.WriteLine($" => {rubrica[index].FirstName}, {rubrica[index].LastName}");
                //Console.WriteLine(" => " + rubrica[index].FirstName + ", " + rubrica[index].LastName);
            }
        }

        private static void AggiungiPersonaARubricaInPosizione(Person[] rubrica, int index)
        {
            //5) Richiedo il nome e cognome della persona
            Console.Write("nome: ");
            var nome = Console.ReadLine();
            Console.Write("cognome: ");
            var cognome = Console.ReadLine();

            //6) Creo oggetto Person da inserire in rubrica
            Person person = new Person
            {
                FirstName = nome,
                LastName = cognome
            };

            //7) Aggiungo persona a rubrica
            rubrica[index] = person;

            //8) Se ho inserito tutte le persone termino il ciclo
        }


        //******************************************************************
        public static void InserisciPersoneEMostraRubrica()
        {
            //Dimensiono array per la rubrica
            Person[] rubrica = new Person[3];

            //Richiedo persona 1 (nome + cognome)
            Console.Write("Nome 1: ");
            string nome1 = Console.ReadLine();
            Console.Write("Cognome 1: ");
            string cognome1 = Console.ReadLine();

            //Creo oggetto persona e inserisco valori
            Person uno = new Person();
            uno.FirstName = nome1;
            uno.LastName = cognome1;

            //Aggiungo persona a rubrica
            rubrica[0] = uno;


            //Richiedo persona 2 (nome + cognome)
            Console.Write("Nome 2: ");
            string nome2 = Console.ReadLine();
            Console.Write("Cognome 2: ");
            string cognome2 = Console.ReadLine();

            //Creo oggetto persona e inserisco valori
            Person due = new Person
            {
                FirstName = nome2,
                LastName = cognome2
            };

            //Aggiungo persona a rubrica
            rubrica[1] = due;


            //Richiedo persona 1 (nome + cognome)
            //Creo oggetto persona e inserisco valori
            //Aggiungo persona a rubrica
            Console.Write("Nome 2: ");
            string nome3 = Console.ReadLine();
            Console.Write("Cognome 2: ");
            string cognome3 = Console.ReadLine();
            rubrica[2] = new Person
            {
                FirstName = nome3,
                LastName = cognome3
            };

            //Mostro contenuto rubrica
            // VERSIONE BECERA!!!!
            //Console.WriteLine(rubrica[0].FirstName + ", " + rubrica[0].LastName);
            //Console.WriteLine(rubrica[1].FirstName + ", " + rubrica[1].FirstName);
            //Console.WriteLine(rubrica[2].FirstName + ", " + rubrica[3].FirstName);
            Console.WriteLine("Iterazione rubrica (for):");
            for (int i = 0; i < rubrica.Length; i++)
            {
                Console.WriteLine(rubrica[i].FirstName + ", " + rubrica[i].LastName);
            }

            Console.WriteLine("Iterazione rubrica (while):");
            int index = 0;
            while (index < rubrica.Length)
            {
                Console.WriteLine(rubrica[index].FirstName + ", " + rubrica[index].LastName);
                index = index + 1;
            }

            Console.WriteLine("Iterazione rubrica (foreach):");
            foreach (Person current in rubrica) 
            {
                Console.WriteLine(current.FirstName + ", " + current.LastName);
            }

        }
    }
}
