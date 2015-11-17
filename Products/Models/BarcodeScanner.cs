using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spire.Barcode;
using System.IO;

namespace Products.Models
{
    public class BarcodeScanner
    {
        public string imageData { get; set; }

        public static void UploadPic(string imageData)
        {
            string Pic_Path = HttpContext.Current.Server.MapPath("MyPicture.png");
            byte[] data = Convert.FromBase64String(imageData);
            File.WriteAllBytes(Pic_Path, data);
        }

        public string ScanBarcode(string imagedata)
        {
            UploadPic(imagedata);
            string Src = HttpContext.Current.Server.MapPath("MyPicture.png");

            if (File.ReadAllBytes(Src).Length > 0)
            {
                string[] readedCode = Spire.Barcode.BarcodeScanner.Scan(Src, Spire.Barcode.BarCodeType.UPCA);

                return readedCode[0];
            }

            return null;
        }
    }
}