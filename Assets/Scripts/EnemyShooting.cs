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
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().direction = Vector2.down;
    }
}
