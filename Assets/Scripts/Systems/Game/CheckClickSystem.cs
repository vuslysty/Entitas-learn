using System.Collections.Generic;
using Entitas;

namespace Systems
{
    public class CheckClickSystem : ReactiveSystem<InputEntity>
    {
        private readonly Contexts _contexts;

        public CheckClickSystem(Contexts contexts) : base(contexts.input)
        {
            _contexts = contexts;
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
                _contexts.debug.CreateEntity().AddDebugLog($"Mouse screen pos: {e.mouseScreenPosition.Value}");
                _contexts.debug.CreateEntity().AddDebugLog($"Mouse world pos: {e.mouseWorldPosition.Value}");
            }
        }
    }
}