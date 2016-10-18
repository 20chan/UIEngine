using UIEngine.Presentations;
using System.Windows.Forms;

namespace AdSlide
{
    public partial class SlideShow : Form
    {
        private readonly Presentation _presentation;

        public SlideShow(Presentation pres)
        {
            InitializeComponent();
            _presentation = pres;
            _presentation.Begin();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (var ui in _presentation.CurrentSlide.Interfaces)
                ui.Draw(e.Graphics);
            base.OnPaint(e);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            this.Invalidate();
        }

        private void SlideShow_MouseDown(object sender, MouseEventArgs e)
        {
            _presentation.Next();
        }
    }
}
