using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    [Header("UI Elements")]
    public GameObject knifeIconPrefab;
    public Transform panelContainer;
    public Sprite iconNormal;
    public Sprite iconDark;

    private List<Image> icons = new List<Image>();

    void Awake()
    {
        instance = this;
    }

    public void SetInitialKnives(int count)
    {
        foreach (Transform child in panelContainer)
        {
            Destroy(child.gameObject);
        }
        icons.Clear();

        for (int i = 0; i < count; i++)
        {
            GameObject newIcon = Instantiate(knifeIconPrefab, panelContainer);
            Image img = newIcon.GetComponent<Image>();
            img.sprite = iconNormal;
            icons.Add(img);
        }
    }

    public void DecreaseKnifeIndex(int index)
    {
        if (index >= 0 && index < icons.Count)
        {
            icons[index].sprite = iconDark;
        }
    }
}