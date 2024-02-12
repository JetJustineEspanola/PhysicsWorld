using UnityEngine;

public class BowShootingScript : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float launchForce = 5f;
    public Transform shotPoint;

    private BowFacingTouch bowFacingTouch;

    private void Start()
    {
        // Get the BowFacingTouch script attached to the bow
        bowFacingTouch = GetComponent<BowFacingTouch>();
    }

    private void Update()
    {
        // Activate shooting after the second touch
        if (!bowFacingTouch.isFirstTouch && Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Began)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Instantiate and shoot the arrow
        GameObject newArrow = Instantiate(arrowPrefab, shotPoint.position, shotPoint.rotation);
        Rigidbody2D arrowRigidbody = newArrow.GetComponent<Rigidbody2D>();
        arrowRigidbody.velocity = transform.right * launchForce;

        // Reset touch state for next shooting
        bowFacingTouch.ResetTouch();
    }
}
