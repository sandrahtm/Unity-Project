using UnityEngine;
using UnityEngine.UI;

public class filterManager : MonoBehaviour
{
    public static filterManager instance; 
    public GameObject filterImage; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActivateFilter()
    {
        if (filterImage != null)
        {
            filterImage.SetActive(true);
        }
    }

    public void DeactivateFilter()
    {
        if (filterImage != null)
        {
            filterImage.SetActive(false);
        }
    }
}
