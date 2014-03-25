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
        [Required(ErrorMessage="Du måste fylla i ett förnamn."), MaxLength(45, ErrorMessage="Förnamnet kan inte vara längre än 45 tecken.")]
        public string FirstName
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Du måste fylla i ett efternamn."), MaxLength(45, ErrorMessage = "Efternamnet kan inte vara längre än 45 tecken.")]
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
        [Required(ErrorMessage = "Du måste fylla i en emailaddress."), EmailAddress(ErrorMessage="Du måste fylla i en giltig emailaddress"),MaxLength(50, ErrorMessage="Emailaddressen kan inte vara längre än 50 tecken.")]
        public string PrimaryEmail
        {
            get;
            set;
        }
    }
}