using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient
{
    public class CloudmersiveNlpApiClient : CloudmersiveClientBase
    {
        

        public CloudmersiveNlpApiClient(string apikey)
        {
            Apikey = apikey;
        }

        public string PartOfSpeechTag_String(string input)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = System.Text.Encoding.ASCII.GetBytes("=" + input);

                var response = client.UploadData("https://api.cloudmersive.com/nlp/postaggerstring", "POST", bytes);

                string result = System.Text.Encoding.ASCII.GetString(response);

                result = Helpers.DecodeEscapedStrings(result);

                return result;
            }
        }

        public string Parse_String(string input)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = System.Text.Encoding.ASCII.GetBytes("=" + input);

                var response = client.UploadData("https://api.cloudmersive.com/nlp/parsestring", "POST", bytes);

                string result = System.Text.Encoding.ASCII.GetString(response);

                result = Helpers.DecodeEscapedStrings(result);

                return result;
            }
        }

        public string ExtractEntities_String(string input)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = System.Text.Encoding.ASCII.GetBytes("=" + input);

                var response = client.UploadData("https://api.cloudmersive.com/nlp/extractentitiesstring", "POST", bytes);

                string result = System.Text.Encoding.ASCII.GetString(response);

                result = Helpers.DecodeEscapedStrings(result);

                return result;
            }
        }
    }
}
