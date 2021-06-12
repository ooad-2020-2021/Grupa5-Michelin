﻿using Michelin.Interfaces;
using Michelin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Michelin.Util
{
    public class ObicniIterator : IIterator
    {
        #region Prototypes
        public List<ZahtjevZaPomoc> zahtjeviZaPomoc { get; set; }
        public int trenutniZahtjev { get; set; }
        #endregion

        #region Constructor
        public ObicniIterator()
        {
            //uzima sve neobradjene zahtjeve iz baze i njima inicijalizira listu
            //trenutni zahtjev postavlja na 0
        }
        #endregion

        #region Metode
        public ZahtjevZaPomoc dajNaredniZahtjevZaPomoc()
        {
            //vraca sljedeci zahtjev iz liste
            throw new NotImplementedException();
        }
        #endregion
    }
}