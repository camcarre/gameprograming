using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); // nom de ta scène de jeu
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitter le jeu !");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("Credits"); // à créer si tu veux une vraie scène de crédits
    }
}
