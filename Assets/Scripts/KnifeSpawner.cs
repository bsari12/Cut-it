using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    public GameObject knifePrefab;
    public int knivesRemaining;
    
    private int totalKnives;
    private Sprite currentLevelKnifeSprite;

    void Start()
    {
        if (GameManager.instance != null && GameManager.instance.currentLevelData != null)
        {
            totalKnives = GameManager.instance.currentLevelData.totalKnives;
            knivesRemaining = totalKnives;
            currentLevelKnifeSprite = GameManager.instance.currentLevelData.knifeSprite;
            
            GameUI.instance.SetInitialKnives(knivesRemaining);
        }
    }

    void Update()
    {
        if (knivesRemaining > 0 && Input.GetMouseButtonDown(0))
        {
            SpawnKnife();
        }
    }

    void SpawnKnife()
    {
        knivesRemaining--;

        int uiIndex = totalKnives - 1 - knivesRemaining;
        GameUI.instance.DecreaseKnifeIndex(uiIndex);
        
        GameObject newKnife = Instantiate(knifePrefab, transform.position, Quaternion.identity);
        
        if (currentLevelKnifeSprite != null)
        {
            newKnife.GetComponent<SpriteRenderer>().sprite = currentLevelKnifeSprite;
        }
    }
}