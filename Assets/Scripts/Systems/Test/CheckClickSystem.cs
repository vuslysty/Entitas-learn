using System.Collections.Generic;
using Entitas;
using Extensions;

namespace Systems.Test
{
    public class CheckClickSystem : ReactiveSystem<InputEntity>
    {
        private readonly DebugContext _debugContext;

        public CheckClickSystem(Contexts contexts) : base(contexts.input)
        {
            _debugContext = contexts.debug;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.MouseDown);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.isMouseDown;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var e in entities)
            {
                _debugContext.SendMessage($"Mouse screen pos: {e.mouseScreenPosition.Value}");
                _debugContext.SendMessage($"Mouse world pos: {e.mouseWorldPosition.Value}");
            }
        }
    }
}