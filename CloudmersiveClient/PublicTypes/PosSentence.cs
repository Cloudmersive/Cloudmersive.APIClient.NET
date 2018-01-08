using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nlpapi.PublicTypes
{
    public class PosSentence
    {
        public System.Collections.Generic.List<PosTaggedWord> Words;

        public PosSentence(List taggedSentence)
        {
            Words = new List<PosTaggedWord>();

            var i = taggedSentence.iterator();

            while (i.hasNext())
            {
                TaggedWord x = (TaggedWord) i.next();

                PosTaggedWord word = new PosTaggedWord(x.word(), x.tag());
                Words.Add(word);
            }
        }
    }
}