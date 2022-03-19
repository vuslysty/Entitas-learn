using Entitas;
using Zenject;

namespace Game
{
    public class SystemFactory : ISystemFactory
    {
        private DiContainer _diContainer;
        
        public SystemFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T CreateSystem<T>() where T : ISystem
        {
            return _diContainer.Instantiate<T>();
        }
    }
}