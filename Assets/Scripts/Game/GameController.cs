using Servises;

namespace Game
{
    public class GameController
    {
        readonly Entitas.Systems _systems;
        private readonly Services _services;

        public GameController(Contexts contexts)
        {
            _services = new Services()
            {
                InputService = new UnityInputService(),
                Logger = new UnityDebugLogService(),
                CameraService = new CameraService()
            };

            _systems = new GameSystems(contexts, _services);
        }

        public void Initialize()
        {
            _systems.Initialize();
        }

        public void Execute()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        public void Destroy()
        {
            _systems.TearDown();
        }
    }
}