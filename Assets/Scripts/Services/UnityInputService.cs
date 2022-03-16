using UnityEngine;
using UnityEngine.EventSystems;

namespace Servises
{
    public class UnityInputService : IInputService
    {
        private readonly UnityEngine.Camera _mainCamera = UnityEngine.Camera.main;
        private Vector3 _screenPosition = new Vector3(0, 0, UnityEngine.Camera.main.nearClipPlane);

        public float Horizontal => UnityEngine.Input.GetAxisRaw("Horizontal");
        public float Vertical => UnityEngine.Input.GetAxisRaw("Vertical");
        public float Jump => UnityEngine.Input.GetAxisRaw("Jump");
    
        public Vector2 GetScreenMousePosition() => UnityEngine.Input.mousePosition;
        public Vector3 GetWorldMousePosition()
        {
            _screenPosition.x = UnityEngine.Input.mousePosition.x;
            _screenPosition.y = UnityEngine.Input.mousePosition.y;
            
            return _mainCamera.ScreenToWorldPoint(_screenPosition);
        }

        public bool GetLeftMouseButton() => UnityEngine.Input.GetMouseButton(0) && !IsPointerOverUIObject();
        public bool GetLeftMouseButtonDown() => UnityEngine.Input.GetMouseButtonDown(0) && !IsPointerOverUIObject();
        public bool GetLeftMouseButtonUp() => UnityEngine.Input.GetMouseButtonUp(0) && !IsPointerOverUIObject();

        public bool GetRightMouseButton() => UnityEngine.Input.GetMouseButton(1) && !IsPointerOverUIObject();
        public bool GetRightMouseButtonDown() => UnityEngine.Input.GetMouseButtonDown(1) && !IsPointerOverUIObject();
        public bool GetRightMouseButtonUp() => UnityEngine.Input.GetMouseButtonUp(1) && !IsPointerOverUIObject();

        private static bool IsPointerOverUIObject()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
    }
}