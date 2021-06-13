using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Michelin.Models { 
	public class NacinPripreme
	{
		#region Properties
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string id { get; set; }

		[Required]
		public string listaSastojaka { get; set; }

		[Required]
		
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

		public NacinPripreme() {
			
			listaSastojaka = "";
			opisPripreme = "";
		}

        #endregion
    }
}
