using System.Drawing;
using UIEngine.Fills;

namespace UIEngine.Interfaces
{
    public class UIPicture : UserInterface
    {
        public Image Image { get; set; }

        public UIPicture(Image image, float sizeRate = 1f)
        {
            this.Image = image;
            this.Size = new Size((int)(image.Size.Width * sizeRate), (int)(image.Size.Height * sizeRate));
            this.Fill = new ImageFill(image);
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            this.Fill.DrawRectangle(g, this.Bound);
        }
    }
}
