using Assets.Code.Extensions;
using UnityEngine;

public class DoorButtonBehaviour : EntityBehaviour
{
    public UnityViewController doorViewController;
    
    protected override void OnStart()
    {
        base.OnStart();

        Entity.isDoorButton = true;

        if (doorViewController)
            Entity.AddConnectedId(doorViewController.Entity.id.value);

        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();

        if (meshRenderer)
        {
            float pressedYPos = transform.position.y - (meshRenderer.bounds.size.y * 0.9f);
            
            Entity
                .With(x => x.AddPosition(transform.position))
                .With(x => x.AddDurationMax(0.5f))
                .With(x => x.AddTwoPositions(transform.position, transform.position.SetY(pressedYPos)));
        }
    }
}