using System.Diagnostics;
using Extensions;
using Extensions.Vectors;
using GameSystems.SpawnSystem;
using UnityEngine;

namespace GizmosRenderer
{
    public class SpawnerRenderer : MonoBehaviour
    {
        [SerializeField] private Spawner[] spawners;
        
        [Conditional("UNITY_EDITOR")]
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            foreach (var spawner in spawners)
            {
                var transformPosition = spawner.transform.position;
                var transformUp = spawner.transform.up;
                var transformRight = spawner.transform.right;

                Vector3 lengthOffset = transformRight * spawner.SpawnerLength / 2;
                Gizmos.DrawLine(transformPosition - lengthOffset, transformPosition + lengthOffset);

                Gizmos.DrawLine(transformPosition, transformPosition + transformUp.Rotate(spawner.Angel1));
                Gizmos.DrawLine(transformPosition, transformPosition + transformUp.Rotate(spawner.Angel2));
            }
        }
    }
}