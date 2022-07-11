using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipMovement : MonoBehaviour
{

    public float maxXPosition;
    public float minXPosition;
    public float mothershipSpeed;
    public float minShowTime = 10f;
    public float maxShowTime = 20f;
    public float maxXOutOfBounds = 12f;
    public float minXOutOfBounds = -12f;
    public float enemyMoveSpeed;

    
    private float movespeed;
    private float enemyPosition = 0;
    private float showTimePassed = 0f;
    private float timeBetweenShow;
    private bool shipDirection;
    public GameObject EnemyShooting;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShow = Random.Range(minShowTime, maxShowTime);
    }

    // Update is called once per frame
    void Update()
    {
        showTimePassed += Time.deltaTime;//adding to show clock

        EnemyShooting.GetComponent<EnemyShooting>().Shoot();
        //call shooting func from enemy shooting class


        if (showTimePassed >= timeBetweenShow)//measure since last show, trip new show once clock expires
        {
            show();
            showTimePassed = 0f;
            timeBetweenShow = Random.Range(minShowTime, maxShowTime);
        }

    }

    private void show()
    {
        //true = to the left- starts on true
        shipDirection = true;

        if (shipDirection == true)
        {
            if (transform.position.x < minXOutOfBounds)
            {
                enemyPosition = 0;
            }
        }
        if (shipDirection == false)
        {
            if (transform.position.x < minXOutOfBounds)
            {
                enemyPosition = 0;
            }
        }


        float moveSpeed = enemyPosition * Time.deltaTime * enemySpeed;
        transform.position = transform.position + new Vector3(moveSpeed, 0f, 0f);
    }

    private void MoveForward()
    {
        transform.position = transform.position + new Vector3(0f, -forwardStep, 0f);
    }
}
