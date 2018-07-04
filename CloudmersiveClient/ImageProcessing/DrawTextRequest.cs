using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.ImageProcessing
{
    /// <summary>
    /// Request to draw one or more pieces of text onto an image
    /// </summary>
    public class DrawTextRequest
    {
        /// <summary>
        /// Image to draw text on, in bytes.  You can also use the BaseImageUrl instead to supply image input as a URL
        /// </summary>
        public byte[] BaseImageBytes { get; set; }

        /// <summary>
        /// Image to draw text on, as an HTTP or HTTPS fully-qualified URL
        /// </summary>
        public string BaseImageUrl { get; set; }



        /// <summary>
        /// One or more pieces of text to draw onto the image
        /// </summary>
        public DrawTextInstance[] TextToDraw { get; set; }
    }

    /// <summary>
    /// Text instance to draw on an image
    /// </summary>
    public class DrawTextInstance
    {
        /// <summary>
        /// Text string to draw
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Font Family to use.  Leave blank to default to "Arial".
        /// </summary>
        public string FontFamilyName { get; set; }

        /// <summary>
        /// Font size to use.
        /// </summary>
        public double FontSize { get; set; }

        /// <summary>
        /// Color to use - can be a hex value (with #) or HTML common color name
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Pixel location of the left edge of the text location
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Pixel location of the top edge of the text location
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Width in pixels of the text box to draw the text in; text will wrap inside this box
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Height in pixels of the text box to draw the text in; text will wrap inside this box
        /// </summary>
        public double Height { get; set; }
    }
}
