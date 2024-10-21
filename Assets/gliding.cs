using UnityEngine;
using UnityEngine.XR;

public class gliding : MonoBehaviour
{
    public Transform xrRig;        
    public Transform headTransform; 
    public float speed = 2.0f;  
    public float smoothing = 0.1f; 

    private Vector3 currentVelocity;

    void Update()
    {
        Vector2 input = GetPrimary2DAxisInput();

        if (input.sqrMagnitude > 0.01f)
        {
            Vector3 forward = headTransform.forward;
            forward.y = 0;  
            forward.Normalize();

            Vector3 right = headTransform.right;
            right.y = 0;
            right.Normalize();

            Vector3 moveDirection = (forward * input.y + right * input.x) * speed;

            xrRig.position += Vector3.SmoothDamp(Vector3.zero, moveDirection, ref currentVelocity, smoothing) * Time.deltaTime;
        }
    }

    Vector2 GetPrimary2DAxisInput()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand); 

        Vector2 primary2DAxisValue;
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxisValue))
        {
            return primary2DAxisValue;
        }

        return Vector2.zero; 
    }
}
