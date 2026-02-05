using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "KnifeHit/Level Data")]
public class LevelData : ScriptableObject
{
    public Sprite targetSprite;
    public Sprite hiddenPhoto;
    public Sprite knifeSprite; 
    
    public int totalKnives;
    public float rotationSpeed;

    public float targetScale = 1f;
    public float colliderRadius = 0.5f;
}