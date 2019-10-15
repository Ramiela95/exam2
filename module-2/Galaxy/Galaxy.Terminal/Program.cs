﻿using Galaxy.Core.BusinessLayers;
using Galaxy.Core.Entities;
using Galaxy.Terminal.Procedures;
using Galaxy.Terminal.Utils;
using System;
using System.Collections.Generic;

namespace Galaxy.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Visualizzo menu e richiedo selezione
            Console.WriteLine("*******************************");
            Console.WriteLine("* MENU                        *");
            Console.WriteLine("*******************************");
            Console.WriteLine("* 1 - Esegui CRUD Genere");
            Console.WriteLine("* 2 - Esegui CRUD Libro");
            var selezione = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 2);

            //Selezione dell'opzione
            switch (selezione) 
            {
                case 1:
                    GeneriWorkflow.EseguiCreaModificaCancella();
                    break;
                case 2:
                    LibriWorkflow.EseguiCreaModificaCancella();
                    break;
                default:
                    Console.WriteLine("Opzione non valida!");
                    break;
            }

            //Richiedo conferma di uscita
            ConsoleUtils.ConfermaUscita();
        }
    }
}