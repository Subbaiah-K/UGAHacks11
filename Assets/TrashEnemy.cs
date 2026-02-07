using UnityEngine;

public class TrashEnemy : MonoBehaviour
{
    public float fallSpeed = 5f;
    public Sprite[] trashSprites; // Drop your 3 sprites here in the Inspector

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        if (trashSprites.Length > 0)
        {
            // Pick a random image from the list
            int randomIndex = Random.Range(0, trashSprites.Length);
            spriteRenderer.sprite = trashSprites[randomIndex];

            // AUTO-ADJUST COLLIDER: This makes the green box fit the new image size
            boxCollider.size = spriteRenderer.sprite.bounds.size;
        }
    }

    void Update()
    {
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
            
            if (this != null && gameObject != null)
            {
                Destroy(gameObject);
                return;
            }
        }
    }
}