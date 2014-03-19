using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Individuellt_arbete.Model
{
    /// <summary>
    /// Represents a Medlem stored in the Database
    /// </summary>
    public class Medlem
    {
        [Required(ErrorMessage="Du måste fylla i ett förnamn.")]
        public string FirstName
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Du måste fylla i ett efternamn.")]
        public string LastName 
        { 
            get; 
            set; 
        }
        public int MedlemId
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Du måste fylla i en emailaddress."), EmailAddress(ErrorMessage="Du måste fylla i en giltig emailaddress")]
        public string PrimaryEmail
        {
            get;
            set;
        }
    }
}