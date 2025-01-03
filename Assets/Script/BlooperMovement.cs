using UnityEngine;

public class BlooperMovement : MonoBehaviour
{
    public float downwardForce = 2f; // Constant downward force
    public float upwardImpulse = 5f; // Upward movement impulse
    public float horizontalImpulse = 3f; // Left or right movement impulse
    public float moveUpInterval = 1f; // Time interval for upward movement

    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Start the automatic upward movement
        InvokeRepeating(nameof(AutoMoveUp), moveUpInterval, moveUpInterval);
        InvokeRepeating(nameof(NullifyAllForces), moveUpInterval / 2f, moveUpInterval);
    }

    void FixedUpdate()
    {
        // Apply constant downward force
        rb.AddForce(Vector2.down * downwardForce);
    }

    public void NullifyAllForces()
    {
        // Nullify all forces
        rb.velocity = Vector2.zero;
    }

    public void AutoMoveUp()
    {

        // Nullify vertical forces
        rb.velocity = new Vector2(rb.velocity.x, 0f);

        // Automatically move upward
        rb.AddForce(Vector2.up * upwardImpulse, ForceMode2D.Impulse);

        // Randomly move left or right
        if (Random.value > 0.5f)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
    }


    public void MoveLeft()
    {
        // Apply leftward impulse
        rb.AddForce(Vector2.left * horizontalImpulse, ForceMode2D.Impulse);
    }

    public void MoveRight()
    {
        // Apply rightward impulse
        rb.AddForce(Vector2.right * horizontalImpulse, ForceMode2D.Impulse);
    }
}
