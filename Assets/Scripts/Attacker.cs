using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 1f;
    GameObject currentTarget;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        if (!currentTarget)
        {
            StopAttacking();
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StopAttacking()
    {
        GetComponent<Animator>().SetBool("isAttacking", false);
        currentTarget = null;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(
                (int)Mathf.Floor(damage + (10 * PlayerPrefsController.GetDifficulty()))
            );
        }
    }

    private void Awake()
    {
        FindObjectOfType<LevelController>().AddEnemySpawn();
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().AddEnemyKill();
    }
}
