using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace Individuellt_arbete.Model
{
	public class AlbumDAL : DALBase
	{
        public List<Album> GetAllAlbums()
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("getAllAlbums", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    List<Album> albums = new List<Album>();

                    int albumIDindex = reader.GetOrdinal("AlbumId");
                    int albumNameIndex = reader.GetOrdinal("AlbumName");
                    int releaseYearIndex = reader.GetOrdinal("ReleaseYear");

                    while (reader.Read())
                    {
                        albums.Add(new Album
                        {
                            AlbumName = reader.GetString(albumNameIndex),
                            AlbumId = reader.GetInt32(albumIDindex),
                            ReleaseYear = reader.GetInt16(releaseYearIndex)
                        });
                    }
                    return albums;
                }
            }
        }
        public List<Album> GetAlbumList(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            using (var conn = CreateConnection())
            {
                List<Album> albums = new List<Album>();
                SqlCommand cmd = new SqlCommand("getAlbumsPageWise", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@startRowIndex", SqlDbType.Int, 4).Value = startRowIndex;
                cmd.Parameters.Add("@maximumRows", SqlDbType.Int, 4).Value = maximumRows;
                cmd.Parameters.Add("@totalRows", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();

                totalRowCount = (int)cmd.Parameters["@totalRows"].Value;
                using (var reader = cmd.ExecuteReader())
                {
                    int albumNameIndex = reader.GetOrdinal("AlbumName");
                    int releaseYearIndex = reader.GetOrdinal("ReleaseYear");
                    int albumIdIndex = reader.GetOrdinal("AlbumId");

                    while (reader.Read())
                    {
                        albums.Add(new Album
                        {
                            AlbumId = reader.GetInt32(albumIdIndex),
                            AlbumName = reader.GetString(albumNameIndex),
                            ReleaseYear = reader.GetInt16(releaseYearIndex),
                        });
                    }
                }
                return albums;
            }
        }
        internal Album GetAlbumById(int id)
        {
            throw new NotImplementedException();
        }

        internal void SaveAlbum(Album album)
        {
            throw new NotImplementedException();
        }

        internal void UpdateAlbum(Album album)
        {
            throw new NotImplementedException();
        }
	}
}