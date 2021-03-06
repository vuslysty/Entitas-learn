using Entitas;
using Services.Interfaces;
using UnityEngine;

namespace Systems.Game
{
    public class MoveToTargetSystem : IExecuteSystem
    {
        private ITimeService _timeService;
        
        private IGroup<GameEntity> _group;

        public MoveToTargetSystem(Contexts contexts, ITimeService timeService)
        {
            _timeService = timeService;
            _group = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Position, GameMatcher.TargetPosition, GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (var e in _group.GetEntities())
            {
                Vector3 position = e.position.value;
                Vector3 targetPosition = e.targetPosition.value;

                if (e.position.value == e.targetPosition.value)
                {
                    e.RemoveTargetPosition();
                    continue;
                }
                
                float speed = e.speed.value;
                    
                e.ReplacePosition(Vector3.MoveTowards(position, targetPosition, speed * _timeService.DeltaTime));
            }
        }
    }
}