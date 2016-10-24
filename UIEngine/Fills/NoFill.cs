using System;
using System.Drawing;

namespace UIEngine.Fills
{
    public class NoFill : Fill
    {
        public override float Transparency
        {
            get
            {
                //None.
                return -1;
            }

            set
            {
                //None.
                return;
            }
        }

        public override void DrawRectangle(Graphics g, int x, int y, int width, int height)
        {
            //Do Nothing.
            return;
        }

        public override void FillRectangle(Graphics g, int x, int y, int width, int height)
        {
            //Do Nothing.
            return;
        }

        public override void DrawString(Graphics g, string text, Font font, Rectangle bound)
        {
            //Do Nothing too.
            return;
        }

        public override void DrawPoligon(Graphics g, Point[] points)
        {
            //Surely, Do Nothing.
            return;
        }

        public override void DrawLine(Graphics g, Point from, Point to, float width)
        {
            //Amazingly, Do Nothing.
            return;
        }
    }
}
