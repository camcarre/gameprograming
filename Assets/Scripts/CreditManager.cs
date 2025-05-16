using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public void RetourMenu()
    {
        SceneManager.LoadScene("MainMenu"); // ou le nom exact de ta scène de menu
    }
}
