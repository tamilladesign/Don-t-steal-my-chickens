using UnityEditor;
using UnityEngine;

public class GetChicken : MonoBehaviour
{
    private float turningPoint = -0.4f;
    private float targetAngle = 180f;
    public GameObject[] chickenPrefabs;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int chickenIndex = Random.Range(0, chickenPrefabs.Length);

        
        if (transform.position.x < turningPoint)
        {
            GameObject newChicken = Instantiate(
                chickenPrefabs[chickenIndex],
                new Vector3(turningPoint, -0.65f, 0),
                Quaternion.Euler(0, targetAngle, 0)
                );
            newChicken.transform.SetParent(this.transform);
        }
    }
}
