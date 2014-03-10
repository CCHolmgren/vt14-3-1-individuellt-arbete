using Individuellt_arbete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Individuellt_arbete.Model
{
    public class Service
    {
        ContactDAL _contact;
        public ContactDAL Contact
        {
            get
            {
                return _contact ?? (_contact = new ContactDAL());
            }
        }
        //Add all functions to get all data from database and insert into
        public void addSong(Song song)
        {
        }
        public List<Song> getAllSongs()
        {
            return Contact.GetAllSongs();
        }
        public List<Song> getAllListened(int medlemId)
        {
            return Contact.GetAllSongs();
        }
        public List<Album> getAllAlbums()
        {
            return Contact.GetAllAlbums();
        }
        public List<Medlem> getAllMedlems()
        {
            return Contact.GetAllMedlems();
        }

        internal static void createMedlem()
        {
            throw new NotImplementedException();
        }
    }
}