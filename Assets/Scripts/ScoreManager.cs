using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    void Start()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score : " + score;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }
}

