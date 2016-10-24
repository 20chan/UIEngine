using System.Drawing;

namespace UIEngine
{
    public abstract class Fill
    {
        public abstract float Transparency { get; set; }
        public abstract void DrawRectangle(Graphics g, int x, int y, int width, int height);
        public void DrawRectangle(Graphics g, Point location, Size size)
            => DrawRectangle(g, location.X, location.Y, size.Width, size.Height);
        public void DrawRectangle(Graphics g, Rectangle bound)
            => DrawRectangle(g, bound.X, bound.Y, bound.Width, bound.Height);
        
        public abstract void FillRectangle(Graphics g, int x, int y, int width, int height);
        public void FillRectangle(Graphics g, Point location, Size size)
            => FillRectangle(g, location.X, location.Y, size.Width, size.Height);
        public void FillRectangle(Graphics g, Rectangle bound)
            => FillRectangle(g, bound.X, bound.Y, bound.Width, bound.Height);

        public void DrawString(Graphics g, string text, Font font, int x, int y, int width, int height)
            => DrawString(g, text, font, new Rectangle(x, y, width, height));
        public abstract void DrawString(Graphics g, string text, Font font, Rectangle bound);

        public abstract void DrawPoligon(Graphics g, Point[] points);

        public abstract void DrawLine(Graphics g, Point from, Point to, float width);
        public void DrawLine(Graphics g, int x1, int y1, int x2, int y2, float width)
            => DrawLine(g, new Point(x1, y1), new Point(x2, y2), width);

        public static Fill DefaultBackgroundFill = new Fills.NoFill();
        public static Fill DefaultFill = new Fills.SolidFill(Color.Black);
    }
}
