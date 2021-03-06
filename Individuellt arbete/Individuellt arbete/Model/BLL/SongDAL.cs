﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace Individuellt_arbete.Model
{
    public class SongDAL : DALBase
    {
        public void AddSong(Song song, int albumId)
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("addSongWithAlbum", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@songName", SqlDbType.VarChar, 50).Value = song.SongName;
                cmd.Parameters.Add("@songLength", SqlDbType.Int, 4).Value = song.Length;
                cmd.Parameters.Add("@bandName", SqlDbType.VarChar, 50).Value = song.BandName;
                cmd.Parameters.Add("@albumId", SqlDbType.Int, 4).Value = albumId;
                cmd.Parameters.Add("@trackNr", SqlDbType.TinyInt, 1).Value = song.TrackNr;
                cmd.Parameters.Add("@songId", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();

                song.SongId = (int)cmd.Parameters["@songId"].Value;
            }
        }
        public List<Song> GetAllSongs()
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("getAllSongs", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    List<Song> songs = new List<Song>();

                    int songIDindex = reader.GetOrdinal("SongId");
                    int songNameIndex = reader.GetOrdinal("SongName");
                    int lengthIndex = reader.GetOrdinal("Length");
                    int bandNameIndex = reader.GetOrdinal("BandName");
                    int trackNrIndex = reader.GetOrdinal("TrackNr");

                    while (reader.Read())
                    {
                        songs.Add(new Song
                        {
                            BandName = reader.GetString(bandNameIndex),
                            SongId = reader.GetInt32(songIDindex),
                            Length = reader.GetInt16(lengthIndex),
                            SongName = reader.GetString(songNameIndex),
                            TrackNr = reader.GetInt16(trackNrIndex)
                        });
                    }
                    return songs;
                }
            }
        }
        public IEnumerable<Song> GetSongList(int maximumRows, int startRowIndex, out int totalRowCount, int albumId)
        {
            using (var conn = CreateConnection())
            {
                List<Song> songs = new List<Song>();
                SqlCommand cmd = new SqlCommand("getSongsPageWise", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@startRowIndex", SqlDbType.Int, 4).Value = startRowIndex;
                cmd.Parameters.Add("@maximumRows", SqlDbType.Int, 4).Value = maximumRows;
                cmd.Parameters.Add("@albumId", SqlDbType.Int, 4).Value = albumId;
                cmd.Parameters.Add("@totalRows", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();

                totalRowCount = (int)cmd.Parameters["@totalRows"].Value;
                using (var reader = cmd.ExecuteReader())
                {
                    int songNameIndex = reader.GetOrdinal("SongName");
                    int bandNameIndex = reader.GetOrdinal("BandName");
                    int lengthIndex = reader.GetOrdinal("Length");
                    int songIdIndex = reader.GetOrdinal("SongId");
                    int trackNrIndex = reader.GetOrdinal("TrackNr");

                    while (reader.Read())
                    {
                        songs.Add(new Song
                        {
                            SongId = reader.GetInt32(songIdIndex),
                            SongName = reader.GetString(songNameIndex),
                            Length = reader.GetInt16(lengthIndex),
                            BandName = reader.GetString(bandNameIndex),
                            TrackNr = reader.GetByte(trackNrIndex)
                        });
                    }
                }
                return songs;
            }
        }
        public IEnumerable<RecentlyListened> GetSongListByUserLatest(int medlemId)
        {
            using (var conn = CreateConnection())
            {
                List<RecentlyListened> recentlylistened = new List<RecentlyListened>();
                SqlCommand cmd = new SqlCommand("getSongListByUserLatest", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@medlemId", SqlDbType.Int, 4).Value = medlemId;

                conn.Open();
                cmd.ExecuteNonQuery();

                using (var reader = cmd.ExecuteReader())
                {
                    int songNameIndex = reader.GetOrdinal("SongName");
                    int dateIndex = reader.GetOrdinal("Date");
                    int lengthIndex = reader.GetOrdinal("Length");
                    int bandNameIndex = reader.GetOrdinal("BandName");
                    int betygIndex = reader.GetOrdinal("Betyg");
                    int songIdIndex = reader.GetOrdinal("SongId");
                    //Date, SongName, ConstrictedRows.Length, BandName, Betyg

                    while (reader.Read())
                    {
                        RecentlyListened rl = new RecentlyListened();
                        rl.SongName = reader.GetString(songNameIndex);
                        rl.Date = reader.GetDateTime(dateIndex);
                        rl.BandName = reader.GetString(bandNameIndex);
                        rl.Betyg = reader.GetInt32(betygIndex);
                        rl.Length = reader.GetInt16(lengthIndex);
                        rl.SongId = reader.GetInt32(songIdIndex);

                            recentlylistened.Add(rl);
                        /*recentlylistened.Add(new RecentlyListened
                        {
                            SongName = reader.GetString(songNameIndex),
                            Date = reader.GetDateTime(dateIndex),
                            BandName = reader.GetString(bandNameIndex),
                            Betyg = reader.GetInt32(betygIndex),
                            Length = reader.GetInt16(lengthIndex)
                        });*/
                    }
                }
                return recentlylistened;
            }
        }

        public void ListenToSong(int songId, int medlemId, int length, DateTime date)
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("listenToSong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@songId", SqlDbType.Int, 4).Value = songId;
                cmd.Parameters.Add("@medlemId", SqlDbType.Int, 4).Value = medlemId;
                cmd.Parameters.Add("@length", SqlDbType.Int, 2).Value = length;
                cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateSong(Song song, int albumId)
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("updateSong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@songId", SqlDbType.Int, 4).Value = song.SongId;
                cmd.Parameters.Add("@songName", SqlDbType.VarChar, 50).Value = song.SongName;
                cmd.Parameters.Add("@bandName", SqlDbType.VarChar, 50).Value = song.BandName;
                cmd.Parameters.Add("@length", SqlDbType.Int, 2).Value = song.Length;
                cmd.Parameters.Add("@trackNr", SqlDbType.TinyInt, 1).Value = song.TrackNr;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveSong(int SongId)
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("removeSong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@songId", SqlDbType.Int, 4).Value = SongId;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void GradeSong(int songId, int medlemId, int grade)
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("gradeSong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@songId", SqlDbType.Int, 4).Value = songId;
                cmd.Parameters.Add("@medlemId", SqlDbType.Int, 4).Value = medlemId;
                cmd.Parameters.Add("@grade", SqlDbType.Int, 4).Value = grade;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal Song GetSong(int SongId)
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("getSongGivenId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@songId", SqlDbType.Int, 4).Value = SongId;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    List<Song> songs = new List<Song>();

                    int songIDindex = reader.GetOrdinal("SongId");
                    int songNameIndex = reader.GetOrdinal("SongName");
                    int lengthIndex = reader.GetOrdinal("Length");
                    int bandNameIndex = reader.GetOrdinal("BandName");
                    int trackNrIndex = reader.GetOrdinal("TrackNr");

                    if (reader.Read())
                    {
                        return new Song
                        {
                            BandName = reader.GetString(bandNameIndex),
                            SongId = reader.GetInt32(songIDindex),
                            Length = reader.GetInt16(lengthIndex),
                            SongName = reader.GetString(songNameIndex),
                            TrackNr = reader.GetByte(trackNrIndex)
                        };
                    }
                    return null;
                }
            }
        }
    }
}