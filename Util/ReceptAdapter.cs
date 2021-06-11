using Michelin.Interfaces;
using Michelin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Michelin.Util
{
    public class ReceptAdapter : Recept, IVegan
    {
        public List<Recept> dajVeganskaJela()
        {
            //vraca sve recepte koji su veganski
            throw new NotImplementedException();
        }

        public List<Recept> dajVeganskaJelaFiltrirana(List<VrstaJela> vrstaJela, List<NacionalnoJelo> nacionalnoJelo, int vrijemePripreme, List<Recept> receptiZaFiltriranje)
        {

            //vraca proslijedjenu listu recepata isfiltriranu na osnovu proslijedjenih parametara
            //i takvu da sadrzi iskljucivo veganske recepte
            throw new NotImplementedException();
        }
    }
}
