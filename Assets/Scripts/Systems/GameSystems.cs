using Systems;
using Systems.Game;

namespace Game
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