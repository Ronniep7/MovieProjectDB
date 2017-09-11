using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProjectDB.Models
{
    public class Rental
    {
        public int MovieID { get; set; }
        public int Id { get; set; }
        public int CustomerID { get; set; }
    }
}