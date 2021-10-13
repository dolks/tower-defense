using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] Attacker[] attackerPrefabs;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            float secondsBeforeNextSpawn = Random.Range(1f, 5f);
            yield return new WaitForSeconds(secondsBeforeNextSpawn);
            Spawn();
        }
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, attackerPrefabs.Length);
        Attacker attacker = Instantiate(attackerPrefabs[randomIndex], transform.position, transform.rotation);
        attacker.transform.parent = transform;
    }
}
