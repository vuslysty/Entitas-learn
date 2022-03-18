using Assets.Code.Extensions;
using UnityEngine;

public class DoorBehaviour : EntityBehaviour
{
    public bool isOpen;
    public Transform openTransform;
    public Transform closeTransform;
    
    protected override void OnStart()
    {
        base.OnStart();
        Entity
            .With(x => x.AddTwoPositions(openTransform.position, closeTransform.position))
            .With(x => x.AddDoorState(isOpen))
            .With(x => x.AddSpeed(1.5f))
            .With(x => x.AddPosition(isOpen ? openTransform.position : closeTransform.position));
    }
}