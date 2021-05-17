using System;
using System.ComponentModel.DataAnnotations;


namespace Michelin.Models
{
	public enum MjernaJedinica
    {
		kg,
		g,
		l,
		ml,
		komad
    }
	public class Sastojak
	{
        #region Properties

		[Required]
        public String naziv { get; set; }

		[Required]
		public double kolicina { get; set; }

		[Required]
		public MjernaJedinica mjernaJedinica { get; set; }

        #endregion

        #region Constructor

		public Sastojak (string naziv, double kolicina, MjernaJedinica mjernaJedinica)
        {
			this.naziv = naziv;
			this.kolicina = kolicina;
			this.mjernaJedinica = mjernaJedinica;
        }
        #endregion

    }
}
