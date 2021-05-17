using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace Michelin.Models
{
	public class Korisnik
	{

		#region Properties

		[Key]
		[Required]
		[StringLength(maximumLength:30, MinimumLength =3, ErrorMessage ="Korisničko ime se mora sastojati od najmanje 3 i" +
			"najviše 30 karaktera!")]
		public String korisnickoIme { get; set; }

		[Required]
		[RegularExpression(@"[A-Z|a-z| ]*", ErrorMessage ="Dozvoljavaju se imena koja se sastoje isključivo od slova!")]
		public String ime { get; set; }

		[Required]
		[RegularExpression(@"[A-Z|a-z| ]*", ErrorMessage = "Dozvoljavaju se prezimena koja se sastoje isključivo od slova!")]
		public String prezime { get; set; }

		[Required]
		public String emailAdresa { get; set; }

		[RegularExpression(@"[0-9]*", ErrorMessage = "Dozvoljeni su samo brojevi bez razmaka!")]
		public String brojMobitela { get; set; }

		[StringLength(maximumLength: 400, MinimumLength = 0, ErrorMessage = "Biografija ne smije biti duža od 400 karaktera!")]
		public String kratkaBiografija { get; set; }

		[Required]
		[RegularExpression(@"[0-9]*", ErrorMessage = "Dozvoljeni su samo brojevi bez razmaka!")]
		public String brojKreditneKartice { get; set; }

		[Required]
		public DateTime datumAktivacije { get; set; }
		public DateTime datumDeaktivacije { get; set; }

		[Required]
		public Boolean aktivan { get; set; }

		[NotMapped]
		public List<Recept> omiljeniRecepti { get; set; }

        #endregion

        #region Constructor

		public Korisnik(string ime, string prezime, string korisnickoIme, string emailAdresa, 
			string brojKreditneKartice, string brojMobitela = null )
		{ this.ime = ime;
			this.prezime = prezime;
			this.korisnickoIme = korisnickoIme;
			this.emailAdresa = emailAdresa;
			this.brojKreditneKartice = brojKreditneKartice;
			this.brojMobitela = brojMobitela;
			datumAktivacije = DateTime.Now;
			aktivan = true;
		}

        #endregion
    }
}

