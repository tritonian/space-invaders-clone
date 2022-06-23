using UnityEngine;


public class Projectile : MonoBehaviour
{
    public Vector2 direction;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (direction != null)
        {
            //move x direction
            
        }

    }

    public void SetSprite(Sprite newSprite)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = newSprite;
        }
        else
        {
            Debug.Log("Sprite renderer hasn't been set to a reference object!");
        }
    }
}
