using UnityEditor;
using UnityEngine;

public class GetChicken : MonoBehaviour
{
    private float turningPoint = -1.5f;
    public GameObject chicken;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < turningPoint)
        {
            Instantiate(chicken, transform.position, chicken.transform.rotation);
            
        }
    }
}
