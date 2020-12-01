using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestValutazioneLinq
{
    public class Esercizio8
    {
        public static List<Persona> createList()
        {
            var lista = new List<Persona>
            {
                new Persona{firstName="Giusi", LastName="Balsamo"},
                new Persona{firstName="Mario", LastName="Rossi"},
                new Persona{firstName="Anna", LastName="Bianchi"},
                new Persona{firstName="Anna", LastName="Gialli"},
                new Persona{firstName="Fabrizio", LastName="Verdi"}
            };
            return lista;
        }

        public static void ListAnnaFabrizio()
        {
            var personList = createList();


            //Visualizzazione dei risultati
            foreach (var p in personList)
            {
                Console.WriteLine("{0} - {1}", p.firstName, p.LastName);
            }
            
            //Query => Method Syntax
            var list = personList.Where(p => p.firstName == "Anna" || p.firstName == "Fabrizio")
                .Select(p => new { Nome = p.firstName, Cognome = p.LastName });

            Console.WriteLine("Lista con Anna e Fabrizio: Method Syntax ");
            foreach (var p in list)
            {
                Console.WriteLine("{0} - {1}", p.Nome, p.Cognome);
            }


            //Query => Query Syntax
            var queryList =
                (from p in personList
                 where p.firstName == "Anna" || p.firstName=="Fabrizio"
                 select new { Nome = p.firstName, cognome= p.LastName}).ToList();

            Console.WriteLine("Lista con Anna e Fabrizio: Query Syntax ");
            foreach (var p in list)
            {
                Console.WriteLine("{0} - {1}", p.Nome, p.Cognome);
            }

        }
    }
}

