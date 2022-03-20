using Extensions;

namespace View.Behaviours
{
    public class SelfInitializedView : EntityBehaviour
    {
        private GameEntity _entity;

        protected override void OnAwake()
        {
            base.OnAwake();
            _entity = Game.CreateEntity();

            ViewController.InitializeView(Game, _entity);
      
            gameObject.RegisterListeners(_entity);
        }
    }
}