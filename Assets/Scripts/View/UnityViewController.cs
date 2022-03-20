using Entitas;
using Entitas.Unity;
using Entitas.VisualDebugging.Unity;
using Extensions;
using UnityEngine;

namespace View
{
    public class UnityViewController : MonoBehaviour, IViewController
    {
        public GameContext Game { get; private set; }
        public GameEntity Entity { get; private set; }

        public IViewController InitializeView(GameContext game, IEntity entity)
        {
            Game = game;
            Entity = (GameEntity) entity;

            gameObject.Link(Entity);

            Entity.AddViewController(this);

            RegisterViewComponents();

            return this;
        }

        public void Destroy()
        {
            gameObject.Unlink();
            gameObject.UnregisterListeners();
            gameObject.DestroyGameObject();
        }

        private void RegisterViewComponents()
        {
            foreach (IViewComponentRegistrator registrator in GetComponentsInChildren<IViewComponentRegistrator>())
                registrator.Register(Entity);
        }
    }
}