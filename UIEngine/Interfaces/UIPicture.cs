using System.Drawing;
using UIEngine.Fills;

namespace UIEngine.Interfaces
{
    public class UIPicture : UserInterface
    {
        public Image Image { get; set; }

        public UIPicture(Image image)
        {
            this.Image = image;
            this.Fill = new ImageFill(image);
        }

        public override void Draw(Graphics g)
        {
            this.Fill.DrawRectangle(g, this.Bound);
        }
    }
}
