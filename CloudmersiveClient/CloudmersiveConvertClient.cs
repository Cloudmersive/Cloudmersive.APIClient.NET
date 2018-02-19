using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient
{
    public class CloudmersiveConvertClient : CloudmersiveClientBase
    {
        public CloudmersiveConvertClient(string apikey)
        {
            Apikey = apikey;
        }

        public CloudmersiveConvertClient()
        {
            LoadApikeyFromConfig();
        }

        public byte[] Document_DocxToPdf(byte[] docxBytes)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = docxBytes;

                var response = client.UploadData("https://api.cloudmersive.com/convert/docx/to/pdf", "POST", bytes);

                return response;
            }
        }

        public byte[] Document_PptxToPdf(byte[] xlsxBytes)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = xlsxBytes;

                var response = client.UploadData("https://api.cloudmersive.com/convert/pptx/to/pdf", "POST", bytes);

                return response;
            }
        }

        public byte[] Document_XlsxToPdf(byte[] xlsxBytes)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = xlsxBytes;

                var response = client.UploadData("https://api.cloudmersive.com/convert/xlsx/to/pdf", "POST", bytes);

                return response;
            }
        }
    }
}
