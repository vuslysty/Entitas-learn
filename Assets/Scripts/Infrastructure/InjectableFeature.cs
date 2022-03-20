using Entitas;
using Factories;

namespace Infrastructure
{
    public class InjectableFeature : Feature
    {
        private readonly ISystemFactory _systemFactory;

        public InjectableFeature(ISystemFactory systemFactory)
        {
            _systemFactory = systemFactory;
        }

        public InjectableFeature(string name, ISystemFactory systemFactory)
            : base( name )
        {
            _systemFactory = systemFactory;
        }

        public void Add<T>() where T : ISystem
        {
            Add(_systemFactory.CreateSystem<T>());
        }
    }
}