using System;

namespace UIEngine
{
    public abstract class Animation
    {
        public UserInterface Parent { get; private set; }
        public Trigger.TriggerType TriggerType { get; set; }
        public Animations.AnimationType AnimationType { get; protected set; }
        public abstract event Action AnimationBeginned;
        public abstract event Action AnimationEnded;
        public abstract event Action AnimationSkipped;
        
        public bool TimerNeeded { get; protected set; }
        public System.Timers.ElapsedEventHandler InnerTimer { get; protected set; }
        public abstract event Action<bool> TimerEnableChanged;
        
        public uint Duration { get; set; }

        public Animation(UserInterface parent, uint duration)
        {
            this.Parent = parent;
            this.Duration = duration;
        }

        public virtual void Play()
        {
            
        }

        public virtual void Skip()
        {
            AfterParent();
            
        }

        /// <summary>
        /// Make parent ui before animation played
        /// </summary>
        public abstract void BeforeParent();
        /// <summary>
        /// Make parent ui after animation played
        /// </summary>
        public abstract void AfterParent();
    }
}
