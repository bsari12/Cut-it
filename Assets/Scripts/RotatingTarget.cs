using UnityEngine;

public class RotatingTarget : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private int requiredKnives;
    private int currentKnivesHit;

    void Start()
    {
        if (GameManager.instance != null && GameManager.instance.currentLevelData != null)
        {
            requiredKnives = GameManager.instance.currentLevelData.totalKnives;
            rotationSpeed = GameManager.instance.currentLevelData.rotationSpeed;
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    public void OnHit()
    {
        currentKnivesHit++;

        if (currentKnivesHit >= requiredKnives)
        {
            BreakTarget();
        }
    }

    void BreakTarget()
    {
        gameObject.SetActive(false);
        GameManager.instance.LevelComplete();
    }
}