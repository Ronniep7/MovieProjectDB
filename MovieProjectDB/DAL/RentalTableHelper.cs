using MovieProjectDB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace MovieProjectDB.DAL
{
    public class RentalTableHelper
    {

        public static List<Rental> GetRentals()
        {
            string Rentalconnection = DAL.DALUtils.getconnection();

            List<Rental> list = new List<Rental>();

            using (System.Data.SqlClient.SqlConnection connection = new SqlConnection(Rentalconnection))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * from RentalTable");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            list.Add(new Rental
                            {

                                //Id = reader.GetInt32(0),
                                //MovieID = reader.GetInt32(1),
                                //CustomerID = reader.GetInt32(2)

                                Id=reader.GetInt32(0),
                                MovieID=reader.GetInt32(1),
                                CustomerID = reader.GetInt32(2)
                             
                            });
                        }
                    }
                }

            }
            return (list);
        }

        public static bool RentalExist(int MovieID)
        {
            List<Rental> ex = DAL.RentalTableHelper.GetRentals();
            bool exist = ex.Exists(item => item.MovieID == MovieID);

            return (exist);
        }

        public static int getID(string table,string movie)
        {
            int MovieID = 0;
            string Rentalconnection = DAL.DALUtils.getconnection();

            using (System.Data.SqlClient.SqlConnection connection = new SqlConnection(Rentalconnection))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * from "+table+" where Name='"+movie+"';");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            MovieID = reader.GetInt32(0);
                        

                        }
                    }
                }

            }
            return (MovieID);
        }

        public static int Insert(int movid,int cusid)
        {
            int nRowsAffected;
            string Movieconnection = DAL.DALUtils.getconnection();

            using (SqlConnection connection = new SqlConnection(Movieconnection))
            {
                connection.Open();

                StringBuilder sb = new StringBuilder();

                sb.Append("INSERT INTO RentalTable (MovieID,CustomerID)");

                sb.Append("VALUES (@MovieID, @CustomerID);");

                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.Parameters.AddWithValue("@MovieID", movid);

                    command.Parameters.AddWithValue("@CustomerID", cusid);
                    


                    nRowsAffected = command.ExecuteNonQuery();

                }
            }

            return nRowsAffected;

        }

     
    }
}