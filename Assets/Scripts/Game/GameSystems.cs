using Servises;
using Systems;

namespace Game
{
    public sealed class GameSystems : Feature
    {
        public GameSystems(Contexts contexts, Services services)
        {
            Add(new ServiceRegistrationSystems(contexts, services));
            
            Add(new RegisterInputsSystem(contexts.input));
            Add(new EmitInputSystem(contexts.input));
            
            Add(new GameEventSystems(contexts));

            Add(new PlayerMoveSystem(contexts, services.InputService, services.CameraService));

            Add(new CheckClickSystem(contexts));
            
            Add(new HandleDebugLogMessageSystem(contexts, services.Logger));

            Add(new GameCleanupSystems(contexts));
            Add(new DebugCleanupSystems(contexts));
        }
    }
}