using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private string mainManuSceneName;

    public void GoMainMenu()
    {
        SceneManager.LoadScene(mainManuSceneName);
    }

    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
