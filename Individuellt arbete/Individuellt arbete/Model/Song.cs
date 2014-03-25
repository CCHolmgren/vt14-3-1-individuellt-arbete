using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Individuellt_arbete.Model
{
    /// <summary>
    /// Represents a Song stored in the database
    /// </summary>
    public class Song
    {
        public int SongId
        {
            get;
            set;
        }
        [Required(ErrorMessage="Du måste fylla i ett låtnamn."), MaxLength(45, ErrorMessage="Låtnamnet kan inte vara längre än 45 tecken.")]
        public string SongName
        {
            get;
            set;
        }
        [Range(1, 32000, ErrorMessage="Längden måste vara mellan 1 och 32000 sekunder.")]
        public int Length
        {
            get;
            set;
        }
        [Required(ErrorMessage="Du måste fylla i ett bandnamn."), MaxLength(50, ErrorMessage="Bandnamnet kan inte vara längre än 50 tecken.")]
        public string BandName
        {
            get;
            set;
        }
        [Range(1, 100, ErrorMessage="Låtnumret måste vara mellan 1 och 100.")]
        public short TrackNr
        {
            get;
            set;
        }
    }
}