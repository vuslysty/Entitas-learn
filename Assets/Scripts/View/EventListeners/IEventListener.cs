using Entitas;

namespace View.EventListeners
{
    public interface IEventListener
    {
        void RegisterListeners(IEntity entity);
        void UnregisterListeners();
    }
}