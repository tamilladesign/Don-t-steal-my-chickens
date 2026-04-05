using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    private Vector3 startPos;
    private bool away = false;

    void Start()
    {
        startPos = transform.position;
        UpdateUI();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, startPos);

        if (dist > 1.0f)
        {
            away = true;
        }

        if (away && dist < 0.2f)
        {
            score++;
            away = false;
            UpdateUI(); 
        }
    }

    
    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = " " + score.ToString();
        }
    }
}