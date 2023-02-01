using System.Diagnostics;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Vector3 _velocity;

    [SerializeField] private float colliderRadius;

    public float ColliderRadius => colliderRadius;

    public void AddForce(Vector2 direction, float force)
    {
        _velocity = direction.normalized * force;
    }

    private void Update()
    {
        PhysicsUpdate();
    }

    private void PhysicsUpdate()
    {
        _velocity += Physics.gravity * Time.deltaTime;
        transform.position += _velocity * Time.deltaTime;
    }

    [Conditional("UNITY_EDITOR")]
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        
        Gizmos.DrawWireSphere(transform.position, colliderRadius);
    }
}
