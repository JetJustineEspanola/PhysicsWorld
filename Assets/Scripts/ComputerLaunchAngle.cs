using UnityEngine;
using TMPro;

public class BowAngleCalculator : MonoBehaviour
{
    public Transform bow;                     // Transform of the bow
    public Transform target;                  // Transform of the target
    public float launchForce = 15f;           // Launch force of the arrow
    public TMP_Text rangeText;                // TextMeshPro text field to display the range
    public TMP_Text initialVelocityText;      // TextMeshPro text field to display the initial velocity
    

    void Start()
    {
        // Calculate the distance from the bow to the target
        float distanceToTarget = Vector3.Distance(bow.position, target.position);

        // Calculate the initial velocity components using projectile motion equations
        float gravity = Mathf.Abs(Physics.gravity.y); // Assuming gravity is negative (downwards)
        float xVelocity = Mathf.Sqrt((launchForce * distanceToTarget) / (0.5f * gravity));

        // Calculate the time of flight
        float time = distanceToTarget / xVelocity;

        // Calculate the range
        float range = xVelocity * time;

        // Update the TextMeshPro text fields with the calculated values
        initialVelocityText.text = "Initial Velocity: " + xVelocity.ToString("F2") + " units/second";
        rangeText.text = "Range: " + range.ToString("F2") + " units";
        
    }
}
