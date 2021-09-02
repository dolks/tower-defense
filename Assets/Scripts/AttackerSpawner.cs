using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] GameObject attackerPrefab;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            float secondsBeforeNextSpawn = Random.Range(1f, 5f);
            Instantiate(attackerPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(secondsBeforeNextSpawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
