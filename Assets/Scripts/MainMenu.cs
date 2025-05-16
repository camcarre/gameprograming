using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitter le jeu !");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
