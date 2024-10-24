using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleLight : MonoBehaviour
{
    public Light pointLight; 
    public AudioSource audioSource; 
    public AudioClip toggleSound;  

    public Color[] colors; //we put the colors we want here
    private int currentColorIndex = 0;  // color index 

    void Start()
    {
        // ensures the pointLight reference is assigned, otherwise try to find it automatically
        if (pointLight == null)
        {
            pointLight = GetComponentInChildren<Light>(); 
        }
        pointLight.range = 300;
        pointLight.intensity = 3;
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        ChangeLightColor();

        //plays a sound
        if (audioSource != null && toggleSound != null)
        {
            audioSource.PlayOneShot(toggleSound);
        }
    }

    public void ChangeLightColor()
    {
        // cycle through the colors array when the lamp is clicked
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        pointLight.color = colors[currentColorIndex];
    }
}
