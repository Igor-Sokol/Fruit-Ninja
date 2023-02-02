using UnityEngine;

namespace Animations
{
    public class RotateAnimation : IAnimation
    {
        private bool _clockwise;
        private float _speed;

        public void SetUp(bool clockwise, float speed)
        {
            _clockwise = clockwise;
            _speed = speed;
        }

        public void UpdateAnimation(Transform transform, float deltaTime)
        {
            transform.Rotate(Vector3.forward, deltaTime * _speed * (_clockwise ? -1 : 1));
        }
    }
}