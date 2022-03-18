namespace Game
{
    public sealed class DebugSystems : InjectableFeature
    {
        public DebugSystems(Contexts contexts)
        {
            Add(new HandleDebugLogMessageSystem(contexts));
            
            Add(new DebugCleanupSystems(contexts));
        }
    }
}