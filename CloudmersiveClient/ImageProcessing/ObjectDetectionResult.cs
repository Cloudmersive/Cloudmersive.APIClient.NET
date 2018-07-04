using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.ImageProcessing
{
    public class ObjectDetectionResult
    {
        /// <summary>
        /// Was the image processed successfully?
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// Array of objects detected in the scene
        /// </summary>
        public DetectedObject[] Objects { get; set; }

        /// <summary>
        /// Number of objects detected in the scene
        /// </summary>
        public int ObjectCount { get; set; }
    }

    /// <summary>
    /// Single object instance, and associated details, detected in an image
    /// </summary>
    public class DetectedObject
    {
        /// <summary>
        /// Class of the object.  Example values are "person", "car", "dining table", etc.
        /// </summary>
        public string ObjectClassName { get; set; }

        /// <summary>
        /// Height, in pixels, of the object
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Width, in pixels, of the object
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Confidence score of detected object; possible values are between 0.0 and 1.0; values closer to 1.0 are higher confidence
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// X location, in pixels, of the left side location of the object, with the right side being X + Width
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y location, in pixels, of the top side location of the object, with the bottom side being Y + Height
        /// </summary>
        public int Y { get; set; }


    }
}
