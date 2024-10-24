using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float waterLevel = 0f;        
    public float floatThreshold = 2f;   
    public float waterDensity = 1f;    
    public float downForce = 4f;        
    public GameObject waterCube;   

    private Rigidbody rb;
    private Bounds waterBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // we get the bounds of the water cube (using the collider or renderer)
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

        // checks if the object is within the bounds of the water
        if (IsInWater())
        {
            Debug.Log("is in water");
            if (difference > 0)  
            {
                Debug.Log("is deep in water");
                float floatForce = difference * waterDensity - rb.mass * downForce;
                rb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);
            }
        }
    }

    private bool IsInWater()
    {
        Vector3 objectPosition = transform.position;
        return waterBounds.Contains(objectPosition);  // checks if the object is inside the water cube's bounds
    }
}
