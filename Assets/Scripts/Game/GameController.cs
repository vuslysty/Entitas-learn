using System;
using Zenject;

namespace Game
{
    public class GameController : IInitializable, ITickable, IDisposable
    {
        private readonly Contexts _contexts;
        private DiContainer _container;
        
        private InjectableFeature _systems;

        public GameController(Contexts contexts, DiContainer container)
        {
            _contexts = contexts;
            _container = container;
            
            contexts.SubscribeId();
        }

        public void Initialize()
        {
            _systems = new InjectableFeature("All systems");
            
            _systems.Add(new GameSystems(_contexts));
            _systems.Add(new InputSystems(_contexts));
            _systems.Add(new DebugSystems(_contexts));

            _systems.IncjectSelfAndChildren(_container);

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