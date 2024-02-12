using TMPro;
using UnityEngine;

public class LaunchAngleDisplay : MonoBehaviour
{
    public Transform ShotPoint;
    public Transform Target;
    public TextMeshProUGUI launchAngleText;
    public TextMeshProUGUI distanceText;

    void Update()
    {
        // Calculate the launch angle relative to the normal position of the bow
        float launchAngle = Mathf.Rad2Deg * Mathf.Atan2(ShotPoint.up.y, ShotPoint.up.x);

        // Normalize the angle to be in the range [0, 360)
        launchAngle =  launchAngle - 90;

        // Calculate the distance from the bow to the target
        float distance = Vector2.Distance(ShotPoint.position, Target.position);

        // Update the UI Texts with the launch angle and distance values
        launchAngleText.text = "Launch Angle: " + launchAngle.ToString("F2") + "°";
        distanceText.text = "Range: " + distance.ToString("F2") + " meter";


    }
}
