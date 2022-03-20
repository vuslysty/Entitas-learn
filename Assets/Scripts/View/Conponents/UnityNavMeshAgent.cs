using UnityEngine;
using UnityEngine.AI;

namespace View.Conponents
{
    class UnityNavMeshAgent : MonoBehaviour, INavMeshAgent, IViewComponentRegistrator
    {
        public NavMeshAgent agent;

        public Vector3 Destination
        {
            get => agent.destination;
            set => agent.SetDestination(value);
        }

        public float MaxSpeed => agent.speed;
        public float CurrentSpeed => agent.velocity.magnitude;

        public bool IsActive
        {
            get => agent.isActiveAndEnabled;
            set => agent.enabled = value;
        }

        public void Register(GameEntity entity)
        {
            entity.AddNavMeshAgent(this);
        }
    }
}