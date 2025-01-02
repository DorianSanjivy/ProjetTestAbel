using UnityEngine;
using DG.Tweening;

public class TestTween : MonoBehaviour
{
    // https://easings.net/

    public float moveDistance = 5f; // Half the total movement distance
    public float moveDuration = 2f; // Duration for one-way movement

    void Start()
    {
        // Save the original position
        Vector3 startPosition = transform.position;

        // Define the target positions (left and right sides)
        Vector3 leftPosition = startPosition + Vector3.left * moveDistance;
        Vector3 rightPosition = startPosition + Vector3.right * moveDistance;

        // Create the DOTween animation
        transform.DOMoveX(rightPosition.x, moveDuration)
            .SetEase(Ease.InOutSine) // Symmetrical ease for both directions
            .SetLoops(-1, LoopType.Yoyo); // Loop indefinitely and ping-pong
    }
}

