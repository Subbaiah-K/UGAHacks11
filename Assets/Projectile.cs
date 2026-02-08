using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Move upward
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        
        // Destroy if it goes off screen to save memory
        if (transform.position.y > 10f) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Make sure your Trash objects have the Tag "Trash"
        if (other.CompareTag("Trash"))
        {
            Destroy(other.gameObject); // Destroy the trash
            Destroy(gameObject);       // Destroy the beam
        }
    }
}