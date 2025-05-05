using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
#if UNITY_WEBGL
        Debug.Log("Quit n'est pas disponible sur WebGL");
#else
        Application.Quit();
#endif
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}