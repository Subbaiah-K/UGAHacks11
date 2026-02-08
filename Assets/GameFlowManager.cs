using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFlowManager : MonoBehaviour
{
    [Header("Level Select UI")]
    public Button level2Button;
    public Button level3Button;

    void Start()
    {
        // Matches the name "Menu" from your assets
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            // Load the current progress from PlayerPrefs (defaults to 1)
            int unlockedLevels = PlayerPrefs.GetInt("LevelsUnlocked", 1);

            // Turn buttons on or off based on progress
            if (level2Button != null) level2Button.interactable = unlockedLevels >= 2;
            if (level3Button != null) level3Button.interactable = unlockedLevels >= 3;
        }
    }

    // Generic loader for your Level 1, Level 2, etc. buttons
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void WinLevel(int currentLevelNumber)
    {
        // Save progress: if you beat level 1, unlock level 2
        int reachedLevel = PlayerPrefs.GetInt("LevelsUnlocked", 1);
        if (currentLevelNumber >= reachedLevel)
        {
            PlayerPrefs.SetInt("LevelsUnlocked", currentLevelNumber + 1);
        }
        
        // Ensure you have a scene named exactly "WinScreen" or update this string
        SceneManager.LoadScene("WinScreen");
    }

    public void LoseLevel()
    {
        // Matches the name "Game Over" from your assets
        ///SceneManager.LoadScene("Game Over");
    }

    public void GoHome()
    {
        // Matches the name "Menu" from your assets
        SceneManager.LoadScene("Menu");
    }

    // Optional: Call this from a button if you want to test from Level 1 again
    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }
}