using System;
using System.Collections.Generic;
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
        public string AlbumName
        {
            get;
            set;
        }
        public int ReleaseYear
        {
            get;
            set;
        }
    }
}