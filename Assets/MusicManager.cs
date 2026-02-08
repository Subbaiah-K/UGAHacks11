using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    // List of scenes where the music IS allowed to play
    public List<string> musicScenes = new List<string> { "Intro1", "Intro2", "Intro3", "Menu" };

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the current scene is in our allowed list
        if (musicScenes.Contains(scene.name))
        {
            if (!audioSource.isPlaying) audioSource.Play();
        }
        else
        {
            // Stop the music if we enter a scene not in the list
            audioSource.Stop();
            // Optional: Destroy(gameObject); // Use this if you never need the music again
        }
    }
}