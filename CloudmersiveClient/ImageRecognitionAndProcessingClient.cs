using CloudmersiveClient.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public ImageDescriptionResponse RecognizeImageToDescription(string fileName)
        {
            return RecognizeImageToDescription(File.ReadAllBytes(fileName));
        }

        public ImageDescriptionResponse RecognizeImageToDescription(byte[] imageBytes)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = imageBytes;

                var response = client.UploadData("https://api.cloudmersive.com/image/recognize/describe", "POST", bytes);

                ImageDescriptionResponse result = JsonConvert.DeserializeObject<ImageDescriptionResponse>( System.Text.Encoding.ASCII.GetString(response) );


                return result;
            }
        }

        public Image CropToFirstFace(string fileName)
        {
            return CropToFirstFace(File.ReadAllBytes(fileName));
        }

        public Image CropToFirstFace(byte[] imageBytes)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = imageBytes;

                var response = client.UploadData("https://api.cloudmersive.com/image/face/crop/first", "POST", bytes);

                using (MemoryStream stream = new MemoryStream(response))
                {

                    Image img = Image.FromStream(stream);

                    return img;
                }
            }
        }
    }
}
