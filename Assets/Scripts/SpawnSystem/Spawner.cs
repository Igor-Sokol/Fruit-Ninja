using System.Diagnostics;
using Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float priority;
    [SerializeField] private Vector2 forceRange;
    [SerializeField][Range(-90f, 90f)] private float angel1;
    [SerializeField][Range(-90f, 90f)] private float angel2;
    [SerializeField] private float spawnerLength;
    [SerializeField] private Vector2 percentagePosition;

    public float Priority => priority;
    public Vector2 PercentagePosition => percentagePosition;

    public void Launch(BlockPhysic blockPhysic)
    {
        Vector3 transformRight = transform.right;
        Vector3 launchPoint = transform.position - transformRight * (spawnerLength / 2) 
                              + transformRight * Random.Range(0, spawnerLength);
        Vector3 launchDirection = transform.up.Rotate(Random.Range(angel1, angel2));

        blockPhysic.transform.position = launchPoint;
        blockPhysic.AddForce(launchDirection, Random.Range(forceRange.x, forceRange.y));
    }

    // Draw directions
    [Conditional("UNITY_EDITOR")]
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        var transformPosition = transform.position;
        var transformUp = transform.up;
        var transformRight = transform.right;

        Vector3 lengthOffset = transformRight * spawnerLength / 2;
        Gizmos.DrawLine(transformPosition - lengthOffset, transformPosition + lengthOffset);

        Gizmos.DrawLine(transformPosition, transformPosition + transformUp.Rotate(angel1));
        Gizmos.DrawLine(transformPosition, transformPosition + transformUp.Rotate(angel2));
    }
}
