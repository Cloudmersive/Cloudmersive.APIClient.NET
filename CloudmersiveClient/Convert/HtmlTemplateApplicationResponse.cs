using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.Convert
{
    /// <summary>
    /// Response from an HTML template application
    /// </summary>
    public class HtmlTemplateApplicationResponse
    {
        /// <summary>
        /// True if the operation was successful, false otherwise
        /// </summary>
        public bool Successful;

        /// <summary>
        /// Final HTML result of all operations on input
        /// </summary>
        public string FinalHtml;
    }
}
