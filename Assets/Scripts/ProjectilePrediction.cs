using UnityEngine;
using TMPro;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce = 5f;
    public Transform shotPoint;
    public TMP_Text xVelocityText;
    public TMP_Text yVelocityText;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;

    TrailRenderer arrowTrail; // Reference to TrailRenderer component
    Vector2 direction; // Class-level variable

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
        BowFacingCursor();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }

    public void AdjustBowAngle(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        Rigidbody2D arrowRigidbody = newArrow.GetComponent<Rigidbody2D>();
        arrowRigidbody.velocity = transform.right * launchForce;

        // Enable the trail renderer when the arrow is shot
        arrowTrail = newArrow.GetComponentInChildren<TrailRenderer>();
        if (arrowTrail != null)
        {
            arrowTrail.enabled = true;
        }
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
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - bowPosition;
        transform.right = direction;
    }
}
