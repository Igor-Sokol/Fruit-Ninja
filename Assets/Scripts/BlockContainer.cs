using System.Collections.Generic;
using System.Diagnostics;
using Adaptive;
using Extensions;
using UnityEngine;

public class BlockContainer : MonoBehaviour
{
    private List<Block> _blocks;
    private Vector2[] _deadZone;
    
    [SerializeField] private Transform container;
    [SerializeField] private Vector2[] deadZonePercentage;

    private void Awake()
    {
        _blocks = new List<Block>();

        _deadZone = new Vector2[deadZonePercentage.Length];
        for (int i = 0; i < deadZonePercentage.Length; i++)
        {
            _deadZone[i] = ScreenManager.Instance.PositionFromPercentage(deadZonePercentage[i]);
        }
    }

    private void Update()
    {
        for (int i = 0; i < _blocks.Count; i++)
        {
            if (CollisionDetector.IsCircleCollision(_blocks[i].transform.position, _blocks[i].ColliderRadius, _deadZone))
            {
                var block = _blocks[i];
                Destroy(block.gameObject);
                _blocks.RemoveAt(i);
            }
        }
    }

    public void AddBlock(Block block)
    {
        _blocks.Add(block);
        block.transform.parent = container;
    }

    [Conditional("UNITY_EDITOR")]
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        
        Gizmos.color = Color.red;
        for (int i = 1; i < deadZonePercentage.Length; i++)
        {
            Gizmos.DrawLine(ScreenManager.Instance.PositionFromPercentage(deadZonePercentage[i - 1]),
                ScreenManager.Instance.PositionFromPercentage(deadZonePercentage[i]));
        }

        if (deadZonePercentage.Length > 1)
        {
            Gizmos.DrawLine(ScreenManager.Instance.PositionFromPercentage(deadZonePercentage[0]),
                ScreenManager.Instance.PositionFromPercentage(deadZonePercentage[deadZonePercentage.Length - 1]));
        }
    }
}