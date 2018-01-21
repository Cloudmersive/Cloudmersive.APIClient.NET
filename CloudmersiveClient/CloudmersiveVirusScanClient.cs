using CloudmersiveClient.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient
{
    public class CloudmersiveVirusScanClient : CloudmersiveClientBase
    {
        public CloudmersiveVirusScanClient(string apikey)
        {
            Apikey = apikey;
        }

        public CloudmersiveVirusScanClient()
        {
            LoadApikeyFromConfig();
        }

        public VirusScanResult ScanFile(string fileName)
        {
            return ScanFileBytes(File.ReadAllBytes(fileName));
        }

        public VirusScanResult ScanFileBytes(byte[] imageBytes)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = imageBytes;

                var response = client.UploadData("https://api.cloudmersive.com/virus/scan/file", "POST", bytes);

                VirusScanResult result = JsonConvert.DeserializeObject<VirusScanResult>(System.Text.Encoding.ASCII.GetString(response));


                return result;
            }
        }
    }
}
