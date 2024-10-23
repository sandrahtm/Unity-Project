using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleLight : MonoBehaviour
{
    public Light pointLight;  // La lumi�re attach�e � la lampe
    public AudioSource audioSource;  // Source audio pour le son d'allumage/extinction
    public AudioClip toggleSound;    // Son jou� � chaque fois qu'on allume/�teint

    public Color[] colors;  // Tableau des couleurs � parcourir
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
        // Changer la couleur de la lumi�re
        ChangeLightColor();

        // Jouer le son d'allumage/extinction si une source audio est pr�sente
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
