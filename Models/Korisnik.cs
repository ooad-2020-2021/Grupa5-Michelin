using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Michelin.Interfaces;

namespace Michelin.Models
{
	public class Korisnik : IdentityUser, IPretplatnik
	{

		#region Properties

		[Required]
		[StringLength(maximumLength: 30, MinimumLength = 3, ErrorMessage = "Korisničko ime se mora sastojati od najmanje 3 i" +
			"najviše 30 karaktera!")]
		public string korisnickoIme { get; set; }

		[Required]
		[RegularExpression(@"[A-Z|a-z| ]*", ErrorMessage = "Dozvoljavaju se imena koja se sastoje isključivo od slova!")]
		public string ime { get; set; }

		[Required]
		[RegularExpression(@"[A-Z|a-z| ]*", ErrorMessage = "Dozvoljavaju se prezimena koja se sastoje isključivo od slova!")]
		public string prezime { get; set; }

		[RegularExpression(@"[0-9]*", ErrorMessage = "Dozvoljeni su samo brojevi bez razmaka!")]
		public string brojMobitela { get; set; }

		[StringLength(maximumLength: 400, MinimumLength = 0, ErrorMessage = "Biografija ne smije biti duža od 400 karaktera!")]
		public string kratkaBiografija { get; set; }

		//zasad nam ne treba broj kreditne kartice
		/*[Required]
		[RegularExpression(@"[0-9]*", ErrorMessage = "Dozvoljeni su samo brojevi bez razmaka!")]
		public string brojKreditneKartice { get; set; }*/

		[Required]
		[DataType(DataType.Date)]
		public DateTime datumAktivacije { get; set; }

		[DataType(DataType.Date)]
		public DateTime datumDeaktivacije { get; set; }

		[Required]
		public Boolean aktivan { get; set; }


		public string omiljeniRecepti { get; set; }

		public string profilnaSlika {get; set;}

        #endregion

        #region Constructor

		public Korisnik(string ime, string prezime, string korisnickoIme, string brojMobitela = null ) 
		{ this.ime = ime;
			this.prezime = prezime;
			this.korisnickoIme = korisnickoIme;
			this.brojMobitela = brojMobitela;
			datumAktivacije = DateTime.Now;
			aktivan = true;
		}

		public Korisnik() { }

        #endregion

        #region Metode
        public List<Recept> pretvoriStringUListu()
        {
			List<Recept> omiljeni = new List<Recept>();
			//dohvatiti recepte iz baze kojima odgovaraju primarni kljucevi u stringu

			return omiljeni;
        }

		public void dodajOmiljeniRecept(Recept recept)
        {
			//dodavanje recepta u listu omiljenih
			//posto je lista zapravog string, na njega nadovezati id recepta
        }

		public void ukloniOmiljeniRecept(Recept recept)
        {
			//pronalazi se u string listaOmiljenihRecepata odgovarajuci kljuc(id) recepta
			//te se uklanja iz stringa
        }

		public void ukljuciObavijesti()
        {
			//dodaje korisnika u pretplatnik repozitorij
        }

		public void iskljuciObavijesti()
        {
			//uklanja korisnika iz pretplatnik repozitorija
        }

		public void posaljiMail()
        {
			//salje korisniku mail sa sadrzajem obavijesti
			//eventualno se treba dodati da ova metoda prima parametar s tekstom obavijesti
        }

		public void posaljiPoruku()
        {
			//salje korisniku SMS poruku sa sadrzajem obavijesti
			//eventualno se treba dodati da ova metoda prima parametar s tekstom obavijesti
		}

        #endregion
    }
}

