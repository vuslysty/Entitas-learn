using System;
using Systems;
using Zenject;

namespace Game
{
    public class GameController : IInitializable, ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        private readonly ISystemFactory _systemFactory;
        
        private BetterSystems _systems;

        public GameController(Contexts contexts, ISystemFactory systemFactory)
        {
            _systemFactory = systemFactory;

            contexts.SubscribeId();
        }

        public void Initialize()
        {
            _systems = new BetterSystems();

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

        public void FixedTick()
        {
            _systems.FixedExecute();
        }

        public void LateTick()
        {
            _systems.LateExecute();
        }

        public void Dispose()
        {
            _systems.TearDown();
        }
    }
}