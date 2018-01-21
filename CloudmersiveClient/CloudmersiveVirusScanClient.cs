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
    }
}
