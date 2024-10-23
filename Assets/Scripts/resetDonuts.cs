using UnityEngine;

public class resetDonuts : MonoBehaviour
{
    public GameObject[] donuts;  // Array to store the donuts you want to reset

    // Method to reset all the donuts by setting them active
    public void ResetDonuts()
    {
        foreach (GameObject donut in donuts)
        {
            donut.SetActive(true);  // Reactivate the donut
        }
    }
}
