using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProjectDB.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Subscription { get; set; }
        public int Age { get; set; }

    }
}