using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerUI : MonoBehaviour
{
    // Single Sapling Games. Countdown Timer In Unity - Easy Beginners Tutorial/ Guide. (July 1, 2018) Accessed: June 09, 2020. Available: https://www.youtube.com/watch?v=o0j7PdU88a4

    public Text timerDisplay;

    private float currentTime = 0f;
    private float startTime = 60f;

    private void Start()
    {
        currentTime = startTime;
    }
     

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerDisplay.text = currentTime.ToString("0"); 

        if (currentTime <= 10)
        {
            timerDisplay.color = Color.red;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene(2);
        }
    }
}
