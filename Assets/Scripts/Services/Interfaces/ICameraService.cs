using UnityEngine;

public interface ICameraService
{
    Ray ScreenPointToRay(Vector3 screenPoint);
}