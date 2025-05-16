using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score : " + score;
    }
}
