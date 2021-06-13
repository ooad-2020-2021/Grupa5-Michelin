using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public String id { get; set; }

        [Required]
		[StringLength(maximumLength:30,MinimumLength =3,
			ErrorMessage ="Naziv recepta mora sadržavati minimalno 3, a najviše 30 karaktera!")]
		[Display(Name ="Naziv")]
		public string naziv { get; set; }

		[Required]
		[Display(Name = "Vrijeme pripreme")]
		public int vrijemePripreme { get; set; }

		[Required]
		[EnumDataType(typeof(NacionalnoJelo))]
		[Display(Name = "Kuhinja")]
		public NacionalnoJelo nacionalnoJelo { get; set; }

		[Required]
		[EnumDataType(typeof(VrstaJela))]
		[Display(Name = "Vrsta jela")]
		public VrstaJela vrstaJela { get; set; }

		[Required]
		[Display(Name = "Vegansko")]
		public Boolean vegansko { get; set; }

		[Required]
		[Display(Name = "Objavio")]
		public Korisnik autor { get; set; }

		[Required]
		[Display(Name = "Nacin pripreme")]
		public NacinPripreme nacinPripreme { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Datum objave")]
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
		public Double izracunajOcjenu(List<Ocjena> ocjene)
        {
			//dobavljaju se sve Ocjene ciji atribut recept odgovara ovom
			//te se racuna prosjecna ocjena recepta na osnovu njih
			//zasad vraca 5.0 dok se ne implementira metoda
			Double ocjena = 0.0;
			int broj = 0;

			foreach(Ocjena o in ocjene)
            {
                if (o.recept == this)
                {
					ocjena += o.vrijednost;
					broj++;
                }
            }
			if (broj > 0)
				return ocjena / broj;
			return 0.0;
        }

		public static List<Recept> filtrirajRecepte(List<VrstaJela> vrstaJela,List<NacionalnoJelo> nacionalnoJelo,
			int vrijemePripreme, List<Recept> listaZaFiltriranje)
        {
			//prima listu recepata koju treba filtirati tako da zadovoljava da atribut vrstaJela se nalazi
			//u proslijedjenoj listi i atribut nacionalnoJelo se nalazi u odgovarajucoj listi
			//te da je vrijeme pripreme do proslijedjenog parametra (npr ako je proslijedjeno 50, priprema mora biti<=50min)

			return listaZaFiltriranje;
        }

		public static List<Recept> dajReceptePoNazivu(List<Recept> recepti, String naziv)
        {
			//vraca sve recepte koji u nazivu sadrze proslijedjeni string
			List<Recept> receptiPoNazivu = new List<Recept>();
			foreach (Recept r in recepti)
            {
				if (r.naziv.Equals(naziv))
                {
					receptiPoNazivu.Add(r);
                }
            }
			return receptiPoNazivu;
        }

		public static List<Recept> dajRecepteBezSastojaka(List<Recept> recepti, List<Sastojak> sastojci)
        {
			//vraca sve recepte koji ne sadrze niti jedan od sastojaka u proslijedjenoj listi
			//poredjenje sastojaka se treba vrsiti po nazivu
			List<Recept> receptiBezSastojaka = new List<Recept>();
			foreach (Recept r in recepti)
            {
				Boolean postojiSastojak = false;
				foreach (String idSastojka in r.nacinPripreme.listaSastojaka.Split(" "))
                {
					foreach (Sastojak s in sastojci)
                    {
						if (idSastojka.Equals(s.id))
                        {
							postojiSastojak = true;
                        }
                    }
                }
				if (!postojiSastojak) receptiBezSastojaka.Add(r);

            }
			return receptiBezSastojaka;
		}

		public static List<Recept> dajDesetNajboljih(List<Recept> recepti,List<Ocjena> ocjene)
        {
			recepti.Sort((x, y) => x.izracunajOcjenu(ocjene).CompareTo(y.izracunajOcjenu(ocjene)));

            if (recepti.Count > 10) 
			recepti.RemoveRange(9, recepti.Count-10);
			return recepti;
		}

		
        #endregion
    }
}
