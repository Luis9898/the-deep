using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    void Start()
    {
        //
    }
    void Update()
    {
        if (!pausePanel.activeInHierarchy)
        {
            PauseGame();
        }

        else if (pausePanel.activeInHierarchy)
        {
            ContinueGame();
        }
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        //Disable scripts that still work while timescale is set to 0
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        //enable the scripts again
    }
}