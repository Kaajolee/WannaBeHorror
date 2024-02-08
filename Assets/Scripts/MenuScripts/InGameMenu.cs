using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    private bool isPaused = false;
    private Canvas canvas;
    public Canvas playerCanvas;

    private void Start()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
    
    void Update()
    {
        TogglePause();
    }
    private void TogglePause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            AudioListener.pause = isPaused;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (isPaused)
            {
                Time.timeScale = 0f;
                canvas.enabled = true;
                playerCanvas.enabled = false;
                
            }
            else
            {
                Time.timeScale = 1f;
                canvas.enabled = false;
                playerCanvas.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
                
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
       
    }
    public void Settings()
    {
        SceneManager.LoadSceneAsync("Settings");
    }
    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        canvas.enabled = false;
        playerCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        AudioListener.pause = isPaused;
    }
}
