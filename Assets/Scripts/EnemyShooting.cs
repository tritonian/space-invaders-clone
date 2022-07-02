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
    private float currentShootTime;

    private void Start()
    {
        currentShootTime = Random.Range(minTimeShoot, maxTimeShoot);
    }

    void Update()
    {
        shotTimePassed += Time.deltaTime;
        if (shotTimePassed >= currentShootTime)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //create projectile
        //create direction for proj.
        //create sprite?
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.GetComponent<Projectile>().direction = Vector2.down;
    }
}
