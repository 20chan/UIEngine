namespace UIEngine
{
    public abstract class Effect
    {
        public UserInterface Parent { get; private set; }
        
        public Effect(UserInterface parent)
        {
            this.Parent = parent;
        }
    }
}
