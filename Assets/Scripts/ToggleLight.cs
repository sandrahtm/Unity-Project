using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleLight : MonoBehaviour
{
    public Light pointLight;  // La lumière attachée à la lampe
    public AudioSource audioSource;  // Source audio pour le son d'allumage/extinction
    public AudioClip toggleSound;    // Son joué à chaque fois qu'on allume/éteint

    public Color[] colors;  // Tableau des couleurs à parcourir
    private int currentColorIndex = 0;  // Index de la couleur actuelle

    void Start()
    {
        // Ensure the pointLight reference is assigned, otherwise try to find it automatically
        if (pointLight == null)
        {
            pointLight = GetComponentInChildren<Light>();  // Finds the Point Light in the children of the lamp
        }
        pointLight.range = 300;
        pointLight.intensity = 3;
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Changer la couleur de la lumière
        ChangeLightColor();

        // Jouer le son d'allumage/extinction si une source audio est présente
        if (audioSource != null && toggleSound != null)
        {
            audioSource.PlayOneShot(toggleSound);
        }
    }

    public void ChangeLightColor()
    {
        // Cycle through the colors array when the lamp is clicked
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        pointLight.color = colors[currentColorIndex];
    }
}
