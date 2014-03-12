using Individuellt_arbete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Individuellt_arbete
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
        public void addSong(Song song, int albumId)
        {
            Contact.AddSong(song, albumId);
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
        public Medlem getMedlem(int id)
        {
            return Contact.GetMedlem(id);
        }
        public static int createMedlem(Medlem medlem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Album> getAlbumList(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return Contact.GetAlbumList(maximumRows, startRowIndex, out totalRowCount);
        }
        public IEnumerable<Song> getSongList(int maximumRows, int startRowIndex, out int totalRowCount, int albumId)
        {
            return Contact.GetSongList(maximumRows, startRowIndex, out totalRowCount, albumId);
        }

        public IEnumerable<RecentlyListened> getSongListLatest(int medlemId)
        {
            return Contact.GetSongListByUserLatest(medlemId);
        }
    }
}