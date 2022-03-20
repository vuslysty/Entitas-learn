using Services.Interfaces;
using UnityEngine;

namespace Services
{
    public class CameraService : ICameraService
    {
        private UnityEngine.Camera _camera;

        private UnityEngine.Camera Camera
        {
            get
            {
                if (_camera == null) 
                    _camera = UnityEngine.Camera.main;

                return _camera;
            }
        }

        public Ray ScreenPointToRay(Vector3 screenPoint)
        {
            return Camera.ScreenPointToRay(screenPoint);
        }
    }
}