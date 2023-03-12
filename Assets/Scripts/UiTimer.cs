using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTimer : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI timeText;

    private float timer = 150;
    
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            DisplayTime(timer);
        }
        else
        {
            timeText.text = "00:00:00";
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }

}
