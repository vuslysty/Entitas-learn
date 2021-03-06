using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems.Game
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
            return entity.hasTwoPositions && entity.hasPosition;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                TwoPositionsComponent positions = e.twoPositions;
                
                Vector3 endPos = e.doorState.isOpen ? positions.firstPosition : positions.secondPosition;

                e.ReplaceTargetPosition(endPos);
            }
        }
    }
}