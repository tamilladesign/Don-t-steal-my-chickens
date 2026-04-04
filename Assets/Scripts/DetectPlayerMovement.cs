using UnityEngine;

public class DetectPlayerMovement : MonoBehaviour
{
    private bool isWarning = false;
    private bool isWatching = false;
    private float timer;
    private float watchDuration;
    private float warningDuration;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetRandomTimer();
        // Starting off safe phase (green)
        spriteRenderer.color = Color.green;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        // Start warning phase
        if (timer <= 0 && !isWatching && !isWarning)
        {
            isWarning = true;

            warningDuration = Random.Range(1f, 2f); // reaction time

            spriteRenderer.color = Color.yellow; // change in visual for warning phase

            Debug.Log("WARNING - get ready!");
        }

        // During warning
        if (isWarning)
        {
            warningDuration -= Time.deltaTime;

            if (warningDuration <= 0)
            {
                isWarning = false;
                isWatching = true;

                watchDuration = Random.Range(2f, 5f);

                spriteRenderer.color = Color.red; // change in visual for watching phase

                Debug.Log("DON'T MOVE");
            }
        }

        // During WATCHING
        if (isWatching)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("You moved — GAME OVER");
                // game over logic here
            }

            watchDuration -= Time.deltaTime;

            if (watchDuration <= 0)
            {
                isWatching = false;

                SetRandomTimer();

                spriteRenderer.color = Color.green; // watching done = back to safe phase visual

                Debug.Log("You can move");
            }
        }
    }

    void SetRandomTimer()
    {
        timer = Random.Range(3f, 8f);
    }
}