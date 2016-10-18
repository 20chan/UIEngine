using System.Drawing;

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
