using UnityEngine;

namespace PlayingFieldComponents
{
    public class PlayingField : MonoBehaviour
    {
        [SerializeField] private Camera workingCamera;
        
        public Vector2 FieldSize { get; private set; }
        public Vector2 FieldLeftBottom { get; private set; }
        public Vector2 FieldRightUpper { get; private set; }
        public Vector2 HalfFieldSize { get; private set; }

        public Vector2 Resolution { get; private set; }

        private void Awake()
        {
            UpdateFieldSize();
        }

        public Vector2 PositionFromPercentage(Vector2 percentage)
        {
            var position = new Vector2(FieldSize.x * percentage.x - HalfFieldSize.x,
                FieldSize.y * percentage.y - HalfFieldSize.y);

            return position;
        }

        public Vector2 WorldToScreenPoint(Vector3 position)
        {
            return workingCamera.WorldToScreenPoint(position);
        }
        
        public Vector2 ScreenToWorldPoint(Vector3 position)
        {
            return workingCamera.ScreenToWorldPoint(position);
        }
        
        private void UpdateFieldSize()
        {
            Resolution = new Vector2(Screen.width, Screen.height);
            
            FieldLeftBottom = workingCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
            FieldRightUpper = workingCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            FieldSize = new Vector2(Mathf.Abs(FieldLeftBottom.x) + Mathf.Abs(FieldRightUpper.x),
                Mathf.Abs(FieldLeftBottom.y) + Mathf.Abs(FieldRightUpper.y));
            
            HalfFieldSize = FieldSize / 2;
        }
    }
}