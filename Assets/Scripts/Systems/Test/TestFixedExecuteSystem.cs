using Extensions;
using Infrastructure;

namespace Systems.Test
{
    public class TestFixedExecuteSystem : IFixedExecuteSystem
    {
        private DebugContext _debugContext;

        public TestFixedExecuteSystem(DebugContext debugContext)
        {
            _debugContext = debugContext;
        }

        public void Execute()
        {
            _debugContext.SendMessage("Fixed Execute");
        }
    }
}