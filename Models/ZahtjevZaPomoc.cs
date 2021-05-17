using System;
using System.ComponentModel.DataAnnotations;

namespace Michelin.Models
{
	public enum KategorijaZahtjevaZaPomoc
    {
		Tehnicki_Problem,
		Pogresno_napisan_recept,
		Neprimjeren_sadrzaj,
		Pitanja_Sugestije
    }
	public class ZahtjevZaPomoc
	{
        #region Properties
        [Required]
		public KategorijaZahtjevaZaPomoc kategorija { get; set; }

		[Required]
		[StringLength(maximumLength:1000,MinimumLength =50, ErrorMessage ="Problem se mora opisati sa najviše 1000, a " +
			"najmanje 50 karaktera!")]
		public String sadrzaj { get; set; }

		[Required]
		public Korisnik korisnik { get; set; }

		[Required]
		public Boolean obradjeno { get; set; }

        #endregion

        #region Constructor
		public ZahtjevZaPomoc(KategorijaZahtjevaZaPomoc kategorija, string sadrzaj, Korisnik korisnik)
        {
			this.sadrzaj = sadrzaj;
			this.kategorija = kategorija;
			this.korisnik = korisnik;
			this.obradjeno = false;
        }
        #endregion
    }
}
