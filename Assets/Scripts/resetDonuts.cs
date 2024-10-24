using UnityEngine;

//resets the donuts (make them reappear)
public class resetDonuts : MonoBehaviour
{
    public GameObject[] donuts;  

    public void ResetDonuts()
    {
        foreach (GameObject donut in donuts)
        {
            donut.SetActive(true);  // reactivate the donut
        }
    }
}
