using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class zoeyController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip turnOnSound;

    private XRSimpleInteractable simpleInteractable;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        simpleInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnDisable()
    {
        simpleInteractable.selectEntered.RemoveListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (audioSource != null && turnOnSound != null)
        {
            animator.SetTrigger("PlayAnimation");
            audioSource.clip = turnOnSound;
            audioSource.Play();
        }
    }
}
