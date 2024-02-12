using UnityEngine;

public class BowFacingTouch : MonoBehaviour
{
    public bool isFirstTouch = true;

    private void Update()
    {
        // Adjust bow position to face the touch position on the first touch
        if (isFirstTouch && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 bowPosition = transform.position;
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 direction = touchPosition - bowPosition;
            transform.right = direction;

            isFirstTouch = false;
        }
    }

    // Method to reset the touch state (to be called when needed)
    public void ResetTouch()
    {
        isFirstTouch = true;
    }
}
