using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;


namespace task.dao
{
    internal class EventDAo
    {
        public int Insert(Event event1)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                connection.Open();
                string query = "insert into Events (Id,Name,Desc,Adress,StartDate,StartTime,EndTime),) values (@Id,@Name,@Desc,@Adress,@StartDate,@StartTime,@EndTime)";

                using(SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", event1.Id);
                    cmd.Parameters.AddWithValue("@Name", event1.Name);
                    cmd.Parameters.AddWithValue("@Desc", event1.Desc);
                    cmd.Parameters.AddWithValue("@Address", event1.Address);
                    cmd.Parameters.AddWithValue("@StartDate", event1.StartDate);
                    cmd.Parameters.AddWithValue("@StartTime", event1.StartTime);
                    cmd.Parameters.AddWithValue("@EndTime", event1.EndTime);

                    return cmd.ExecuteNonQuery();
                }
            }
                
        }
        
        public int Update(Event event1)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                connection.Open();
                string query = "UPDATE Events SET Name = @Name, [Desc] = @Desc, Address = @Address, StartDate = @StartDate, StartTime = @StartTime, EndTime = @EndTime WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", event1.Id);
                    cmd.Parameters.AddWithValue("@Name", event1.Name);
                    cmd.Parameters.AddWithValue("@Desc", event1.Desc);
                    cmd.Parameters.AddWithValue("@Address", event1.Address);
                    cmd.Parameters.AddWithValue("@StartDate", event1.StartDate);
                    cmd.Parameters.AddWithValue("@StartTime", event1.StartTime);
                    cmd.Parameters.AddWithValue("@EndTime", event1.EndTime);

                    return cmd.ExecuteNonQuery();
                }
            }

        }

        public Event GetById(int Id)
        {
            Event event1 = new Event();
            event1 = null;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open ();

                
                string query = "select TOP(1) * from Events where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Id", Id);

                using (var reader = cmd.ExecuteReader())
                {

                    event1.Id = reader.GetInt32(1);
                    event1.Name = reader.GetString(2);
                    event1.Desc = reader.GetString(3);
                    event1.Address = reader.GetString(4);

                    string e5 = reader.GetString(5);
                    event1.StartDate = Convert.ToDateTime(e5);

                    string e6 = reader.GetString(6);
                    event1.StartTime = Convert.ToDateTime(e6);

                    string e7 = reader.GetString(7);
                    event1.EndTime = Convert.ToDateTime(e7);

                    
                }
                return event1;
            }


        }

        public List<Event> GetAll()
        {

            List<Event> events = new List<Event>();

            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                connection.Open();

                string query = "SELECT * FROM Events";

                SqlCommand cmd = new SqlCommand(query, connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Event event1 = new Event();
                        event1.Id = reader.GetInt32(0);
                        event1.Name = reader.GetString(1);
                        event1.Desc = reader.GetString(2);
                        event1.Address = reader.GetString(3);
                        event1.StartDate = reader.GetDateTime(4);
                        event1.StartTime = reader.GetDateTime(5);
                        
                        string e5 = reader.GetString(5);
                        event1.StartDate = Convert.ToDateTime(e5);

                        string e6 = reader.GetString(6);
                        event1.StartTime = Convert.ToDateTime(e6);

                        string e7 = reader.GetString(7);
                        event1.EndTime = Convert.ToDateTime(e7);

                        events.Add(event1);
                    }
                }
            }

            return events;

        }

        public void Delete(int eventId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                connection.Open();
                string query = "DELETE FROM Events WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", eventId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }



}
