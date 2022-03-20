using Factories;
using Infrastructure;
using Systems.Test;

namespace Systems
{
    public sealed class TestSystems : InjectableFeature
    {
        public TestSystems(ISystemFactory systemFactory) : base(systemFactory)
        {
            Add<TestTearDownSystem>();
            
            Add<TestCleanupSystem>();
            Add<TestFixedExecuteSystem>();
            Add<TestLateExecuteSystem>();
            Add<TestExecuteSystem>();
        }
    }
}