using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.ImageProcessing
{
    /// <summary>
    /// Result of an NSFW classification
    /// </summary>
    public class NsfwResult
    {
        /// <summary>
        /// True if the classification was successfully run, false otherwise
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// Score between 0.0 and 1.0.  Scores of 0.0-0.2 represent high probability safe content, while scores 0.8-1.0 represent high probability unsafe content.  Content between 0.2 and 0.8 is of increasing raciness.
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Classification result into four categories: SafeContent_HighProbability, UnsafeContent_HighProbability, RacyContent, SafeContent_ModerateProbability
        /// </summary>
        public string ClassificationOutcome { get; set; }

    }
}
