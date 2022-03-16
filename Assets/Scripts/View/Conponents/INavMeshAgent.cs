using UnityEngine;

public interface INavMeshAgent
{
    Vector3 Destination { get; set; }
    float MaxSpeed { get; }
    float CurrentSpeed { get; }
}