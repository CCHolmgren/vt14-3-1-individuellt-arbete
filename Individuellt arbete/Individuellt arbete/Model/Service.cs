using Individuellt_arbete.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Individuellt_arbete
{
    public class Service
    {
        MedlemDAL _medlem;
        SongDAL _song;
        AlbumDAL _album;

        public MedlemDAL Medlem
        {
            get
            {
                return _medlem ?? (_medlem = new MedlemDAL());
            }
        }
        public AlbumDAL Album
        {
            get { return _album ?? (_album = new AlbumDAL()); }
        }
        public SongDAL Song
        {
            get { return _song ?? (_song = new SongDAL()); }
        }

        //Add all functions to get all data from database and insert into
        public void addSong(Song song, int albumId)
        {
            Song.AddSong(song, albumId);
        }
        public List<Song> getAllSongs()
        {
            return Song.GetAllSongs();
        }
        public List<Song> getAllListened(int medlemId)
        {
            return Song.GetAllSongs();
        }
        public List<Album> getAllAlbums()
        {
            return Album.GetAllAlbums();
        }
        public List<Medlem> getAllMedlems()
        {
            return Medlem.GetAllMedlems();
        }
        public Medlem getMedlem(int id)
        {
            return Medlem.GetMedlem(id);
        }
        public static int createMedlem(Medlem medlem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Album> getAlbumList(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return Album.GetAlbumList(maximumRows, startRowIndex, out totalRowCount);
        }
        public IEnumerable<Song> getSongList(int maximumRows, int startRowIndex, out int totalRowCount, int albumId)
        {
            return Song.GetSongList(maximumRows, startRowIndex, out totalRowCount, albumId);
        }

        public IEnumerable<RecentlyListened> getSongListLatest(int medlemId)
        {
            return Song.GetSongListByUserLatest(medlemId);
        }

        public void ListenToSong(int songId, int medlemId, int length, DateTime date)
        {
            Song.ListenToSong(songId, medlemId, length, date);
        }

        public Album getAlbumById(int id)
        {
            return Album.GetAlbumById(id);
        }

        public void saveAlbum(Album album)
        {
            ICollection<ValidationResult> validationResult;
            if (!album.Validate(out validationResult))
            {
                var vx = new ValidationException("Objektet klarade inte valideringen.");
                vx.Data.Add("validationResult", validationResult);
                throw vx;
            }
            if(album.AlbumId == 0)
            {
                Album.SaveAlbum(album);
            }
            else
            {
                Album.UpdateAlbum(album);
            }
        }
    }
}