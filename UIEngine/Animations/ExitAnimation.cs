using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIEngine.Animations
{
    public abstract class ExitAnimation : Animation
    {
        public ExitAnimation(UserInterface parent, uint duration) : base(parent, duration) { AnimationType = AnimationType.Exit; }
    }
}
