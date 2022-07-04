using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // pretty terrible performance-wise, there are better ways to do this - maybe have parent have a reference
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if we hit ourselves
        // if we didn't, destroy

        // collision should only happen when a projectile hits, but can be our projectile
        Projectile hitProjectile = collision.GetComponent<Projectile>();
        if (hitProjectile == null)
        {
            // check for null reference
            Debug.Log("Hit something that doesn't have the projectile script! Something is wrong.");
            return;
        }
        if (hitProjectile.direction == Vector2.down)
        {
            // hit our own projectile
            return;
        }

        // if we have gotten this far, it is a projectile and it isn't ours
        // before we destroy, tell GameManager we died so it can add a score
        gameManager.KilledEnemy();
        Destroy(gameObject); // destroy this enemy
    }
}
