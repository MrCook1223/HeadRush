using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecretMenu : MonoBehaviour {

    public Sprite[] Slike;
    public GameObject ImagePanel;
    public Texture2D Test2;
    public Texture2D Temporery;
    public void SelectCarecter1()
    {
        ImagePanel.GetComponent<Image>().sprite = Slike[0];
        //ImagePanel.GetComponent<SpriteRenderer>().sprite = Slike[0];

    }

    public void SelectCarecter2()
    {
        ImagePanel.GetComponent<Image>().sprite = Slike[1];
    }


    public void Play()
    {

        Temporery.SetPixels(Test2.GetPixels()); 
        Temporery.Apply();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
