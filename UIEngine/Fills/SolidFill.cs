using System.Drawing;

namespace UIEngine.Fills
{
    public class SolidFill : Fill
    {
        private Color _color;
        public Color Color
        {
            get { return _color; }
            set
            {
                _pen = new Pen(this._color);
                _color = value;
            }
        }

        public override float Transparency
        {
            get { return (float)this.Color.A / (float)byte.MaxValue; }
            set { this.Color = Color.FromArgb((int)(value * 255), this.Color); }
        }

        private Pen _pen;

        public SolidFill(Color color)
        {
            this.Color = color;
        }

        public override void DrawRectangle(Graphics g, int x, int y, int width, int height)
        {
            g.DrawRectangle(_pen, x, y, width, height);
        }

        public override void DrawString(Graphics g, string text, Font font, Rectangle bound)
        {
            if (_pen.Color.A == 0) System.Diagnostics.Debugger.Break();
            g.DrawString(text, font, _pen.Brush, bound);
        }

        public override void DrawPoligon(Graphics g, Point[] points)
        {
            g.DrawPolygon(_pen, points);
        }

        public override void DrawLine(Graphics g, Point from, Point to, float width)
        {
            Pen p = new Pen(Color, width);
            g.DrawLine(p, from, to);
        }
    }
}
