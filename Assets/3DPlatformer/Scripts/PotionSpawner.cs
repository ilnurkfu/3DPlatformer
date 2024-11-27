using UnityEngine;

public class PotionSpawner : BaseSpawner
{
    private void OnValidate()
    {
        if (spawnPrefab.GetComponent<IPotionBase>() == null)
        {
            Debug.LogWarning("��������� ������ �� �������� ������ ��������� <IPotionBase>");
            spawnPrefab = null;
        }
    }

    public override void Spawn()
    {
        if(isSpawn == true)
        {
            currentObject = Instantiate(spawnPrefab, spawnPoint.position, Quaternion.identity);
            currentObject.GetComponent<IPotionBase>().SetRandomValue();
        }

        SpawnCheck();
    }
}
