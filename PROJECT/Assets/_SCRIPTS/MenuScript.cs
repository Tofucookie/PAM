using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static bool paused = false;

    public GameObject PausedUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        PausedUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void Pause()
    {
        PausedUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Settings()
    {

    }

    public void QuitGame()
    {
        Debug.Log("Game Will Quit");
        Application.Quit();
    }
}