using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public Text playerScoreDisplay;

    private int playerScore;

    public void PlayerScored(int playerID)
    {
        if (playerID == 1)
        {
            playerScore++;
        }
        UpdateScore();
        {
            if (playerScore >= 5)
            {
                SceneManager.LoadScene(4);
            }
               
        }
    }

    private void Start()
    {
        UpdateScore();
    }
    private void UpdateScore()
    {
        playerScoreDisplay.text = playerScore.ToString();
    }

}
