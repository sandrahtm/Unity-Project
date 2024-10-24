using UnityEngine;
using UnityEngine.UI;

//to activate or desactivate the canvas when we eat a donut
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
    }

    public void showFilter()
    {
        filterImage.SetActive(true);
    }

    public void removeFilter()
    {
        filterImage.SetActive(false);
    }
}
