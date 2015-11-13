using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Products.Models;
using System.IO;

namespace Products.Models
{
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; }
        public string barcode { get; set; }
        public string storeLocation { get; set; }
        public string storeName { get; set; }
        public virtual List<Stores> Store { get; set; }
        ProductContex db = new ProductContex();
        WebSearch webSearch = new WebSearch();

        public List<Product> GetAll()
        {
            List<Product> listProduct = new List<Product>(db.Product);
            return listProduct;
        }

        public Product Get(int id)
        {
            return GetAll().Where(x => x.id == id).FirstOrDefault();
        }

        public string Get(string barcode)
        {
            return webSearch.SearchByBarcode(barcode, 1);
        }

        public List<Product> Create(Product product)
        {
            db.Product.Add(product);
            db.SaveChanges();
            return GetAll();
        }

        public List<Product> Update(Product product)
        {
            Product p = Get(product.id);
            db.Product.Remove(p);
            db.Product.Add(product);
            db.SaveChanges();
            return GetAll();
        }

        public List<Product> Delete(int id)
        {
            Product p = Get(id);
            db.Product.Remove(p);
            db.SaveChanges();
            return GetAll();
        }
     }
}