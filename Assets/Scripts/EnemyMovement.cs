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

    private float enemyPosition = 1f; // 1 is right direction ->, neg is <-

    void Start()
    {
        GetMinMax();
    }

    void Update()
    {
        //enemy loss detection - active in heirarchy 

        GetMinMax(); // check if we are out of bounds
        MoveEnemies(); // set direction of movement based on position, move
    }
    
    void MoveEnemies()
    {
        // check if our right-most enemy is past right wall
        if (maxXPosition > maxXOutOfBounds)
        {
            // move left
            enemyPosition = -1;
        }

        // check if our left-most enemy is past left wall
        if (minXPosition < minXOutOfBounds)
        {
            // move right
            enemyPosition = 1;
        }

        transform.position = transform.position + new Vector3(enemyPosition * Time.deltaTime, 0f, 0f);
    }

    public void GetMinMax()
    {
        maxXPosition = 0f;
        minXPosition = 0f;

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
        }
    }
}


