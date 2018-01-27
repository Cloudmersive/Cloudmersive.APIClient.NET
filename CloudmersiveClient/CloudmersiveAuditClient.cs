using CloudmersiveClient.Audit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient
{
    public class CloudmersiveAuditClient : CloudmersiveClientBase
    {
        public CloudmersiveAuditClient(string apikey)
        {
            Apikey = apikey;
        }

        public CloudmersiveAuditClient()
        {
            LoadApikeyFromConfig();
        }

        public AuditLogResponse WriteLogMessageFull(AuditLogWriteRequest req)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Apikey", Apikey);
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";



                var bytes = System.Text.Encoding.ASCII.GetBytes("=" + JsonConvert.SerializeObject(req)  );

                var response = client.UploadData("https://api.cloudmersive.com/audit/log/write-message-full", "POST", bytes);

                string result = System.Text.Encoding.ASCII.GetString(response);



                return JsonConvert.DeserializeObject<AuditLogResponse>(result);
            }
        }
    }
}
