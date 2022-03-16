using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
    public class DoorStateChangedSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public DoorStateChangedSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DoorState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasDoor && entity.hasPosition && entity.hasDurationMax;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                Vector3 currentPos = e.position.value;
                DoorComponent door = e.door;
                
                e.ReplaceStartMovePosition(currentPos);
                e.ReplaceEndMovePosition(e.doorState.isOpen ? door.openPosition : door.closePosition);

                float maxDistance = Vector3.Distance(door.openPosition, door.closePosition);
                float moveDistance = Vector3.Distance(e.startMovePosition.value, e.endMovePosition.value);

                float moveTime = Mathf.Lerp(0, e.durationMax.Value, moveDistance / maxDistance);
                
                e.ReplaceDuration(moveTime);
                e.ReplaceDurationElapsed(0);
            }
        }
    }
}