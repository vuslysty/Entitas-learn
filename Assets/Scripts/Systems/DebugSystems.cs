namespace Game
{
    public sealed class DebugSystems : InjectableFeature
    {
        public DebugSystems(ISystemFactory systemFactory) : base(systemFactory)
        {
            Add<HandleDebugLogMessageSystem>();
            
            Add<DebugCleanupSystems>();
        }
    }
}