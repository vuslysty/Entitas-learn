using Entitas;

namespace Game
{
    public interface ISystemFactory
    {
        T CreateSystem<T>() where T : ISystem;
    }
}