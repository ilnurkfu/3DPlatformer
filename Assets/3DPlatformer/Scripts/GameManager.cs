using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float perfectTime;

    [SerializeField] private int levelComplitionMinutes;
    [SerializeField] private int levelComplitionSeconds;
    [SerializeField] private int perfectMinutes;
    [SerializeField] private int perfectSeconds;

    [SerializeField] private LevelTimer timer;

    [SerializeField] private LevelProggres levelProggres;

    [SerializeField] private Finish finish;

    [SerializeField] private SecretObject secretObject;

    [SerializeField] private FinalMenu finalMenu;

    [SerializeField] private UISwitcher uISwitcher;

    [SerializeField] private LevelInformer levelInformer;

    private void Start()
    {
        finish.OnFinished += EndLevel;
        secretObject.FindSecretObject += FindSecret;
    }

    public void EndLevel()
    {
        levelProggres.OpenStar();
        if(TimeComparison() == true)
        {
            levelProggres.OpenStar();
        }
        finalMenu.SetFinalStatistics(levelProggres.GetStarsCount(), levelProggres.GetOpenStarsCount(), perfectMinutes, perfectSeconds, levelComplitionMinutes, levelComplitionSeconds);
        uISwitcher.EnableFinalMenu();
        levelInformer.SetCurrentStarsCount(levelProggres.GetOpenStarsCount());
    }

    private void FindSecret()
    {
        levelProggres.OpenStar();
    }

    private bool TimeComparison()
    {
        levelComplitionMinutes = Mathf.FloorToInt(timer.LevelComplitionTime / 60);
        levelComplitionSeconds = Mathf.FloorToInt(timer.LevelComplitionTime % 60);
        perfectMinutes = Mathf.FloorToInt(perfectTime / 60);
        perfectSeconds = Mathf.FloorToInt(perfectTime % 60);

        if (perfectMinutes >= levelComplitionMinutes)
        {
            if(perfectSeconds >= levelComplitionSeconds)
            {
                return true;
            }
            return false;
        }
        return false;
    }
}
