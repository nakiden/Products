using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Products.Models;

namespace Products.Models
{
    public class Stores
    {
        public int id { get; set; }
        public string name { get; set; }
        public double productPrice { get; set; }
        public string storeLocation { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}