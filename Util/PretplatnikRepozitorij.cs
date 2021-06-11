using Michelin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Michelin.Util
{
    public class PretplatnikRepozitorij
    {
        #region Prototypes
        public List<IPretplatnik> pretplatnici { get; set; }
        public PretplatnikRepozitorij repozitorij { get; set; }

        #endregion

        #region Constructor
        private PretplatnikRepozitorij()
        {
            repozitorij = new PretplatnikRepozitorij();
        }
        #endregion

        #region Metode
        public PretplatnikRepozitorij getInstance()
        {
            return repozitorij;
        }
        public void dodajPretplatnika(IPretplatnik pretplatnik)
        {
            //dodaje pretplatnika u listu
        }
        public void ukloniPretplatnika(IPretplatnik pretplatnik)
        {
            //uklanja pretplatnika iz liste
        }

        public void obavijestiPretplatnike()
        {
            //za svakog pretplatnika u listi poziva posaljiMail i posaljiPoruku
        }
        #endregion
    }

}
