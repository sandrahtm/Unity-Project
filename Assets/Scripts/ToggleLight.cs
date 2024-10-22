using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LampInteraction : MonoBehaviour
{
    public Light lampLight;
    public AudioSource audioSource;
    public AudioClip toggleSound;

    public Color[] colors;
    private int currentColorIndex = 0;

    private XRSimpleInteractable interactable;

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
        ChangeLightColor();

        if (audioSource != null && toggleSound != null)
        {
            audioSource.PlayOneShot(toggleSound);
        }
    }

    private void ChangeLightColor()
    {
        if (currentColorIndex < colors.Length)
        {
            lampLight.color = colors[currentColorIndex];
            lampLight.range = 300f;
            lampLight.intensity = 1;
            lampLight.enabled = true;

            currentColorIndex++;
        }
        else
        {
            lampLight.enabled = false;
        }
    }
}
