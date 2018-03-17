using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.Convert
{
    /// <summary>
    /// Details of the screenshot request
    /// </summary>
    public class ScreenshotRequest
    {
        /// <summary>
        /// URL address of the website to screenshot.  HTTP and HTTPS are both supported, as are custom ports.
        /// </summary>
        public string Url;

        /// <summary>
        /// Optional: Additional number of milliseconds to wait once the web page has finished loading before taking the screenshot.  Can be helpful for highly asynchronous websites.
        /// </summary>
        public int ExtraLoadingWait;
    }

    /// <summary>
    /// Details of the HTML to PDF request
    /// </summary>
    public class HtmlToPdfRequest
    {
        /// <summary>
        /// HTML to render to PDF
        /// </summary>
        public string Html;

        /// <summary>
        /// Optional: Additional number of milliseconds to wait once the web page has finished loading before taking the screenshot.  Can be helpful for highly asynchronous websites.
        /// </summary>
        public int ExtraLoadingWait;
    }
}
