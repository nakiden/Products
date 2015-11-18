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
        public string brand { get; set; }
        public string barcode { get; set; }
        public string publisher { get; set; }
        public double price { get; set; }
        public virtual List<Stores> Store { get; set; }
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
            Product returnedProduct = FindRecordInDB(barcode);

            if(returnedProduct == null)
            {
               returnedProduct = CreateFromAPI(barcode, 1);
            } 
            return returnedProduct;
        }

        public Product GetByImage(string imagedata)
        {
            BarcodeScanner br = new BarcodeScanner();
            return Get(br.ScanBarcode(imagedata));
        }

        public Product FindRecordInDB(string barcode)
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

        public Product Create(Product product)
        {
            Product pr = FindRecordInDB(product.barcode);
            if (pr == null)
            {
                pr = product;
 
            }
            pr.Store.Add(setStore(product));
            db.Product.Add(product);
            db.SaveChanges();
            return Get(product.barcode);
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

        public Stores setStore(Product product)
        {
            return new Stores() { productPrice = product.Store[0].productPrice, name = product.Store[0].name, latitude = product.Store[0].latitude, longitude = product.Store[0].longitude, storeLocation = product.Store[0].storeLocation };
        }

      /*  public IEnumerable<Stores> getStoresByProductId(int id)
        {
            return db.Store.Where(i => i.Product_id == id);
        }*/

        public Product Update(Product product, Stores store)
        {
            Product p = Get(product.id);
         //   db.Store.RemoveRange(getStoresByProductId(product.id));
            db.Product.Remove(p);
            product.Store.Add(store);
            db.Product.Add(product);
            try {
                db.SaveChanges();
            } catch (Exception ex)
            {
                string exe = ex.InnerException.ToString();
                Console.WriteLine(exe);
            }
            return Get(product.id);
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