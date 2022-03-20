using Factories;
using Infrastructure;
using Systems.Game;

namespace Systems
{
    public sealed class GameSystems : InjectableFeature
    {
        public GameSystems(ISystemFactory systemFactory) : base(systemFactory)
        {
            Add<GameEventSystems>();
            
            Add<PlayerMoveSystem>();
            Add<PlayerAnimationSpeedSystem>();
            
            Add<DoorButtonAnimateSystem>();
            Add<DoorButtonChangeDoorStateSystem>();
            Add<DoorStateChangedSystem>();
            
            Add<MoveToTargetSystem>();
            
            Add<GameCleanupSystems>();
        }
    }
}