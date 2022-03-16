public class SelfInitializedView : EntityBehaviour
{
    private GameEntity _entity;

    protected override void OnAwake()
    {
        base.OnAwake();
        _entity = Contexts.sharedInstance.game.CreateEntity();

        ViewController.InitializeView(Contexts.sharedInstance.game, _entity);
      
        gameObject.RegisterListeners(_entity);
    }
}