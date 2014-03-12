using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Individuellt_arbete.Model
{
    public class PlayingSong
    {
        public int stopValue
        {
            get;
            set;
        }
        public int currentValue
        {
            get;
            set;
        }
        public Song SongPlaying
        {
            get;
            set;
        }
        public bool isPlaying
        {
            get
            {
                return currentValue < stopValue;
            }
        }
        public bool stop
        {
            get;
            set;
        }
    }
}
