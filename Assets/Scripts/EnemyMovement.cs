using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float maxXPosition;
    public float minXPosition;
    public float maxXOutOfBounds;
    public float minXOutOfBounds;
    public float enemySpeed;
    public float speedInterval;

    private float enemyPosition;
    void Start()
    {
        GetMinMax();
    }

    void Update()
    {
        //find far right and left enemies
        //looping through enemies, figuring out farthest

        //enemy loss detection - active in heirarchy 

        //function get min/max(){}
        //movement- similar to enemy shooting script
        //time pass for movement 

        GetMinMax();
        
        if ( maxXPosition < maxXOutOfBounds)
        {
            enemyPosition = -1 * enemySpeed;
        }
        
        if (minXPosition > minXOutOfBounds)
        {
            enemyPosition = 1 * enemySpeed;
        }

        transform.position = transform.position + new Vector3(enemyPosition * Time.deltaTime, 0f, 0f);

    }
    
    void moveEnemies()
    {

    }

    public void GetMinMax()
    {


        foreach (Transform enemy in transform.GetComponentsInChildren<Transform>())
        {
            if (!enemy.gameObject.activeInHierarchy) continue;

            if (enemy.position.x > maxXPosition)
            {
                maxXPosition = enemy.position.x;
            }
            if (enemy.position.x < minXPosition)
            {
                minXPosition = enemy.position.x;
            }
            //need code to tell distinguis when enemies don't go as far as max or min x
        }
    }
    //get min/max, call in both start and update

}


