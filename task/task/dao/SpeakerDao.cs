using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.dao
{
    internal class SpeakerDao
    {

        public void Insert(Speaker speaker)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                connection.Open();
                string query = "INSERT INTO Speakers (Id, Fullname, Position, Company, ImageUrl) VALUES (@Id, @Fullname, @Position, @Company, @ImageUrl)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", speaker.Id);
                    cmd.Parameters.AddWithValue("@Fullname", speaker.Fullname);
                    cmd.Parameters.AddWithValue("@Position", speaker.Position);
                    cmd.Parameters.AddWithValue("@Company", speaker.Company);
                    cmd.Parameters.AddWithValue("@ImageUrl", speaker.ImageUrl);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Speaker speaker)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                connection.Open();
                string query = "UPDATE Speakers SET Fullname = @Fullname, Position = @Position, Company = @Company, ImageUrl = @ImageUrl WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", speaker.Id);
                    cmd.Parameters.AddWithValue("@Fullname", speaker.Fullname);
                    cmd.Parameters.AddWithValue("@Position", speaker.Position);
                    cmd.Parameters.AddWithValue("@Company", speaker.Company);
                    cmd.Parameters.AddWithValue("@ImageUrl", speaker.ImageUrl);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Speaker GetById(int id)
        {
            Speaker speaker = null;
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                connection.Open();
                string query = "SELECT Id, Fullname, Position, Company, ImageUrl FROM Speakers WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            speaker = new Speaker
                            {
                                Id = (int)reader["Id"],
                                Fullname = (string)reader["Fullname"],
                                Position = (string)reader["Position"],
                                Company = (string)reader["Company"],
                                ImageUrl = (string)reader["ImageUrl"]
                            };
                        }
                    }
                }
            }
            return speaker;
        }

        public List<Speaker> GetAll()
        {
            List<Speaker> speakers = new List<Speaker>();
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                connection.Open();
                string query = "SELECT Id, Fullname, Position, Company, ImageUrl FROM Speakers";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            speakers.Add(new Speaker
                            {
                                Id = (int)reader["Id"],
                                Fullname = (string)reader["Fullname"],
                                Position = (string)reader["Position"],
                                Company = (string)reader["Company"],
                                ImageUrl = (string)reader["ImageUrl"]
                            });
                        }
                    }
                }
            }
            return speakers;
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                connection.Open();
                string query = "DELETE FROM Speakers WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}

