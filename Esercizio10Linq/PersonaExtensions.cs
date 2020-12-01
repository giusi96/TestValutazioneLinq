using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esercizio10Linq
{
   public  static class PersonaExtensions
    {
        public static List<VeicoliPosseduti> veicoliposseduti(this Persona proprietario, List<Veicolo> veicoloList)
        {
            int id = proprietario.ID;
            var veicoli =
                (from v in veicoloList
                 where v.ProprietarioID == id
                 select new VeicoliPosseduti(){
                     ID= v.ProprietarioID, Targa= v.Targa, Prezzo= v.Prezzo}).ToList();

            return veicoli;
        }
    }
}
