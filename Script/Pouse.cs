using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pouse : MonoBehaviour {

    public bool GameIsPoused = false;
    public GameObject PousePanel;
    public static bool Pospeskometre = false;
    public GameObject MuteSound;
    public static bool soundMute = false;
    public Sprite[] Icones;
    public Image Sound;
    public Image Pospeskometer;

    public void PouseGame()
    {
        if (GameIsPoused)
        {
            Resume();
        }
        else
        {
            Posed();
        }
    }

    public void pospeskometreChange()
    {
        if (Pospeskometre)
        {
            Pospeskometer.sprite = Icones[2];
            Pospeskometre = false;
        }
        else
        {
            Pospeskometer.sprite = Icones[3];
            Pospeskometre = true;
        }
    }

    public void Mute()
    {
        if (soundMute)
        {
            Sound.sprite = Icones[1];
            MuteSound.GetComponent<AudioSource>().mute = false;
            soundMute = false;
        }
        else
        {
            Sound.sprite = Icones[0];
            MuteSound.GetComponent<AudioSource>().mute = true;
            soundMute = true;
        }
    }



    void Resume()
    {
        Time.timeScale = 1f;
        GameIsPoused = false;
        PousePanel.SetActive(false);
    }

    void Posed()
    {
        Time.timeScale = 0f;
        GameIsPoused = true;
        if(soundMute)
            Sound.sprite = Icones[0];
        else
            Sound.sprite = Icones[1];
        if(Pospeskometre)
            Pospeskometer.sprite = Icones[3];
        else
            Pospeskometer.sprite = Icones[2];
        PousePanel.SetActive(true);
    }
}
