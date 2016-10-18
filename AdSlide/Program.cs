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
            Slide first = new Slide();
            UILabel label = new UILabel() { Text = "hi", Position = new Point(100, 100), Size = new Size(300, 300), Font = new Font("맑은 고딕", 40f) };
            FadeInAni ani = new FadeInAni(label, 1000);
            ani.TriggerType = UIEngine.Trigger.TriggerType.WithPrevious;
            first.Interfaces.Add(label);
            first.Animations.Add(ani);

            presentation.Slides.Add(first);

            Application.Run(new SlideShow(presentation));
        }
    }
}
