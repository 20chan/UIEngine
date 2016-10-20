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
            _presentation.InvalidateNeeded += () => {
                System.Diagnostics.Trace.WriteLine("Invalidate"); this.Invalidate(); };
            _presentation.Begin();
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (var ui in _presentation.CurrentSlide.Interfaces)
                ui.Draw(e.Graphics);
            base.OnPaint(e);
        }

        private void SlideShow_MouseDown(object sender, MouseEventArgs e)
        {
            _presentation.Next();
        }
    }
}
