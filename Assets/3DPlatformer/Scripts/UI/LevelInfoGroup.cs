using UnityEngine;

public class LevelInfoGroup : MonoBehaviour
{
    [SerializeField] private LevelInfo[] levelsInfo;

    [SerializeField] private MainMenu mainMenu;

    private void Start()
    {
        for (int i = 0; i < levelsInfo.Length; i++)
        {
            int number = i;
            levelsInfo[number].OnSelect += () => SelectLevelInfo(levelsInfo[number]);
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

        mainMenu.SetCurrentLevel(currentLevelInfo.CurrentLevel);
    }
}
