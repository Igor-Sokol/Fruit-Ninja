using UnityEngine;

namespace Adaptive
{
    public class PlayingField : MonoBehaviour
    {
        [SerializeField] private Camera workingCamera;
        
        public Vector2 FieldSize { get; private set; }
        public Vector2 FieldLeftBottom { get; private set; }
        public Vector2 FieldRightUpper { get; private set; }
        public Vector2 HalfFieldSize { get; private set; }

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

        private void UpdateFieldSize()
        {
            FieldLeftBottom = workingCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
            FieldRightUpper = workingCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            FieldSize = new Vector2(Mathf.Abs(FieldLeftBottom.x) + Mathf.Abs(FieldRightUpper.x),
                Mathf.Abs(FieldLeftBottom.y) + Mathf.Abs(FieldRightUpper.y));
            
            HalfFieldSize = FieldSize / 2;
        }
    }
}