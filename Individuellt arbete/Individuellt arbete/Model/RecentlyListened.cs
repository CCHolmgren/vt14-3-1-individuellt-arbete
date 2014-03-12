using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Individuellt_arbete.Model
{
    public class RecentlyListened
    {
        public DateTime Date{
            get;
            set;
        }
        public string SongName {
            get;
            set;
        }
        public int Length {
            get;
            set;
        }
        public string BandName {
            get;
            set;
        }
        public int Betyg{
            get;
            set;
        }
    }
}