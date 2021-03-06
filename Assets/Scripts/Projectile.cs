using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MainPlayArea>()
            || collision.gameObject.GetComponent<Defender>()
            || collision.gameObject.GetComponent<Projectile>()) {
            return;
        }

        gameObject.GetComponent<DamageDealer>().DealDamage(collision.gameObject);
        Destroy(gameObject);
    }
}
