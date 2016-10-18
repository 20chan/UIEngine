using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIEngine
{
    public abstract class Animation
    {
        public UserInterface Parent { get; private set; }
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
    }
}
