using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class displayQuitText : MonoBehaviour
{
    public GameObject textObject;  // Reference to the Text (Quit) GameObject

    private XRBaseInteractable interactable;  // Reference to the interactable component

    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();  // Get the XR Interactable component
        textObject.SetActive(false);  // Ensure the text is initially hidden
    }

    private void OnEnable()
    {
        interactable.hoverEntered.AddListener(OnHoverEntered);
        interactable.hoverExited.AddListener(OnHoverExited);
    }

    private void OnDisable()
    {
        interactable.hoverEntered.RemoveListener(OnHoverEntered);
        interactable.hoverExited.RemoveListener(OnHoverExited);
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        // Show the text when the ray hovers over the door
        textObject.SetActive(true);
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        // Hide the text when the ray stops hovering over the door
        textObject.SetActive(false);
    }
}
