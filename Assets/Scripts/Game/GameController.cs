using System;
using Zenject;

namespace Game
{
    public class GameController : IInitializable, ITickable, IDisposable
    {
        private readonly ISystemFactory _systemFactory;
        
        private Entitas.Systems _systems;

        public GameController(Contexts contexts, ISystemFactory systemFactory)
        {
            _systemFactory = systemFactory;

            contexts.SubscribeId();
        }

        public void Initialize()
        {
            _systems = new Entitas.Systems();

            _systems.Add(new GameSystems(_systemFactory));
            _systems.Add(new InputSystems(_systemFactory));
            _systems.Add(new DebugSystems(_systemFactory));

            _systems.Initialize();
        }

        public void Tick()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        public void Dispose()
        {
            _systems.TearDown();
        }
    }
}