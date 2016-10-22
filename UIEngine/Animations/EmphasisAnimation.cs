using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIEngine.Animations
{
    public abstract class EmphasisAnimation : Animation
    {
        public EmphasisAnimation(UserInterface parent, uint duration) : base(parent, duration) { AnimationType = AnimationType.Emphasis; }
    }
}
