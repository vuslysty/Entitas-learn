using Assets.Code.ViewComponentRegistrators;
using UnityEngine;
using UnityEngine.AI;

class UnityNavMeshAgent : MonoBehaviour, INavMeshAgent, IViewComponentRegistrator
{
    public NavMeshAgent agent;
    
    public Vector3 Destination
    {
        get => agent.destination;
        set => agent.destination = value;
    }

    public void Register(GameEntity entity)
    {
        entity.AddNavMeshAgent(this);
    }
}