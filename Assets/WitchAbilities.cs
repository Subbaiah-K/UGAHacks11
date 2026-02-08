using UnityEngine;
using UnityEngine.UI; // Needed for the 'A' flash

public class WitchAbilities : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Image whiteFlashImage; // Assign a UI Image that covers the screen
    public Transform firePoint;   // Where the beam comes out of

    void Update()
    {
        // U - Fire Standard Beam
        if (Input.GetKeyDown(KeyCode.U))
        {
            Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        }

        // G - Fire Triple Beam (Bigger/More)
        if (Input.GetKeyDown(KeyCode.G))
        {
            FireTriple();
        }

        // A - Flash and Destroy All
        if (Input.GetKeyDown(KeyCode.A))
        {
            FlashAndClear();
        }
    }

    void FireTriple()
    {
        // Fires three projectiles at slightly different angles
        Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 0, 0));
        Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 0, 15));
        Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 0, -15));
    }

    void FlashAndClear()
    {
        // 1. Find all objects tagged "Trash" and destroy them
        GameObject[] allTrash = GameObject.FindGameObjectsWithTag("Trash");
        foreach (GameObject trash in allTrash)
        {
            Destroy(trash);
        }

        // 2. Trigger visual flash (Requires a white UI Image)
        if (whiteFlashImage != null) StartCoroutine(DoFlash());
    }

    System.Collections.IEnumerator DoFlash()
    {
        whiteFlashImage.color = new Color(1, 1, 1, 1); // Fully white
        float alpha = 1f;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime * 2f; // Fade out
            whiteFlashImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }
}