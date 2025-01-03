using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the character
    public Transform spritePlayer; // Reference to the sprite child object
    public float flipSpeed = 10f; // Speed of flipping

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Ensure the spritePlayer is assigned
        if (spritePlayer == null)
        {
            Debug.LogError("spritePlayer is not assigned! Please assign the child object.");
        }
    }

    void Update()
    {
        // Get input for movement
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right arrows
        float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down arrows

        moveInput = new Vector2(moveX, moveY).normalized; // Normalize to prevent diagonal overspeeding

        // Flip sprite based on mouse position
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0.0f;

        if (worldMousePosition.x < transform.position.x)
        {
            Vector3 targetScale = new Vector3(-1f, 1f, 1f);
            spritePlayer.localScale = Vector3.Lerp(spritePlayer.localScale, targetScale, flipSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 targetScale = new Vector3(1f, 1f, 1f);
            spritePlayer.localScale = Vector3.Lerp(spritePlayer.localScale, targetScale, flipSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        // Move the character
        rb.velocity = moveInput * moveSpeed;
    }
}
