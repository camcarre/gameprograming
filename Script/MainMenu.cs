using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Panels")]
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    public GameObject difficultyPanel;
    public GameObject creditsPanel;

    [Header("Audio Settings")]
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Toggle muteMusicToggle;

    [Header("Animation")]
    public float buttonAnimationSpeed = 0.1f;
    public float buttonScaleFactor = 1.1f;

    [Header("Difficulty")]
    public string currentDifficulty = "Normal";
    
    private List<Button> allButtons = new List<Button>();

    private void Start()
    {
        // Find all buttons and add animation effects
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            allButtons.Add(button);
            AddButtonAnimation(button);
        }

        // Initialize settings
        LoadSettings();
        
        // Ensure main menu is active at start
        ShowMainMenu();
    }

    // Menu Navigation Methods
    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        difficultyPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void ShowOptions()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        difficultyPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void ShowDifficultySelection()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        difficultyPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void ShowCredits()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        difficultyPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    // Game Flow Control
    public void StartGame()
    {
        // Save current settings before starting
        SaveSettings();
        
        // Set difficulty in PlayerPrefs so the game can access it
        PlayerPrefs.SetString("Difficulty", currentDifficulty);
        PlayerPrefs.Save();
        
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        SaveSettings();
        
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

    // Difficulty Selection
    public void SetDifficulty(string difficulty)
    {
        currentDifficulty = difficulty;
        Debug.Log("Difficulty set to: " + difficulty);
        
        // Optional: Return to main menu after selecting difficulty
        ShowMainMenu();
    }

    // Audio Controls
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void ToggleMusic(bool enabled)
    {
        float volume = enabled ? 0f : -80f; // -80dB effectively mutes the audio
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetInt("MusicEnabled", enabled ? 1 : 0);
    }

    // Settings Management
    private void SaveSettings()
    {
        if (volumeSlider != null)
            PlayerPrefs.SetFloat("MasterVolume", volumeSlider.value);
        
        if (muteMusicToggle != null)
            PlayerPrefs.SetInt("MusicEnabled", muteMusicToggle.isOn ? 1 : 0);
        
        PlayerPrefs.SetString("Difficulty", currentDifficulty);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        // Load volume settings
        if (volumeSlider != null && PlayerPrefs.HasKey("MasterVolume"))
        {
            float volume = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
            volumeSlider.value = volume;
            SetMasterVolume(volume);
        }
        
        // Load music toggle
        if (muteMusicToggle != null && PlayerPrefs.HasKey("MusicEnabled"))
        {
            bool musicEnabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
            muteMusicToggle.isOn = musicEnabled;
            ToggleMusic(musicEnabled);
        }
        
        // Load difficulty
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            currentDifficulty = PlayerPrefs.GetString("Difficulty", "Normal");
        }
    }

    // Button Animation
    private void AddButtonAnimation(Button button)
    {
        // Add event triggers for pointer enter and exit
        EventTrigger trigger = button.gameObject.GetComponent<EventTrigger>();
        
        if (trigger == null)
            trigger = button.gameObject.AddComponent<EventTrigger>();
            
        EventTrigger.Entry entryEnter = new EventTrigger.Entry();
        entryEnter.eventID = EventTriggerType.PointerEnter;
        entryEnter.callback.AddListener((data) => { OnPointerEnter(button); });
        trigger.triggers.Add(entryEnter);
        
        EventTrigger.Entry entryExit = new EventTrigger.Entry();
        entryExit.eventID = EventTriggerType.PointerExit;
        entryExit.callback.AddListener((data) => { OnPointerExit(button); });
        trigger.triggers.Add(entryExit);
    }
    
    private void OnPointerEnter(Button button)
    {
        StartCoroutine(ScaleButton(button, Vector3.one * buttonScaleFactor, buttonAnimationSpeed));
    }
    
    private void OnPointerExit(Button button)
    {
        StartCoroutine(ScaleButton(button, Vector3.one, buttonAnimationSpeed));
    }
    
    private IEnumerator ScaleButton(Button button, Vector3 targetScale, float duration)
    {
        Vector3 initialScale = button.transform.localScale;
        float elapsedTime = 0;
        
        while (elapsedTime < duration)
        {
            button.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        button.transform.localScale = targetScale;
    }

    // Pause Menu functionality (can be called from other scripts)
    public static void PauseGame()
    {
        Time.timeScale = 0f;
    }
    
    public static void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    
    public void ReturnToMainMenu()
    {
        ResumeGame(); // Make sure to reset the time scale
        SceneManager.LoadScene("MainMenu");
    }
}