using Entitas;
using UnityEngine;

namespace Systems
{
    public class MoveFromAToBSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _group;

        public MoveFromAToBSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.StartMovePosition, GameMatcher.EndMovePosition,
                    GameMatcher.Duration, GameMatcher.DurationElapsed, GameMatcher.Position, GameMatcher.Moving));
        }

        public void Execute()
        {
            foreach (var e in _group.GetEntities())
            {
                if (e.durationElapsed.Value >= e.duration.Value)
                {
                    e.ReplacePosition(e.endMovePosition.value);
                    e.isMoving = false;
                }
                else
                {
                    float normalizedTime = e.durationElapsed.Value / e.duration.Value;
                    Vector3 newPosition = Vector3.Lerp(e.startMovePosition.value, e.endMovePosition.value, normalizedTime);
                    
                    e.ReplacePosition(newPosition);
                    e.ReplaceDurationElapsed(e.durationElapsed.Value + Time.deltaTime);
                }
            }
        }
    }
}