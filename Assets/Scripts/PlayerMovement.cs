using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float turningPoint = -1.5f;
    private Vector2 playerRotation = new Vector2(0, 180);
    private SpriteRenderer spriteRenderer;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
       if (transform.position.x < turningPoint)
        {
            speed = -speed;
            spriteRenderer.flipX = true;
            
        }
    }
}
