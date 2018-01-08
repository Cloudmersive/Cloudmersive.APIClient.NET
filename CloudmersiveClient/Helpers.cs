using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient
{
    internal class Helpers
    {
        internal static string DecodeEscapedStrings(string input)
        {
            if (input == null)
            {
                return null;
            }

            string result = input.Trim();

            result = result.Trim("\"".ToCharArray());

            result = result.Replace("\\n", "\n");
            result = result.Replace("\\r", "");

            return result;
        }
    }
}
