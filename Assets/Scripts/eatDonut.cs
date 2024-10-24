using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using System.Collections;


// depending on the donut, it will show or remove a filter on the player's camera. when the user triggers a donut, we make the donut disappear and a sound is played
public class eatDonut : MonoBehaviour
{
    private bool isEaten;
    public AudioSource audioSource;
    public AudioClip turnOnSound;
    public GameObject filterImage;
    public bool isFirstDonut = false;

    private XRBaseInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
        isEaten = false;
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
        isEaten = !isEaten;
        if (isEaten)
        {
            audioSource.clip = turnOnSound;
            if (isFirstDonut)
            {
                filterManager.instance.showFilter();
            }
            else
            {
                filterManager.instance.removeFilter();
            }

            StartCoroutine(PlaySoundAndDestroy());

        }
    }

    private IEnumerator PlaySoundAndDestroy()
    {
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

        gameObject.SetActive(false);
    }

}