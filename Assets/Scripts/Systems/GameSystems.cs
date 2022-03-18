using Systems;
using Systems.Game;

namespace Game
{
    public sealed class GameSystems : InjectableFeature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new GameEventSystems(contexts));

            Add(new PlayerMoveSystem(contexts));
            Add(new PlayerAnimationSpeedSystem(contexts));
            
            Add(new DoorButtonAnimateSystem(contexts));
            Add(new DoorButtonChangeDoorStateSystem(contexts));
            Add(new DoorStateChangedSystem(contexts));
            
            Add(new MoveToTargetSystem(contexts));

            Add(new GameCleanupSystems(contexts));
        }
    }
}