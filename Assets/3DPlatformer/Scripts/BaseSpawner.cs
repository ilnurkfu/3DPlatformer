using TMPro;
using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour, ISpawner, ITriggerObject
{
    [SerializeField] protected bool isSpawn;

    [SerializeField] private string spawnText;
    [SerializeField] private string notSpawnText;

    [SerializeField] private TextMeshProUGUI uiText;

    [SerializeField] protected GameObject spawnPrefab;
    [SerializeField] protected GameObject currentObject;

    [SerializeField] protected Transform spawnPoint;

    private void Start()
    {
        SpawnCheck();
    }

    private void Update()
    {
        SpawnCheck();
    }

    public abstract void Spawn();

    public void TriggerAction(Character character)
    {
        Spawn();
    }

    protected void SpawnCheck()
    {
        if (currentObject == null)
        {
            isSpawn = true;
        }
        else
        {
            isSpawn = false;
        }

        SetUIText();
    }

    private void SetUIText()
    {
        if(isSpawn)
        {
            uiText.text = spawnText;
        }
        else
        {
            uiText.text = notSpawnText;
        }
    }

    public void ExitAction(Character character)
    {
        
    }
}
