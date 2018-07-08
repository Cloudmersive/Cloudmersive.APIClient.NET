using Newtonsoft.Json;
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

        public CloudmersiveNlpApiClient()
        {
            LoadApikeyFromConfig();
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

        public LanguageDetectionResponse DetectLanguage(string input)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = System.Text.Encoding.ASCII.GetBytes("=" + input);

                var response = client.UploadData("https://api.cloudmersive.com/nlp/language/detect", "POST", bytes);

                string result = System.Text.Encoding.ASCII.GetString(response);

                result = Helpers.DecodeEscapedStrings(result);

                return JsonConvert.DeserializeObject< LanguageDetectionResponse>( result );
            }
        }
    }

    public class LanguageDetectionResponse
    {
        /// <summary>
        /// True if the language detection operation was successful, false otherwise
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// ISO 639 three letter language code
        /// </summary>
        public string DetectedLanguage_ThreeLetterCode { get; set; }

        /// <summary>
        /// The full name (in English) of the detected language
        /// </summary>
        public string DetectedLanguage_FullName { get; set; }
    }
}
