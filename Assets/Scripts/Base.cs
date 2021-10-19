using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Attacker>())
        {
            FindObjectOfType<Lives>().SubtractLives(1);
            Destroy(collision.gameObject);
        }
    }
}
