using MovieProjectDB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace MovieProjectDB.DAL
{
    public class MovieTableHelper
    {
        public static List<Movie> GetMovies()
        {
            string Movieconnection = DAL.DALUtils.getconnection();

            List<Movie> list = new List<Movie>();

            using (System.Data.SqlClient.SqlConnection connection = new SqlConnection(Movieconnection))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * from MovieTable");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            list.Add(new Movie
                            {

                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Category=reader.GetString(2),




                            });
                        }
                    }
                }

            }
            return (list);
        }
        public static int Insert(string strMovieName, string strCategoryName)
        {
            int nRowsAffected;
            string Movieconnection = DAL.DALUtils.getconnection();

            using (SqlConnection connection = new SqlConnection(Movieconnection))
            {

                connection.Open();

                StringBuilder sb = new StringBuilder();

                sb.Append("INSERT INTO MovieTable (Name,Category)");

                sb.Append("VALUES (@NameRonnie, @CategoryPasaha);");

                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.Parameters.AddWithValue("@NameRonnie", strMovieName);

                    command.Parameters.AddWithValue("@CategoryPasaha", strCategoryName);

                    nRowsAffected = command.ExecuteNonQuery();

                }
            }

            return nRowsAffected;


        }

        public static bool MovExist (string MovieName)
        {
            List<Movie> ex = DAL.MovieTableHelper.GetMovies();
            bool exist = false;

            foreach (var item in ex)
            {

                if (item.Name == MovieName)
                    exist = true;

            }
            return (exist);

        }
    }
}