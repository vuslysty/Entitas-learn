using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
    public class DoorStateChangedSystem : ReactiveSystem<GameEntity>
    {
        public DoorStateChangedSystem(Contexts contexts) : base(contexts.game)
        { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DoorState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTwoPositions && entity.hasPosition && entity.hasDurationMax;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                TwoPositionsComponent positions = e.twoPositions;
                
                Vector3 currentPos = e.position.value;
                Vector3 endPos = e.doorState.isOpen ? positions.firstPosition : positions.secondPosition;

                e.ReplaceStartMovePosition(currentPos);
                e.ReplaceEndMovePosition(endPos);
                
                e.isStartMoving = true;
            }
        }
    }
}