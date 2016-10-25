using System;
using System.Timers;

namespace UIEngine.Animations.Emphasis
{
    public class SpinAni : EmphasisAnimation
    {
        public override event Action AnimationEnded;
        public override event Action AnimationSkipped;
        public override event Action<bool> TimerEnableChanged;

        private float _originalRot;
        private float _elapsed = 0;

        public SpinAni(UserInterface parent, uint duration, int spin = 1) : base(parent, duration)
        {
            _originalRot = parent.Rotation;
            InnerTimer += (sender, e) =>
            {
                if (_elapsed >= Duration)
                {
                    AnimationEnded?.Invoke();
                    TimerNeeded = false;
                    TimerEnableChanged?.Invoke(false);
                    return;
                }

                Parent.Rotation = _originalRot + spin * 360f * (float)(Duration - (int)_elapsed) / (float)Duration;
                _elapsed += (uint)((Timer)sender).Interval;
                //System.Diagnostics.Debug.WriteLine("IN" + _elapsed);

            };
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

        public override void AfterParent() { Parent.Rotation = _originalRot; }

        public override void BeforeParent() { AfterParent(); }
    }
}
