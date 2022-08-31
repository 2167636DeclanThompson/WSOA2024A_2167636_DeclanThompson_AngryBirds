using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ScoreController scoreController;
    public KeyCode Escape;
    
    public void PlayerScored(int playerID)
    {
        scoreController.PlayerScored(playerID);
    }

    public void Update()
    {
        if (Input.GetKey(Escape))
        {
            Application.Quit();
        }
    }

}
