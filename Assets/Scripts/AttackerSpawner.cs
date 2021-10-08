using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] Attacker attackerPrefab;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            float secondsBeforeNextSpawn = Random.Range(1f, 5f);
            yield return new WaitForSeconds(secondsBeforeNextSpawn);
            Attacker attacker = Instantiate(attackerPrefab, transform.position, transform.rotation) as Attacker;
            attacker.transform.parent = transform;
        }
    }
}
