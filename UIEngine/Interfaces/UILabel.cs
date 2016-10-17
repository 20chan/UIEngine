using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Text;

namespace UIEngine.Interfaces
{
    public class UILabel : UserInterface
    {
        public string Text { get; set; }
        public Font Font { get; set; }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            Fill.DrawString(g, Text, Font, Bound);
        }
    }
}
