using UnityEngine;

public class ArrowDisappear : MonoBehaviour
{
    public float delayAfterCollision = 3.0f; // Delay after hitting an object
    private bool hasCollided = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the arrow has not collided before
        if (!hasCollided)
        {
            hasCollided = true;

            // Add your collision handling logic here

            // Invoke the DestroyArrow function after a delay
            Invoke("DestroyArrow", delayAfterCollision);
        }
    }

    void DestroyArrow()
    {
        // Destroy the arrow GameObject
        Destroy(gameObject);
    }
}
