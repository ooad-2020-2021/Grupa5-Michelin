using System;
using System.ComponentModel.DataAnnotations;

namespace Michelin.Models
{
	public  class Komentar
	{
        #region Properties
        [Required]
		[StringLength(maximumLength:300, MinimumLength =5, ErrorMessage ="Komentar mora biti duži od 5 karaktera i kraći od 300!")]
		public String sadrzaj { get; set; }

		[Required]
		public Korisnik autor { get; set; }

		[Required]
		public Recept recept { get; set; }
		public DateTime datum { get; set; }

        #endregion

        #region Constructor
		public Komentar(string sadrzaj, Korisnik autor, Recept recept)
        {
			this.sadrzaj = sadrzaj;
			this.autor = autor;
			this.recept = recept;
			datum = DateTime.Now;
        }
        #endregion
    }
}
