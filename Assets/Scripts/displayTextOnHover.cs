using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class displayTextOnHover : MonoBehaviour
{
    public GameObject textObject; 

    private XRBaseInteractable interactable; 

    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>(); 
        textObject.SetActive(false); 
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
        textObject.SetActive(true);
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        textObject.SetActive(false);
    }
}
