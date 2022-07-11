using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipMovementFixed : MonoBehaviour
{

    //public float maxXPosition; // no longer used
    //public float minXPosition; // no longer used
    //public float mothershipSpeed; // no longer used
    
    public float maxXOutOfBounds = 12f;
    public float minXOutOfBounds = -12f;
    public float enemyMoveSpeed;

    
    //private float movespeed; // not used, enemyMoveSpeed is used
    private float enemyPosition = 0;
    
    private bool shipDirection;
    //public EnemyShooting enemyShooting; // changed from GameObject type to EnemyShooting type and renamed to lowercase enemyShooting, also not used anymore though

    private Vector2 movementDirection = Vector2.zero; // default direction zero (should be zero if we don't specify, but just to make sure)

    private void Start()
    {
        // other option for destroying, rather than checking position each frame
        Destroy(gameObject, 15);
    }

    void Update()
    {
        // this mothership spawning-related stuff can't be on this script because we need to
        // spawn it outside of the movement script and only move the ship in this script
        // moving it to enemy parent game object in scene, with new script MothershipSpawner
        //showTimePassed += Time.deltaTime;//adding to show clock

        //enemyShooting.GetComponent<EnemyShooting>().Shoot(); // not correct calling
        //enemyShooting.Shoot(); // will discuss this change - oh and mothership doesn't shoot
        //call shooting func from enemy shooting class

        //if (showTimePassed >= timeBetweenShow)//measure since last show, trip new show once clock expires
        //{
        //    Show();
        //    showTimePassed = 0f;
        //    timeBetweenShow = Random.Range(minShowTime, maxShowTime);
        //}
        MoveForward();
    }

    private void Show() // leaving this function as it is and adding to MoveForward in stead, which I think is a better name
    {
        //true = to the left- starts on true
        shipDirection = true;

        // ALEX COMMENT - is it supposed to hit the wall then turn around? I thought in the game it just went across the screen then disappeared

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

        float moveSpeed = enemyPosition * Time.deltaTime * enemyMoveSpeed; // ALEX COMMENT - enemy position is never changed from 0, so moveSpeed will always be 0
        transform.position = transform.position + new Vector3(moveSpeed, 0f, 0f); // ALEX COMMENT - this probably is supposed to be in the update function where it will run every frame? You have it twice.
    }

    private void MoveForward() // ALEX COMMENT - this needs to be called every frame (or update step)
    {
        //transform.position = transform.position + new Vector3(0f, -forwardStep, 0f); // ALEX COMMENT - forwardStep undefined - enemyMoveSpeed is effectively the same thing

        // check if we are past the bounds on either side - for example, if we are past bound on right side, we want to move left until we hit left wall, then keep moving that direction
        // keeping track of direction in Vector2 movementDirecion - if it is Vector2.zero still then we know direction hasn't been set yet, so only doing check once (probably not the best way to do this)
        // once a direction has been set, it won't be Vector2.zero anymore and won't go through this if statement
        if (movementDirection == Vector2.zero)
        {
            // no direction set yet - check which direction to go
            if (transform.position.x > maxXOutOfBounds)
            {
                // right of right bound
                // set direction left
                movementDirection = Vector2.left;
            }

            if (transform.position.x < minXOutOfBounds)
            {
                // left of left bound
                // set direction right
                movementDirection = Vector2.right;
            }
        }

        // move some speed in the direction set above, scaled by frame rate - pretty much copied from your code
        float moveStep = movementDirection.x * Time.deltaTime * enemyMoveSpeed;
        transform.position = transform.position + new Vector3(moveStep, 0f, 0f);


        // now we want to check if our direction is left and we are past left bound - if we are, destroy
        if (transform.position.x < minXOutOfBounds && movementDirection == Vector2.left)
        {
            // moving left and past left bound, so destroy
            Destroy(gameObject);
        }
        // now same thing for moving right-
        if (transform.position.x > maxXOutOfBounds && movementDirection == Vector2.right)
        {
            // moving left and past left bound, so destroy
            Destroy(gameObject);
        }
        // an easier way might be to just destroy after some seconds - we know it will be outside the frame by that point and it's ok if it's past frame by a lot
    }
}
