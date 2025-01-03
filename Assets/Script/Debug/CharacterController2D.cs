using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the character
    public float flipSpeed = 10f; // Speed of flipping

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input for movement
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right arrows
        float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down arrows

        moveInput = new Vector2(moveX, moveY).normalized; // Normalize to prevent diagonal overspeeding
    }

    void FixedUpdate()
    {
        // Move the character
        rb.velocity = moveInput * moveSpeed;
    }
}
