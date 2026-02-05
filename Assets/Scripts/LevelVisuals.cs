using UnityEngine;

public class LevelVisuals : MonoBehaviour
{
    public SpriteRenderer targetRenderer;
    public SpriteRenderer hiddenPhotoRenderer;
    public RotatingTarget rotatingTargetScript;
    public CircleCollider2D targetCollider;

    void Start()
    {
        if (GameManager.instance != null && GameManager.instance.currentLevelData != null)
        {
            LevelData data = GameManager.instance.currentLevelData;
            
            if (targetRenderer != null && data.targetSprite != null) 
            {
                targetRenderer.sprite = data.targetSprite;
                targetRenderer.transform.localScale = new Vector3(data.targetScale, data.targetScale, 1f);
            }

            if (targetCollider != null)
            {
                targetCollider.radius = data.colliderRadius;
            }

            if (hiddenPhotoRenderer != null && data.hiddenPhoto != null) 
            {
                SetSpriteAndResize(hiddenPhotoRenderer, data.hiddenPhoto);
            }

            if (rotatingTargetScript != null) 
            {
                rotatingTargetScript.rotationSpeed = data.rotationSpeed;
            }
        }
    }

    void SetSpriteAndResize(SpriteRenderer renderer, Sprite newSprite)
    {
        Vector2 oldSize = renderer.sprite.bounds.size;
        Vector3 oldScale = renderer.transform.localScale;
        renderer.sprite = newSprite;
        Vector2 newSize = newSprite.bounds.size;
        float newX = (oldSize.x * oldScale.x) / newSize.x;
        float newY = (oldSize.y * oldScale.y) / newSize.y;
        renderer.transform.localScale = new Vector3(newX, newY, 1f);
    }
}