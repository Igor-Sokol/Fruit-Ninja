using System.Diagnostics;
using Adaptive;
using BlockComponents;
using UnityEngine;

namespace GizmosRenderer
{
    public class DeadZoneRenderer : MonoBehaviour
    {
        [SerializeField] private BlockDeadZone[] deadZones;
        [SerializeField] private PlayingField playingField;
        
        [Conditional("UNITY_EDITOR")]
        private void OnDrawGizmos()
        {
            if (!Application.isPlaying) return;
        
            Gizmos.color = Color.red;

            foreach (var deadZone in deadZones)
            {
                Gizmos.DrawLine(playingField.PositionFromPercentage(new Vector2(deadZone.Zone.x, deadZone.Zone.y)), 
                    playingField.PositionFromPercentage(new Vector2(deadZone.Zone.width, deadZone.Zone.y)));
        
                Gizmos.DrawLine(playingField.PositionFromPercentage(new Vector2(deadZone.Zone.width, deadZone.Zone.y)),
                    playingField.PositionFromPercentage(new Vector2(deadZone.Zone.width, deadZone.Zone.height)));
        
                Gizmos.DrawLine(playingField.PositionFromPercentage(new Vector2(deadZone.Zone.width, deadZone.Zone.height)),
                    playingField.PositionFromPercentage(new Vector2(deadZone.Zone.x, deadZone.Zone.height)));
        
                Gizmos.DrawLine(playingField.PositionFromPercentage(new Vector2(deadZone.Zone.x, deadZone.Zone.height)),
                    playingField.PositionFromPercentage(new Vector2(deadZone.Zone.x, deadZone.Zone.y)));
            }
        }
    }
}