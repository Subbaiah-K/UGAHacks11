using UnityEngine;

public class WitchMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        // This links the variable to the component you added in the Inspector
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from WASD or Arrow Keys
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // MovePosition is the best way to move a Rigidbody2D
        rb.MovePosition(rb.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}