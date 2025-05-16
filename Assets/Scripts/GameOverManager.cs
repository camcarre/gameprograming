using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Appelé par le bouton "Rejouer"
    public void ReplayGame()
    {
        // Recharge la scène active du niveau principal
        SceneManager.LoadScene(0); // ⚠️ Remplace par le nom exact de ta scène principale
    }

    // Appelé par le bouton "Quitter"
    public void QuitGame()
    {
        Debug.Log("Quitter le jeu");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
