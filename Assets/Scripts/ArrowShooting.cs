using UnityEngine;
using UnityEngine.UI;

public class ArrowShooting : MonoBehaviour
{
    public Rigidbody2D ArrowRigidBody;
    public GameObject Arrow;
    public Slider forceSlider;
    public Transform ShotPoint;
    public float minShootForce = 5f;
    public float maxShootForce = 20f;
   

    private float currentShootForce;

    void Start()
    {
        currentShootForce = minShootForce;
    }

    void Update()
    {
        // Check for user input or any other triggering event
        if (Input.GetMouseButtonDown(0))
        {
            StartShooting();
            Debug.Log("GetMouseButton is working");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ShootArrow();
        }
      
    }

    void StartShooting()
    {
        // Reset the shoot force when starting a new shot
        currentShootForce = minShootForce;
    }

    void UpdateShootingForce()
    {
        // Update the shoot force based on the slider value
        currentShootForce = Mathf.Lerp(minShootForce, maxShootForce, forceSlider.value);
    }

    void ShootArrow()
    {
        // Instantiate a new arrow and store the GameObject
        GameObject newArrowObject = Instantiate(Arrow, ShotPoint.position, ShotPoint.rotation);

        // Access the Rigidbody2D component of the instantiated arrow
        Rigidbody2D newArrowRigidbody = newArrowObject.GetComponent<Rigidbody2D>();

        // Apply force to the new arrow
        newArrowRigidbody.AddForce(newArrowObject.transform.right * currentShootForce, ForceMode2D.Impulse);
    }
}
