using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace UIEngine.Fills
{
    public class ImageFill : Fill
    {
        public Image Image { get; set; }
        public Size Size { get { return Image.Size; } }

        public ImageFill(Image image)
        {
            this.Image = image;
        }

        public override void DrawRectangle(Graphics g, int x, int y, int width, int height)
        {
            g.DrawImage(Image, x, y, width, height);
        }
    }
}
