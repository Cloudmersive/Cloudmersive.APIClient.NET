using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.Convert
{
    /// <summary>
    /// HTML template application request
    /// </summary>
    public class HtmlTemplateApplicationRequest
    {
        /// <summary>
        /// HTML template input as a string
        /// </summary>
        public string HtmlTemplate;

        /// <summary>
        /// Operations to apply to this template
        /// </summary>
        public HtmlTemplateOperation[] Operations;
    }

    /// <summary>
    /// Valid operations that can be applied to an HTML template
    /// </summary>
    public enum HtmlTemplateOperationAction
    {
        /// <summary>
        /// Replace a string
        /// </summary>
        Replace = 1
    }

    public class HtmlTemplateOperation
    {
        /// <summary>
        /// Operation action to take
        /// </summary>
        public HtmlTemplateOperationAction Action;

        /// <summary>
        /// For Replace operations, the string to match against (to be replaced with ReplaceWith string)
        /// </summary>
        public string MatchAgsint;

        /// <summary>
        /// For Replace operations, the string to Replace the original string with
        /// </summary>
        public string ReplaceWith;
    }
}
