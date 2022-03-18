using Entitas;
using View;

namespace Systems
{
    public class PlayerAnimationSpeedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public PlayerAnimationSpeedSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.NavMeshAgent, GameMatcher.PlayerAnimator));
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                INavMeshAgent navMeshAgent = entity.navMeshAgent.Value;
                PlayerAnimator playerAnimator = entity.playerAnimator.Value;

                if (!navMeshAgent.IsActive || navMeshAgent.MaxSpeed == 0)
                    continue;
                
                playerAnimator.SetNormalizedSpeed(navMeshAgent.CurrentSpeed / navMeshAgent.MaxSpeed);
            }
        }
    }
}