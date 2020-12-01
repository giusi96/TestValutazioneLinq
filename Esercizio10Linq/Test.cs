using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esercizio10Linq
{
    public class Test
    {
        //Creazione liste:
        public static List<Persona> createPersonList()
        {
            var lista = new List<Persona>
            {
                new Persona{ID=1,Nome="Giusi",Cognome="Balsamo", Nazione="Italia" },
                new Persona{ID=2,Nome="Mario",Cognome="Rossi", Nazione="Francia" },
                new Persona{ID=3,Nome="Luca",Cognome="Verdi", Nazione="Italia" },
                new Persona{ID=4,Nome="Anna",Cognome="Bianchi", Nazione="Spagna" },
            };
            return lista;
        }

        public static List<Veicolo> createVeicoloList()
        {
            var lista = new List<Veicolo>
            {
               new Veicolo{ID=1, Targa="abcde", Peso=450, Colore="Blu",Prezzo=11000, ProprietarioID=2},
               new Veicolo{ID=2, Targa="fghil", Peso=560, Colore="Nero",Prezzo=25000, ProprietarioID=1},
               new Veicolo{ID=3, Targa="mnopq", Peso=425, Colore="Rosso",Prezzo=17990.99, ProprietarioID=2},
               new Veicolo{ID=4, Targa="rstuv", Peso=669, Colore="Nero",Prezzo=40350, ProprietarioID=4},
         
            };
            return lista;
        }

        public static void QueryExecution()
        {
            var personList = createPersonList();
            var veicoloList = createVeicoloList(); ;

            //Visualizzazione dei risultati
            Console.WriteLine("Lista delle persone: ");
            foreach (var p in personList)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", p.ID, p.Nome, p.Cognome, p.Nazione);
            }

            Console.WriteLine("Lista dei veicoli: ");
            foreach (var p in veicoloList)
            {
                Console.WriteLine("{0} - {1} - {2} Kg - {3} - {4} € - {5}", p.ID, p.Targa, p.Peso, p.Colore, p.Prezzo, p.ProprietarioID);
            }



            //Punto3-Query Syntax
            var sumByColor =
                from o in veicoloList
                group o by o.Colore into list
                select new { colore = list.Key, num = list.Count() };

            Console.WriteLine("Numero di macchine per colore: ");
            foreach (var p in sumByColor)
            {
                Console.WriteLine($"{p.colore} - {p.num}");
            }


            //Punto 4-Query Syntax
            var groupJoinList =
                from p in veicoloList
                group p by p.ProprietarioID
                into gr
                select new { proprietarioID = gr.Key, PrezzoMedio = gr.Average(p => p.Prezzo), PesoTot = gr.Sum(p => p.Peso) }
                into gr1
                join c in personList
                on gr1.proprietarioID equals c.ID
                select new { c.Nome, gr1.PesoTot, gr1.PrezzoMedio };


            Console.WriteLine("Peso Complessivo e prezzo medio per persona: ");
            foreach (var item in groupJoinList)
            {
                Console.WriteLine("{0} - {1} Kg - {2} €", item.Nome, item.PesoTot, item.PrezzoMedio);
            }


            //Punto 5-Extension Method
            Persona p1 = new Persona { ID = 2, Nome = "Mario", Cognome = "Rossi", Nazione = "Francia" };

            List<VeicoliPosseduti> veicoliPosseduti = p1.veicoliposseduti(veicoloList);
            var numVeicoli_p1 = veicoliPosseduti.Count();
            Console.WriteLine($"Il proprietario {p1.Nome} ha {numVeicoli_p1} veicoli: ");
            foreach (var item in veicoliPosseduti)
            {
                Console.WriteLine($"{item.ID} - {item.Prezzo} € - {item.Targa}");
            }
                
                
        }


    }
}


