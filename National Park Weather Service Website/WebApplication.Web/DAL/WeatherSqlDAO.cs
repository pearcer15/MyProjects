using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        private string connectionString;
        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// A method to retrieve the weather data for one park
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns>a list of weather objects</returns>
        public IList<Weather> GetParkForecast(string parkCode)
        {
            IList<Weather> forecast = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from weather where parkCode = @parkCode;", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather weather = ConvertReaderToWeather(reader);
                        forecast.Add(weather);
                    }
                }
            }
            catch (SqlException ex)
            {
                //ToDo: actually do something with this catch
                throw;
            }

            return forecast;
        }

        /// <summary>
        /// Converts sql data into a weather object
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Weather ConvertReaderToWeather(SqlDataReader reader)
        {
            Weather weather = new Weather()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                ForecastDay = Convert.ToInt32(reader["fiveDayForecastValue"]),
                Low = Convert.ToDouble(reader["low"]),
                High = Convert.ToDouble(reader["high"]),
                Forecast = Convert.ToString(reader["forecast"])
            };
            return weather;
        }
    }
}
