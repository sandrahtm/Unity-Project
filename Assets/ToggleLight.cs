using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleLight : MonoBehaviour
{
    public Light pointLight;
    public AudioSource audioSource; 
    public AudioClip turnOnSound; 
    public AudioClip turnOffSound;

    private XRBaseInteractable interactable; 

    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
        pointLight.enabled = false;
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
        pointLight.enabled = !pointLight.enabled;
        if (pointLight.enabled)
        {
            audioSource.clip = turnOnSound;
        }
        else
        {
            audioSource.clip = turnOffSound;
        }
        audioSource.Play(); 
    }
}
