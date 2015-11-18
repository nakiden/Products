using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class WebResource
    {
        public int id { get; set; }
        public string domain { get; set; }
        public string link { get; set; }
        public string token { get; set; }
        public string contentType { get; set; }
    }
    ////////////////////////////////////////
    //   LIST OF RESOURCES IS BELOW      //
    ///////////////////////////////////////
    public class Datakick_dot_com
    {
        public string gtin14 { get; set; }
        public string brand_name { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public double serving_size { get; set; }
        public double servings_per_container { get; set; }
        public double calories { get; set; }
        public double fat_calories { get; set; }
        public double potassium { get; set; }
        public double sugars { get; set; }
        public double protein { get; set; }
        public string publisher { get; set; }
        public Product.ImageURL [] images { get; set; }
        public WebResource datakick_webResource { get; set; }

        public Product ToProduct()
        {
            return new Product() { barcode = this.gtin14, publisher = this.publisher, title = this.name, brand = this.brand_name };
        }
    }
}