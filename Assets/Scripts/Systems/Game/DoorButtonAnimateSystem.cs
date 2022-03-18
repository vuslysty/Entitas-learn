using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
    public class DoorButtonAnimateSystem : ReactiveSystem<GameEntity>
    {
        private DebugContext _debugContext;

        public DoorButtonAnimateSystem(Contexts contexts) : base(contexts.game)
        {
            _debugContext = contexts.debug;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return new Collector<GameEntity>(
                new[] {
                    context.GetGroup(GameMatcher.TriggerEnter),
                    context.GetGroup(GameMatcher.TriggerExit),
                },
                new[] {
                    GroupEvent.Added,
                    GroupEvent.Added
                }
            );
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasDoorButton && entity.hasPosition && entity.hasTwoPositions;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                TwoPositionsComponent positions = e.twoPositions;
                
                Vector3 currentPos = e.position.value;
                Vector3 endPos = currentPos;

                if (e.isTriggerEnter)
                {
                    endPos = positions.secondPosition;
                    _debugContext.SendMessage("Button Pressed");
                }
                else if (e.isTriggerExit)
                {
                    endPos = positions.firstPosition;
                    _debugContext.SendMessage("Button Released");
                }
                
                e.ReplaceTargetPosition(endPos);
            }
        }
    }
}