using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Michelin.Models
{

	public enum NacionalnoJelo
    {
		Talijanska_Kuhinja,
		Francuska_Kuhinja,
		Bosanska_Kuhinja,
		Kineska_Kuhinja,
		Meksicka_Kuhinja,
		Ostalo

    }

	public enum VrstaJela
    {
		Slano_Kuhano,
		Slano_Przeno,
		Slano_Peceno,
		Slano_Rostilj,
		Slano_Ostalo,
		Slatko_Torta,
		Slatko_Kolac,
		Slatko_Ostalo

    }
	public class Recept
	{
        #region Properties
        [Required]
		[StringLength(maximumLength:30,MinimumLength =3,
			ErrorMessage ="Naziv recepta mora sadržavati minimalno 3, a najviše 30 karaktera!")]
		[RegularExpression(@"[a-z|A-Z| |0-9]*",ErrorMessage ="Naziv recepta smije sadržavati samo slova, brojeve i razmake!")]
		public String naziv { get; set; }

		[Required]
		public int vrijemePripreme { get; set; }

		[Required]
		public NacionalnoJelo nacionalnoJelo { get; set; }

		[Required]
		public VrstaJela vrstaJela { get; set; }

		[Required]
		public Korisnik autor { get; set; }

		[Required]
		public NacinPripreme nacinPripreme { get; set; }
		public DateTime datum { get; set; }

        #endregion

        #region Constructor
		public Recept(string naziv, int vrijemePripreme, NacionalnoJelo nacionalnoJelo,
			VrstaJela vrsta, Korisnik autor, NacinPripreme nacinPripreme)
        {
			this.naziv = naziv;
			this.vrijemePripreme = vrijemePripreme;
			this.nacionalnoJelo = nacionalnoJelo;
			this.vrstaJela = vrsta;
			this.autor = autor;
			this.nacinPripreme = nacinPripreme;
			datum = DateTime.Now;
        }

        #endregion
    }
}
