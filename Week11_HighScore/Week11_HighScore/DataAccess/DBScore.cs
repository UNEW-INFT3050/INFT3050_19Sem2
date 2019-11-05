using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Week11_HighScore.DataAccess
{
    // 
    // Data access layer class for accessing the score table
    public class DBScore
    {
        private String m_connectionString;
        public DBScore()
        {
            // grab connection string from web.config
            m_connectionString = ConfigurationManager.ConnectionStrings["HighScore"].ConnectionString;
        }

        //
        // get high scores from the database
        public List<Models.ScoreRecord> GetHighScores()
        {
            // return obj
            List<Models.ScoreRecord> records = new List<Models.ScoreRecord>();

            // using releases held resources
            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // get connection string
                // get top ten high scores ordered from highest to lowest
                string sql = "SELECT TOP 10 [Score],[Name] FROM[StroidsHighScore].[dbo].[ScoreView] ORDER BY[Score] DESC";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // run command
                    SqlDataReader reader = command.ExecuteReader();

                    // build up list
                    while (reader.Read())
                    {
                        Models.ScoreRecord record = new Models.ScoreRecord();
                        record.Name = reader["Name"].ToString();
                        record.Score = (int)reader["Score"];
                        records.Add(record);
                    }
                }
            }
            

            return records;
        }


        //
        // Add a new high score
        public void AddNewScore(Models.ScoreRecord record)
        {
            // using releases held resources
            using (SqlConnection connection = new SqlConnection(m_connectionString))
            {
                // get connection string
                // get top ten high scores ordered from highest to lowest
                string sql = "INSERT INTO[dbo].[Score] ([Score],[Name]) VALUES(@ScoreValue,@Name)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("ScoreValue", record.Score);
                    command.Parameters.AddWithValue("Name", record.Name);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
     