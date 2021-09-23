using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {

        Debug.Log("QUIT!");

        // Não funciona no unity mas quando buildar funciona
        Application.Quit();
    }
}
