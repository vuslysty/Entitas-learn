using Entitas;

namespace Factories
{
    public interface ISystemFactory
    {
        T CreateSystem<T>() where T : ISystem;
    }
}