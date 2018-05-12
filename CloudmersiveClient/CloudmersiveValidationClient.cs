using CloudmersiveClient.Validation;
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

        public CloudmersiveValidationApiClient()
        {
            LoadApikeyFromConfig();
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

        public GeolocateIPResponse GeolocateIP(string ip)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = System.Text.Encoding.ASCII.GetBytes("=" + ip);

                var response = client.UploadData("https://api.cloudmersive.com/validate/ip/geolocate", "POST", bytes);

                string result = System.Text.Encoding.ASCII.GetString(response);



                return JsonConvert.DeserializeObject<GeolocateIPResponse>(result);
            }
        }

        public WhoisResponse GetDomainWhois(string domain)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = System.Text.Encoding.ASCII.GetBytes("=" + domain);

                var response = client.UploadData("https://api.cloudmersive.com/validate/domain/whois", "POST", bytes);

                string result = System.Text.Encoding.ASCII.GetString(response);



                return JsonConvert.DeserializeObject<WhoisResponse>(result);
            }
        }

        public VatLookupResponse VatLookup(VatLookupRequest lookup)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = System.Text.Encoding.ASCII.GetBytes("=" + domain);

                var response = client.UploadData("https://api.cloudmersive.com/validate/vat/lookup", "POST", bytes);

                string result = System.Text.Encoding.ASCII.GetString(response);



                return JsonConvert.DeserializeObject<VatLookupResponse>(result);
            }
        }
    }
}
