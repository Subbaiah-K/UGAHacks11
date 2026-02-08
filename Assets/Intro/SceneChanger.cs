using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
   public static string levelToResume;


   // KEEP THIS: Your Intro/Menu buttons use this
   public void LoadNextScene(string sceneName)
   {
       Time.timeScale = 1f; // Ensure time is moving
       SceneManager.LoadScene(sceneName);
   }


   // NEW: Use this for the Pause button in your levels
   public void GoToPause()
   {
       levelToResume = SceneManager.GetActiveScene().name;
       Time.timeScale = 0f; // FREEZE
       SceneManager.LoadScene("Pause");
   }


   // NEW: Use this for the 'Play' button in your Pause scene
   public void ResumeGame()
   {
       Time.timeScale = 1f; // UNFREEZE
       if (!string.IsNullOrEmpty(levelToResume))
       {
           SceneManager.LoadScene(levelToResume);
       }
   }


   // NEW: Use this for 'Home' or 'Stop' in your Pause scene
   public void QuitToMenu()
   {
       Time.timeScale = 1f;
       SceneManager.LoadScene("Menu");
   }
}
