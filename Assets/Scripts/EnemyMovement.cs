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
    public float forwardStep;
    public float minYPosition;
    public float playerDeathPosition;
    public GameManager gameManager;

    private float enemyPosition = 1f; // 1 is right direction ->, neg is <-
    public int enemyCount; // number of enemies in group
    public int startingEnemyCount;

    void Start()
    {
        GetMinMax();
        startingEnemyCount = enemyCount;
    }

    void Update()
    {
        //enemy loss detection - active in heirarchy 

        GetMinMax(); // check if we are out of bounds, also gets number of enemies
        MoveEnemies(); // set direction of movement based on position, move
        CheckDeath();//see if enemies have over run player, end game.

        if (enemyCount <= 0)
        {
            // go to next level
            FindObjectOfType<GameManager>().NextLevel();
            Destroy(gameObject); // destroy so we stop running this update function and don't call NextLevel each frame
            return;
        }
    }
    
    void MoveEnemies()
    {
        // check if our right-most enemy is past right wall
        if (maxXPosition > maxXOutOfBounds)
        {
            // move left
            enemyPosition = -1;
            MoveForward();
        }

        // check if our left-most enemy is past left wall
        if (minXPosition < minXOutOfBounds)
        {
            // move right
            enemyPosition = 1;
            MoveForward();
        }

        // calculate movement speed using direction, deltaTime, speed setting, and multiplier calculated from number of enemies killed (scales from 1f to 2f)
        float moveSpeed = enemyPosition * Time.deltaTime * enemySpeed * (2f - ((float)enemyCount / (float)startingEnemyCount));
        transform.position = transform.position + new Vector3(moveSpeed, 0f, 0f);
    }

    private void MoveForward()
    {
        transform.position = transform.position + new Vector3(0f, -forwardStep, 0f);
    }

    public void GetMinMax()
    {
        maxXPosition = 0f;
        minXPosition = 0f;

        enemyCount = 0;

        foreach (Transform enemy in transform.GetComponentsInChildren<Transform>())
        {
            if (!enemy.gameObject.activeInHierarchy || enemy.transform == transform) continue;

            enemyCount += 1;

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
    public void CheckDeath()
    {
        minYPosition = 0f;

        foreach (Transform enemy in transform.GetComponentInChildren<Transform>())
        {
            if (!enemy.gameObject.activeInHierarchy || enemy.transform == transform) continue;

            if (enemy.position.y < minYPosition)
            {
                minYPosition = enemy.position.y;
            }
        }
        if (minYPosition <= playerDeathPosition)
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }
    }
}


