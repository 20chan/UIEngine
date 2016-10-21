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
            {
                Slide first = new Slide();
                UILabel label = new UILabel() { Text = "Example", Position = new Point(100, 100), Size = new Size(300, 300),
                    Font = new Font("맑은 고딕", 80f), Fill = new UIEngine.Fills.SolidFill(Color.Blue) };
                UIPicture pic = new UIPicture(Image.FromFile(@"D:\Image\Logo\photo.jpg")) { Position = new Point(0, 0), Size = new Size(500, 500) };
                FadeInAni fadein = new FadeInAni(label, 1000) { TriggerType = UIEngine.Trigger.TriggerType.WithPrevious };
                FadeOutAni fadeout = new FadeOutAni(label, 1000) { TriggerType = UIEngine.Trigger.TriggerType.AfterPrevious };
                FadeInAni imgfadein = new FadeInAni(pic, 1000) { TriggerType = UIEngine.Trigger.TriggerType.AfterPrevious };
                FadeOutAni imgfadeout = new FadeOutAni(pic, 1000) { TriggerType = UIEngine.Trigger.TriggerType.MouseClick };
                first.Interfaces.Add(pic);
                first.Interfaces.Add(label);

                first.Animations.Add(fadein);
                first.Animations.Add(imgfadein);
                first.Animations.Add(imgfadeout);
                first.Animations.Add(fadeout);

                presentation.Slides.Add(first);
            }

            {
                Slide second = new Slide();
                UILabel label = new UILabel()
                {
                    Text = "Second Slide :)",
                    Position = new Point(0, 0),
                    Size = new Size(500, 500),
                    Font = new Font("Curlz MT", 80f),
                    Fill = new UIEngine.Fills.SolidFill(Color.Blue)
                };
                UIPicture pic = new UIPicture(Image.FromFile(@"D:\Image\Logo\haskell.png")) { Position = new Point(0, 0), Size = new Size(600, 400) };
                FadeInAni fadein = new FadeInAni(label, 1000) { TriggerType = UIEngine.Trigger.TriggerType.WithPrevious };
                FadeOutAni fadeout = new FadeOutAni(label, 1000) { TriggerType = UIEngine.Trigger.TriggerType.AfterPrevious };
                FadeInAni imgfadein = new FadeInAni(pic, 1000) { TriggerType = UIEngine.Trigger.TriggerType.WithPrevious };
                FadeOutAni imgfadeout = new FadeOutAni(pic, 1000) { TriggerType = UIEngine.Trigger.TriggerType.MouseClick };
                second.Interfaces.Add(pic);
                second.Interfaces.Add(label);

                second.Animations.Add(fadein);
                second.Animations.Add(imgfadein);
                second.Animations.Add(imgfadeout);
                second.Animations.Add(fadeout);

                presentation.Slides.Add(second);
            }

            Application.Run(new SlideShow(presentation));
        }
    }
}
