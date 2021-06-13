using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Michelin.Interfaces;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using Michelin.Util;

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

		public List<Recept> dajKorisnikoveRecepte(List<Recept> sviRecepti)
        {
			List<Recept> recepti = new List<Recept>();
			foreach (Recept r in sviRecepti)
            {
				if (r.autor == this)
					recepti.Add(r);
            }
			return recepti;
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
			PretplatnikRepozitorij.getInstance().dodajPretplatnika(this);
		}

		public void iskljuciObavijesti()
        {
			PretplatnikRepozitorij.getInstance().ukloniPretplatnika(this);
		}

		public void posaljiMail()
        {
			MimeMessage message = new MimeMessage();

			MailboxAddress from = new MailboxAddress("Michelin",
			"admin@example.com");
			message.From.Add(from);

			MailboxAddress to = new MailboxAddress(korisnickoIme,
			Email);
			message.To.Add(to);

			message.Subject = "Michelin: Novost";
			BodyBuilder bodyBuilder = new BodyBuilder();
			bodyBuilder.HtmlBody = "<h1>Ažurirana je kategorija najboljih recepata!</h1>";
			bodyBuilder.TextBody = "Ažurirana je kategorija najboljih recepata!";
			message.Body = bodyBuilder.ToMessageBody();

			SmtpClient client = new SmtpClient();
			client.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
			client.Authenticate("lemuel.rippin@ethereal.email", "GN2Nf74YUpwNg2tANr");
			client.Send(message);
			client.Disconnect(true);
			client.Dispose();
		}

		public void posaljiPoruku()
        {
			if (brojMobitela != null)
			{
				string broj = brojMobitela.Substring(1);
				string accountSid = Environment.GetEnvironmentVariable("AC641892399a6fc5dd07a4c18fdad2eb31");
				string authToken = Environment.GetEnvironmentVariable("2a4bec242c39c2896de7a28909463d73");

				TwilioClient.Init(accountSid, authToken);

				var message = MessageResource.Create(
					body: "Michelin: Kategorija s najboljim receptima je ažurirana!",
					from: new Twilio.Types.PhoneNumber("+16158007624"),
					to: new Twilio.Types.PhoneNumber("+387" + broj)
				);

				Console.WriteLine(message.Sid);
			}
		}

        #endregion
    }
}

