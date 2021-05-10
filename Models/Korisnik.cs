using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
	public Korisnik() {
		//
		// TODO: Add constructor logic here
		//
		public String KorisnickoIme { get; set; }
		public String ime { get; set; }
		public String prezime { get; set; }
		public String emailAdresa { get; set; }
		public String brojMobitela { get; set; }
		public String kratkaBiografija { get; set; }
		public String brojKreditneKartice { get; set; }
		public DateTime datumAktivacije { get; set; }
		public DateTime datumDeaktivacije { get; set; }
		public Boolean aktivan { get; set; }
		public List<Recept> omiljeniRecepti { get; set; }
	}
}
