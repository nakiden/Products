﻿using System;
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
        public string brand { get; set; }
        public string barcode { get; set; }
        public string publisher { get; set; }
        public string storeLocation { get; set; }
        public string storeName { get; set; }
        public double price { get; set; }
        public ImageURL [] images { get; set; }
        //public virtual List<Stores> Store { get; set; }
        ProductContex db = new ProductContex();
        WebSearch webSearch = new WebSearch();


        public struct ImageURL
        {
            public string url { get; set; }
        }

        public List<Product> GetAll()
        {
            List<Product> listProduct = new List<Product>(db.Product);
            return listProduct;
        }

        public Product Get(int id)
        {
            return GetAll().Where(x => x.id == id).FirstOrDefault();
        }

        public Product Get(string barcode)
        {
            Product returnedProduct = isRecordInDB(barcode);

            if(returnedProduct == null)
            {
               returnedProduct = CreateFromAPI(barcode, 1);
            } 
            return returnedProduct;
        }

        public Product isRecordInDB(string barcode)
        {

            foreach (var pr in db.Product)
            {
                if (pr.barcode == barcode)
                {
                    return pr;
                }
            }
            return null;
        }

        public List<Product> Create(Product product)
        {
            db.Product.Add(product);
            db.SaveChanges();
            return GetAll();
        }

        public Product CreateFromAPI(string barcode, int ApiID)
        {
            Product pr = new Product();
            pr = webSearch.SearchByBarcode(barcode, 1);

            if (pr != null) {
                db.Product.Add(pr);
                db.SaveChanges();
                return pr;
            }
            return null;
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