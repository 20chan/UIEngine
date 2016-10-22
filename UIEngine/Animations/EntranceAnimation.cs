using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIEngine.Animations
{
    public abstract class EntranceAnimation : Animation
    {
        public EntranceAnimation(UserInterface parent, uint duration) : base(parent, duration) { AnimationType = AnimationType.Entrance; }
    }
}
