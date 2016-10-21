using System;
using System.Drawing;
using System.Windows.Forms;
using UIEngine.Interfaces;
using UIEngine.Animations;
using UIEngine.Presentations;

namespace AdSlide
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Presentation presentation = new Presentation();
            presentation.PresentationEnded += () => Application.Exit();

            Slide first = new Slide();
            UILabel label = new UILabel() { Text = "Example", Position = new Point(100, 100), Size = new Size(300, 300),
                Font = new Font("맑은 고딕", 80f), Fill = new UIEngine.Fills.SolidFill(Color.White) };
            UIPicture pic = new UIPicture(Image.FromFile(@"D:\Image\Logo\photo.jpg")) { Position = new Point(0, 0), Size = new Size(500, 500) };
            FadeInAni fadein = new FadeInAni(label, 1000);
            fadein.TriggerType = UIEngine.Trigger.TriggerType.WithPrevious;
            FadeOutAni fadeout = new FadeOutAni(label, 1000);
            fadeout.TriggerType = UIEngine.Trigger.TriggerType.MouseClick;
            first.Interfaces.Add(pic);
            first.Interfaces.Add(label);

            first.Animations.Add(fadein);
            first.Animations.Add(fadeout);

            presentation.Slides.Add(first);

            Application.Run(new SlideShow(presentation));
        }
    }
}
