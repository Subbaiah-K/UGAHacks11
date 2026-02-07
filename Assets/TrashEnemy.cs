using UnityEngine;

public class TrashEnemy : MonoBehaviour
{
    [HideInInspector] // Hide this so the LevelManager controls it
    public float fallSpeed; 
    
    public Sprite[] trashSprites;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        if (trashSprites.Length > 0)
        {
            int randomIndex = Random.Range(0, trashSprites.Length);
            spriteRenderer.sprite = trashSprites[randomIndex];
            boxCollider.size = spriteRenderer.sprite.bounds.size;
        }
    }

    void Update()
    {
        // Now uses the speed assigned by the LevelManager
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null) health.TakeDamage();
            if (this != null && gameObject != null) { Destroy(gameObject); return; }
        }
    }
}