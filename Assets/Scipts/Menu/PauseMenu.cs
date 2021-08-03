using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isGamePaused = false;
    [SerializeField] GameObject pauseBar;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isGamePaused) 
            {
                ResumeGame();

            }
            else 
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseBar.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public  void ResumeGame()
    {
        pauseBar.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void LoadMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
