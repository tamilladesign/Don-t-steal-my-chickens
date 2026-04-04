using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Vector2 originalPos = new Vector2 (3f, -0.6f);
    private float exitPos = 4f;
    private float targetAngle = 180f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > exitPos)
        {
            transform.position = originalPos;
            transform.eulerAngles = new Vector2 (0, targetAngle);
            
        }
    }
}
