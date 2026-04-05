using UnityEngine;
using UnityEngine.UI;

public class DetectPlayerMovement : MonoBehaviour
{
    private bool isWarning = false;
    private bool isWatching = false;
    private float timer;
    private float watchDuration;
    private float warningDuration;
    private SpriteRenderer spriteRenderer;

    public GameObject safePrefab;
    public GameObject warningPrefab;
    public GameObject dangerPrefab;
    private GameObject currentVisual;

    public GameObject gameOverPanel;

    void Start()
    {

        Time.timeScale = 1f;
        if (gameOverPanel != null) gameOverPanel.SetActive(false);

        spriteRenderer = GetComponent<SpriteRenderer>();
        SetRandomTimer();
        // Starting off safe phase (green)
        if (spriteRenderer != null) spriteRenderer.enabled = false;

        SetRandomTimer();
        SwapPrefab(safePrefab);
        
    }

    void Update()
    {
        timer -= Time.deltaTime;

        // Start warning phase
        if (timer <= 0 && !isWatching && !isWarning)
        {
            isWarning = true;

            warningDuration = Random.Range(0.5f, 1f); // reaction time

            SwapPrefab(warningPrefab);
            

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

                SwapPrefab(dangerPrefab);
                

                Debug.Log("DON'T MOVE");
            }
        }

        // During WATCHING
        if (isWatching)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                TriggerGameOver(); 
                Debug.Log("You moved — GAME OVER");
                // game over logic here
            }

            watchDuration -= Time.deltaTime;

            if (watchDuration <= 0)
            {
                isWatching = false;

                SetRandomTimer();

                SwapPrefab(safePrefab);
                Debug.Log("You can move");
            }
        }
    }

    void SetRandomTimer()
    {
        timer = Random.Range(3f, 8f);
    }

    void SwapPrefab(GameObject prefab)
    {
        if (prefab == null) return;
        if (currentVisual != null) Destroy(currentVisual);

        currentVisual = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        currentVisual.transform.localPosition = Vector2.zero;
    }

    void TriggerGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        Time.timeScale = 0f;
    }
}