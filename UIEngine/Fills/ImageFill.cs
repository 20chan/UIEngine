using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace UIEngine.Fills
{
    public class ImageFill : Fill
    {
        public Image Image { get; set; }
        public Size Size { get { return Image.Size; } }

        public override float Transparency { get; set; } = 1f;
        
        public ImageFill(Image image)
        {
            this.Image = image;
        }

        public override void DrawRectangle(Graphics g, int x, int y, int width, int height)
        {
            ColorMatrix matrix = new ColorMatrix();
            matrix.Matrix33 = Transparency;
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            g.DrawImage(Image, new Rectangle(x, y, width, height), 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, attributes);
        }

        public override void DrawPoligon(Graphics g, Point[] points)
        {
            throw new NotImplementedException();
        }

        public override void DrawLine(Graphics g, Point from, Point to, float width)
        {
            throw new NotImplementedException();
        }

        public override void DrawString(Graphics g, string text, Font font, Rectangle bound)
        {
            throw new NotImplementedException();
        }
    }
}
