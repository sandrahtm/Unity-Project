using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float waterLevel = 0f;        
    public float floatThreshold = 2f;    
    public float waterDensity = 1f;      
    public float downForce = 4f;         

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    void FixedUpdate()
    {
        float objectHeight = transform.position.y;
        float difference = waterLevel - objectHeight;

        if (difference > 0) 
        {
            float floatForce = difference * waterDensity - rb.mass * downForce;
            rb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);
        }
    }
}
