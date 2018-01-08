using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nlpapi.PublicTypes
{
    public class PosTaggedWord
    {
        public object Word;
        public object Tag;

        public PosTaggedWord(string str, string tag)
        {
            this.Word = str;
            this.Tag = tag;
        }
    }
}