using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    //default min/max shoot time- overided by inspector value
    public float minTimeShoot = 1f;
    public float maxTimeShoot = 10f;

    public GameObject projectilePrefab;
    //public Sprite projectileSprite;

    private float shotTimePassed = 0f;
    private float timeBetweenShots;

    private void Start()
    {
        timeBetweenShots = Random.Range(minTimeShoot, maxTimeShoot);
    }

    void Update()
    {
        shotTimePassed += Time.deltaTime;
        if (shotTimePassed >= timeBetweenShots)
        {
            Shoot();
            shotTimePassed = 0f;
            timeBetweenShots = Random.Range(minTimeShoot, maxTimeShoot); // set new random range so shots aren't evenly spaced
        }
    }

    private void Shoot()
    {
        //create projectile
        //create direction for proj.
        //create sprite?

        if (CheckFirst())
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().direction = Vector2.down;
        }
    }

    private bool CheckFirst() // return true if first in column, false if not - don't shoot if not first in column
    {
        // send out a boxcast (like a raycast, but a box) in the down direction, and save the list of what we hit into an array
        RaycastHit2D[] hits = Physics2D.BoxCastAll(
            new Vector2(transform.position.x, transform.position.y), 
            new Vector2(0.1f, 0.1f), 
            0f, 
            Vector2.down,
            5f);

        // if we hit something, hits won't be empty
        if (hits != null)
        {
            // loop through each object hit and compare tag to enemy, if we hit an enemy then we weren't first in line
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform == transform) continue; // hit ourselves

                if (hit.transform.CompareTag("Enemy")) // hit an enemy, so not in front
                {
                    return false;
                }
            }
        }
        
        // if we made it here, we were first in line and should shoot
        return true;
    }
}
