using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float desiredHeight = 10f;

    void Start()
    {
        // Calculate the orthographic size based on the desired height and screen height
        Camera.main.orthographicSize = Screen.height / (2f * desiredHeight);

        // Position the camera at a fixed distance from the game world's origin
        transform.position = new Vector3(0f, 0f, -10f); // Adjust the z position as needed
    }
}