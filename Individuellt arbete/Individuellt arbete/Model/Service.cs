﻿using Individuellt_arbete.Model;
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

        //Song
        public List<Song> getAllSongs()
        {
            return Song.GetAllSongs();
        }
        public List<Song> getAllListened(int medlemId)
        {
            return Song.GetAllSongs();
        }
        public IEnumerable<Song> getSongList(int maximumRows, int startRowIndex, out int totalRowCount, int albumId)
        {
            return Song.GetSongList(maximumRows, startRowIndex, out totalRowCount, albumId);
        }
        public IEnumerable<RecentlyListened> getSongListLatest(int medlemId)
        {
            return Song.GetSongListByUserLatest(medlemId);
        }
        public void saveSong(Song song, int albumId)
        {
            ICollection<ValidationResult> validationResult;
            if (!song.Validate(out validationResult))
            {
                var vx = new ValidationException("Objectet klarade inte validering.");
                vx.Data.Add("validationResult", validationResult);
                throw vx;
            }
            if (song.SongId == 0)
            {
                Song.AddSong(song, albumId);
            }
            else
            {
                Song.UpdateSong(song, albumId);
            }
        }
        public void removeSong(int SongId)
        {
            Song.RemoveSong(SongId);
        }
        public void ListenToSong(int songId, int medlemId, int length, DateTime date)
        {
            Song.ListenToSong(songId, medlemId, length, date);
        }
        public void gradeSong(int songId, int medlemId, int grade)
        {
            Song.GradeSong(songId, medlemId, grade);
        }

        //Album
        public List<Album> getAllAlbums()
        {
            return Album.GetAllAlbums();
        }
        public IEnumerable<Album> getAlbumList(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return Album.GetAlbumList(maximumRows, startRowIndex, out totalRowCount);
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
            if (album.AlbumId == 0)
            {
                Album.SaveAlbum(album);
            }
            else
            {
                Album.UpdateAlbum(album);
            }
        }
        public void deleteAlbum(int AlbumId)
        {
            Album.DeleteAlbum(AlbumId);
        }

        //Medlem
        public List<Medlem> getAllMedlems()
        {
            return Medlem.GetAllMedlems();
        }
        public Medlem getMedlem(int id)
        {
            return Medlem.GetMedlem(id);
        }
        public void createMedlem(Medlem medlem)
        {
            ICollection<ValidationResult> validationResult;
            if (!medlem.Validate(out validationResult))
            {
                var vx = new ValidationException("Objektet klarade inte valideringen.");
                vx.Data.Add("validationResult", validationResult);
                throw vx;
            }
            Medlem.AddMedlem(medlem);
        }

        public List<Model.AlbumHasGenre> getGenresFromAlbum(int albumId)
        {
            return Album.GetGenres(albumId);
        }

        public List<Genre> getAllGenres()
        {
            return Album.GetAllGenres();
        }

        public void addGenreToAlbum(int genreId, int albumId)
        {
            Album.addGenreToAlbum(genreId, albumId);
        }

        public Song getSong(int SongId)
        {
            return Song.GetSong(SongId);
        }
    }
}