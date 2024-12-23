using UnityEngine;

public class UISwitcher : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private FinalMenu finalMenu;
    [SerializeField] private StatisticsMenu statisticsMenu;

    [SerializeField]
    private void Start()
    {
        SetCursorLockMode(false);
    }

    public void SwitchPauseMenu()
    {
        if (finalMenu.gameObject.activeSelf == false)
        {
            statisticsMenu.gameObject.SetActive(pauseMenu.gameObject.activeSelf);
            pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
            SetCursorLockMode(pauseMenu.gameObject.activeSelf);
        }
    }

    public void EnableFinalMenu()
    {
        pauseMenu.gameObject.SetActive(false);
        statisticsMenu.gameObject.SetActive(false);
        SetCursorLockMode(true);
        finalMenu.gameObject.SetActive(true);
    }

    public void SetCursorLockMode(bool pauseMenuIsActive)
    {
        if (pauseMenuIsActive == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public bool GetPauseMenuStatus()
    {
        return pauseMenu.gameObject.activeSelf;
    }
}
