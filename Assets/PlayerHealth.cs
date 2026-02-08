using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 3;
    public float iFrameDuration = 1.5f;
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
        
        if (currentHearts >= 0 && currentHearts < heartIcons.Length)
        {
            heartIcons[currentHearts].enabled = false; 
        }

        if (currentHearts <= 0)
        {
            Debug.Log("Game Over!");
            
            // 1. Tell the manager to handle any internal win/loss logic
            GameFlowManager manager = Object.FindFirstObjectByType<GameFlowManager>();
            if (manager != null)
            {
                manager.LoseLevel();
            }

            // 2. Load the actual Game Over Scene we just created
            // Make sure the name in quotes matches your Scene filename exactly!
            SceneManager.LoadScene("GameOverScene"); 
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