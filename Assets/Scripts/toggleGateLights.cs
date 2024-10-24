using UnityEngine;

public class toggleGateLights : MonoBehaviour
{
    public Light lightToToggle; 

    private bool isLightOn = false;  // state to keep track of the light

    public void ToggleLight()
    {
        isLightOn = !isLightOn;

        lightToToggle.enabled = isLightOn;
    }
}
