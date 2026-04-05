using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float turningPoint = -1.5f;
    private float originalPos = 3f;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Animator animator;
   

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
            //changed so that the direction the fox faces will always be its opposite when it reaches the coop,
            //instead of stuck at 1 flip with spriteRenderer.flipX = true;
            spriteRenderer.flipX = !spriteRenderer.flipX;
            
        }
       if (transform.position.x > originalPos)
        {
            speed = -speed;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

       
       if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isWalking", true);
        }
       else
        {
            animator.SetBool("isWalking", false);
        }
    }

   
}
