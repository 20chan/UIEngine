using System;
using System.Timers;

namespace UIEngine.Animations
{
    public class FadeOutAni : Animation
    {
        public override event Action AnimationEnded;
        public override event Action<bool> TimerEnableChanged;
        private readonly float originalAlpha;

        private uint _elapsed = 0;

        public FadeOutAni(UserInterface parent, uint duration) : base(parent, duration)
        {
            InnerTimer += (sender, e) =>
            {
                Parent.Fill.Transparency = (float)(Duration - (int)_elapsed) / (float)Duration;
                _elapsed += (uint)((Timer)sender).Interval;

                if (_elapsed >= Duration)
                {
                    AnimationEnded?.Invoke();
                    TimerNeeded = false;
                    TimerEnableChanged?.Invoke(false);
                }
            };
            originalAlpha = parent.Fill.Transparency;
        }

        public override void Play()
        {
            base.Play();
            TimerNeeded = true;
            TimerEnableChanged?.Invoke(true);
        }

        public override void BeforeParent()
        {
            Parent.Fill.Transparency = originalAlpha;
        }

        public override void AfterParent()
        {
            Parent.Fill.Transparency = 0;
        }
    }
}
