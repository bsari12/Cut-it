using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public LevelData[] allLevels;
    public int currentLevelIndex;
    [HideInInspector] public LevelData currentLevelData;
    public bool isGameOver = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        currentLevelIndex = PlayerPrefs.GetInt("SavedLevel", 0);
        LoadLevelData(currentLevelIndex);
    }

    public void LoadLevelData(int index)
    {
        isGameOver = false;
        if (index < allLevels.Length)
        {
            currentLevelData = allLevels[index];
        }
        else
        {
            currentLevelIndex = 0;
            LoadLevelData(0);
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        currentLevelIndex = 0;
        PlayerPrefs.SetInt("SavedLevel", 0);
        LoadLevelData(0); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelComplete()
    {
        if (isGameOver) return;
        Invoke("NextLevel", 1f);
    }

    public void NextLevel()
    {
        currentLevelIndex++;
        PlayerPrefs.SetInt("SavedLevel", currentLevelIndex);
        
        LoadLevelData(currentLevelIndex); 
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}