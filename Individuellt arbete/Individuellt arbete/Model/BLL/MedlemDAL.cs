using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;

namespace Individuellt_arbete.Model
{
    public class MedlemDAL : DALBase
    {
        /// <summary>
        /// Deletes the contact with the given contactId
        /// </summary>
        /// <param name="contactId">Integer representing a contact</param>
        public void DeleteContact(int contactId)
        {

            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("Person.uspRemoveContact", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contactId;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Get a given contact given a contactId
        /// </summary>
        /// <param name="contactId">Integer representing a contact</param>
        /// <returns></returns>
        public Medlem GetContactById(int contactId)
        {
            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("Person.uspGetContact", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ContactId", SqlDbType.Int, 4).Value = contactId;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    int contactIDindex = reader.GetOrdinal("ContactId");
                    int firstNameIndex = reader.GetOrdinal("FirstName");
                    int lastNameIndex = reader.GetOrdinal("LastName");
                    int emailAdressIndex = reader.GetOrdinal("EmailAddress");

                    if (reader.Read())
                    {
                        return new Medlem
                        {
                            MedlemId = reader.GetInt32(contactIDindex),
                            FirstName = reader.GetString(firstNameIndex),
                            LastName = reader.GetString(lastNameIndex),
                            PrimaryEmail = reader.GetString(emailAdressIndex)
                        };
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// Get all contacts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Medlem> GetContacts()
        {
            using (var conn = CreateConnection())
            {
                List<Medlem> contacts = new List<Medlem>();

                var cmd = new SqlCommand("Person.uspGetContacts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    int contactIDindex = reader.GetOrdinal("ContactId");
                    int firstNameIndex = reader.GetOrdinal("FirstName");
                    int lastNameIndex = reader.GetOrdinal("LastName");
                    int emailAdressIndex = reader.GetOrdinal("EmailAddress");

                    while (reader.Read())
                    {
                        contacts.Add(new Medlem
                        {
                            MedlemId = reader.GetInt32(contactIDindex),
                            FirstName = reader.GetString(firstNameIndex),
                            LastName = reader.GetString(lastNameIndex),
                            PrimaryEmail = reader.GetString(emailAdressIndex)
                        });
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// GetContactsPageWise is used by the ListView to populate it with pagination
        /// Gets maximumRows amount of contacts given a startRowIndex
        /// Sets totalRowCount based on the query
        /// </summary>
        /// <param name="maximumRows">Amount of rows to get</param>
        /// <param name="startRowIndex">Index to start on.</param>
        /// <param name="totalRowCount"></param>
        /// <returns></returns>
        public IEnumerable<Medlem> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var contacts = new List<Medlem>();
                    var cmd = new SqlCommand("Person.uspGetContactsPageWise", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PageIndex", SqlDbType.Int, 4).Value = startRowIndex / maximumRows + 1;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int, 4).Value = maximumRows;
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    totalRowCount = (int)cmd.Parameters["@RecordCount"].Value;
                    using (var reader = cmd.ExecuteReader())
                    {
                        var contactIdIndex = reader.GetOrdinal("ContactID");
                        int firstNameIndex = reader.GetOrdinal("FirstName");
                        int lastNameIndex = reader.GetOrdinal("LastName");
                        int emailAdressIndex = reader.GetOrdinal("EmailAddress");

                        while (reader.Read())
                        {
                            contacts.Add(new Medlem
                            {
                                MedlemId = reader.GetInt32(contactIdIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex),
                                PrimaryEmail = reader.GetString(emailAdressIndex)
                            });
                        }
                    }
                    return contacts;
                }
                catch
                {
                    throw;
                }
            }
        }
        
        
        
        public List<Medlem> GetAllMedlems()
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("getAllMedlems", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    List<Medlem> medlems = new List<Medlem>();

                    int medlemIDindex = reader.GetOrdinal("MedlemId");
                    int firstNameIndex = reader.GetOrdinal("FirstName");
                    int lastNameIndex = reader.GetOrdinal("LastName");
                    int primaryEmailIndex = reader.GetOrdinal("PrimaryEmail");

                    while (reader.Read())
                    {
                        medlems.Add(new Medlem
                        {
                            MedlemId = reader.GetInt32(medlemIDindex),
                            FirstName = reader.GetString(firstNameIndex),
                            LastName = reader.GetString(lastNameIndex),
                            PrimaryEmail = reader.GetString(primaryEmailIndex)
                        });
                    }
                    return medlems;
                }
            }
        }
        public void AddMedlem(Medlem medlem)
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("addMedlemWithUniqueEmail", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@firstName", SqlDbType.VarChar, 45).Value = medlem.FirstName;
                cmd.Parameters.Add("@lastName", SqlDbType.VarChar, 45).Value = medlem.LastName;
                cmd.Parameters.Add("@primaryEmail", SqlDbType.VarChar, 50).Value = medlem.PrimaryEmail;

                cmd.Parameters.Add("@medlemId", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();

                medlem.MedlemId = (int)cmd.Parameters["@medlemId"].Value;
            }
        }
        public Medlem GetMedlem(int id)
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("getMedlem", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@medlemId", SqlDbType.Int, 4).Value = id;

                conn.Open();
                
                using (var reader = cmd.ExecuteReader())
                {
                    int medlemIDindex = reader.GetOrdinal("MedlemId");
                    int firstNameIndex = reader.GetOrdinal("FirstName");
                    int lastNameIndex = reader.GetOrdinal("LastName");
                    int primaryEmailIndex = reader.GetOrdinal("PrimaryEmail");

                    if (reader.Read())
                    {
                        return new Medlem
                        {
                            MedlemId = reader.GetInt32(medlemIDindex),
                            FirstName = reader.GetString(firstNameIndex),
                            LastName = reader.GetString(lastNameIndex),
                            PrimaryEmail = reader.GetString(primaryEmailIndex)
                        };
                    }
                    return null;
                }
            }
        }
        /// <summary>
        /// Creates a new element in the database and put the contact into it
        /// </summary>
        /// <param name="contact"></param>
        public void InsertMedlem(Medlem medlem)
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("Person.AddSong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = medlem.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = medlem.LastName;
                cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 50).Value = medlem.PrimaryEmail;

                cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();

                medlem.MedlemId = (int)cmd.Parameters["@ContactID"].Value;
            }
        }
        /// <summary>
        /// Update a already existing contact with the new information
        /// </summary>
        /// <param name="contact"></param>
        public void UpdateContact(Medlem medlem)
        {
            using (var conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("Person.uspUpdateContact", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@MedlemId", SqlDbType.Int, 4).Value = medlem.MedlemId;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = medlem.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = medlem.LastName;
                cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 50).Value = medlem.PrimaryEmail;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
    }
}