using HelloAcademy.Procedures;
using HelloAcademy.Utils;
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
            Console.WriteLine("Quante persone vuoi inserire (da 1 a 9)? ");
            int totalPersons = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 9);

            //Richiamo la funzione che genera la rubrica
            // => TODO var rubrica = ComposizioneRubrica(totalPersons);

            //Dimensionamento della rubrica
            List<Person> rubrica = CaricaRubricaDaDatabase();

            //4) Itero per il numero di persone richiesto
            for (int index = 0; index < totalPersons; index++)
            {
                //Richiamo una funzione a cui passo la rubrica
                //e l'indice corrente e questa mi aggiunge la persona
                AggiungiPersonaARubricaInPosizione(rubrica);
            }

            //9) Itero la rubrica e stampo a video (con for) tutte le persone
            StampaRubrica(rubrica);
           
            //Cerimonia finale
            ConsoleUtils.ConfermaUscita();
        }

        private static List<Person> CaricaRubricaDaDatabase()
        {
            //Mi assicuro che esista la folder di archivio
            var archiveFolder = FunzioniFileSystem.AssicuratiCheEsistaCartellaDiArchivio();

            //Tento di farmi dare le righe contenute nel database (se esiste)
            string[] tutteLeRigheDelDatabase = FunzioniFileSystem.OttieniRigheDaDatabase(archiveFolder);

            List<Person> persone = new List<Person>();

            //Itero per tutti gli elementi dell'array
            foreach (var currentRow in tutteLeRigheDelDatabase) 
            {
                //Individuo la posizione della ","
                int virgolaPosition = currentRow.IndexOf(",");

                //Se non viene trovata la ",", passiamo al prossimo elemento
                if (virgolaPosition < 0)
                    continue;

                //Prendo come nome la stringa prima della virgola
                string nome = currentRow.Substring(0, virgolaPosition);

                //Prendo quello che ho dopo la virgola come cognome
                string cognome = currentRow.Substring(virgolaPosition + 1);

                //Creazione dell'oggetto persona
                Person currentPerson = new Person
                {
                    FirstName = nome,
                    LastName = cognome
                };

                //Aggiungo la persona alla lista
                persone.Add(currentPerson);
            }

            return persone;
        }

        private static void StampaRubrica(List<Person> rubrica)
        {
            Console.WriteLine("*** Visualizzazione contenuto rubrica***");
            for (var index = 0; index < rubrica.Count; index++)
            {
                Console.WriteLine($" => {rubrica[index].FirstName}, {rubrica[index].LastName}");
                //Console.WriteLine(" => " + rubrica[index].FirstName + ", " + rubrica[index].LastName);
            }
        }

        private static void AggiungiPersonaARubricaInPosizione(List<Person> rubrica)
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
            rubrica.Add(person);

            //Aggiungo la persona al file database
            SalvaPersonaInFile(person);

            //8) Se ho inserito tutte le persone termino il ciclo
        }

        private static void SalvaPersonaInFile(Person person)
        {
            //Assicuriamoci che esista la folder per il file di archivio
            var archiveFolder = FunzioniFileSystem.AssicuratiCheEsistaCartellaDiArchivio();
            //** Arrivo a questo punto e sono sicuro al 100% che la cartella dove
            //** sarà conservato il file database esiste: ne ottengo il percorso

            string datiDellaPersonaInFormatoStringa = ConvertiPersonaInStringa(person);

            //Aggiungi testo a file
            FunzioniFileSystem.AggiungiTestoAFileDatabase(datiDellaPersonaInFormatoStringa, archiveFolder);
        }

        private static string ConvertiPersonaInStringa(Person person)
        {
            return $"{person.FirstName},{person.LastName}";
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
