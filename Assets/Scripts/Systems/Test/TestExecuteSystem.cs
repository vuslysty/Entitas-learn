using Entitas;
using Extensions;

namespace Systems.Test
{
    public class TestExecuteSystem : IExecuteSystem
    {
        private DebugContext _debugContext;

        public TestExecuteSystem(DebugContext debugContext)
        {
            _debugContext = debugContext;
        }

        public void Execute()
        {
            _debugContext.SendMessage("Simple Execute");
        }
    }
}