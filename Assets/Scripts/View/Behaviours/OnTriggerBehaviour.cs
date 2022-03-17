using Assets.Code.Extensions;
using UnityEngine;

public class OnTriggerBehaviour : EntityBehaviour
{
    public LayerMask TriggeringLayers;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.Matches(TriggeringLayers))
            return;
        
        Entity.isTriggerEnter = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.Matches(TriggeringLayers))
            return;
        
        Entity.isTriggerStay = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.Matches(TriggeringLayers))
            return;
        
        Entity.isTriggerExit = true;
    }
}