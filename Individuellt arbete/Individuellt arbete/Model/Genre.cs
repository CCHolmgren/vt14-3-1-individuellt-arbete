using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Individuellt_arbete.Model
{
    /// <summary>
    /// Represents an Genre stored in the database
    /// </summary>
    public class Genre
    {
        public int GenreId
        {
            get;
            set;
        }
        public string GenreName
        {
            get;
            set;
        }
    }
}