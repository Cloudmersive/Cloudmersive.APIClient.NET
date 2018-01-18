using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient
{
    public class ImageRecognitionAndProcessingClient : CloudmersiveClientBase
    {
        public ImageRecognitionAndProcessingClient(string apikey)
        {
            Apikey = apikey;
        }

        public ImageRecognitionAndProcessingClient()
        {
            LoadApikeyFromConfig();
        }

        public string RecognizeImageToDescription(string fileName)
        {
            return RecognizeImageToDescription(File.ReadAllBytes(fileName));
        }

        public string RecognizeImageToDescription(byte[] imageBytes)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = imageBytes;

                var response = client.UploadData("https://api.cloudmersive.com/image/recognize/describe", "POST", bytes);

                string result = System.Text.Encoding.ASCII.GetString(response);

                result = Helpers.DecodeEscapedStrings(result);

                return result;
            }
        }
    }
}
