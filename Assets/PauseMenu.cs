using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false, showingControls = false;
    public GameObject pauseMenuUI, controls;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused && !showingControls)
                ResumeGame();
            else if (GameIsPaused && showingControls)
                HideMenu();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        GameIsPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        GameIsPaused = false;
    }

    public void HideMenu()
    {
        controls.SetActive(false);
        showingControls = false;
    }

    public void DisplayMenu()
    {
        Debug.Log("In pause menu");
        controls.SetActive(true);
        showingControls = true;
    }

    public void QuitGame()
    {
        Debug.LogWarning("quitting game...");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
