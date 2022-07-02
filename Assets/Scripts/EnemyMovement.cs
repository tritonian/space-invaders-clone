using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float maxXPosition;
    private float minXPosition;
    public float maxXOOB;
    public float minXOOB;
    public float enemySpeed;
    public float speedInterval;

    Vector2 enemyPosition = new Vector2();
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
        
        if ( maxXPosition < maxXOOB)
        {
            enemyPosition.x = 1 * enemySpeed;
        }
        
        if (minXPosition > minXOOB)
        {
            enemyPosition.x = -1 * enemySpeed;
        }

        transform.position = transform.position + new Vector3(enemyPosition.x * Time.deltaTime, 0f, 0f);

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


