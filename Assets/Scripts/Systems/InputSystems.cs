using Systems;
using Zenject;

namespace Game
{
    public sealed class InputSystems : InjectableFeature
    {
        public InputSystems(ISystemFactory systemFactory) : base(systemFactory)
        {
            Add<RegisterInputsSystem>();
            Add<EmitInputSystem>();
        }
    }
}