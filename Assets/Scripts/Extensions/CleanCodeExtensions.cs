using System;
using Entitas;
using UnityEngine;
using View.EventListeners;

namespace Extensions
{
    public static class CleanCodeExtensions
    {
        public static void RegisterListeners(this GameObject view, IEntity entity)
        {
            foreach (IEventListener listener in view.GetComponentsInChildren<IEventListener>())
                listener.RegisterListeners(entity);
        }
    
        public static void UnregisterListeners(this GameObject view)
        {
            foreach (IEventListener listener in view.GetComponentsInChildren<IEventListener>())
                listener.UnregisterListeners();
        }
    
        public static void SubscribeId (this Contexts contexts)
        {
            foreach (var context in contexts.allContexts)
            {
                if (Array.FindIndex(context.contextInfo.componentTypes, v => v == typeof(IdComponent)) >= 0)
                {
                    context.OnEntityCreated += AddId;
                }
            }
        }

        private static void AddId (IContext context, IEntity entity)
        {
            (entity as GameEntity)?.ReplaceId(entity.creationIndex);
        }

        public static void SendMessage(this DebugContext debugContext, string message)
        {
            debugContext.CreateEntity().AddDebugLog(message);
        }
    }
}