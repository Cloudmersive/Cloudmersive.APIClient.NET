﻿using CloudmersiveClient.ImageProcessing;
using CloudmersiveClient.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public FaceLocateResponse LocateFaces(byte[] imageBytes)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = imageBytes;

                var response = client.UploadData("https://api.cloudmersive.com/image/face/locate", "POST", bytes);

                FaceLocateResponse result = JsonConvert.DeserializeObject<FaceLocateResponse>(System.Text.Encoding.ASCII.GetString(response));


                return result;
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

        public byte[] Resize(byte[] imageBytes, int maxWidth, int maxHeight)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Apikey", Apikey);

            MultipartFormDataContent form = new MultipartFormDataContent();

            form.Add(new ByteArrayContent(imageBytes), "input", "input");
            HttpResponseMessage response = httpClient.PostAsync(
                "https://api.cloudmersive.com/image/resize/preserveAspectRatio/" + maxWidth + "/" + maxHeight, form).Result;

            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            return response.Content.ReadAsByteArrayAsync().Result; //  .ReadAsStringAsync().Result;


            //using (WebClient client = new WebClient())
            //{
            //    client.Headers.Add("Apikey", Apikey);
            //    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



            //    var bytes = imageBytes;

            //    var response = client.UploadData(
            //        "https://api.cloudmersive.com/image/resize/preserveAspectRatio/" + maxWidth + "/" + maxHeight, "POST", bytes);

            //    return response;
            //}
        }



        public Image DrawRectangles(DrawRectangleRequest request)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);

                string url = "https://api.cloudmersive.com/image/edit/draw/rectangle";

                //url = "http://localhost:64058/image/edit/draw/rectangle";

                string strInput =  JsonConvert.SerializeObject(request);

                client.Headers.Add("Content-Type", "application/json");

                var response = client.UploadData(url,
                    "POST", System.Text.Encoding.ASCII.GetBytes(strInput)  );

                using (MemoryStream stream = new MemoryStream(/*Encoding.UTF8.GetBytes*/(response)))
                {

                    Image img = Image.FromStream(stream);

                    return img;
                }
            }
        }

        public Image DrawText(DrawTextRequest request)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);

                string url = "https://api.cloudmersive.com/image/edit/draw/text";

                //url = "http://localhost:64058/image/edit/draw/text";

                string strInput = JsonConvert.SerializeObject(request);

                client.Headers.Add("Content-Type", "application/json");

                var response = client.UploadData(url,
                    "POST", System.Text.Encoding.ASCII.GetBytes(strInput));

                using (MemoryStream stream = new MemoryStream(/*Encoding.UTF8.GetBytes*/(response)))
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
