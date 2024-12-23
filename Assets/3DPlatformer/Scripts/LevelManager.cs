using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int currentLevelIndex;

    private static LevelManager instance;

    public static LevelManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentLevelIndex(int newLevelIndex)
    {
        currentLevelIndex = newLevelIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }

    public void NextLevel()
    {
        currentLevelIndex++;
        SceneManager.LoadScene(currentLevelIndex);
    }
}
