using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient
{
    public class CloudmersiveValidationApiClient : CloudmersiveClientBase
    {
        public CloudmersiveValidationApiClient(string apikey)
        {
            Apikey = apikey;
        }

        public class FullEmailValidationResponse
        {
            public bool ValidAddress;
            public string MailServerUsedForValidation;
        }

        public FullEmailValidationResponse ValidateEmailAddress_Full(string emailAddress)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = System.Text.Encoding.ASCII.GetBytes("=" + emailAddress);

                var response = client.UploadData("https://api.cloudmersive.com/validate/email/address/full", "POST", bytes);

                string result = System.Text.Encoding.ASCII.GetString(response);



                return JsonConvert.DeserializeObject<FullEmailValidationResponse>(result);
            }
        }
    }
}
