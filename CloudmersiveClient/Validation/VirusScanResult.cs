using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.Validation
{
    public class VirusScanResult
    {
        public bool CleanResult;
        public VirusFound[] FoundViruses;
    }

    public class VirusFound
    {
        public string FileName;
        public string VirusName;
    }
}
