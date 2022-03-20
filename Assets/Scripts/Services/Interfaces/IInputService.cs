using UnityEngine;

namespace Services.Interfaces
{
    public interface IInputService
    {
        float Horizontal { get; }
        float Vertical { get; }
        float Jump { get; }

        Vector2 GetScreenMousePosition();
        Vector3 GetWorldMousePosition();

        bool GetLeftMouseButton();
        bool GetLeftMouseButtonDown();
        bool GetLeftMouseButtonUp();

        bool GetRightMouseButton();
        bool GetRightMouseButtonDown();
        bool GetRightMouseButtonUp();
    }
}