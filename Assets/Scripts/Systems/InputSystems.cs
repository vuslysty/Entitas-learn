using Systems;

namespace Game
{
    public sealed class InputSystems : InjectableFeature
    {
        public InputSystems(Contexts contexts)
        {
            Add(new RegisterInputsSystem(contexts.input));
            Add(new EmitInputSystem(contexts.input));
        }
    }
}