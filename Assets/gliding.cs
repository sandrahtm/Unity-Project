using UnityEngine;
using UnityEngine.XR;

public class gliding : MonoBehaviour
{
    public Transform xrRig;        // Reference to the XR Rig to move
    public Transform headTransform;  // Reference to the VR headset (camera)
    public float speed = 2.0f;      // Speed of movement
    public float smoothing = 0.1f;  // Smoothing factor for smooth movement

    private Vector3 currentVelocity;

    void Update()
    {
        // Get the input from the primary 2D axis (joystick)
        Vector2 input = GetPrimary2DAxisInput();

        // Only move if there's input
        if (input.sqrMagnitude > 0.01f)
        {
            // Get forward direction from the headset (camera)
            Vector3 forward = headTransform.forward;
            forward.y = 0;  // Ignore the Y component to keep the movement on the XZ plane
            forward.Normalize();

            // Get right direction relative to the headset
            Vector3 right = headTransform.right;
            right.y = 0;
            right.Normalize();

            // Calculate movement direction based on input and headset orientation
            Vector3 moveDirection = (forward * input.y + right * input.x) * speed;

            // Apply smoothing to the movement for a gliding effect
            xrRig.position += Vector3.SmoothDamp(Vector3.zero, moveDirection, ref currentVelocity, smoothing) * Time.deltaTime;
        }
    }

    // Function to get the joystick input from the controller
    Vector2 GetPrimary2DAxisInput()
    {
        // Check which hand you want to use (you can use XRNode.LeftHand or XRNode.RightHand)
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);  // Change to XRNode.RightHand if needed

        // Read the value of the primary 2D axis (joystick)
        Vector2 primary2DAxisValue;
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxisValue))
        {
            return primary2DAxisValue;
        }

        return Vector2.zero;  // Return zero if no input is detected
    }
}
