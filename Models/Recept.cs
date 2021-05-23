using System;
using System.ComponentModel.DataAnnotations;

namespace Michelin.Models
{

	public enum NacionalnoJelo
    {
		[Display(Name = "Talijanska kuhinja")]
		Talijanska_Kuhinja,
		[Display(Name = "Francuska kuhinja")]
		Francuska_Kuhinja,
		[Display(Name = "Bosanska kuhinja")]
		Bosanska_Kuhinja,
		[Display(Name = "Kineska kuhinja")]
		Kineska_Kuhinja,
		[Display(Name = "Meksička kuhinja")]
		Meksicka_Kuhinja,
		[Display(Name = "Ostalo")]
		Ostalo

    }

	public enum VrstaJela
    {
		[Display(Name = "Kuhano")]
		Slano_Kuhano,
		[Display(Name = "Prženo")]
		Slano_Przeno,
		[Display(Name = "Pečeno")]
		Slano_Peceno,
		[Display(Name = "Roštilj")]
		Slano_Rostilj,
		[Display(Name = "Slano")]
		Slano_Ostalo,
		[Display(Name = "Torta")]
		Slatko_Torta,
		[Display(Name = "Kolač")]
		Slatko_Kolac,
		[Display(Name = "Slatko")]
		Slatko_Ostalo

    }
	public class Recept
	{
        #region Properties
		[Key]
		[Required]
		public string id { get; set; }

        [Required]
		[StringLength(maximumLength:30,MinimumLength =3,
			ErrorMessage ="Naziv recepta mora sadržavati minimalno 3, a najviše 30 karaktera!")]
		[RegularExpression(@"[a-z|A-Z| |0-9]*",ErrorMessage ="Naziv recepta smije sadržavati samo slova, brojeve i razmake!")]
		public string naziv { get; set; }

		[Required]
		public int vrijemePripreme { get; set; }

		[Required]
		[EnumDataType(typeof(NacionalnoJelo))]
		public NacionalnoJelo nacionalnoJelo { get; set; }

		[Required]
		[EnumDataType(typeof(VrstaJela))]
		public VrstaJela vrstaJela { get; set; }

		[Required]
		public Boolean vegansko { get; set; }

		[Required]
		public Korisnik autor { get; set; }

		[Required]
		public NacinPripreme nacinPripreme { get; set; }

		[DataType(DataType.Date)]
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
