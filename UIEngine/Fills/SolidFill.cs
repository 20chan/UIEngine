using System;
using System.Drawing;

namespace UIEngine.Fills
{
    public class SolidFill : Fill
    {
        private Pen _pen;
        private Color _color;
        public Color Color
        {
            get { return _color; }
            set
            {
                _pen = new Pen(value);
                _color = value;
            }
        }

        public override float Transparency
        {
            get { return (float)this.Color.A / (float)byte.MaxValue; }
            set { this.Color = Color.FromArgb((int)(value * 255), this.Color);
                //System.Diagnostics.Debug.WriteLine(Color);
            }
        }
        
        public SolidFill(Color color, float transparency = 1f)
        {
            this.Color = color;
        }

        public override void DrawRectangle(Graphics g, int x, int y, int width, int height)
        {
            g.DrawRectangle(_pen, x, y, width, height);
        }

        public override void FillRectangle(Graphics g, int x, int y, int width, int height)
        {
            g.FillRectangle(_pen.Brush, x, y, width, height);
        }

        public override void DrawString(Graphics g, string text, Font font, Rectangle bound)
        {
            g.DrawString(text, font, _pen.Brush, bound);
            //System.Diagnostics.Debug.WriteLine("DRAW : " + _pen.Color);
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
