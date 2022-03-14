namespace DefaultNamespace.Systems
{
    public sealed class RootSystems : Feature
    {
        public RootSystems(Contexts contexts)
        {
            Add(new CreatePlayerSystem(contexts));
            Add(new LogHealthSystem(contexts));
        }
    }
}