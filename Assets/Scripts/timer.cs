using UnityEngine;
using TMPro; 

public class timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;  
    private float timeElapsed;        

    void Start()
    {
        timeElapsed = 0;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeElapsed / 60F);
        int seconds = Mathf.FloorToInt(timeElapsed % 60F);

        timerText.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);
    }
}
