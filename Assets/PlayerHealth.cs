using UnityEngine;
using System.Collections;
using UnityEngine.UI; // REQUIRED: Allows the script to see your Heart Images

public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 3;
    public float iFrameDuration = 1.5f;
    
    // This creates the field in the Inspector for you to drag your hearts into
    public Image[] heartIcons; 

    private int currentHearts;
    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHearts = maxHearts;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage()
    {
        if (isInvincible) return;

        currentHearts--;
        
        // UI Logic: Disable the heart icon corresponding to the life lost
        if (currentHearts >= 0 && currentHearts < heartIcons.Length)
        {
            heartIcons[currentHearts].enabled = false; 
        }

        if (currentHearts <= 0)
        {
            Debug.Log("Game Over!");
            // Restarts the game
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
        else
        {
            StartCoroutine(BecomeInvincible());
        }
    }

    private IEnumerator BecomeInvincible()
    {
        isInvincible = true;
        for (float i = 0; i < iFrameDuration; i += 0.1f)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        spriteRenderer.enabled = true;
        isInvincible = false;
    }
}