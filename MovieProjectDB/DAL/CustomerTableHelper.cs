using MovieProjectDB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace MovieProjectDB.DAL
{
    public class CustomerTableHelper
    {
        public static int Insert(string strName, string strSubscription, string strage)
        {
            int nRowsAffected;
            string Movieconnection = DAL.DALUtils.getconnection();

            using (SqlConnection connection = new SqlConnection(Movieconnection))
            {
                connection.Open();

                StringBuilder sb = new StringBuilder();

                sb.Append("INSERT INTO CustomerTable (Name,Subscription,Age)");

                sb.Append("VALUES (@Name, @Subscription,@Age);");

                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.Parameters.AddWithValue("@Name", strName);

                    command.Parameters.AddWithValue("@Subscription", strSubscription);
                    command.Parameters.AddWithValue("@Age", strage);


                    nRowsAffected = command.ExecuteNonQuery();

                }
            }

            return nRowsAffected;

        }
        public static List<Customer> GetCustomers()
        {
            string Customerconnection = DAL.DALUtils.getconnection();

            List<Customer> list = new List<Customer>();

            using (System.Data.SqlClient.SqlConnection connection = new SqlConnection(Customerconnection))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * from CustomerTable");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            list.Add(new Customer
                            {

                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Subscription = reader.GetString(2),
                                Age = reader.GetInt32(3)




                            });
                        }
                    }
                }

            }
            return (list);
        }

        public static bool CustomerExist(string CustomerName)
        {
            List<Customer> ex = DAL.CustomerTableHelper.GetCustomers();
            bool exist = ex.Exists(item => item.Name == CustomerName);

            return (exist);
        }

    }
}