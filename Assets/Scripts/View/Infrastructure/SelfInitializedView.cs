public class SelfInitializedView : EntityBehaviour
{
    private GameEntity _entity;

    protected override void OnAwake()
    {
        base.OnAwake();
        _entity = Contexts.sharedInstance.game.CreateEntity();

        if (!_entity.hasId)
            ContextsIdExtensions.AddId(Contexts.sharedInstance.game, _entity);

        ViewController.InitializeView(Contexts.sharedInstance.game, _entity);
      
        gameObject.RegisterListeners(_entity);
    }
}