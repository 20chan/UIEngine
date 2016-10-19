using System;
using System.Linq;
using System.Timers;
using System.Collections.Generic;

namespace UIEngine.Presentations
{
    public class Slide
    {
        public List<UserInterface> Interfaces { get; }
        public List<Animation> Animations { get; }
        public event Action InvalidateNeeded;

        private Timer _timer;
    

        public bool IsAllAnimationsPlayed { get { return Animations.Count == _curAni; } }
        private int _curAni = 0;

        public Slide()
        {
            Interfaces = new List<UserInterface>();
            Animations = new List<Animation>();

            _timer = new Timer(100);
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach(var ani in Animations)
            {
                if (ani.TimerNeeded)
                    ani.InnerTimer?.Invoke(sender, e);
            }
            InvalidateNeeded?.Invoke();
        }

        private void SetAnimationsTimer()
        {
            foreach(var ani in Animations)
            {
                ani.TimerEnableChanged += (enabled) =>
                {
                    //타이머가 정지되어있는데 실행이 필요함
                    if (enabled && !_timer.Enabled)
                        _timer.Start();
                    //모든 애니메이션이 타이머가 필요 없음
                    if (!enabled && _timer.Enabled && Animations.All((a) => !a.TimerNeeded))
                        _timer.Stop();
                };
            }
        }

        private void SetAnimationsTrigger()
        {
            for(int i = 1; i < Animations.Count; i++)
            {
                if (Animations[i].TriggerType == Trigger.TriggerType.AfterPrevious)
                    Animations[i - 1].AnimationEnded += () => Animations[i].Play();
            }
        }

        private void SetUIsBeforePlay()
        {
            foreach (var ani in Animations)
                ani.BeforeParent();
        }

        public void SlideBegin()
        {
            SetAnimationsTimer();
            SetAnimationsTrigger();
            SetUIsBeforePlay();
            if(Animations.Count > 0)
            {
                if (Animations.First().TriggerType == Trigger.TriggerType.WithPrevious)
                    Animations[_curAni++].Play();
                else if (Animations.First().TriggerType == Trigger.TriggerType.AfterPrevious)
                    throw new NotImplementedException(); //After Transition
            }
        }

        public void PlayAnimation()
        {
            if (IsAllAnimationsPlayed) throw new InvalidOperationException("No more animations!");
            Animations[_curAni++].Play();

            while (!IsAllAnimationsPlayed) //Play all WithPrevious animations
            {
                if (Animations[_curAni].TriggerType == Trigger.TriggerType.WithPrevious)
                    Animations[_curAni++].Play();
                else
                    break;
            }

            //AfterPrevious animations should be set in 'SetAnimationTrigger' method
        }

        public void UndoAnimation()
        {
            throw new NotImplementedException();
        }
    }
}
