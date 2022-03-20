using Entitas;
using UnityEngine;

namespace View.EventListeners
{
    public class PositionListener : MonoBehaviour, IPositionListener, IEventListener
    {
        private GameEntity _entity;

        public void RegisterListeners(IEntity entity)
        {
            _entity = (GameEntity)entity;
            _entity.AddPositionListener(this);
        
            if (_entity.hasPosition)
                OnPosition(_entity, _entity.position.value);
        }

        public void UnregisterListeners() =>
            _entity.RemovePositionListener();

        public void OnPosition(GameEntity entity, Vector3 value)
        {
            transform.position = value;
        }
    }
}