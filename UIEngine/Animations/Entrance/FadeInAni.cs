using System;
using System.Timers;

namespace UIEngine.Animations.Entrance
{
    public class FadeInAni : EntranceAnimation
    {
        public override event Action AnimationEnded;
        public override event Action AnimationSkipped;
        public override event Action<bool> TimerEnableChanged;
        private readonly float originalAlpha;

        private uint _elapsed = 0;

        public FadeInAni(UserInterface parent, uint duration) : base(parent, duration)
        {
            InnerTimer += (sender, e) =>
            {
                if (_elapsed >= Duration)
                {
                    AnimationEnded?.Invoke();
                    TimerNeeded = false;
                    TimerEnableChanged?.Invoke(false);
                    return;
                }

                Parent.Fill.Transparency = 1.0f - (float)(Duration - (int)_elapsed) / (float)Duration;
                _elapsed += (uint)((Timer)sender).Interval;
                System.Diagnostics.Trace.WriteLine("IN" + _elapsed);

            };
            originalAlpha = parent.Fill.Transparency;
        }

        public override void Play()
        {
            base.Play();
            TimerNeeded = true;
            TimerEnableChanged?.Invoke(true);
        }

        public override void Skip()
        {
            base.Skip();
            AnimationSkipped?.Invoke();
            TimerNeeded = false;
            TimerEnableChanged?.Invoke(false);
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