using System.Collections.Generic;
using Entitas;

namespace Systems
{
    public class DoorButtonChangeDoorStateSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _gameContext;

        public DoorButtonChangeDoorStateSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TriggerEnter);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDoorButton && entity.hasConnectedId;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                var doorEntity = _gameContext.GetEntityWithId(e.connectedId.value);

                if (doorEntity == null)
                    return;
                
                doorEntity.ReplaceDoorState(!doorEntity.doorState.isOpen);
            }
        }
    }
}