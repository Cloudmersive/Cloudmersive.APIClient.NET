using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.ImageProcessing
{
    public class FaceLocateResponse
    {
        /// <summary>
        /// True if the operation was successful, false otherwise
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// Array of faces found in the image
        /// </summary>
        public Face[] Faces { get; set; }

        /// <summary>
        /// Number of faces found in the image
        /// </summary>
        public int FaceCount { get; set; }
    }

    /// <summary>
    /// Location of one face in an image
    /// </summary>
    public class Face
    {
        /// <summary>
        /// X coordinate of the left side of the face
        /// </summary>
        public int LeftX { get; set; }

        /// <summary>
        /// Y coordinate of the top side of the face
        /// </summary>
        public int TopY { get; set; }

        /// <summary>
        /// X coordinate of the right side of the face
        /// </summary>
        public int RightX { get; set; }

        /// <summary>
        /// Y coordinate of the bottom side of the face
        /// </summary>
        public int BottomY { get; set; }
    }
}
