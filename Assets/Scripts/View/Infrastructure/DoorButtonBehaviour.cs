using Assets.Code.Extensions;

public class DoorButtonBehaviour : EntityBehaviour
{
    public UnityViewController doorViewController;
    
    protected override void OnStart()
    {
        base.OnStart();
        Entity
            .With(x => x.isDoorButton = true)
            .With(x => x.AddConnectedId(doorViewController.Entity.id.value));
    }
}