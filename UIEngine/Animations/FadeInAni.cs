using System;
using System.Timers;

namespace UIEngine.Animations
{
    public class FadeInAni : Animation
    {
        public override event Action AnimationEnded;
        private Timer _timer;

        public FadeInAni(UserInterface parent, uint duration) : base(parent, duration)
        {
            _timer = new Timer(20);
            _timer.Elapsed += _timer_Elapsed;
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
            Parent.Fill.Transparency = Duration / (Duration - _elapsed);
            _elapsed += (uint)_timer.Interval;

            if (_elapsed == Duration)
            {
                AnimationEnded?.Invoke();
                _timer.Stop();
            }
        }
    }
}