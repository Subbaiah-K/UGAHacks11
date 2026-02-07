using UnityEngine;

public class TrashEnemy : MonoBehaviour
{
    public float fallSpeed = 5f;

    void Update()
    {
        // Makes the trash fall down
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the thing we hit is the Player
        if (other.CompareTag("Player"))
        {
            // Tell the PlayerHealth script to lose a heart
            other.GetComponent<PlayerHealth>().TakeDamage();
            
            // Destroy the trash so it doesn't hit twice
            Destroy(gameObject); 
        }
    }
}