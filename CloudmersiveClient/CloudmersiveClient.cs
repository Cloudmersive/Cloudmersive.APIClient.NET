using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient
{
    public abstract class CloudmersiveClientBase
    {


        protected string Apikey;

        public long GetApikeyUsage()
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";


                
                var response = client.DownloadString("https://api.cloudmersive.com/nlp/apikeyusage/" + Apikey);

                return Convert.ToInt64(response);
            }
        }

        


    }
}
