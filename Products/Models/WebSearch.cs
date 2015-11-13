using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Products.Models;
using System.IO;
using System.Web.UI;

namespace Products.Models
{
    public class WebSearch
    {
        //WebResource resource = new WebResource();
        public List<WebResource> WebApiList = new List<WebResource>() {
            new WebResource { id = 1, domain = "https://www.datakick.org", contentType = "application/json", link = "/api/items/"},
            new WebResource { id = 2, domain = "https://api.outpan.com", contentType = "application/json", link = "/v2/products/", token = "ee8d801d4f3a780c3d55f9e9e2507e7b"}
            // place for another API
        };

        public string getURL(string barcode, int webApiID)
        {
            string url;
            switch (webApiID)
            {
                case 1: url = WebApiList[0].domain + WebApiList[0].link + barcode;
                    break;
                case 2: url = WebApiList[1].domain + WebApiList[1].link + barcode + "?apikey=" + WebApiList[1].token;
                    break;
                default: url = null;
                    break;
            }
            return url;
        }

        public string SearchByBarcode(string barcode, int ApiID)
        {
            string url = getURL(barcode, ApiID), result;

            try {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                result = StreamToString(resStream);
            } catch (Exception ex) {
                result = ex.ToString();
            }

            return result;
        }

        public string StreamToString(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            return responseFromServer;
        }
    }
}