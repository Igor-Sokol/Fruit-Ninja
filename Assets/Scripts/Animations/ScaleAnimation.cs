using UnityEngine;

namespace Animations
{
    public class ScaleAnimation : IAnimation
    {
        private float _timer;
        private Vector2 _scaleRange;
        private float _speed;

        public void SetUp(Vector2 scaleRange, float speed)
        {
            _scaleRange = scaleRange;
            _speed = speed;
        }
        
        public void UpdateAnimation(Transform transform, float deltaTime)
        {
            _timer += deltaTime;

            transform.localScale = Vector3.Lerp(new Vector3(_scaleRange.x, _scaleRange.x),
                new Vector3(_scaleRange.y, _scaleRange.y),
                Mathf.PingPong(_timer * _speed, 1));
        }
    }
}