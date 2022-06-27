using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float maxXPosition;
    public float minXPosition;
    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        //user input for 2 directions-one axis
        //movement script
        //clamp-keep player on rail
        //shoot input

        Vector2 movementInput = new Vector2();

        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // if x is less than min/max: movement 0
            if (transform.position.x <= minXPosition)
            {
                movementInput.x = 0;
            }
            //if player presses left arrow, set movement to neg 1
            else movementInput.x = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // if x is greater than min/max: movement 0
            if (transform.position.x >= maxXPosition)
            {
                movementInput.x = 0;
            }
            //set movement to pos 1
            else movementInput.x = 1;
        }
       
        transform.position = transform.position + new Vector3(movementInput.x * Time.deltaTime * playerSpeed, 0f, 0f);

        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }

    }
    private void Shoot()
    {
        //create projectile
        //give direction

        Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
        projectile.direction = Vector2.up;
    }
}
