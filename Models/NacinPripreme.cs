using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Michelin.Models { 
	public class NacinPripreme
	{
		#region Properties
		[Key]
		[Required]
		public string id { get; set; }

		[Required]
		public string listaSastojaka { get; set; }

		[Required]
		[StringLength(maximumLength:3000,MinimumLength = 50, ErrorMessage ="Opis pripreme se mora sastojati od najmanje 50 i" +
			"najviše 3000 karaktera!")]
		public string opisPripreme { get; set; }

        #endregion

        #region Constructor
		public NacinPripreme(List<Sastojak> sastojci, string opis)
        {
			foreach(Sastojak sastojak in sastojci)
            {
				listaSastojaka += sastojak.id + ";";
            }
			opisPripreme = opis;
        }

		public NacinPripreme() { }

        #endregion
    }
}
