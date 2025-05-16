using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;

    public Image[] hearts; // à remplir dans l'Inspector avec les 3 sprites

    void Start()
    {
        currentLives = maxLives;
        UpdateHeartsUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentLives -= damage;
        UpdateHeartsUI();

        if (currentLives <= 0)
        {
            Die();
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentLives;
        }
    }

    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}
