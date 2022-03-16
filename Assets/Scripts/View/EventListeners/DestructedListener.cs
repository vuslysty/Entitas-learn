using Entitas;
using UnityEngine;

public class DestructedListener : MonoBehaviour, IGameDestroyedListener, IEventListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddGameDestroyedListener(this);

        OnDestroyed(_entity);
    }

    public void UnregisterListeners() =>
        _entity.RemoveGameDestroyedListener();

    public void OnDestroyed(GameEntity entity)
    {
        if (entity.isDestroyed)
        {
            IViewController controller = gameObject.GetComponent<IViewController>();
            controller.Destroy();
        }
    }
}