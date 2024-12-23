using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInformer", menuName = "Scriptable Objects/LevelInformer")]
public class LevelInformer : ScriptableObject
{
    [SerializeField] private int currentStarsCount;

    private void Start()
    {
        Debug.Log(Path.Combine(Application.persistentDataPath, $"{name}.json").ToString());
    }

    public string SavePath
    {
        get
        {
            return Path.Combine(Application.persistentDataPath, $"{name}.json");
        }
    }

    private void Save()
    {
        try
        {
            string jsonData = JsonUtility.ToJson(this, true);
            File.WriteAllText(SavePath, jsonData);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Ошибка при сохранении данных: {e.Message}");
        }
    }

    public void Load()
    {
        try
        {
            if (File.Exists(SavePath))
            {
                string jsonData = File.ReadAllText(SavePath);
                JsonUtility.FromJsonOverwrite(jsonData, this);
            }
            else
            {
                Debug.LogWarning("Файл сохранения не найден");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Ошибка при загрузке данных: {e.Message}");
        }
    }

    public int CurrentStarsCount
    {
        get
        {
            return currentStarsCount;
        }
    }

    public void SetCurrentStarsCount(int newCurrentStarsCount)
    {
        if (currentStarsCount < newCurrentStarsCount)
        {
            currentStarsCount = newCurrentStarsCount;
            Save();
        }
    }
}
