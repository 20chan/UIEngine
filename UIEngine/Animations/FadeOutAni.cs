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
                if (_elapsed >= Duration)
                {
                    Skip();
                    return;
                }

                //if (_elapsed == Duration) System.Diagnostics.Debugger.Break();
                Parent.Fill.Transparency = (float)(Duration - (int)_elapsed) / (float)Duration;
                System.Diagnostics.Trace.WriteLine("OUT" + _elapsed);

                _elapsed += (uint)((Timer)sender).Interval;
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
            AnimationEnded?.Invoke();
            TimerNeeded = false;
            TimerEnableChanged?.Invoke(false);
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
