using UnityEngine;
using TMPro;
using System.Collections;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce = 5f;
    public Transform shotPoint;
    public GameObject point;
    public int numberOfPoints;
    public float spaceBetweenPoints;

    private GameObject[] points;
    private TrailRenderer arrowTrail;
    private Vector2 direction;
    private bool canShoot = true; // Flag to check if the bow can shoot
    private bool adjustRotation = true; // Flag to control whether the bow should adjust its rotation

    private void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (adjustRotation)
        {
            BowFacingCursor();
        }

        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }

    public void AdjustBowAngle(float angle)
    {
        // Restrict the rotation within -90 to 90 degrees
        angle = Mathf.Clamp(angle, -90f, 90f);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    public void ShootButtonClicked()
    {
        if (canShoot) // Only shoot when canShoot is true
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        Rigidbody2D arrowRigidbody = newArrow.GetComponent<Rigidbody2D>();
        arrowRigidbody.velocity = transform.right * launchForce;

        // Disable shooting until the arrow lands
        canShoot = false;

        // Enable the trail renderer when the arrow is shot
        arrowTrail = newArrow.GetComponentInChildren<TrailRenderer>();
        if (arrowTrail != null)
        {
            arrowTrail.enabled = true;
        }

        // Check if the arrow lands
        StartCoroutine(CheckArrowLanded(newArrow));
    }

    private IEnumerator CheckArrowLanded(GameObject arrow)
    {
        yield return new WaitUntil(() => arrow.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.01f);

        // Re-enable shooting after the arrow lands
        canShoot = true;
    }

    private Vector2 PointPosition(float t)
    {
        Vector2 horizontalPosition = (Vector2)shotPoint.position + (direction.normalized * launchForce * t);
        Vector2 verticalPosition = 0.5f * Physics2D.gravity * (t * t);
        return horizontalPosition + verticalPosition;
    }

    private void BowFacingCursor()
    {
        Vector2 bowPosition = transform.position;

        // Check if there are any touches on the screen
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch (you can modify this if you want to handle multiple touches)

            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); // Convert touch position to world space

            // Calculate the distance between the bow and the touch position
            float distance = Vector2.Distance(bowPosition, touchPosition);

            // Define a maximum range for adjusting the angle (e.g., 3 units)
            float maxRange = 4f;

            // Check if the touch position is within the allowed range
            if (distance <= maxRange)
            {
                // If within range, adjust the bow's rotation
                direction = touchPosition - bowPosition;
                transform.right = direction;
            }
            else
            {
                // If outside range, do not adjust the bow's rotation
            }
        }

    
    }

}
