using System;
using System.Collections.Generic;
using Entitas;

namespace Systems
{
    public class DoorButtonChangeDoorStateSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _gameContext;
        private IGroup<GameEntity> _doorStateGroup;

        public DoorButtonChangeDoorStateSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
            _doorStateGroup = _gameContext.GetGroup(GameMatcher.DoorState);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TriggerEnter);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasDoorButton;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                GameEntity connectedDoorEntity = null;

                if (e.hasConnectedId)
                    connectedDoorEntity = _gameContext.GetEntityWithId(e.connectedId.value);
                
                switch (e.doorButton.value)
                {
                    case DoorButtonType.SingleRevert:
                    {
                        if (connectedDoorEntity == null)
                            return;

                        connectedDoorEntity.ReplaceDoorState(!connectedDoorEntity.doorState.isOpen);
                        break;
                    }
                    case DoorButtonType.SingleClose:
                    {
                        if (connectedDoorEntity == null)
                            return;

                        connectedDoorEntity.ReplaceDoorState(false);
                        break;
                    }
                    case DoorButtonType.SingleOpen:
                    {
                        if (connectedDoorEntity == null)
                            return;

                        connectedDoorEntity.ReplaceDoorState(true);
                        break;
                    }
                    case DoorButtonType.GlobalRevert:
                    {
                        foreach (var door in _doorStateGroup.GetEntities())
                        {
                            door.ReplaceDoorState(!door.doorState.isOpen);
                        }
                        break;
                    }
                    case DoorButtonType.GlobalClose:
                    {
                        foreach (var door in _doorStateGroup.GetEntities())
                        {
                            door.ReplaceDoorState(false);
                        }
                        break;
                    }
                    case DoorButtonType.GlobalOpen:
                    {
                        foreach (var door in _doorStateGroup.GetEntities())
                        {
                            door.ReplaceDoorState(true);
                        }
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}