using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Individuellt_arbete.Model
{
    /// <summary>
    /// Represents an Album stored in the database
    /// </summary>
    public class AlbumHasGenre
    {
        public int Album_has_GenreId
        {
            get;
            set;
        }
        public int AlbumId
        {
            get;
            set;
        }
        public string Genre
        {
            get;
            set;
        }
        public int GenreId
        {
            get;
            set;
        }
    }
}