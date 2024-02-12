using UnityEngine;

public class ArrowTrail : MonoBehaviour
{
    private TrailRenderer trailRenderer;

    void Start()
    {
        // Get the TrailRenderer component attached to the arrow
        trailRenderer = GetComponent<TrailRenderer>();
        // Disable the trail renderer by default
        DisableTrail();
    }

    // Method to enable the trail renderer
    public void EnableTrail()
    {
        if (trailRenderer != null)
        {
            trailRenderer.enabled = true;
        }
    }

    // Method to disable the trail renderer
    public void DisableTrail()
    {
        if (trailRenderer != null)
        {
            trailRenderer.enabled = false;
        }
    }
}
