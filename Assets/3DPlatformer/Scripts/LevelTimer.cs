using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float levelComplitionTime;

    [SerializeField] private TextMeshProUGUI timerText;

    public float LevelComplitionTime
    {
        get
        {
            return levelComplitionTime;
        }
    }

    private void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        levelComplitionTime = 0f;
        UpdateTimerText();
    }

    private void Update()
    {
        levelComplitionTime += Time.deltaTime;
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(levelComplitionTime / 60);
        int seconds = Mathf.FloorToInt(levelComplitionTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
