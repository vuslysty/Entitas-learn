using Extensions;
using Infrastructure;

namespace Systems.Test
{
    public class TestLateExecuteSystem : ILateExecuteSystem
    {
        private DebugContext _debugContext;

        public TestLateExecuteSystem(DebugContext debugContext)
        {
            _debugContext = debugContext;
        }

        public void Execute()
        {
            _debugContext.SendMessage("Late Execute");
        }
    }
}