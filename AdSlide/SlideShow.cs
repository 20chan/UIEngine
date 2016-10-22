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
            DoubleBuffered = true;
            _presentation = pres;
            _presentation.InvalidateNeeded += () =>
            {
                System.Diagnostics.Debug.WriteLine("Invalidate"); this.Invalidate();
            };
            _presentation.Begin();
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _presentation.Draw(e.Graphics, Width, Height);
        }

        private void SlideShow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _presentation.Next();
        }
    }
}
