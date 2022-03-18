using UnityEngine;
using UnityEngine.EventSystems;

namespace Servises
{
    public class UnityInputService : IInputService
    {
        private readonly Camera _mainCamera = Camera.main;
        private Vector3 _screenPosition = new Vector3(0, 0, Camera.main.nearClipPlane);

        public float Horizontal => Input.GetAxisRaw("Horizontal");
        public float Vertical => Input.GetAxisRaw("Vertical");
        public float Jump => Input.GetAxisRaw("Jump");
    
        public Vector2 GetScreenMousePosition() => Input.mousePosition;
        public Vector3 GetWorldMousePosition()
        {
            _screenPosition.x = Input.mousePosition.x;
            _screenPosition.y = Input.mousePosition.y;
            
            return _mainCamera.ScreenToWorldPoint(_screenPosition);
        }

        public bool GetLeftMouseButton() => Input.GetMouseButton(0) && !IsPointerOverUIObject();
        public bool GetLeftMouseButtonDown() => Input.GetMouseButtonDown(0) && !IsPointerOverUIObject();
        public bool GetLeftMouseButtonUp() => Input.GetMouseButtonUp(0) && !IsPointerOverUIObject();

        public bool GetRightMouseButton() => Input.GetMouseButton(1) && !IsPointerOverUIObject();
        public bool GetRightMouseButtonDown() => Input.GetMouseButtonDown(1) && !IsPointerOverUIObject();
        public bool GetRightMouseButtonUp() => Input.GetMouseButtonUp(1) && !IsPointerOverUIObject();

        private static bool IsPointerOverUIObject()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
    }
}