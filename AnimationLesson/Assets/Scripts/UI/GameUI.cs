using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

    public GameObject gameOverPanel, mainMenuPanel, healthPanel;
    public PlayerController player;

	// Update is called once per frame
	void Update () {
        GameOver();
	}

    public void GameOver()
    {
        if (player.health <= 0)
        {
            gameOverPanel.SetActive(true);
            return;
        }
    }

    public void Trigger_StartGame()
    {
        mainMenuPanel.SetActive(false);
        healthPanel.SetActive(true);
    }

    public void Trigger_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Trigger_Exit()
    {
        Application.Quit();
    }

}
