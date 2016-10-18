using System;

namespace UIEngine
{
    public abstract class Animation
    {
        public UserInterface Parent { get; private set; }
        public Trigger.TriggerType TriggerType { get; set; }
        public abstract event Action AnimationEnded;
        
        public uint Duration { get; set; }

        public Animation(UserInterface parent, uint duration)
        {
            this.Parent = parent;
            this.Duration = duration;
        }

        public virtual void Play()
        {

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
