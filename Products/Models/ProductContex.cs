using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Products.Models;

namespace Products.Models
{
    public class ProductContex : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Stores> Store { get; set; }
    }
}