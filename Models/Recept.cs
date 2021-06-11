using System;
using System.Collections.Generic;
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
		public String id { get; set; }

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

		public string slika { get; set; }
		public string video { get; set; }

        #endregion

        #region Constructor
		public Recept(string naziv, int vrijemePripreme, NacionalnoJelo nacionalnoJelo,
			VrstaJela vrsta, Boolean vegansko, Korisnik autor, NacinPripreme nacinPripreme)
        {
			this.id = new Guid().ToString();
		
			this.naziv = naziv;
			this.vrijemePripreme = vrijemePripreme;
			this.nacionalnoJelo = nacionalnoJelo;
			this.vrstaJela = vrsta;
			this.vegansko = vegansko;
			this.autor = autor;
			this.nacinPripreme = nacinPripreme;
			datum = DateTime.Now;
        }

		public Recept() { }

        #endregion

        #region Metode
		public Double izracunajOcjenu()
        {
			//dobavljaju se sve Ocjene ciji atribut recept odgovara ovom
			//te se racuna prosjecna ocjena recepta na osnovu njih
			//zasad vraca 5.0 dok se ne implementira metoda

			return 5.0;
        }

		public static List<Recept> filtrirajRecepte(List<VrstaJela> vrstaJela,List<NacionalnoJelo> nacionalnoJelo,
			int vrijemePripreme, List<Recept> listaZaFiltriranje)
        {
			//prima listu recepata koju treba filtirati tako da zadovoljava da atribut vrstaJela se nalazi
			//u proslijedjenoj listi i atribut nacionalnoJelo se nalazi u odgovarajucoj listi
			//te da je vrijeme pripreme do proslijedjenog parametra (npr ako je proslijedjeno 50, priprema mora biti<=50min)

			return listaZaFiltriranje;
        }

		public static List<Recept> dajReceptePoNazivu(String naziv)
        {
			//vraca sve recepte koji u nazivu sadrze proslijedjeni string

			return new List<Recept>();
        }

		public static List<Recept> dajRecepteBezSastojaka(List<Sastojak> sastojci)
        {
			//vraca sve recepte koji ne sadrze niti jedan od sastojaka u proslijedjenoj listi
			//poredjenje sastojaka se treba vrsiti po nazivu
			return new List<Recept>();
		}

		public static List<Recept> dajDesetNajboljih()
        {
			//vraca 10 recepata sa trenutno najboljom ocjenom

			return new List<Recept>();
		}
        #endregion
    }
}
