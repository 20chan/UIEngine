using System;
using System.Linq;
using System.Timers;
using System.Collections.Generic;
using System.Drawing;

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

            _timer = new Timer(50);
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach(var ani in Animations)
            {
                if (ani.TimerNeeded)
                {
                    ani.InnerTimer?.Invoke(sender, e);
                }
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
                    //원래 코드 : Animations[i - 1].AnimationEnded += () => Animations[i].Play();
                    //이때 대리자 대신 람다를 사용했을때는 i가 마지막 값이 남아있어서 인덱스에러가 났음.
                    //암튼 결론은 대리자로 고쳐버렸음! :)
                    Animations[i - 1].AnimationEnded += new Action(Animations[i].Play);
            }
        }

        private void SetUIsBeforePlay()
        {
            //한 인터페이스에 여러 애니메이션이 있다면 첫번째 애니메이션의 BeforeParent로 설정하는걸로 변경
            /* Before
            foreach (var ani in Animations)
                ani.BeforeParent();
            */

            //After
            foreach(var ui in Interfaces)
            {
                var uiAnims = Animations.Where(ani => ani.Parent == ui);
                if (uiAnims == null || uiAnims.Count() == 0)
                    continue;
                uiAnims.First().BeforeParent();
            }
        }

        public void SlideBegin()
        {
            SetAnimationsTimer();
            SetAnimationsTrigger();
            SetUIsBeforePlay();
            if(Animations.Count > 0)
            {
                /*
                if (Animations.First().TriggerType == Trigger.TriggerType.WithPrevious)
                    Animations[_curAni++].Play();
                else if (Animations.First().TriggerType == Trigger.TriggerType.AfterPrevious)
                    throw new NotImplementedException(); //After Transition
                */
                PlayAnimation();
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

        protected internal void Draw(Graphics g, int width, int height)
        {
            using (Bitmap b = new Bitmap(width, height))
            using (Graphics _g = Graphics.FromImage(b))
            {
                foreach (var ui in Interfaces)
                {
                    ui.Draw(_g);
                }
                g.Clear(Color.White);
                g.DrawImage(b, 0, 0);
            }
        }
    }
}
