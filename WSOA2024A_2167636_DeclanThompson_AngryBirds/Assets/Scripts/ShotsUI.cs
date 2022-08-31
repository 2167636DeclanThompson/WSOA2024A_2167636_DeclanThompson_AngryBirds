using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShotsUI : MonoBehaviour
{
    public Text shotsDisplay;
    public BallController ballController;

    private void Start()
    {
        ballController.maxShots = 5;
    }

    private void Update()
    {
        shotsDisplay.text = ballController.maxShots.ToString();

        if (ballController.maxShots <= 0)
        {
            ballController.maxShots = 0;
            SceneManager.LoadScene(3);
        }
    }

}
