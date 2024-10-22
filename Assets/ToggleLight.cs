using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleLight : MonoBehaviour
{
    public Light lampLight;  // La lumière attachée à la lampe
    public AudioSource audioSource;  // Source audio pour le son d'allumage/extinction
    public AudioClip toggleSound;    // Son joué à chaque fois qu'on allume/éteint

    public Color[] colors;  // Tableau des couleurs à parcourir
    private int currentColorIndex = 0;  // Index de la couleur actuelle

    private XRSimpleInteractable interactable;  // Référence au Simple Interactable

    private void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
    }

    private void OnEnable()
    {
        // Ajouter un écouteur d'événement lorsque l'objet est sélectionné (interagi)
        interactable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnDisable()
    {
        // Enlever l'écouteur d'événement lors de la désactivation
        interactable.selectEntered.RemoveListener(OnSelectEntered);
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

    // Fonction pour changer la couleur de la lumière
    private void ChangeLightColor()
    {
        if (colors.Length > 0)  // S'assurer qu'il y a des couleurs dans le tableau
        {
            // Changer la couleur de la lampe à la prochaine couleur
            lampLight.color = colors[currentColorIndex];

            // Incrémenter l'index de couleur, et revenir à zéro si on atteint la fin du tableau
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
        }
    }
}
