using System;
using UnityEngine;
using UnityEngine.UI;
public class LevelInfo : MonoBehaviour
{
    [SerializeField] private int currentLevel;

    [SerializeField] private GameObject outline;

    [SerializeField] private LevelInformer levelInformer;

    [SerializeField] private GameObject[] levelStars;

    [SerializeField] private Button levelButton;

    public Action OnSelect;

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
    }

    public LevelInformer CurrentLevelInformer
    {
        get
        {
            return levelInformer;
        }
    }

    //private void Start()
    //{
    //    levelInformer.Load();
    //    for (int i = 0; i < levelStars.Length; i++)
    //    {
    //        if (levelInformer.CurrentStarsCount > i)
    //        {
    //            levelStars[i].SetActive(true);
    //        }
    //    }
    //}

    public void Initialized()
    {
        levelInformer.Load();
        for (int i = 0; i < levelStars.Length; i++)
        {
            if (levelInformer.CurrentStarsCount > i)
            {
                levelStars[i].SetActive(true);
            }
        }
    }

    public void OnClick()
    {
        OnSelect?.Invoke();
    }

    public void Select()
    {
        outline.SetActive(true);
        Debug.Log("Select");
    }

    public void Deselect()
    {
        outline.SetActive(false);
        Debug.Log("Deselect");
    }

    public void UnlockingLevel()
    {
        levelButton.interactable = true;
    }

    public void DefaultSettings()
    {
        outline.SetActive(false);
    }
}
