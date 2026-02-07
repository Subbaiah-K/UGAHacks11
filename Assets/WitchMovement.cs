using UnityEngine;

public class WitchMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    [Header("Movement Limits")]
    public float minY = -4.5f; // Adjust based on your screen bottom
    public float maxY = -2.0f; // The "limit" for how far up she can go
    public float minX = -8.5f; // Keeps her from going off-screen left
    public float maxX = 8.5f;  // Keeps her from going off-screen right

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Now getting both Horizontal (A/D) and Vertical (W/S) input
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Calculate the target position
        Vector2 targetPosition = rb.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime;

        // Apply the "Space Shooter" limit (Clamping)
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        rb.MovePosition(targetPosition);
    }
}