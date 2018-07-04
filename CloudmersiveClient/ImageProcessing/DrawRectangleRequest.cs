using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.ImageProcessing
{
    /// <summary>
    /// Request to draw one or more rectangles on a base image
    /// </summary>
    public class DrawRectangleRequest
    {
        /// <summary>
        /// Image to draw rectangles on, in bytes.  You can also use the BaseImageUrl instead to supply image input as a URL
        /// </summary>
        public byte[] BaseImageBytes { get; set; }

        /// <summary>
        /// Image to draw rectangles on, as an HTTP or HTTPS fully-qualified URL
        /// </summary>
        public string BaseImageUrl { get; set; }

        /// <summary>
        /// Rectangles to draw on the image.  Rectangles are drawn in index order.
        /// </summary>
        public DrawRectangleInstance[] RectanglesToDraw { get; set; }
    }

    /// <summary>
    /// Rectangle instance to draw on an image
    /// </summary>
    public class DrawRectangleInstance
    {
        /// <summary>
        /// Border Color to use - can be a hex value (with #) or HTML common color name.  Transparent colors are supported.
        /// </summary>
        public string BorderColor { get; set; }

        /// <summary>
        /// Width in pixels of the border.  Pass in 0 to draw a rectangle with no border
        /// </summary>
        public double BorderWidth { get; set; }

        /// <summary>
        /// Fill Color to use - can be a hex value (with #) or HTML common color name.  Transparent colors are supported.  Leave blank to not fill the rectangle.
        /// </summary>
        public string FillColor { get; set; }

        /// <summary>
        /// Pixel location of the left edge of the rectangle location
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Pixel location of the top edge of the rectangle location
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Width in pixels of the rectangle
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Height in pixels of the rectangle
        /// </summary>
        public double Height { get; set; }
    }
}
