using UnityEngine;

//resets the cubes in the stand2
public class resetButton : MonoBehaviour
{
    public GameObject[] objectsToReset;

    private Vector3[] originalPositions;  // store original positions
    private Quaternion[] originalRotations;  // store original rotations

    void Start()
    {
        originalPositions = new Vector3[objectsToReset.Length];
        originalRotations = new Quaternion[objectsToReset.Length];

        // store the original positions and rotations
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            originalPositions[i] = objectsToReset[i].transform.position;
            originalRotations[i] = objectsToReset[i].transform.rotation;
        }
    }

    // reset all objects to their original positions and rotations
    public void ResetObjects()
    {
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].transform.position = originalPositions[i];
            objectsToReset[i].transform.rotation = originalRotations[i];

            Rigidbody rb = objectsToReset[i].GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
