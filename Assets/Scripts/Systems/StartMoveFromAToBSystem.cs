using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
    public class StartMoveFromAToBSystem : ReactiveSystem<GameEntity>
    {
        public StartMoveFromAToBSystem(Contexts contexts) : base(contexts.game)
        { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.StartMoving);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTwoPositions && entity.hasStartMovePosition && entity.hasEndMovePosition && entity.hasDurationMax;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                float maxDistance = Vector3.Distance(e.twoPositions.firstPosition, e.twoPositions.secondPosition);
                float moveDistance = Vector3.Distance(e.startMovePosition.value, e.endMovePosition.value);

                float moveTime = 0;
                
                if (maxDistance > 0)
                    moveTime = Mathf.Lerp(0, e.durationMax.Value, moveDistance / maxDistance);
                
                e.ReplaceDuration(moveTime);
                e.ReplaceDurationElapsed(0);

                e.isMoving = true;
            }
        }
    }
}