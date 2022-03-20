using Factories;
using Infrastructure;
using Systems.Debug;
using Systems.Test;

namespace Systems
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