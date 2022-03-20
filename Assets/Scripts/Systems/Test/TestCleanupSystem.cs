using Entitas;
using Extensions;

namespace Systems.Test
{
    public class TestCleanupSystem : ICleanupSystem
    {
        private DebugContext _debugContext;

        public TestCleanupSystem(DebugContext debugContext)
        {
            _debugContext = debugContext;
        }
        
        public void Cleanup()
        {
            _debugContext.SendMessage("Cleanup");
        }
    }
}