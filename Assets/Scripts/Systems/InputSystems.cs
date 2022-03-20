using Factories;
using Infrastructure;
using Systems.Input;

namespace Systems
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