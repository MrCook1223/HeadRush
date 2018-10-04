using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGame()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Initiate.Fade("FaceCut", Color.white, 2.0f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
