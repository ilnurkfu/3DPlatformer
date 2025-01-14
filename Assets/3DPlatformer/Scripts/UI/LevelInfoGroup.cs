using UnityEngine;
using UnityEngine.UI;

public class LevelInfoGroup : MonoBehaviour
{
    [SerializeField] private LevelInfo[] levelsInfo;

    [SerializeField] private MainMenu mainMenu;

    [SerializeField] private Button apllyButton;

    private void Start()
    {
        int levelPassed = 0;

        for (int i = 0; i < levelsInfo.Length; i++)
        {
            int number = i;
            levelsInfo[number].Initialized();
            levelsInfo[number].OnSelect += () => SelectLevelInfo(levelsInfo[number]);

            if (levelsInfo[number].CurrentLevelInformer.CurrentStarsCount > 0 && number < levelsInfo.Length - 1)
            {
                levelsInfo[number + 1].UnlockingLevel();
            }

            if(levelsInfo[number].CurrentLevelInformer.CurrentStarsCount == 3)
            {
                levelPassed++;
            }
        }

        if(levelPassed >= levelsInfo.Length - 1)
        {
            UnlockSecretlevel();
        }
    }

    public void ApplyDefaultSetting()
    {
        for (int i = 0; i < levelsInfo.Length; i++)
        {
            levelsInfo[i].DefaultSettings();
            apllyButton.interactable = false;
        }
    }

    private void SelectLevelInfo(LevelInfo currentLevelInfo)
    {
        for (int i = 0; i < levelsInfo.Length; i++)
        {
            Debug.Log(levelsInfo[i] == currentLevelInfo);
            if (levelsInfo[i] == currentLevelInfo)
            {
                levelsInfo[i].Select();
            }
            else
            {
                levelsInfo[i].Deselect();
            }
        }

        apllyButton.interactable = true;
        mainMenu.SetCurrentLevel(currentLevelInfo.CurrentLevel);
    }

    private void UnlockSecretlevel()
    {
        levelsInfo[levelsInfo.Length - 1].gameObject.SetActive(true);
    }
}
