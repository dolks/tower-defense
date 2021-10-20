using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedObject = collision.gameObject;
        if (!collidedObject.GetComponent<Defender>()) { return; }
        if (collidedObject.name.ToString().Equals("Gravestone"))
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        } else
        {
            GetComponent<Attacker>().Attack(collision.gameObject);
        }
    }
}
