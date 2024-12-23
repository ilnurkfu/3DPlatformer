using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int currentlevel;

    [SerializeField] private string playSceneName;

    public void QuitApplication()
    {
        Debug.Log("Выход из игры");
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(playSceneName);
    }

    public void SetCurrentLevel(int newLevel)
    {
        currentlevel = newLevel;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(currentlevel);
    }

}
