using Blocks.BlockComponents;
using Extensions.Vectors;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameSystems.SpawnSystem
{
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
        public float Angel1 => angel1;
        public float Angel2 => angel2;
        public float SpawnerLength => spawnerLength;

        public void Launch(BlockPhysic blockPhysic)
        {
            Vector3 transformRight = transform.right;
            Vector3 launchPoint = transform.position - transformRight * (spawnerLength / 2) 
                                  + transformRight * Random.Range(0, spawnerLength);
            Vector3 launchDirection = transform.up.Rotate(Random.Range(angel1, angel2));

            blockPhysic.transform.position = launchPoint;
            blockPhysic.SetForce(launchDirection, Random.Range(forceRange.x, forceRange.y));
        }
    }
}
