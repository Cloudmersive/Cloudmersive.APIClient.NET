using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.Validation
{
    public class WhoisResponse
    {
        public bool ValidDomain;
        public string WhoisServer;
        public string RawTextRecord;
        public DateTime? CreatedDt;
    }
}
