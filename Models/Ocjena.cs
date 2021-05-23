using System;
using System.ComponentModel.DataAnnotations;

namespace Michelin.Models
{
	public class Ocjena
	{
        #region Properties

        [Key]
        [Required]
        public string id { get; set; }

        [Required]
        public Korisnik korisnik { get; set; }

        [Required]
		public Recept recept { get; set; }

        [Required]
        [Range(1,5)]
		public double vrijednost { get; set; }

        #endregion

        #region Constructor
        public Ocjena (Korisnik autor, Recept recept, double vrijednost)
        {
            korisnik = autor;
            this.recept = recept;
            this.vrijednost = vrijednost;
        }
        #endregion
    }
}
