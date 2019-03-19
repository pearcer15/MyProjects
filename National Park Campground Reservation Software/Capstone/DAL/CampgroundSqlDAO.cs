using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Capstone.Models;

namespace Capstone.DAL
{
    public class CampgroundSqlDAO : ICampgroundDAO
    {
        private string connectionString;

        public CampgroundSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Gets the list of campgrounds by park id.
        /// </summary>
        /// <param name="parkID">The id of the park.</param>
        /// <returns>campgrounds</returns>
        public IList<Campground> GetAllCampgroundsByPark(int parkID)
        {
            List<Campground> campgrounds = new List<Campground>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from campground where park_id = @park_id;", conn);
                    cmd.Parameters.AddWithValue("@park_id", parkID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Campground campground = ConvertReaderToCampground(reader);
                        campgrounds.Add(campground);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error retreiving parks");
                Console.WriteLine(ex.Message);
            }

            return campgrounds;
        }

        /// <summary>
        /// Converts a row in sql into a campground object.
        /// </summary>
        /// <param name="reader">The line being read from the database.</param>
        /// <returns>campground</returns>
        private Campground ConvertReaderToCampground(SqlDataReader reader)
        {
            Campground campground = new Campground();
            campground.ID = Convert.ToInt32(reader["campground_id"]);
            campground.ParkID = Convert.ToInt32(reader["park_id"]);
            campground.Name = Convert.ToString(reader["name"]);
            campground.OpeningMonth = Convert.ToInt32(reader["open_from_mm"]);
            campground.ClosingMonth = Convert.ToInt32(reader["open_to_mm"]);
            campground.DailyFee = Convert.ToDecimal(reader["daily_fee"]);

            return campground;
        }
    }
}
