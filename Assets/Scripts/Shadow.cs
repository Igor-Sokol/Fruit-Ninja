using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer shadowSprite;
    [SerializeField] private Vector2 shadowOffset;

    public bool ShadowEnabled { get => shadowSprite.enabled; set => shadowSprite.enabled = value; }
    
    public void SetSprite(Sprite originSprite)
    {
        shadowSprite.sprite = originSprite;
    }

    private void Update()
    {
        var parentPosition = transform.parent.position;
        var parentScale = transform.parent.localScale;
        
        transform.position = parentPosition + new Vector3(shadowOffset.x * parentScale.x * parentScale.x,
            shadowOffset.y * parentScale.y * parentScale.y);
    }
}
