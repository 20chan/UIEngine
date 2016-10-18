using System;
using System.Linq;
using System.Collections.Generic;

namespace UIEngine.Presentations
{
    public class Slide
    {
        public List<UserInterface> Interfaces { get; }
        public List<Animation> Animations { get; }

        public bool IsAllAnimationsPlayed { get { return Animations.Count == _curAni; } }
        private int _curAni = 0;

        public Slide()
        {
            Interfaces = new List<UserInterface>();
            Animations = new List<Animation>();
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
            SetAnimationsTrigger();
            SetUIsBeforePlay();
            if(Animations.Count > 0)
            {
                if (Animations.First().TriggerType == Trigger.TriggerType.WithPrevious)
                    Animations.First().Play();
                else if (Animations.First().TriggerType == Trigger.TriggerType.AfterPrevious)
                    throw new NotImplementedException(); //After Transition
            }
        }

        public void PlayAnimation()
        {
            if (IsAllAnimationsPlayed) throw new InvalidOperationException("No more animations!");
            Animations[_curAni++].Play();

            while (IsAllAnimationsPlayed) //Play all WithPrevious animations
                if (Animations[_curAni].TriggerType == Trigger.TriggerType.WithPrevious)
                    Animations[_curAni++].Play();

            //AfterPrevious animations should be set in 'SetAnimationTrigger' method
        }

        public void UndoAnimation()
        {
            throw new NotImplementedException();
        }
    }
}
