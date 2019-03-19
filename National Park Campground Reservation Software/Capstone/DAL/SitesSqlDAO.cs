using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Capstone.Models;

namespace Capstone.DAL
{
    public class SitesSqlDAO : ISiteDAO
    {
        private string connectionString;

        public SitesSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Gets the list of available sites.
        /// </summary>
        /// <param name="park_id">park's id</param>
        /// <param name="campground_id">campground's id</param>
        /// <param name="startingDate">reservation starting date</param>
        /// <param name="endingDate">reservation ending date</param>
        /// <returns></returns>
        public IList<Site> GetAvailableSites(int park_id, int campground_id, DateTime startingDate, DateTime endingDate)
        {
            List<Site> sites = new List<Site>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = conn.CreateCommand();

                    if(campground_id != 0)
                    {
                        cmd.CommandText = @"select top 5 *
                                          from site
                                          where site.campground_id = @campground_id and
                                          site_id not in
                                          (select site.site_id 
                                          from site 
                                          left join reservation on site.site_id = reservation.site_id
                                          where site.campground_id = @campground_id and (
                                          @startDate <= reservation.to_date and 
                                          @endDate >= reservation.from_date));";
                    }
                    else
                    {
                        cmd.CommandText = @"select *
                                          from site
                                          join campground on site.campground_id = campground.campground_id
                                          where campground.park_id = @park_id and
                                          site_id not in
                                          (select site.site_id
                                          from site
                                          join campground on site.campground_id = campground.campground_id
                                          left join reservation on site.site_id = reservation.site_id
                                          where campground.park_id = @park_id and(
                                          @startDate between reservation.from_date and reservation.to_date or
                                          @endDate between reservation.from_date and reservation.to_date));";
                    }

                    cmd.Parameters.AddWithValue("@campground_id", campground_id);
                    cmd.Parameters.AddWithValue("@startDate", startingDate);
                    cmd.Parameters.AddWithValue("@endDate", endingDate);
                    cmd.Parameters.AddWithValue("@park_id", park_id);
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();            

                    while (reader.Read())
                    {
                        Site site = ConvertReaderToSite(reader);
                        sites.Add(site);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error retreiving sites");
                Console.WriteLine(ex.Message);
            }

            return sites;
        }

        /// <summary>
        ///  Converts a row in sql into a site object.
        /// </summary>
        /// <param name="reader">The line being read from the database.</param>
        /// <returns>site</returns>
        private Site ConvertReaderToSite(SqlDataReader reader)
        {
            Site site = new Site();

            site.ID = Convert.ToInt32(reader["site_id"]);
            site.CampgroundID = Convert.ToInt32(reader["campground_id"]);
            site.SiteNumber = Convert.ToInt32(reader["site_number"]);
            site.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
            site.Accessible = Convert.ToBoolean(reader["accessible"]);
            site.MaxRVLength = Convert.ToInt32(reader["max_rv_length"]);
            site.Utilities = Convert.ToBoolean(reader["utilities"]);

            return site;
        }
    }
    
}
