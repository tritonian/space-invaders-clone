using UnityEngine;


public class Projectile : MonoBehaviour
{
    // settings
    public Vector2 direction; // x, y vector that determines direction, for example (0, 1) up or (0, -1) down
    public float stepLength; // scalar value to move each step
    public float screenHeight = 5f; // used for killing projectiles that move off screen

    // local variables
    private SpriteRenderer spriteRenderer; // the sprite renderer component on this game object - private because we get it in the start method

    private void Start()
    {
        // gets the sprite renderer component on the gameobject this script is on
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (direction != null)
        {
            // if direction isn't empty, it has been assigned
            // move some speed up/down based on that direction

            Vector3 moveStep = stepLength * Time.deltaTime * direction; // the vector we want to move - scaled by deltaTime
            transform.position = transform.position + moveStep; // add the vector we want to move to our current position
        }

        // kill projectile when it leaves the screen plus a tiny buffer
        if (Mathf.Abs(transform.position.y) > screenHeight + 1f)
        {
            Destroy(gameObject);
        }
    }

    public void SetSprite(Sprite newSprite)
    {
        // check that we have a valid spriteRenderer assigned
        if (spriteRenderer != null)
        {
            // set that sprite renderer to use the sprite that got passed in
            spriteRenderer.sprite = newSprite;
        }
        else
        {
            Debug.Log("Sprite renderer hasn't been assigned!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // projectiles get destroyed no matter what they hit - except the thing that launched them
        // this function should also be called on the other object that got hit
        // projectile is set up as a trigger and with a kinematic rigidbody2D so that it will trigger collisions

        //Debug.Log("Projectile hit something" + collision.name + " " + collision.tag);

        // check if we hit the thing that launched us - Player is tagged "Player" - Compare tag is better than string comparison using if (tag == tag)
        if (direction == Vector2.up && collision.CompareTag("Player"))
        {
            // projectile came from player and hit itself - don't destroy
            return;
        }

        if (direction == Vector2.down && collision.CompareTag("Enemy"))
        {
            // projectile came from enemy and hit itself - don't destory
            return;
        }

        Destroy(gameObject); // destroys this projectile
    }
}
