using UnityEngine;

namespace View.Conponents
{
    public interface INavMeshAgent
    {
        Vector3 Destination { get; set; }
        float MaxSpeed { get; }
        float CurrentSpeed { get; }
        bool IsActive { get; set; }
    }
}