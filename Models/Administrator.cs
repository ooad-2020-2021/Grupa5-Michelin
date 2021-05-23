using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Michelin.Models
{
	public class Administrator
	{
        #region Properties

        [Required]
        [Key]
        public string emailAdresa { get; set; }

        
		public string zahtjeviZaPomoc { get; set; }

        #endregion

        #region Constructor
        public Administrator(string email)
        {
            emailAdresa = email;
            zahtjeviZaPomoc = new string("");
        }
        #endregion

        public List<ZahtjevZaPomoc> pretvoriStringUListu()
        {
            List<ZahtjevZaPomoc> zahtjevi = new List<ZahtjevZaPomoc>();
            //dohvatiti zahtjeve iz baze kojima odgovaraju primarni kljucevi iz stringa
            return zahtjevi;
        }
    }
}
