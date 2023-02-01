using System.Diagnostics;
using Adaptive;
using BlockInteraction;
using UnityEngine;

public class BlockDeadZone : MonoBehaviour
{
    private Rect _actualDeadZone;
    
    [SerializeField] private PlayingField playingField;
    [SerializeField] private BlockPool blockPool;
    [SerializeField] private BlockContainer blockContainer;
    [SerializeField] private Rect zone;

    private void Start()
    {
        var actualPosition = playingField.PositionFromPercentage(new Vector2(zone.x, zone.y));
        _actualDeadZone.x = actualPosition.x;
        _actualDeadZone.y = actualPosition.y;
        
        actualPosition = playingField.PositionFromPercentage(new Vector2(zone.width, zone.height));
        _actualDeadZone.width = actualPosition.x;
        _actualDeadZone.height = actualPosition.y;
    }

    private void Update()
    {
        CheckBeyondZone();
    }

    private void CheckBeyondZone()
    {
        foreach (var block in blockContainer.Blocks)
        {
            if (BlockBeyondZone(block))
            {
                blockContainer.RemoveBlock(block);
                blockPool.ReturnBlock(block);
            }
        }
    }

    private bool BlockBeyondZone(Block block)
    {
        Vector3 blockPosition = block.transform.position;
        var offsetDeadZone = _actualDeadZone;
        
        offsetDeadZone.x += block.ColliderRadius;
        offsetDeadZone.y += block.ColliderRadius;
        offsetDeadZone.height -= block.ColliderRadius;
        offsetDeadZone.width -= block.ColliderRadius;
        
        if (blockPosition.x <= offsetDeadZone.x || blockPosition.x >= offsetDeadZone.width 
            || blockPosition.y <= offsetDeadZone.y || blockPosition.y >= offsetDeadZone.height)
        {
            return true;
        }

        return false;
    }
    
    [Conditional("UNITY_EDITOR")]
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        
        Gizmos.color = Color.red;

        Gizmos.DrawLine(playingField.PositionFromPercentage(new Vector2(zone.x, zone.y)), 
            playingField.PositionFromPercentage(new Vector2(zone.width, zone.y)));
        
        Gizmos.DrawLine(playingField.PositionFromPercentage(new Vector2(zone.width, zone.y)),
            playingField.PositionFromPercentage(new Vector2(zone.width, zone.height)));
        
        Gizmos.DrawLine(playingField.PositionFromPercentage(new Vector2(zone.width, zone.height)),
            playingField.PositionFromPercentage(new Vector2(zone.x, zone.height)));
        
        Gizmos.DrawLine(playingField.PositionFromPercentage(new Vector2(zone.x, zone.height)),
            playingField.PositionFromPercentage(new Vector2(zone.x, zone.y)));
    }
}