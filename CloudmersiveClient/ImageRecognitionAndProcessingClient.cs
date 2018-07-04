using CloudmersiveClient.ImageProcessing;
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


        public Image ConvertToPainting(byte[] imageBytes, string style = "udnie")
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = imageBytes;

                var response = client.UploadData("https://api.cloudmersive.com/image/artistic/painting/" + style, 
                    "POST", bytes);

                using (MemoryStream stream = new MemoryStream(response))
                {

                    Image img = Image.FromStream(stream);

                    return img;
                }
            }
        }



        public ObjectDetectionResult DetectObjects(byte[] imageBytes)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = imageBytes;

                var response = client.UploadData("https://api.cloudmersive.com/image/recognize/detect-objects",
                    "POST", bytes);

                string strResult = Encoding.UTF8.GetString(response);

                return JsonConvert.DeserializeObject<ObjectDetectionResult>(strResult);
            }
        }



        public Image DrawRectangles(DrawRectangleRequest request)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";


                var response = client.UploadData("https://api.cloudmersive.com/image/edit/draw/rectangle",
                    "POST", Encoding.UTF8.GetBytes( JsonConvert.SerializeObject(request) ) );

                using (MemoryStream stream = new MemoryStream(response))
                {

                    Image img = Image.FromStream(stream);

                    return img;
                }
            }
        }


        public NsfwResult NsfwClassification(string fileName)
        {
            return NsfwClassification(File.ReadAllBytes(fileName));
        }

        public NsfwResult NsfwClassification(byte[] imageBytes)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = imageBytes;

                var response = client.UploadData("https://api.cloudmersive.com/image/nsfw/classify", "POST", bytes);

                NsfwResult result = JsonConvert.DeserializeObject<NsfwResult>(System.Text.Encoding.ASCII.GetString(response));


                return result;
            }
        }


    }
}
