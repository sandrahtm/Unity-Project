using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float waterLevel = 0f;         // Reference water level
    public float floatThreshold = 2f;     // Buoyancy threshold
    public float waterDensity = 1f;       // Water density
    public float downForce = 4f;          // Downward force due to weight
    public GameObject waterCube;          // Reference to the water cube

    private Rigidbody rb;
    private Bounds waterBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Get the bounds of the water cube (using the collider or renderer)
        if (waterCube != null)
        {
            Collider waterCollider = waterCube.GetComponent<Collider>();
            if (waterCollider != null)
            {
                waterBounds = waterCollider.bounds;
            }
        }
    }

    void FixedUpdate()
    {
        float objectHeight = transform.position.y;
        Debug.Log("object height " + objectHeight);
        float difference = waterLevel - objectHeight;

        // Check if the object is within the bounds of the water
        if (IsInWater())
        {
            Debug.Log("is in water");
            if (difference > 0)  // Object is below the water surface
            {
                Debug.Log("is deep in water");
                float floatForce = difference * waterDensity - rb.mass * downForce;
                rb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);
            }
        }
    }

    // Method to check if the object is within the water bounds
    private bool IsInWater()
    {
        Vector3 objectPosition = transform.position;
        return waterBounds.Contains(objectPosition);  // Check if the object is inside the water cube's bounds
    }
}
