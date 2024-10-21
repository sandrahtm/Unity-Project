using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class eatDonut : MonoBehaviour
{
    public bool isFirstDonut = false;  // True pour le premier donut, False pour le second
    private bool isEaten = false;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!isEaten)
        {
            isEaten = true;

            audioSource.Play();

            if (isFirstDonut)
            {
                filterManager.instance.ActivateFilter();  
            }
            else
            {
                filterManager.instance.DeactivateFilter(); 
            }

            gameObject.SetActive(false);
        }
    }
}
