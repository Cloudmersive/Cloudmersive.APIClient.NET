using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.Validation
{
    public class VatLookupResponse
    {
        /// <summary>
        /// Two-letter country code
        /// </summary>
        public string CountryCode;

        /// <summary>
        /// VAT number
        /// </summary>
        public string VatNumber;

        /// <summary>
        /// True if the VAT code is valid, false otherwise
        /// </summary>
        public bool IsValid;

        /// <summary>
        /// Name of the business
        /// </summary>
        public string BusinessName;

        /// <summary>
        /// Business address
        /// </summary>
        public string BusinessAddress;
    }
}
