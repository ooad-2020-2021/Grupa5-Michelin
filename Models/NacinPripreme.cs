using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Michelin.Models { 
	public class NacinPripreme
	{
		#region Properties

		[Required]
		[NotMapped]
		public List<Sastojak> listaSastojaka { get; set; }

		[Required]
		[StringLength(maximumLength:3000,MinimumLength = 50, ErrorMessage ="Opis pripreme se mora sastojati od najmanje 50 i" +
			"najviše 3000 karaktera!")]
		public String opisPripreme { get; set; }

        #endregion

        #region Constructor
		public NacinPripreme(List<Sastojak> sastojci, string opis)
        {
			listaSastojaka = sastojci;
			opisPripreme = opis;
        }

        #endregion
    }
}
