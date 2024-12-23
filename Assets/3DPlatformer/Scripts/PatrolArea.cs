using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PatrolArea : MonoBehaviour, ITriggerObject
{
    [SerializeField] private List<Enemy> listEnemies;

    [SerializeField] private List<int> keys;
    [SerializeField] private Dictionary<int, Enemy> enemies = new Dictionary<int, Enemy>();
    private void Start()
    {
        for(int i = 0; i < listEnemies.Count; i++)
        {
            enemies.Add(i, listEnemies[i]);
            keys.Add(i);
            int number = i;
            enemies[i].OnDied += () => DeleteEnemy(number);
        }
    }

    public void TriggerAction(Character character)
    {
        ActivatedChase(character);
    }

    public void ExitAction(Character character)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[keys[i]].SetChase(false);
        }
    }

    private void DeleteEnemy(int keyNumber)
    {
        enemies.Remove(keyNumber);
        keys.Remove(keyNumber);
    }

    public void DeleteEnemy()
    {
        Debug.Log("Delete");
    }

    private void ActivatedChase(Character character)
    {
        if(character.GetComponent<Player>())
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[keys[i]].SetChase(true);
            }
        }
    }
}
