using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject Pause;

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
        if (isPaused)
        {
          isPaused = !isPaused;
          ResumeGame();
        }
        else
        {
          isPaused = !isPaused;
          PauseGame();
        }
      }
    }

    public void ResumeGame()
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void PauseGame()
    {
        Pause.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void BackMenu()
    {
      SceneManager.LoadScene(0);
      ResumeGame();
    }
    
    public void RetryLevel()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      ResumeGame();
    }
}
