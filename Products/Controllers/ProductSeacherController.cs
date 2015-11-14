using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Products.Models;

namespace Products.Controllers
{
    public class ProductSeacherController : ApiController
    {
        public IEnumerable<Product> Get()
        {
            return new Product().GetAll();
        }

        public Product Get(int id)
        {
            return new Product().Get(id);
        }

        public Product Get(string barcode)
        {
            return new Product().Get(barcode);
        }

        public IEnumerable<Product> Post(Product product)
        {
            return new Product().Create(product);
        }

        public IEnumerable<Product> Put(Product product)
        {
            return new Product().Update(product);
        }

        public IEnumerable<Product> Delete(int id)
        {
            return new Product().Delete(id);
        }
    }

}
