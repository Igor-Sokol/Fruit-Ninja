using UnityEngine;

namespace Adaptive
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        private Camera _mainCamera;
        
        public Vector2 CameraSize { get; private set; }
        public Vector2 CameraLeftBottom { get; private set; }
        public Vector2 CameraRightUpper { get; private set; }
        public Vector2 HalfCameraSize { get; private set; }

        private void Awake()
        {
            _mainCamera = Camera.main;
            UpdateCameraSize();
        }

        public Vector2 PositionFromPercentage(Vector2 percentage)
        {
            var position = new Vector2(HalfCameraSize.x * (percentage.x / 100f),
                HalfCameraSize.y * (percentage.y / 100f));

            return position;
        }

        private void UpdateCameraSize()
        {
            CameraLeftBottom = _mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
            CameraRightUpper = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            CameraSize = new Vector2(Mathf.Abs(CameraLeftBottom.x) + Mathf.Abs(CameraRightUpper.x),
                Mathf.Abs(CameraLeftBottom.y) + Mathf.Abs(CameraRightUpper.y));
            
            HalfCameraSize = CameraSize / 2;
        }
    }
}