using UnityEngine;

public class toggleGateLights : MonoBehaviour
{
    public Light lightToToggle;  // Reference to the Light component

    private bool isLightOn = false;  // State to keep track of the light

    public void ToggleLight()
    {
        // Toggle the state
        isLightOn = !isLightOn;

        // Turn the light on or off based on the new state
        lightToToggle.enabled = isLightOn;
    }
}
