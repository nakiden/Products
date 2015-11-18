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

        public Product Post(Product product)
        {
            return new Product().Create(product);
        }

        public Product Put(Product product)
        {
            Stores st = new Stores() { name = product.Store[0].name, latitude = product.Store[0].latitude, longitude = product.Store[0].longitude, storeLocation = product.Store[0].storeLocation };

            return new Product().Update(product,st);
        }

        public IEnumerable<Product> Delete(int id)
        {
            return new Product().Delete(id);
        }
    }

}
