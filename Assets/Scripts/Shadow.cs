using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private Vector2 shadowOffset;
    
    private void Update()
    {
        var parentPosition = transform.parent.position;
        var parentScale = transform.parent.localScale;
        
        transform.position = parentPosition + new Vector3(shadowOffset.x * parentScale.x * parentScale.x,
            shadowOffset.y * parentScale.y * parentScale.y);
    }
}
