using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner spawnerInLane;
    Animator animator; 

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if(AttackerIsInLane())
        {
            animator.SetBool("isAttacking", true);
        } else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough =
                Mathf.Abs(spawner.transform.position.y - transform.position.y)
                <= Mathf.Epsilon;

            if (isCloseEnough)
            {
                spawnerInLane = spawner;
                break;
            }
        }
    }

    private bool AttackerIsInLane()
    {
        return spawnerInLane != null && spawnerInLane.transform.childCount > 0;
    }
}
