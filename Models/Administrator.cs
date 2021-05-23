using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Michelin.Models
{
	public class Administrator
	{
        #region Properties

        [Required]
        [Key]
        public string emailAdresa { get; set; }

 

        #endregion

        #region Constructor
        public Administrator(string email)
        {
            emailAdresa = email;
            
        }
        #endregion

       
    }
}
