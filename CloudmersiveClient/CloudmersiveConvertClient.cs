using CloudmersiveClient.Convert;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public byte[] Document_XlsxToCsv(byte[] xlsxBytes)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = xlsxBytes;

                var response = client.UploadData("https://api.cloudmersive.com/convert/xlsx/to/csv", "POST", bytes);

                return response;
            }
        }

        public byte[] Document_AutodetectToPdf(byte[] inputBytes, string fileName)
        {
            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();

            form.Add(new ByteArrayContent(inputBytes, 0, inputBytes.Length), "inputFile", fileName);

            httpClient.DefaultRequestHeaders.Add("Apikey", Apikey);

            HttpResponseMessage response = httpClient.PostAsync("https://api.cloudmersive.com/convert/autodetect/to/pdf", form).Result;

            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            var sd = response.Content.ReadAsByteArrayAsync().Result;// ReadAsStringAsync().Result;

            return sd;
        }

        public byte[] Document_AutodetectToPdf(string filePath)
        {
            return Document_AutodetectToPdf(File.ReadAllBytes(filePath), Path.GetFileName(filePath));
        }

        public byte[] Image(byte[] inputBytes, string fileName, string outputFileType)
        {
            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();

            form.Add(new ByteArrayContent(inputBytes, 0, inputBytes.Length), "inputFile", fileName);

            httpClient.DefaultRequestHeaders.Add("Apikey", Apikey);

            string format1 = Path.GetExtension(fileName).Replace(".", "");

            HttpResponseMessage response = httpClient.PostAsync("https://api.cloudmersive.com/convert/image/" + format1 + "/to/" + outputFileType, form).Result;

            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            var sd = response.Content.ReadAsByteArrayAsync().Result;// ReadAsStringAsync().Result;

            return sd;
        }

        public byte[] WebScreenshot(ScreenshotRequest req)
        {
            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();

            //form.Add(new ByteArrayContent(inputBytes, 0, inputBytes.Length), "inputFile", fileName);
            

            httpClient.DefaultRequestHeaders.Add("Apikey", Apikey);

            string stringPayload = JsonConvert.SerializeObject(req);

            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync("https://api.cloudmersive.com/convert/web/url/to/screenshot", httpContent).Result;

            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            var sd = response.Content.ReadAsByteArrayAsync().Result;// ReadAsStringAsync().Result;

            return sd;
        }

        public HtmlTemplateApplicationResponse ApplyHtmlTemplate(HtmlTemplateApplicationRequest input)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/json";


                string info = JsonConvert.SerializeObject(input);
                var bytes = System.Text.Encoding.ASCII.GetBytes( info );

                var response = client.UploadData("https://api.cloudmersive.com/convert/template/html/apply", "POST", bytes);

                string result = System.Text.Encoding.ASCII.GetString(response);



                return JsonConvert.DeserializeObject<HtmlTemplateApplicationResponse>(result);
            }
        }

        public string CsvToJson(byte[] inputBytes)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = inputBytes; // System.Text.Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(input));

                var response = client.UploadData("https://api.cloudmersive.com/convert/csv/to/json", "POST", bytes);

                string result = System.Text.Encoding.ASCII.GetString(response);



                return result;
            }
        }

        public string XmlToJson(byte[] inputBytes)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = inputBytes; // System.Text.Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(input));

                var response = client.UploadData("https://api.cloudmersive.com/convert/xml/to/json", "POST", bytes);

                string result = System.Text.Encoding.ASCII.GetString(response);



                return result;
            }
        }
    }
}
