using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerTile : MonoBehaviour
{
    public float health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // when something collides with us, take damage

        Debug.Log("Colided with" + collision.name);

        if (collision.CompareTag("Bunker"))
        {
            return;
        }

        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            return;
        }

        //Debug.Log("Collided with a bunker piece, bunker taking damage.");
        health -= 20f;

        // change sprite based on current health - scale down in y to show "shrinking"
        float percentHealth = health / 100f; // get current health out of 100 - should actually grab max health on start in case max health isn't 100 - same with setting scale
        transform.localScale = new Vector3(1f, percentHealth, 1f);

        // destroy if health hits 0
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
