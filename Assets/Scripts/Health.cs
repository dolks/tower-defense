using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] AudioClip deathSound;
    [SerializeField] float deathSoundVolume = 10f;
    [SerializeField] GameObject deathVFXPrefab;

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public int GetHealth() { return health; }

    public void SetHealth(int newHealth) { health = newHealth; }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(
            deathSound,
            Camera.main.transform.position,
            deathSoundVolume
        );
        GameObject deathVFXObject = Instantiate(deathVFXPrefab, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
}
