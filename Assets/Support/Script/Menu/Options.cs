using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; // para ter o audioMixer disponivel

public class Options : MonoBehaviour
{
    public static int teste = 2;
    public AudioMixer audioMixer;
    public GameObject MainMenu;
    public GameObject Option;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
        Debug.Log(index);
    }

    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
        Debug.Log(isFull);
    }
    
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Option.SetActive(false);
            MainMenu.SetActive(true);
        }
    }
}
