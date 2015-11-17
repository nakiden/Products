using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Products.Models;

namespace Products.Controllers
{
    public class BarcodeController : ApiController
    {
        public Product Get(string barcode)
        {
            return new Product().Get(barcode);
        }

        public Product Post(BarcodeScanner br)
        {
            return new Product().GetByImage(br.imageData);
        }
    }
}
