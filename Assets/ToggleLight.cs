using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleLight : MonoBehaviour
{
    public Light pointLight; 

    private XRBaseInteractable interactable; 

    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>(); 
    }

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Toggle the light on and off
        pointLight.enabled = !pointLight.enabled;
    }
}
