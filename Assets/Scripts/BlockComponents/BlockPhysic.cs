using System.Diagnostics;
using Managers;
using UnityEngine;

namespace BlockComponents
{
    public class BlockPhysic : MonoBehaviour
    {
        private Vector3 _velocity;

        [SerializeField] private float colliderRadius;
        [SerializeField] private TimeScaleManager timeScaleManager;

        public float ColliderRadius => colliderRadius * transform.localScale.x;
        public Vector3 Velocity => _velocity;

        public void SetTimeScaleManager(TimeScaleManager scaleManager)
        {
            timeScaleManager = scaleManager;
        }
        
        public void SetForce(Vector2 direction, float force)
        {
            _velocity = direction.normalized * force;
        }

        public void AddForce(Vector2 direction, float force)
        {
            _velocity += (Vector3)(direction.normalized * force);
        }

        public void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
        }

        public void SetColliderRadius(float value)
        {
            colliderRadius = value;
        }

        private void Update()
        {
            PhysicsUpdate();
        }

        private void PhysicsUpdate()
        {
            float timeScale = timeScaleManager ? timeScaleManager.CurrentScale : Time.timeScale;
            
            _velocity += Physics.gravity * (Time.deltaTime * timeScale);
            transform.position += _velocity * (Time.deltaTime * timeScale);
        }
        
        [Conditional("UNITY_EDITOR")]
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
        
            Gizmos.DrawWireSphere(transform.position, ColliderRadius);
        }
    }
}
