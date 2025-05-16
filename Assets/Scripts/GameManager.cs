using UnityEngine;
using TMPro; // ← ajoute ça

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText; // ← remplace "Text" par "TMP_Text"

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
