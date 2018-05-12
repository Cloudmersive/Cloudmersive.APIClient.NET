using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.Validation
{
    public class VatLookupRequest
    {
        /// <summary>
        /// VAT code to lookup; example "CZ25123891"
        /// </summary>
        public string VatCode;
    }
}
