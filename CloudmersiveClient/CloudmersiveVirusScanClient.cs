using System;
using System.Collections.Generic;
using System.Linq;
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

        public ImageDescriptionResponse ScanFile(string fileName)
        {
            return ScanFileBytes(File.ReadAllBytes(fileName));
        }

        public ImageDescriptionResponse ScanFileBytes(byte[] imageBytes)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = imageBytes;

                var response = client.UploadData("https://api.cloudmersive.com/image/recognize/describe", "POST", bytes);

                ImageDescriptionResponse result = JsonConvert.DeserializeObject<ImageDescriptionResponse>(System.Text.Encoding.ASCII.GetString(response));


                return result;
            }
        }
    }
}
