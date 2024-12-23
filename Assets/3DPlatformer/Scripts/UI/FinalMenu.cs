using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI starsText;

    [SerializeField] private int nextSceneIndex;

    public void SetFinalStatistics(int allStarsCount, int currentStarsCount, int PerfectTimeMinutes, int PerfectTimeSeconds, int currentTimeMinutes, int currentTimeSeconds)
    {
        if (currentTimeMinutes > PerfectTimeMinutes)
        {
            timerText.text = $"<Color=red>{currentTimeMinutes:00}:{currentTimeSeconds:00}</Color> / {PerfectTimeMinutes:00}:{PerfectTimeSeconds:00}";
        }
        else
        {
            if (currentTimeSeconds > PerfectTimeSeconds)
            {
                timerText.text = $"<Color=red>{currentTimeMinutes:00}:{currentTimeSeconds:00}</Color> / {PerfectTimeMinutes:00}:{PerfectTimeSeconds:00}";
            }
            else
            {
                timerText.text = $"<Color=green>{currentTimeMinutes:00}:{currentTimeSeconds:00}</Color> / {PerfectTimeMinutes:00}:{PerfectTimeSeconds:00}";
            }
        }
        
        starsText.text = $"{currentStarsCount} / {allStarsCount}";
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
