using System;
using System.Timers;

namespace UIEngine.Animations
{
    public class FadeInAni : Animation
    {
        public override event Action AnimationEnded;
        private Timer _timer;

        private readonly float originalAlpha;

        public FadeInAni(UserInterface parent, uint duration) : base(parent, duration)
        {
            _timer = new Timer(20);
            _timer.Elapsed += _timer_Elapsed;

            originalAlpha = parent.Fill.Transparency;
        }

        public override void Play()
        {
            base.Play();
            _elapsed = 0;
            _timer.Start();
        }

        private uint _elapsed = 0;
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Parent.Fill.Transparency = 1.0f - (float)(Duration - _elapsed) / (float)Duration;
            _elapsed += (uint)_timer.Interval;

            if (_elapsed == Duration)
            {
                AnimationEnded?.Invoke();
                _timer.Stop();
            }
        }

        public override void BeforeParent()
        {
            Parent.Fill.Transparency = 0;
        }

        public override void AfterParent()
        {
            Parent.Fill.Transparency = originalAlpha;
        }
    }
}