using System;
using Extensions;
using Infrastructure;
using Systems;
using Zenject;

namespace Game
{
    public class GameController : IInitializable, ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        private readonly BetterSystems _systems;

        public GameController(Contexts contexts, BetterSystems systems)
        {
            _systems = systems;
            
            contexts.SubscribeId();
        }

        private void AddSystems()
        {
            _systems.Add<GameSystems>();
            _systems.Add<InputSystems>();
            _systems.Add<DebugSystems>();
        }

        public void Initialize()
        {
            AddSystems();

            _systems.Initialize();
        }

        public void Tick()
        {
            _systems.Execute();
        }

        public void FixedTick()
        {
            _systems.FixedExecute();
        }

        public void LateTick()
        {
            _systems.LateExecute();
            _systems.Cleanup();
        }

        public void Dispose()
        {
            _systems.TearDown();
        }
    }
}