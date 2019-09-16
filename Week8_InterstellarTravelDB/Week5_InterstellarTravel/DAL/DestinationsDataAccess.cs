using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Week8_InterstellarTravel.Models;

namespace Week8_InterstellarTravel.DAL
{
    [DataObject(true)]
    public class DestinationsDataAccess : IDestinationsDataAccess
    {
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["InterstellarConnectionString"].ConnectionString;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Models.Destination> GetDestinations()
        {
            List<Models.Destination> destinations = new List<Models.Destination>();
            string sql = @"SELECT [Id], [Name] ,[DistanceFromEarth], [ShortDescription]
                    ,[LongDescription] ,[Price],[Image] FROM[dbo].[Destination]";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Models.Destination destination = CreateDestination(reader);
                        destinations.Add(destination);
                    }

                }
            }
            return destinations;
        }

        
        private static Models.Destination CreateDestination(SqlDataReader reader)
        {
            Models.Destination destination = new Models.Destination();
            destination.Id = (int)reader["Id"];
            destination.LongDescription = reader["LongDescription"].ToString();
            destination.ShortDescription = reader["ShortDescription"].ToString();
            destination.Name = reader["Name"].ToString();
            destination.DistanceInKm = (long)reader["DistanceFromEarth"];
            destination.Price = (decimal)reader["Price"];
            destination.ImagePath = reader["Image"].ToString(); 
            return destination;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Models.Destination GetDestinationById(int id)
        {
            string sql = @"SELECT [Id], [Name] ,[DistanceFromEarth], [ShortDescription]
                    ,[LongDescription] ,[Price],[Image] FROM[dbo].[Destination] where [Id]=@Id";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("Id", id));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return CreateDestination(reader);
                    }
                }
            }
            return null;
        }
    }
}