using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Michelin.Models
{
	public class Administrator
	{
        #region Properties

        [Required]
        [Key]
        public String emailAdresa { get; set; }

        [NotMapped]
		public List<ZahtjevZaPomoc> zahtjeviZaPomoc { get; set; }

        #endregion

        #region Constructor
        public Administrator(string email)
        {
            emailAdresa = email;
            zahtjeviZaPomoc = new List<ZahtjevZaPomoc>();
        }
        #endregion
    }
}
