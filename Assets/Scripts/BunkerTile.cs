using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerTile : MonoBehaviour
{
    public float health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // when something collides with us, take damage
        // going to assume it's a projectile

        //Debug.Log("Collided with a bunker piece, bunker taking damage.");
        health -= 20f;

        // could check health here and if health is less than some number, set a new sprite

        // destroy if health hits 0
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
