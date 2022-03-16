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

        public PlayerMoveSystem(Contexts contexts, IInputService inputService, ICameraService cameraService) : base(contexts.input)
        {
            _inputService = inputService;
            _cameraService = cameraService;

            _playerNavMeshGroup = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.NavMeshAgent));
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
            foreach (var e in _playerNavMeshGroup)
            {
                Ray ray = _cameraService.ScreenPointToRay(_inputService.GetScreenMousePosition());
                
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    e.navMeshAgent.Value.Destination = hit.point;
                }
            }
        }
    }
}