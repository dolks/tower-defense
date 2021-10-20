using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    int enemiesSpawned = 0;
    int enemiesKilledSoFar = 0;
    bool levelFinished = false;

    void Update()
    {
        if (levelFinished) { return; }
        if (enemiesKilledSoFar == enemiesSpawned
            && FindObjectOfType<GameTimer>().IsFinished())
        {
            levelFinished = true;
            Debug.Log("You did eet");
        }
    }

    public void AddEnemyKill() { enemiesKilledSoFar++; }

    public void AddEnemySpawn() { enemiesSpawned++; }

    public void StopSpawners()
    {
        foreach(AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            spawner.StopSpawing();
        }
    }
}
