namespace DefaultNamespace.Systems
{
    public sealed class RootSystems : Feature
    {
        public RootSystems(Contexts contexts)
        {
            Add(new GameEventSystems(contexts));
            
            Add(new CreatePlayerSystem(contexts));
            Add(new LogHealthSystem(contexts));

            Add(new GameCleanupSystems(contexts));
        }
    }
}