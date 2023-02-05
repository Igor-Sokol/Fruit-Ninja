using UnityEngine;

namespace Animations
{
    public class ScaleAnimation : IAnimation
    {
        private Vector3 _targetScale;
        private float _speed;

        public void SetUp(float targetScale, float speed)
        {
            _targetScale = new Vector3(targetScale, targetScale, targetScale);
            _speed = speed;
        }
        
        public void UpdateAnimation(Transform transform, float deltaTime)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, _speed * Time.deltaTime);
        }
    }
}