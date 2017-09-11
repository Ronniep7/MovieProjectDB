using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProjectDB.DAL
{
    public class DALUtils
    {

        public static string getconnection()
        {
            string strConnection =

@"Data Source = (LocalDB)\MSSQLLocalDB;" +

@"AttachDbFilename = |DataDirectory|\MovieRentalDB.mdf;" +

"Initial Catalog = MovieRentalDB;" +

" Integrated Security = True ;";

            return (strConnection);

        }


    }
}