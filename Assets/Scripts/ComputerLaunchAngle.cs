using UnityEngine;
using TMPro;

public class BowAngleCalculator : MonoBehaviour
{
    public Transform bow;             // Transform of the bow
    public Transform target;          // Transform of the target
    public float launchForce = 15f;   // Launch force of the arrow
    public TMP_Text xVelocityText;    // TextMeshPro text field to display the X velocity hint
    public TMP_Text yVelocityText;    // TextMeshPro text field to display the Y velocity hint
    public TMP_Text angleText;        // TextMeshPro text field to display the launch angle hint

    void Start()
    {
        // Calculate the distance from the bow to the target
        float distanceToTarget = Vector2.Distance(bow.position, target.position);

        // Calculate the X and Y velocities based on the launch force and distance to the target
        Vector2 velocities = CalculateVelocities(launchForce, distanceToTarget);

        // Calculate the launch angle needed to hit the target based on the calculated velocities
        float launchAngle = CalculateLaunchAngle(velocities);

        // Update the TextMeshPro text fields with the calculated X and Y velocity hints, and launch angle hint
        xVelocityText.text = "X Velocity Hint: " + velocities.x.ToString("F2");
        yVelocityText.text = "Y Velocity Hint: " + velocities.y.ToString("F2");
        angleText.text = "Launch Angle Hint: " + launchAngle.ToString("F2") + " degrees";
    }

    // Method to calculate the X and Y velocities
    Vector2 CalculateVelocities(float launchForce, float distanceToTarget)
    {
        // Calculate the initial velocity components using projectile motion equations
        // v_x = sqrt((launchForce * distanceToTarget) / (0.5 * gravity))
        // v_y = sqrt(2 * gravity * distanceToTarget)
        float gravity = Mathf.Abs(Physics2D.gravity.y); // Assuming gravity is negative (downwards)
        float xVelocity = Mathf.Sqrt((launchForce * distanceToTarget) / (0.5f * gravity));
        float yVelocity = Mathf.Sqrt(2 * gravity * distanceToTarget);

        return new Vector2(xVelocity, yVelocity);
    }

    // Method to calculate the launch angle
    float CalculateLaunchAngle(Vector2 velocities)
    {
        // Calculate the launch angle using arctan
        return Mathf.Rad2Deg * Mathf.Atan((velocities.y) / velocities.x);
    }
}
