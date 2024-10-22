using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleLight : MonoBehaviour
{
    public Light lampLight;  // La lumi�re attach�e � la lampe
    public AudioSource audioSource;  // Source audio pour le son d'allumage/extinction
    public AudioClip toggleSound;    // Son jou� � chaque fois qu'on allume/�teint

    public Color[] colors;  // Tableau des couleurs � parcourir
    private int currentColorIndex = 0;  // Index de la couleur actuelle

    private XRSimpleInteractable interactable;  // R�f�rence au Simple Interactable

    private void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
    }

    private void OnEnable()
    {
        // Ajouter un �couteur d'�v�nement lorsque l'objet est s�lectionn� (interagi)
        interactable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnDisable()
    {
        // Enlever l'�couteur d'�v�nement lors de la d�sactivation
        interactable.selectEntered.RemoveListener(OnSelectEntered);
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

    // Fonction pour changer la couleur de la lumi�re
    private void ChangeLightColor()
    {
        if (colors.Length > 0)  // S'assurer qu'il y a des couleurs dans le tableau
        {
            // Changer la couleur de la lampe � la prochaine couleur
            lampLight.color = colors[currentColorIndex];

            // Incr�menter l'index de couleur, et revenir � z�ro si on atteint la fin du tableau
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
        }
    }
}
