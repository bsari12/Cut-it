using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    public GameObject knifePrefab;
    public int knivesRemaining;
    
    private int totalKnives;
    private Sprite currentLevelKnifeSprite;
    private GameObject currentKnifeObject;

    void Start()
    {
        if (GameManager.instance != null && GameManager.instance.currentLevelData != null)
        {
            totalKnives = GameManager.instance.currentLevelData.totalKnives;
            knivesRemaining = totalKnives;
            currentLevelKnifeSprite = GameManager.instance.currentLevelData.knifeSprite;
            
            GameUI.instance.SetInitialKnives(knivesRemaining);
            SpawnPassiveKnife();
        }
    }

    void Update()
    {
        if (knivesRemaining > 0 && Input.GetMouseButtonDown(0) && currentKnifeObject != null)
        {
            ThrowCurrentKnife();
        }
    }

    void SpawnPassiveKnife()
    {
        currentKnifeObject = Instantiate(knifePrefab, transform.position, Quaternion.identity);
        
        if (currentLevelKnifeSprite != null)
        {
            currentKnifeObject.GetComponent<SpriteRenderer>().sprite = currentLevelKnifeSprite;
        }

        currentKnifeObject.GetComponent<Knife>().enabled = false;
        currentKnifeObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void ThrowCurrentKnife()
    {
        knivesRemaining--;

        int uiIndex = totalKnives - 1 - knivesRemaining;
        GameUI.instance.DecreaseKnifeIndex(uiIndex);

        currentKnifeObject.GetComponent<Knife>().enabled = true;
        currentKnifeObject.GetComponent<BoxCollider2D>().enabled = true;
        
        currentKnifeObject = null;

        if (knivesRemaining > 0)
        {
            Invoke("SpawnPassiveKnife", 0.1f);
        }
    }
}