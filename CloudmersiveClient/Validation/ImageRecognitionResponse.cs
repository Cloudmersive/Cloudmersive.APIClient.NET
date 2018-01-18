using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.Validation
{
    /// <summary>
    /// Result of recognizing an image
    /// </summary>
    public class ImageDescriptionResponse
    {
        /// <summary>
        /// Was the image processed successfully?
        /// </summary>
        public bool Successful;

        /// <summary>
        /// Is the resulting best outcome recognition a high confidence outcome?
        /// </summary>
        public bool Highconfidence;

        /// <summary>
        /// The best Machine Learning outcome
        /// </summary>
        public RecognitionOutcome BestOutcome;

        /// <summary>
        /// Best backup ("runner up") Machine Learning outcome
        /// </summary>
        public RecognitionOutcome RunnerUpOutcome;
    }

    /// <summary>
    /// Specific recognition outcome
    /// </summary>
    public class RecognitionOutcome
    {
        /// <summary>
        /// Scores closer to 1 are better than scores closer to 0
        /// </summary>
        public double ConfidenceScore;

        /// <summary>
        /// English language description of the image
        /// </summary>
        public string Description;
    }
}
