using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Individuellt_arbete.Model
{
    /// <summary>
    /// Represents an Album stored in the database
    /// </summary>
    public class Album
    {
        public int AlbumId
        {
            get;
            set;
        }
        [Required(ErrorMessage="Du måste fylla i ett albumnamn."), MaxLength(50, ErrorMessage="Albumnamnet kan inte vara längre än 50 tecken.") ]
        public string AlbumName
        {
            get;
            set;
        }
        [Required(ErrorMessage="Du måste fylla i ett giltigt releaseyear")]
        public int ReleaseYear
        {
            get;
            set;
        }
    }
}