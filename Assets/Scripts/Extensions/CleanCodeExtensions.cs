using Entitas;
using UnityEngine;

public static class CleanCodeExtensions
{
    public static void RegisterListeners(this GameObject view, IEntity entity)
    {
        foreach (IEventListener listener in view.GetComponents<IEventListener>())
            listener.RegisterListeners(entity);
    }
    
    public static void UnregisterListeners(this GameObject view)
    {
        foreach (IEventListener listener in view.GetComponents<IEventListener>())
            listener.UnregisterListeners();
    }
}