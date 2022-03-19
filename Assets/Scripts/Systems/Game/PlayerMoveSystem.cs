using System.Collections.Generic;
using Entitas;
using Servises;
using UnityEngine;

namespace Systems
{
    public class PlayerMoveSystem : ReactiveSystem<InputEntity>
    {
        private readonly IInputService _inputService;
        private readonly ICameraService _cameraService;

        private readonly IGroup<GameEntity> _playerNavMeshGroup;

        public PlayerMoveSystem(Contexts contexts, ICameraService cameraService, IInputService inputService) : base(contexts.input)
        {
            _cameraService = cameraService;
            _inputService = inputService;
            _playerNavMeshGroup = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.NavMeshAgent));
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.AllOf(InputMatcher.MouseDown));
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.isLeftMouse;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var e in _playerNavMeshGroup)
            {
                INavMeshAgent navMeshAgent = e.navMeshAgent.Value;

                if (!navMeshAgent.IsActive)
                    continue;
                
                Ray ray = _cameraService.ScreenPointToRay(_inputService.GetScreenMousePosition());
                
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
                {
                    navMeshAgent.Destination = hit.point;
                }
            }
        }
    }
}