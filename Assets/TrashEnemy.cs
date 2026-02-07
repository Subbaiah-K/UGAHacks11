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
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage();
            }
            
            // This is the safety check
            if (this != null && gameObject != null)
            {
                Destroy(gameObject);
                return; // STOP the script here so it doesn't look for more code
            }
        }
    }
}