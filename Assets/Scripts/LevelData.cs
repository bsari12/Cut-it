using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "KnifeHit/Level Data")]
public class LevelData : ScriptableObject
{
    public Sprite targetSprite;
    public Sprite hiddenPhoto;
    public Sprite knifeSprite; 
    public int totalKnives;
    public float rotationSpeed;
}