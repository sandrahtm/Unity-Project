using UnityEngine;

public class resetButton : MonoBehaviour
{
    public GameObject[] objectsToReset;  // Array to store the objects you want to reset

    private Vector3[] originalPositions;  // Store original positions
    private Quaternion[] originalRotations;  // Store original rotations

    void Start()
    {
        // Initialize arrays
        originalPositions = new Vector3[objectsToReset.Length];
        originalRotations = new Quaternion[objectsToReset.Length];

        // Store the original positions and rotations
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            originalPositions[i] = objectsToReset[i].transform.position;
            originalRotations[i] = objectsToReset[i].transform.rotation;
        }
    }

    // This method will reset all objects to their original positions and rotations
    public void ResetObjects()
    {
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].transform.position = originalPositions[i];
            objectsToReset[i].transform.rotation = originalRotations[i];

            // Optional: Reset Rigidbody velocity and angular velocity if present
            Rigidbody rb = objectsToReset[i].GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
