using UnityEditor;
using UnityEngine;

public class GetChicken : MonoBehaviour
{
    private float turningPoint = -1.5f;
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
            Instantiate(chickenPrefabs[chickenIndex], new Vector2(0, 0), chickenPrefabs[chickenIndex].transform.rotation);

        }
    }
}
