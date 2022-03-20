using UnityEngine;

namespace Services.Interfaces
{
    public interface ICameraService
    {
        Ray ScreenPointToRay(Vector3 screenPoint);
    }
}